using Abp.Domain.Repositories;
using Abp.Timing;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Bets
{
    public class BetManager : IBetManager
    {
        private readonly IRepository<Bet> _betRepository;

        public BetManager(IRepository<Bet> betRepository)
        {
            this._betRepository = betRepository;
        }

        public void BetOnMatch(Bet bet, Match match)
        {
            if (match.IsOKToBet())
            {
                this._betRepository.InsertOrUpdate(bet);
            }
            else
            {
                throw new UserFriendlyException("INVALIDBET", "Cannot bet now.");
            }
        }
    }
}
