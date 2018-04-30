using Autofac;
using HouseholdExpensesTrackerServer.Application.Households.CommandHandler;
using HouseholdExpensesTrackerServer.Dispatchers;
using HouseholdExpensesTrackerServer.Domain.Households.Repository;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Event;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Query;
using HouseholdExpensesTrackerServer.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HouseholdExpensesTrackerServer.CompositionRoot
{
    public class DefaultModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            RegisterEvents(builder);
            RegisterCommands(builder);
            RegisterQueries(builder);
            RegisterRepositories(builder);
        }

        private static void RegisterEvents(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return new EventDispatcher(context);
            })
            .As<IEventDispatcher>()
            .InstancePerLifetimeScope();
        }

        private static void RegisterCommands(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return new CommandDispatcher(context);
            })
            .As<ICommandDispatcher>()
            .InstancePerLifetimeScope();

            var assembly = Assembly.Load(new AssemblyName("HouseholdExpensesTrackerServer.Application"));
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(ICommandHandler<>));
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

            var assembly = Assembly.Load(new AssemblyName("HouseholdExpensesTrackerServer.Application"));
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IQueryHandler<,>));
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<HouseholdRepository>()
                .As<IHouseholdRepository>().InstancePerLifetimeScope();
            //builder.RegisterGeneric(typeof(EntityFrameworkRepository<,>))
            //    .As(typeof(IRepository<,>));
        }
    }
}
