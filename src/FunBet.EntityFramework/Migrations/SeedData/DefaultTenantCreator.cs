using System.Linq;
using FunBet.EntityFramework;
using FunBet.MultiTenancy;

namespace FunBet.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly FunBetDbContext _context;

        public DefaultTenantCreator(FunBetDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
