using Autofac;
using HouseholdExpensesTrackerServer.Dispatchers;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Event;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Query;
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
            RegisterCommnads(builder);
            RegisterQueries(builder);
        }

        private static void RegisterDomainEvents(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return new DomainEventDispatcher(context);
            })
            .As<IDomainEventDispatcher>()
            .InstancePerLifetimeScope();
        }

        private static void RegisterCommnads(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return new CommandDispatcher(context);
            })
            .As<ICommandDispatcher>()
            .InstancePerLifetimeScope();
        }

        private static void RegisterQueries(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return new QueryDispatcher(context);
            })
            .As<IQueryDispatcher>()
            .InstancePerLifetimeScope();
        }
    }
}
