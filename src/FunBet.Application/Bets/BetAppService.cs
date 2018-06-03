﻿using System;
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
            betModel.PredictorId = AbpSession.UserId.Value;
            betModel.PredictTime = Clock.Now;
            var match = _matchRepository.Get(input.MatchId);

            _betManager.BetOnMatch(betModel, match);
        }
    }
}
