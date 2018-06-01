using FunBet.EntityFramework;
using FunBet.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBet.Migrations.SeedData
{
    public class TeamsCreator
    {

        public static List<Team> InitialTeams { get; private set; }

        private readonly FunBetDbContext _context;

        static TeamsCreator()
        {
            InitialTeams = new List<Team>
            {
                new Team(null, "Russia", "RUS", "https://upload.wikimedia.org/wikipedia/en/thumb/f/f3/Flag_of_Russia.svg/900px-Flag_of_Russia.png", "flag-ru", "🇷🇺"),
            };
        }

        public TeamsCreator(FunBetDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateLanguages();
        }

        private void CreateLanguages()
        {
            foreach (var team in InitialTeams)
            {
                AddTeamIfNotExists(team);
            }
        }

        private void AddTeamIfNotExists(Team team)
        {
            if (_context.Teams.Any(l => l.TenantId == team.TenantId && l.Name == team.Name))
            {
                return;
            }

            _context.Teams.Add(team);

            _context.SaveChanges();
        }
    }
}
