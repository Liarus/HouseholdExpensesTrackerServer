using HouseholdExpensesTrackerServer.Application.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Households.Command
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
