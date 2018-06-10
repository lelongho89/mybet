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
        private readonly IRepository<Group> _groupRepository;

        public MatchAppService(IRepository<Match> matchRepository,
            IRepository<Team> teamRepository,
            IRepository<Group> groupRepository)
        {
            this._matchRepository = matchRepository;
            this._teamRepository = teamRepository;
            this._groupRepository = groupRepository;
        }

        public GetAllOutput GetAll(GetAllInput input)
        {
            var teams = this._teamRepository.GetAllList(); // TODO: get from Cache
            var matches = this._matchRepository.GetAll()
                                            .OrderBy(x => x.Date)
                                            .MapTo<List<MatchDto>>();
            // All matches
            matches.ForEach(x =>
            {
                var homeTeam = teams.FirstOrDefault(t => t.Id == x.HomeTeam);
                x.HomeTeamName = homeTeam.Name;
                x.HomeTeamIso2 = homeTeam.Iso2;

                var awayTeam = teams.FirstOrDefault(t => t.Id == x.AwayTeam);
                x.AwayTeamName = awayTeam.Name;
                x.AwayTeamIso2 = awayTeam.Iso2;
            });


            // Matches by group
            var groups = this._groupRepository.GetAllList().MapTo<List<GroupDto>>();

            groups.ForEach(g =>
            {
                g.Matches = matches.Where(m => m.GroupId == g.Id).ToList();
            });


            return new GetAllOutput()
            {
                Matches = matches,
                Groups = groups
            };
        }

        /// <summary>
        /// Get next 6 matches from today.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ListResultDto<MatchDto> GetNextMatches(GetNextMatchesInput input)
        {
            var matches = this._matchRepository.GetAll()
                                            .Where(x => !x.Finished && x.Date > Clock.Now)
                                            .OrderBy(x => x.Date)
                                            .Take(input.MaxResultCount)
                                            .MapTo<List<MatchDto>>();

            var teams = this._teamRepository.GetAllList(); // TODO: get from Cache

            matches.ForEach(x =>
            {
                var homeTeam = teams.FirstOrDefault(t => t.Id == x.HomeTeam);
                x.HomeTeamName = homeTeam.Name;
                x.HomeTeamIso2 = homeTeam.Iso2;

                var awayTeam = teams.FirstOrDefault(t => t.Id == x.AwayTeam);
                x.AwayTeamName = awayTeam.Name;
                x.AwayTeamIso2 = awayTeam.Iso2;
            });

            return new ListResultDto<MatchDto>(matches);
        }
    }
}
