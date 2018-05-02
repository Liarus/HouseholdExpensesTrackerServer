using HouseholdExpensesTrackerServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Households.Command
{
    public class DeleteHouseholdCommand : BaseCommand
    {
        public readonly int HouseholdId;

        public DeleteHouseholdCommand(int householdId)
        {
            this.HouseholdId = householdId;
        }
    }
}
