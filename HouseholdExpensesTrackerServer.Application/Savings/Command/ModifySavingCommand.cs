using HouseholdExpensesTrackerServer.Application.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Savings.Command
{
    public class ModifySavingCommand : BaseCommand
    {
        public readonly int SavingId;

        public readonly int SavingTypeId;

        public readonly string Name;

        public readonly string Description;

        public readonly decimal Amount;

        public readonly DateTime Date;

        public readonly int Version;

        public ModifySavingCommand(int savingId, int savingTypeId, string name, string description,
            decimal amount, DateTime date, int version)
        {
            this.SavingId = savingId;
            this.SavingTypeId = savingTypeId;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.Date = date;
            this.Version = version;
        }
    }
}
