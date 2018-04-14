using HouseholdExpensesTrackerServer.Domain.Identity;
using HouseholdExpensesTrackerServer.Infrastructure.Context;
using HouseholdExpensesTrackerServer.Web.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Web.Identity
{
    public class UserManager : IUserManager
    {
        private IDbContext _context;

        public UserManager(IDbContext context)
        {
            _context = context;
        }

        public User Validate(string loginTypeCode, string identifier, string secret)
        {
            var credentialType = _context.CredentialTypes.FirstOrDefault(ct => string.Equals(ct.Code, loginTypeCode, StringComparison.OrdinalIgnoreCase));

            if (credentialType == null)
                return null;

            var credential = _context.Credentials.FirstOrDefault(
              c => c.CredentialTypeId == credentialType.Id && string.Equals(c.Identifier, identifier, StringComparison.OrdinalIgnoreCase) && c.Secret == Md5Hasher.ComputeHash(secret)
            );

            if (credential == null)
                return null;

            return _context.Users.Find(credential.UserId);
        }

        public async void SignIn(HttpContext httpContext, User user, bool isPersistent = false)
        {
            var identity = new ClaimsIdentity(this.GetUserClaims(user), CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await httpContext.SignInAsync(
              CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties() { IsPersistent = isPersistent }
            );
        }

        public async void SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public int GetCurrentUserId(HttpContext httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
                return -1;

            var claim = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (claim == null)
                return -1;

            int currentUserId;

            if (!int.TryParse(claim.Value, out currentUserId))
                return -1;

            return currentUserId;
        }

        public User GetCurrentUser(HttpContext httpContext)
        {
            var currentUserId = this.GetCurrentUserId(httpContext);

            if (currentUserId == -1)
                return null;

            return _context.Users.Find(currentUserId);
        }

        private IEnumerable<Claim> GetUserClaims(User user)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.AddRange(this.GetUserRoleClaims(user));
            return claims;
        }

        private IEnumerable<Claim> GetUserRoleClaims(User user)
        {
            var claims = new List<Claim>();
            IEnumerable<int> roleIds = _context.UserRoles.Where(ur => ur.UserId == user.Id).Select(ur => ur.RoleId).ToList();

            if (roleIds != null)
            {
                foreach (int roleId in roleIds)
                {
                    var role = _context.Roles.Find(roleId);

                    claims.Add(new Claim(ClaimTypes.Role, role.Code));
                    claims.AddRange(this.GetUserPermissionClaims(role));
                }
            }

            return claims;
        }

        private IEnumerable<Claim> GetUserPermissionClaims(Role role)
        {
            var claims = new List<Claim>();
            IEnumerable<int> permissionIds = _context.RolePermissions.Where(rp => rp.RoleId == role.Id).Select(rp => rp.PermissionId).ToList();

            if (permissionIds != null)
            {
                foreach (int permissionId in permissionIds)
                {
                    var permission = _context.Permissions.Find(permissionId);

                    claims.Add(new Claim("Permission", permission.Code));
                }
            }

            return claims;
        }
    }
}
