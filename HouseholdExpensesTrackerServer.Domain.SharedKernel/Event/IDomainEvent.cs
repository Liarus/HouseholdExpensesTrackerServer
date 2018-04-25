using HouseholdExpensesTrackerServer.Domain.SharedKernel.Message;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Event
{
    public interface IDomainEvent : IMessage
    {
        Guid Id { get; set; }
        IIdValue AggregateId { get; set; }
        int AggregateVersion { get; set; }
        DateTimeOffset TimeStamp { get; set; }
    }
}
