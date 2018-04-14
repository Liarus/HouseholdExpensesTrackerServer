using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identity
{
    public class Role
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Position { get; set; }
    }
}
