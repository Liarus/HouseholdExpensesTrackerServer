using HouseholdExpensesTrackerServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Savings.Command
{
    public class DeleteSavingTypeCommand : BaseCommand
    {
        public readonly int SavingTypeId;

        public DeleteSavingTypeCommand(int savingTypeId)
        {
            this.SavingTypeId = savingTypeId;
        }
    }
}
