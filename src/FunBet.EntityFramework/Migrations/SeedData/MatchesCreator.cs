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
            InitialMatches = new List<Match>();
        }

        public MatchesCreator(FunBetDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            InitMatchesData();
            CreateMatches();
        }

        private void InitMatchesData()
        {
            var groupA = _context.Groups.FirstOrDefault(x => x.Name == "Group A");
            //InitialMatches.Add
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
