using HouseholdExpensesTrackerServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class DeleteCredentialTypeCommand : BaseCommand
    {
        public readonly int CredentialTypeId;

        public DeleteCredentialTypeCommand(int credentialTypeId)
        {
            this.CredentialTypeId = credentialTypeId;
        }
    }
}
