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
using FunBet.Matches.Dto;
using System.Linq.Dynamic;
using FunBet.Teams;

namespace FunBet.Matches
{
    [AbpAuthorize()]
    public class MatchAppService : FunBetAppServiceBase, IMatchAppService
    {
        private readonly IRepository<Match> _matchRepository;
        private readonly IRepository<Team> _teamRepository;

        public MatchAppService(IRepository<Match> matchRepository,
            IRepository<Team> teamRepository)
        {
            this._matchRepository = matchRepository;
            this._teamRepository = teamRepository;
        }

        public ListResultDto<MatchDto> GetAll(GetAllInput input)
        {
            var teams = this._teamRepository.GetAllList();
            var data = this._matchRepository.GetAll()
                                            .OrderBy(x => x.Date)
                                            .ToList()
                                            .MapTo<List<MatchDto>>();
            data.ForEach(x =>
            {
                var homeTeam = teams.FirstOrDefault(t => t.Id == x.HomeTeam);
                x.HomeTeamName = homeTeam.Name;
                x.HomeTeamIso2 = homeTeam.Iso2;

                var awayTeam = teams.FirstOrDefault(t => t.Id == x.AwayTeam);
                x.AwayTeamName = awayTeam.Name;
                x.AwayTeamIso2 = awayTeam.Iso2;
            });

            return new ListResultDto<MatchDto>(data);
        }
    }
}
