using Autofac;
using HouseholdExpensesTrackerServer.DomainEventBroker;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.CompositionRoot
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            RegisterDomainEvents(builder);
        }

        private static void RegisterDomainEvents(ContainerBuilder builder)
        {
            builder.Register(componentContext => 
                new DomainEventsDispatcher(new ContainerFacade(componentContext.Resolve<IComponentContext>())))
                .As<IDomainEventsDispatcher>();
        }
    }
}
