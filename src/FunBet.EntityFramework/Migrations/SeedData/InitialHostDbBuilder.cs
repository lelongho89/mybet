using FunBet.EntityFramework;
using EntityFramework.DynamicFilters;

namespace FunBet.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly FunBetDbContext _context;

        public InitialHostDbBuilder(FunBetDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
