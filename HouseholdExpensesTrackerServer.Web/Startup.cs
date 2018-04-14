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
using HouseholdExpensesTrackerServer.Domain.Identity;
using HouseholdExpensesTrackerServer.Web.Helpers;

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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            });

            services.AddDbContext<HouseholdDbContext>(
                options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddScoped<IDbContext>(provider => provider.GetService<HouseholdDbContext>());
            services.AddScoped<IUserManager, UserManager>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseStaticFiles();
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
                await InsertTestData(db);
            }
        }

        private static async Task InsertTestData(IDbContext context)
        {
            if (context.CredentialTypes.Any())
            {
                return;
            }

            var type = new CredentialType { Code = "Email", Name = "Email address" };
            var user = new User { Created = DateTime.Now, Name = "Administrator" };
            var cred = new Credential { CredentialType = type, Identifier = "admin@example.com", Secret = Md5Hasher.ComputeHash("admin"), User = user };
            context.Credentials.Add(cred);

            await context.SaveChangesAsync();
        }
    }
}
