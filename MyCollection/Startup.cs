using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCollection.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DAL.Entities;
using DAL.Context;
using DAL.Repo;
using Common.DataContracts;
using DAL.Entities.Messages;
using Common.MTO;
using DAL.UnitOfWork;
using DAL.Converters;
using BLL.UserCases;

namespace MyCollection
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("azure")));

            //services.AddDefaultIdentity<ApplicationUser>()
            //    .AddDefaultUI(UIFramework.Bootstrap4)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddIdentity<ApplicationUserEF, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                //options.User.RequireUniqueEmail = true;

            })
                .AddEntityFrameworkStores<DatabaseContext>();

            //services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
            services.AddTransient<IRepositoryGeneric<MovieDetail, MovieEF, int>, RepositoryGeneric<MovieDetail, MovieEF, int>>();
            services.AddTransient<IRepositoryGeneric<MovieSummary, MovieEF, int>, RepositoryGeneric<MovieSummary, MovieEF, int>>();
            services.AddTransient<IRepositoryGeneric<Adress, AdressEF, int>, RepositoryGeneric<Adress, AdressEF, int>>();
            services.AddTransient<IRepositoryGeneric<ApplicationUserEF,ApplicationUserEF, string>, RepositoryGeneric<ApplicationUserEF, ApplicationUserEF, string>>();
            services.AddTransient<IRepositoryGeneric<Message, MessageEF, int>, RepositoryGeneric<Message, MessageEF, int>>();
            services.AddTransient<IRepositoryGeneric<Conversation, ConversationEF, int>, RepositoryGeneric<Conversation, ConversationEF, int>>();

            services.AddTransient<TypeConverter<MovieDetail, MovieEF>, MovieDetailConverter>();
            services.AddTransient<TypeConverter<MovieSummary, MovieEF>, MovieSummaryConverter>();
            services.AddTransient<TypeConverter<Adress, AdressEF>, AdressConverter>();
            services.AddTransient<TypeConverter<ApplicationUserEF, ApplicationUserEF>, ApplicationUserConverter>();
            services.AddTransient<TypeConverter<Message, MessageEF>, MessageConverter>();
            services.AddTransient<TypeConverter<Conversation, ConversationEF>, ConversationConverter>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
