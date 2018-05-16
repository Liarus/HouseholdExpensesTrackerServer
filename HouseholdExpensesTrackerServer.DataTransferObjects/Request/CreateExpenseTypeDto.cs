using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.DataTransferObjects.Request
{
    public class CreateExpenseTypeDto
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }
    }
}
