using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class ModifyCredentialTypeCommand : ICommandHandler
    {
        public readonly int CredentialTypeId;

        public readonly string Name;

        public readonly string Code;

        public readonly string RowVersion;

        public ModifyCredentialTypeCommand(int credentialTypeId, string name, 
            string code, string rowVersion)
        {
            this.CredentialTypeId = credentialTypeId;
            this.Code = code;
            this.Name = name;
            this.RowVersion = rowVersion;
        }
    }
}
