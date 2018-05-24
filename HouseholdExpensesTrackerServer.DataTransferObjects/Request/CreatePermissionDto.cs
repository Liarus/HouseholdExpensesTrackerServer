using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.DataTransferObjects.Request
{
    public class CreatePermissionDto
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
