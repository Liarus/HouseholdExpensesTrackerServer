using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class AddCredentialCommand : ICommandHandler
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
