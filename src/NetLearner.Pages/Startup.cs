using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Services;
using Microsoft.AspNetCore.Http;

namespace NetLearner.Pages
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
            services.AddDbContext<LibDbContext>(options =>
            {
                options
                   .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                      assembly =>
                      assembly.MigrationsAssembly
                         (typeof(LibDbContext).Assembly.FullName));
            });
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<LibDbContext>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizePage("/LearningResources/Create");
                    options.Conventions.AuthorizePage("/LearningResources/Edit");
                    options.Conventions.AuthorizePage("/LearningResources/Delete");
                    options.Conventions.AuthorizePage("/ResourceLists/Create");
                    options.Conventions.AuthorizePage("/ResourceLists/Edit");
                    options.Conventions.AuthorizePage("/ResourceLists/Delete");
                    options.Conventions.AllowAnonymousToPage("/Index");
                });

            services.AddTransient<ILearningResourceService, LearningResourceService>();
            services.AddTransient<IResourceListService, ResourceListService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                // redirects to Razor Pages Error page in non-dev environment
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
