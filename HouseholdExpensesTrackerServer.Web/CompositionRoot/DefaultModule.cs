using Autofac;
using HouseholdExpensesTrackerServer.Common.Command;
using HouseholdExpensesTrackerServer.Common.Configuration;
using HouseholdExpensesTrackerServer.Common.Event;
using HouseholdExpensesTrackerServer.Common.Query;
using HouseholdExpensesTrackerServer.Domain.Expenses.Repository;
using HouseholdExpensesTrackerServer.Domain.Households.Repository;
using HouseholdExpensesTrackerServer.Domain.Identities.Repository;
using HouseholdExpensesTrackerServer.Domain.Savings.Repository;
using HouseholdExpensesTrackerServer.Infrastructure.Dispatchers;
using HouseholdExpensesTrackerServer.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;
using static HouseholdExpensesTrackerServer.Common.Core.Consts;

namespace HouseholdExpensesTrackerServer.Web.CompositionRoot
{
    public class DefaultModule : Autofac.Module
    {
        public Func<NameValueCollection> ConfigurationProvider { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            this.RegisterConfigurations(builder);
            RegisterEvents(builder);
            RegisterCommands(builder);
            RegisterQueries(builder);
            RegisterRepositories(builder);
        }

        private void RegisterConfigurations(ContainerBuilder builder)
        {
            var configuration = this.ConfigurationProvider?.Invoke();
            if (configuration == null)
            {

            }
            var appConfig = ApplicationConfiguration.Create(
                configuration.Get(ApplicationConfigurationKeys.HouseholdConnectionString),
                60);
            builder.RegisterInstance(appConfig)
                .As<IApplicationConfiguration>()
                .SingleInstance();
        }

        private static void RegisterEvents(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return new EventDispatcher(context);
            })
            .As<IEventDispatcherAsync>()
            .InstancePerLifetimeScope();
        }

        private static void RegisterCommands(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return new CommandDispatcher(context);
            })
            .As<ICommandDispatcherAsync>()
            .InstancePerLifetimeScope();

            var assembly = Assembly.Load(new AssemblyName("HouseholdExpensesTrackerServer.Application"));
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(ICommandHandlerAsync<>));
        }

        private static void RegisterQueries(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return new QueryDispatcher(context);
            })
            .As<IQueryDispatcherAsync>()
            .InstancePerLifetimeScope();

            var assembly = Assembly.Load(new AssemblyName("HouseholdExpensesTrackerServer.Application"));
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IQueryHandlerAsync<,>));
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<HouseholdRepository>()
                .As<IHouseholdRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SavingTypeRepository>()
                .As<ISavingTypeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ExpenseTypeRepository>()
                .As<IExpenseTypeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PermissionRepository>()
                .As<IPermissionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RoleRepository>()
                .As<IRoleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CredentialTypeRepository>()
                .As<ICredentialTypeRepository>().InstancePerLifetimeScope();
            //builder.RegisterGeneric(typeof(EntityFrameworkRepository<,>))
            //    .As(typeof(IRepository<,>));
        }
    }
}
