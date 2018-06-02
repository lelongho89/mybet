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
            InitialGroups = new List<Group>
            {
                new Group("Group A"),
                new Group("Group B"),
                new Group("Group C"),
                new Group("Group D"),
                new Group("Group E"),
                new Group("Group F"),
                new Group("Group G"),
                new Group("Group H"),
                new Group("Round of 16"),
                new Group("Quater-finals"),
                new Group("Semi-finals"),
                new Group("Third-place"),
                new Group("Final")
            };

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
