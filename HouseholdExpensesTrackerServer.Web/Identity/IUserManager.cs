using HouseholdExpensesTrackerServer.Domain.Identities.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Web.Identity
{
    public interface IUserManager
    {
        User Validate(string loginTypeCode, string identifier, string secret);

        void SignIn(HttpContext httpContext, User user, bool isPersistent = false);

        void SignOut(HttpContext httpContext);

        int GetCurrentUserId(HttpContext httpContext);

        User GetCurrentUser(HttpContext httpContext);
    }
}
