using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using FunBet.Standings.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Standings
{
    [AbpAuthorize()]
    public class StandingAppService : FunBetAppServiceBase, IStandingAppService
    {
        private readonly IRepository<Standing> _standingRepository;
        public StandingAppService(IRepository<Standing> standingRepository)
        {
            _standingRepository = standingRepository;
        }
        public ListResultDto<StandingDto> GetAll(GetAllInput input)
        {
            var data = _standingRepository.GetAll().OrderByDescending(x => x.Points).MapTo<List<StandingDto>>();
            return new ListResultDto<StandingDto>(data);
        }
    }
}
