using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseholdExpensesTrackerServer.Infrastructure.Context;
using HouseholdExpensesTrackerServer.Web.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using HouseholdExpensesTrackerServer.Web.Helpers;
using HouseholdExpensesTrackerServer.CompositionRoot;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using HouseholdExpensesTrackerServer.Domain.Identities.Model;
using HouseholdExpensesTrackerServer.Web.Common.Mvc;
using System.Collections.Specialized;
using static HouseholdExpensesTrackerServer.Common.Core.Consts;
using Serilog;

namespace HouseholdExpensesTrackerServer.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc()
                .AddDefaultJsonOptions();
            services.AddHttpContextAccessor();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            });

            services.AddDbContext<HouseholdDbContext>(
                options =>
                    options.UseSqlServer(
                        this.Configuration.GetConnectionString(ApplicationConfigurationKeys.HouseholdConnectionString))
            );
            services.AddScoped<IDbContext>(provider => provider.GetService<HouseholdDbContext>());
            services.AddLogging(builder => builder.AddSerilog(dispose: true));
            services.AddScoped<IUserManager, UserManager>();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DefaultModule { ConfigurationProvider = this.ConfigurationProvider });
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options
                .WithOrigins(new string[] { "http://localhost:4200" })
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
            );

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseErrorHandler();
            app.UseMvc();
            Initialize(app.ApplicationServices).Wait();
        }

        public static async Task Initialize(IServiceProvider service)
        {
            using (var serviceScope = service.CreateScope())
            {
                var scopeServiceProvider = serviceScope.ServiceProvider;
                var db = scopeServiceProvider.GetService<IDbContext>();
                db.Database.Migrate();
                await InsertTestDataAsync(db);
            }
        }

        private static async Task InsertTestDataAsync(IDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.CredentialTypes.Any())
            {
                return;
            }

            var type = CredentialType.Create(Guid.NewGuid(), "Email address", "Email");
            var user = User.Create(Guid.NewGuid(), "Administrator");
            context.CredentialTypes.Add(type);
            await context.SaveChangesAsync();
            var cred = Credential.Create(type.Id, "admin@example.com", Md5Hasher.ComputeHash("admin"));
            user.AddCredential(cred);
            context.Users.Add(user);

            await context.SaveChangesAsync();
        }

        private NameValueCollection ConfigurationProvider() => new NameValueCollection
        {
            [ApplicationConfigurationKeys.HouseholdConnectionString] =
               this.Configuration.GetConnectionString(ApplicationConfigurationKeys.HouseholdConnectionString)
        };
    }
}
