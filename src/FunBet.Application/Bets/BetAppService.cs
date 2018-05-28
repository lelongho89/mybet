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

namespace FunBet.Bets
{
    [AbpAuthorize()]
    public class BetAppService : FunBetAppServiceBase, IBetAppService
    {
        private readonly IBetManager _betManager;
        private readonly IRepository<Match> _matchRepository;
        private readonly IRepository<Bet> _betRepository;

        public BetAppService(IBetManager betManager, IRepository<Match> matchRepository,
            IRepository<Bet> betRepository)
        {
            this._betManager = betManager;
            this._matchRepository = matchRepository;
            this._betRepository = betRepository;
        }

        public void Bet(BetInput input)
        {
            var betModel = input.Id.HasValue ? this._betRepository.Get(input.Id.Value) : input.MapTo<Bet>();
            betModel.PredictTime = Clock.Now;
            var match = _matchRepository.Get(input.MatchId);

            _betManager.BetOnMatch(betModel, match);
        }

        public ListResultDto<MatchDto> GetAllMatches(GetAllMatchesInput input)
        {
            var data = this._matchRepository.GetAll().OrderBy(x => x.StartTime).ThenBy(x => x.Group).ToList();
            return new ListResultDto<MatchDto>(data.MapTo<List<MatchDto>>());
        }
    }
}
