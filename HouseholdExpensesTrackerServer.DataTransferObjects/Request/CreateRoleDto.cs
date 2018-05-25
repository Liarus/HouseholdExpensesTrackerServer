using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.DataTransferObjects.Request
{
    public class CreateRoleDto
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
}
