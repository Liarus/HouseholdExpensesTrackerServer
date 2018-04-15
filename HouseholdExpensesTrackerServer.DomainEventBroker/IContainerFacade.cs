using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.DomainEventBroker
{
    public interface IContainerFacade
    {
        IEnumerable<T> ResolveAll<T>();

        T Resolve<T>(params Parameter[] parameters);
    }
}
