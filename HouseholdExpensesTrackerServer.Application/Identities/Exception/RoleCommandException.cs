using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Identities.Exception
{
    public class RoleCommandException : System.Exception
    {
        public RoleCommandException(string message) : base(message)
        {

        }
    }
}
