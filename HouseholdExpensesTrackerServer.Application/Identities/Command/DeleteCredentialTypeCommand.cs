using HouseholdExpensesTrackerServer.Application.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Identities.Command
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
