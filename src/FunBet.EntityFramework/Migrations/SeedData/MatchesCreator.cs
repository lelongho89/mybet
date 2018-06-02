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
            var groupMatchesDic = new Dictionary<string, List<Match>>();

            groupMatchesDic.Add("Group A", new List<Match>
            {
                new Match(1, "group", 1, 2, DateTime.Parse("2018-06-14T18:00:00+03:00"), false, 1),
                new Match(2, "group", 3, 4, DateTime.Parse("2018-06-15T17:00:00+05:00"), false, 1),
                new Match(17, "group", 1, 3, DateTime.Parse("2018-06-19T21:00:00+03:00"), false, 2),
                new Match(18, "group", 4, 2, DateTime.Parse("2018-06-20T18:00:00+03:00"), false, 2),
                new Match(33, "group", 4, 1, DateTime.Parse("2018-06-25T18:00:00+04:00"), false, 3),
                new Match(34, "group", 2, 3, DateTime.Parse("2018-06-25T17:00:00+03:00"), false, 3)
            });

            groupMatchesDic.Add("Group B", new List<Match>
            {
                new Match(3, "group", 5, 6, DateTime.Parse("2018-06-15T21:00:00+03:00"), false, 1), 
                new Match(4, "group", 7, 8, DateTime.Parse("2018-06-15T18:00:00+03:00"), false, 1), 
                new Match(19, "group", 5, 7, DateTime.Parse("2018-06-20T15:00:00+03:00"), false, 2), 
                new Match(20, "group", 8, 6, DateTime.Parse("2018-06-20T21:00:00+03:00"), false, 2), 
                new Match(35, "group", 8, 5, DateTime.Parse("2018-06-25T21:00:00+03:00"), false, 3), 
                new Match(36, "group", 6, 7, DateTime.Parse("2018-06-25T20:00:00+02:00"), false, 3)
            });

            groupMatchesDic.Add("Group C", new List<Match>
            {
                new Match(5,"group",9,10,DateTime.Parse("2018-06-16T13:00:00+03:00"),false,1),
                new Match(6,"group",11,12,DateTime.Parse("2018-06-16T19:00:00+03:00"),false,1),
                new Match(21,"group",9,11,DateTime.Parse("2018-06-21T20:00:00+05:00"),false,2),
                new Match(22,"group",12,10,DateTime.Parse("2018-06-21T16:00:00+04:00"),false,2),
                new Match(37,"group",12,9,DateTime.Parse("2018-06-26T17:00:00+03:00"),false,3),
                new Match(38,"group",10,11,DateTime.Parse("2018-06-26T17:00:00+02:00"),false,3)
            });

            groupMatchesDic.Add("Group D", new List<Match>
            {
                new Match(7,"group",13,14,DateTime.Parse("2018-06-16T16:00:00+03:00"),false,1),
                new Match(8,"group",15,16,DateTime.Parse("2018-06-16T21:00:00+02:00"),false,1),
                new Match(23,"group",13,15,DateTime.Parse("2018-06-21T21:00:00+03:00"),false,2),
                new Match(24,"group",16,14,DateTime.Parse("2018-06-22T18:00:00+03:00"),false,2),
                new Match(39,"group",16,13,DateTime.Parse("2018-06-26T21:00:00+03:00"),false,3),
                new Match(40,"group",14,15,DateTime.Parse("2018-06-26T21:00:00+03:00"),false,3)
            });

            groupMatchesDic.Add("Group E", new List<Match>
            {
                new Match(9,"group",17,18,DateTime.Parse("2018-06-17T21:00:00+03:00"),false,1),
                new Match(10,"group",19,20,DateTime.Parse("2018-06-17T16:00:00+04:00"),false,1),
                new Match(25,"group",17,19,DateTime.Parse("2018-06-22T15:00:00+03:00"),false,2),
                new Match(26,"group",20,18,DateTime.Parse("2018-06-22T20:00:00+02:00"),false,2),
                new Match(41,"group",20,17,DateTime.Parse("2018-06-27T21:00:00+03:00"),false,3),
                new Match(42,"group",18,19,DateTime.Parse("2018-06-27T21:00:00+03:00"),false,3)
            });

            groupMatchesDic.Add("Group F", new List<Match>
            {
                new Match(11,"group",21,22,DateTime.Parse("2018-06-17T18:00:00+03:00"),false,1),
                new Match(12,"group",23,24,DateTime.Parse("2018-06-18T15:00:00+03:00"),false,1),
                new Match(27,"group",21,23,DateTime.Parse("2018-06-23T21:00:00+03:00"),false,2),
                new Match(28,"group",24,22,DateTime.Parse("2018-06-23T18:00:00+03:00"),false,2),
                new Match(43,"group",24,21,DateTime.Parse("2018-06-27T17:00:00+03:00"),false,3),
                new Match(44,"group",22,23,DateTime.Parse("2018-06-27T19:00:00+05:00"),false,3)
            });

            groupMatchesDic.Add("Group G", new List<Match>
            {
                new Match(13,"group",25,26,DateTime.Parse("2018-06-18T18:00:00+03:00"),false,1),
                new Match(14,"group",27,28,DateTime.Parse("2018-06-18T21:00:00+03:00"),false,1),
                new Match(29,"group",25,27,DateTime.Parse("2018-06-23T15:00:00+03:00"),false,2),
                new Match(30,"group",28,26,DateTime.Parse("2018-06-24T15:00:00+03:00"),false,2),
                new Match(45,"group",28,25,DateTime.Parse("2018-06-28T20:00:00+02:00"),false,3),
                new Match(46,"group",26,27,DateTime.Parse("2018-06-28T21:00:00+03:00"),false,3)
            });

            groupMatchesDic.Add("Group H", new List<Match>
            {
                new Match(15,"group",29,30,DateTime.Parse("2018-06-19T18:00:00+03:00"),false,1),
                new Match(16,"group",31,32,DateTime.Parse("2018-06-19T15:00:00+03:00"),false,1),
                new Match(31,"group",29,31,DateTime.Parse("2018-06-24T20:00:00+05:00"),false,2),
                new Match(32,"group",32,30,DateTime.Parse("2018-06-24T21:00:00+03:00"),false,2),
                new Match(47,"group",32,29,DateTime.Parse("2018-06-28T17:00:00+03:00"),false,3),
                new Match(48,"group",30,31,DateTime.Parse("2018-06-28T18:00:00+04:00"),false,3)
            });

            foreach (var group in groupMatchesDic)
            {
                var groupModel = _context.Groups.FirstOrDefault(x => x.Name == group.Key);
                if(groupModel != null)
                {
                    var matchesToAdd = group.Value;
                    matchesToAdd.ForEach(x => x.GroupId = groupModel.Id);
                    InitialMatches.AddRange(matchesToAdd);
                }
            }
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
