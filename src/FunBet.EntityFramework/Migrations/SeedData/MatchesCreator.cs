using FunBet.EntityFramework;
using FunBet.Matches;
using FunBet.Teams;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Migrations.SeedData
{
    public class MatchesCreator
    {

        public static List<Match> InitialMatches { get; private set; }

        private readonly FunBetDbContext _context;

        static MatchesCreator()
        {
            //InitialTeams = new List<Team>
            //{
            //    new Team(null, "Russia", "RUS", "https://upload.wikimedia.org/wikipedia/en/thumb/f/f3/Flag_of_Russia.svg/900px-Flag_of_Russia.png", "flag-ru", "🇷🇺"),
            //};
        }

        public MatchesCreator(FunBetDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateMatches();
        }

        private void CreateMatches()
        {
            foreach (var match in InitialMatches)
            {
                AddMatchIfNotExists(match);
            }
        }

        private void AddMatchIfNotExists(Match match)
        {
            if (_context.Matches.Any(l => l.TenantId == match.TenantId && l.Name == match.Name))
            {
                return;
            }

            _context.Matches.Add(match);

            _context.SaveChanges();
        }
    }
}
