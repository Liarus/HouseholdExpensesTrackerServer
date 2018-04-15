using Autofac;
using Autofac.Core;
using HouseholdExpensesTrackerServer.DomainEventBroker;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.CompositionRoot
{
    public class ContainerFacade : IContainerFacade
    {
        private readonly IComponentContext _container;

        public ContainerFacade(IComponentContext container)
        {
            _container = container;
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _container.Resolve<IEnumerable<T>>();
        }

        public T Resolve<T>(params Parameter[] parameters)
        {
            return _container.Resolve<T>(parameters);
        }
    }
}
