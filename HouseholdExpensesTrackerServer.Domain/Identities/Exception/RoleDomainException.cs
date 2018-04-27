using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Exception
{
    public class RoleDomainException : System.Exception
    {
        public RoleDomainException(string message) : base(message)
        {

        }
    }
}
