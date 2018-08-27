using HouseholdExpensesTrackerServer.Application.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Identities.Command
{
    public class AddCredentialCommand : BaseCommand
    {
        public readonly int UserId;

        public readonly int CredentialTypeId;

        public readonly string Identifier;

        public readonly string Secret;

        public AddCredentialCommand(int userId, int credentialTypeId, string identifier, string secret)
        {
            this.UserId = userId;
            this.CredentialTypeId = credentialTypeId;
            this.Identifier = identifier;
            this.Secret = secret;
        }
    }
}
