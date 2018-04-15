using HouseholdExpensesTrackerServer.Domain.DomainSpecification.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.DomainSpecification.Object
{
    public interface IAggregateRoot
    {
        ICollection<IDomainEvent> Events { get; }
    }
}
