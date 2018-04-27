using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Identities.Exception
{
    public class CredentialTypeCommandException : System.Exception
    {
        public CredentialTypeCommandException(string message) : base(message)
        {

        }
    }
}
