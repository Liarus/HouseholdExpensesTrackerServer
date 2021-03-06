﻿using HouseholdExpensesTrackerServer.Application.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Identities.Command
{
    public class ModifyUserCommand : BaseCommand
    {
        public readonly int UserId;

        public readonly string Name;

        public readonly int Version;

        public ModifyUserCommand(int userId, string name, int version)
        {
            this.UserId = userId;
            this.Name = name;
            this.Version = version;
        }
    }
}
