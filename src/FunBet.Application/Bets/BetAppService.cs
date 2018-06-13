using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Timing;
using FunBet.Bets.Dto;
using FunBet.Matches;
using FunBet.Teams;

namespace FunBet.Bets
{
    [AbpAuthorize()]
    public class BetAppService : FunBetAppServiceBase, IBetAppService
    {
        private readonly IBetManager _betManager;
        private readonly IRepository<Match> _matchRepository;
        private readonly IRepository<Bet> _betRepository;
        private readonly IRepository<Team> _teamRepository;

        public BetAppService(IBetManager betManager, IRepository<Match> matchRepository,
            IRepository<Team> teamRepository,
            IRepository<Bet> betRepository)
        {
            this._betManager = betManager;
            this._teamRepository = teamRepository;
            this._matchRepository = matchRepository;
            this._betRepository = betRepository;
        }

        public ListResultDto<BetMatchDto> GetMatchesToBet(GetMatchesToBetInput input)
        {
            var teams = this._teamRepository.GetAllList();
            var matches = this._matchRepository.GetAll()
                                            .OrderBy(x => x.Date)
                                            .MapTo<List<BetMatchDto>>();
                          
            var bets = this._betRepository.GetAll().Where(x => x.PredictorId == AbpSession.UserId.Value).ToList();


            // All matches
            matches.ForEach(x =>
            {
                var homeTeam = teams.FirstOrDefault(t => t.Id == x.HomeTeam);
                x.HomeTeamName = homeTeam.Name;
                x.HomeTeamIso2 = homeTeam.Iso2;

                var awayTeam = teams.FirstOrDefault(t => t.Id == x.AwayTeam);
                x.AwayTeamName = awayTeam.Name;
                x.AwayTeamIso2 = awayTeam.Iso2;

                var bet = bets.FirstOrDefault(b => b.MatchId == x.Id);
                if (bet != null)
                {
                    x.HomePredict = bet.HomePredict;
                    x.AwayPredict = bet.AwayPredict;
                    x.BetId = bet.Id;
                }
            });

            return new ListResultDto<BetMatchDto>()
            {
                Items = matches
            };
        }

        public void Bet(BetInput input)
        {
            Bet betModel = new Bets.Bet();

            if (input.Id.HasValue)
            {
                betModel = this._betRepository.Get(input.Id.Value);
                input.MapTo(betModel);
            }
            else
            {
                input.MapTo<Bet>();
            }

            betModel.PredictorId = AbpSession.UserId.Value;
            betModel.PredictTime = Clock.Now;
            var match = _matchRepository.Get(input.MatchId);

            _betManager.BetOnMatch(betModel, match);
        }
    }
}
