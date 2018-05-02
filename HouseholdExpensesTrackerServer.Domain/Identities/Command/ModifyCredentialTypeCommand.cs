using HouseholdExpensesTrackerServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class ModifyCredentialTypeCommand : BaseCommand
    {
        public readonly int CredentialTypeId;

        public readonly string Name;

        public readonly string Code;

        public readonly int Version;

        public ModifyCredentialTypeCommand(int credentialTypeId, string name, 
            string code, int version)
        {
            this.CredentialTypeId = credentialTypeId;
            this.Code = code;
            this.Name = name;
            this.Version = version;
        }
    }
}
