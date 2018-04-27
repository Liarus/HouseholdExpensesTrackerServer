using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Identities.Exception
{
    public class PermissionCommandException : System.Exception
    {
        public PermissionCommandException(string message) : base(message)
        {

        }
    }
}
