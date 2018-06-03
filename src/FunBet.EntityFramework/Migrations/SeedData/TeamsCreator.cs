using FunBet.EntityFramework;
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
    public class TeamsCreator
    {

        public static List<Team> InitialTeams { get; private set; }

        private readonly FunBetDbContext _context;

        static TeamsCreator()
        {
            InitialTeams = new List<Team>
            {
                new Team(
                  "Russia",
                  "RUS",
                  "ru",
                  "https://upload.wikimedia.org/wikipedia/en/thumb/f/f3/Flag_of_Russia.svg/900px-Flag_of_Russia.png",
                  "flag-ru",
                  "🇷🇺"
                ),
                new Team(
                  "Saudi Arabia",
                  "KSA",
                  "sa",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/Flag_of_Saudi_Arabia.svg/750px-Flag_of_Saudi_Arabia.png",
                  "flag-sa",
                  "🇸🇦"
                ),
                new Team(
                  "Egypt",
                  "EGY",
                  "eg",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fe/Flag_of_Egypt.svg/900px-Flag_of_Egypt.png",
                  "flag-eg",
                  "🇪🇬"
                ),
                new Team(
                  "Uruguay",
                  "URU",
                  "uy",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fe/Flag_of_Uruguay.svg/900px-Flag_of_Uruguay.png",
                  "flag-uy",
                  "🇺🇾"
                ),
                new Team(
                  "Portugal",
                  "POR",
                  "pt",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5c/Flag_of_Portugal.svg/600px-Flag_of_Portugal.png",
                  "flag-pt",
                  "🇵🇹"
                ),
                new Team(
                  "Spain",
                  "ESP",
                  "es",
                  "https://upload.wikimedia.org/wikipedia/en/thumb/9/9a/Flag_of_Spain.svg/750px-Flag_of_Spain.png",
                  "flag-es",
                  "🇪🇸"
                ),
                new Team(
                  "Morocco",
                  "MAR",
                  "ma",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/Flag_of_Morocco.svg/900px-Flag_of_Morocco.png",
                  "flag-ma",
                  "🇲🇦"
                ),
                new Team(
                  "Iran",
                  "IRN",
                  "ir",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/c/ca/Flag_of_Iran.svg/630px-Flag_of_Iran.png",
                  "flag-ir",
                  "🇮🇷"
                ),
                new Team(
                  "France",
                  "FRA",
                  "fr",
                  "https://upload.wikimedia.org/wikipedia/en/thumb/c/c3/Flag_of_France.svg/900px-Flag_of_France.png",
                  "flag-fr",
                  "🇫🇷"
                ),
                new Team(
                  "Australia",
                  "AUS",
                  "au",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/8/88/Flag_of_Australia_%28converted%29.svg/1280px-Flag_of_Australia_%28converted%29.png",
                  "flag-au",
                  "🇦🇺"
                ),
                new Team(
                  "Peru",
                  "PER",
                  "pe",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/d/df/Flag_of_Peru_%28state%29.svg/900px-Flag_of_Peru_%28state%29.png",
                  "flag-pe",
                  "🇵🇪"
                ),
                new Team(
                  "Denmark",
                  "DEN",
                  "dk",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9c/Flag_of_Denmark.svg/740px-Flag_of_Denmark.png",
                  "flag-dk",
                  "🇩🇰"
                ),
                new Team(
                  "Argentina",
                  "ARG",
                  "ar",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1a/Flag_of_Argentina.svg/800px-Flag_of_Argentina.png",
                  "flag-ar",
                  "🇦🇷"
                ),
                new Team(
                  "Iceland",
                  "ISL",
                  "is",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/c/ce/Flag_of_Iceland.svg/800px-Flag_of_Iceland.png",
                  "flag-is",
                  "🇮🇸"
                ),
                new Team(
                  "Croatia",
                  "CRO",
                  "hr",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Flag_of_Croatia.svg/800px-Flag_of_Croatia.png",
                  "flag-hr",
                  "🇭🇷"
                ),
                new Team(
                  "Nigeria",
                  "NGA",
                  "ng",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/7/79/Flag_of_Nigeria.svg/800px-Flag_of_Nigeria.png",
                  "flag-ng",
                  "🇳🇬"
                ),
                new Team(
                  "Brazil",
                  "BRA",
                  "br",
                  "https://upload.wikimedia.org/wikipedia/en/thumb/0/05/Flag_of_Brazil.svg/720px-Flag_of_Brazil.png",
                  "flag-br",
                  "🇧🇷"
                ),
                new Team(
                  "Switzerland",
                  "SUI",
                  "ch",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/0/08/Flag_of_Switzerland_%28Pantone%29.svg/320px-Flag_of_Switzerland_%28Pantone%29.png",
                  "flag-ch",
                  "🇨🇭"
                ),
                new Team(
                  "Costa Rica",
                  "CRC",
                  "cr",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bc/Flag_of_Costa_Rica_%28state%29.svg/833px-Flag_of_Costa_Rica_%28state%29.png",
                  "flag-cr",
                  "🇨🇷"
                ),
                new Team(
                  "Serbia",
                  "SRB",
                  "rs",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/f/ff/Flag_of_Serbia.svg/1350px-Flag_of_Serbia.png",
                  "flag-rs",
                  "🇷🇸"
                ),
                new Team(
                  "Germany",
                  "GER",
                  "de",
                  "https://upload.wikimedia.org/wikipedia/en/thumb/b/ba/Flag_of_Germany.svg/800px-Flag_of_Germany.png",
                  "flag-de",
                  "🇩🇪"
                ),
                new Team(
                  "Mexico",
                  "MEX",
                  "mx",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Flag_of_Mexico.svg/800px-Flag_of_Mexico.png",
                  "flag-mx",
                  "🇲🇽"
                ),
                new Team(
                  "Sweden",
                  "SWE",
                  "se",
                  "https://upload.wikimedia.org/wikipedia/en/thumb/4/4c/Flag_of_Sweden.svg/1600px-Flag_of_Sweden.png",
                  "flag-se",
                  "🇸🇪"
                ),
                new Team(
                  "South Korea",
                  "KOR",
                  "kr",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/0/09/Flag_of_South_Korea.svg/900px-Flag_of_South_Korea.png",
                  "flag-kr",
                  "🇰🇷"
                ),
                new Team(
                  "Belgium",
                  "BEL",
                  "be",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/6/65/Flag_of_Belgium.svg/450px-Flag_of_Belgium.png",
                  "flag-be",
                  "🇧🇪"
                ),
                new Team(
                  "Panama",
                  "PAN",
                  "pa",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Flag_of_Panama.svg/450px-Flag_of_Panama.png",
                  "flag-pa",
                  "🇵🇦"
                ),
                new Team(
                  "Tunisia",
                  "TUN",
                  "tn",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/c/ce/Flag_of_Tunisia.svg/1200px-Flag_of_Tunisia.png",
                  "flag-tn",
                  "🇹🇳"
                ),
                new Team(
                  "England",
                  "ENG",
                  "gb-eng",
                  "https://upload.wikimedia.org/wikipedia/en/thumb/b/be/Flag_of_England.svg/800px-Flag_of_England.png",
                  "flag-england",
                  "🏴󠁧󠁢󠁥󠁮󠁧󠁿"
                ),
                new Team(
                  "Poland",
                  "POL",
                  "pl",
                  "https://upload.wikimedia.org/wikipedia/en/thumb/1/12/Flag_of_Poland.svg/1280px-Flag_of_Poland.png",
                  "flag-pl",
                  "🇵🇱"
                ),
                new Team(
                  "Senegal",
                  "SEN",
                  "sn",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fd/Flag_of_Senegal.svg/900px-Flag_of_Senegal.svg.png",
                  "flag-sn",
                  "🇸🇳"
                ),
                new Team(
                  "Colombia",
                  "COL",
                  "co",
                  "https://upload.wikimedia.org/wikipedia/commons/thumb/2/21/Flag_of_Colombia.svg/450px-Flag_of_Colombia.png",
                  "flag-co",
                  "🇨🇴"
                ),
                new Team(
                  "Japan",
                  "JPN",
                  "jp",
                  "https://upload.wikimedia.org/wikipedia/en/thumb/9/9e/Flag_of_Japan.svg/900px-Flag_of_Japan.png",
                  "flag-jp",
                  "🇯🇵"
                )
            };
        }

        public TeamsCreator(FunBetDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateTeams();
        }

        private void CreateTeams()
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
