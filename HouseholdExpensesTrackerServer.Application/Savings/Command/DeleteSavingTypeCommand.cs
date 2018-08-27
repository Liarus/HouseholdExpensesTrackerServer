using HouseholdExpensesTrackerServer.Application.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Savings.Command
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
