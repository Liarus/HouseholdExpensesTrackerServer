﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.DataTransferObjects.Request
{
    public class ModifyRoleDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public ICollection<int> PermissionIds { get; set; }

        public int Version { get; set; }
    }
}
