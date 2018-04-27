using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Exception
{
    public class UserDomainException : System.Exception
    {
        public UserDomainException(string message) : base(message)
        {

        }
    }
}
