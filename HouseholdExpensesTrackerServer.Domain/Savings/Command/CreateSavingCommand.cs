using HouseholdExpensesTrackerServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Savings.Command
{
    public class CreateSavingCommand : BaseCommand
    {
        public readonly int HouseholdId;

        public readonly int SavingTypeId;

        public readonly string Name;

        public readonly string Description;

        public readonly decimal Amount;

        public readonly DateTime Date;

        public CreateSavingCommand(int householdId, int savingTypeId, string name, string description,
            decimal amount, DateTime date)
        {
            this.HouseholdId = householdId;
            this.SavingTypeId = savingTypeId;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.Date = date;
        }
    }
}
