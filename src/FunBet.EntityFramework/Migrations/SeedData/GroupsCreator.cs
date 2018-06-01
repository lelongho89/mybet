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
    public class GroupsCreator
    {

        public static List<Group> InitialGroups { get; private set; }

        private readonly FunBetDbContext _context;

        static GroupsCreator()
        {
            //InitialTeams = new List<Team>
            //{
            //    new Team(null, "Russia", "RUS", "https://upload.wikimedia.org/wikipedia/en/thumb/f/f3/Flag_of_Russia.svg/900px-Flag_of_Russia.png", "flag-ru", "🇷🇺"),
            //};
        }

        public GroupsCreator(FunBetDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateGroups();
        }

        private void CreateGroups()
        {
            foreach (var group in InitialGroups)
            {
                AddGroupIfNotExists(group);
            }
        }

        private void AddGroupIfNotExists(Group group)
        {
            if (_context.Groups.Any(l => l.TenantId == group.TenantId && l.Name == group.Name))
            {
                return;
            }

            _context.Groups.Add(group);

            _context.SaveChanges();
        }
    }
}
