using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Definitions.Command
{
    public abstract class BaseCommand : ICommand
    {
        public Guid AggregateId { get; protected set; }
        public int AggregateExpectedVersion { get; protected set; }

    }
}
