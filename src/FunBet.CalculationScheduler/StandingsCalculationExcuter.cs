using Abp.Dependency;
using Abp.Domain.Repositories;
using FunBet.Bets;
using FunBet.CalculationScheduler;
using FunBet.Matches;
using FunBet.Standings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.CalculationScheduler
{
    public class StandingsCalculationExcuter : ITransientDependency
    {
        public Log Log { get; private set; }

        private readonly IRepository<Standing> _standingRepository;
        private readonly IRepository<Bet> _betRepository;
        private readonly IRepository<Match> _matchRepository;
        private readonly IScoreManager _scoreManager;

        public StandingsCalculationExcuter(
            IRepository<Standing> standingRepository,
            IRepository<Bet> betRepository,
            IRepository<Match> matchRepository,
            IScoreManager scoreManager,
            Log log)
        {
            Log = log;

            _standingRepository = standingRepository;
            _betRepository = betRepository;
            _matchRepository = matchRepository;
            _scoreManager = scoreManager;
        }

        public void Run(long exactPredictorId)
        {
            Log.Write("Calculation scheduler started...");

            try
            {
                // Get all bets which have not processed yet.
                var finishedMatchBets = from bet in _betRepository.GetAll().Where(x => !x.IsProcessed)
                                        join match in _matchRepository.GetAll().Where(x => x.Finished) on bet.MatchId equals match.Id
                                        select new BetMatch
                                        {
                                            BetId = bet.Id,
                                            PredictorId = bet.PredictorId,
                                            HomePredict = bet.HomePredict,
                                            AwayPredict = bet.AwayPredict,
                                            MatchId = match.Id,
                                            HomeResult = match.HomeResult,
                                            AwayResult = match.AwayResult
                                        };

                var betsByPredictor = finishedMatchBets.GroupBy(x => x.PredictorId);

                foreach (var bbp in betsByPredictor)
                {
                    long predictorId = bbp.Key;
                    int addingPoints = 0;

                    Log.Write($"Processing for {predictorId} on matches { string.Join(", ", bbp.ToList().Select(x => x.MatchId.ToString()))}");

                    foreach (BetMatch bet in bbp.ToList())
                    {
                        addingPoints += _scoreManager.CalculateScore(new Score(bet.HomePredict ?? -1, bet.AwayPredict ?? -1), new Score(bet.HomeResult ?? -1, bet.AwayResult ?? -1));

                        _betRepository.Update(bet.BetId, (b) => b.IsProcessed = true);
                    }

                    // Get current Standing of predictorId
                    var standing = _standingRepository.GetAll().FirstOrDefault(x => x.PredictorId == predictorId);
                    if (standing == null) standing = new Standing();
                    standing.Points += addingPoints;
                    standing.PredictorId = predictorId;
                    _standingRepository.InsertOrUpdate(standing);

                    Log.Write($"Finished processing for {predictorId}");
                }
            }
            catch (Exception ex)
            {
                Log.Write("An error occured during calculation processing:");
                Log.Write(ex.ToString());
                Log.Write("Canceled processing.");
                return;
            }

            Log.Write("Calculation completed.");
            Log.Write("--------------------------------------------------------");

            
        }
    }
}
