using Abp.Authorization;
using FunBet.Authorization.Roles;
using FunBet.Authorization.Users;

namespace FunBet.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
