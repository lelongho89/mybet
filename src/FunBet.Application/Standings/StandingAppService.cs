﻿using Abp.Authorization;
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
    }
}
