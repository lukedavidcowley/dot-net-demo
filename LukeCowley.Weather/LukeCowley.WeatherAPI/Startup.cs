using LukeCowley.Business.Data;
using LukeCowley.Business.Data.Providers;
using LukeCowley.Business.Models;
using LukeCowley.Business.Services;
using LukeCowley.Data.Contexts;
using LukeCowley.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Hangfire.SqlServer;
using Hangfire;
using System;
using Microsoft.EntityFrameworkCore;
using LukeCowley.WeatherAPI.Data;

namespace LukeCowley.WeatherAPI
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
            
            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddDbContext<MarsWeatherContext>(options =>
            {
                options.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=MarsWeather;Integrated Security=True;MultipleActiveResultSets=True");
            });
            services.AddTransient<IMarsWeatherDataProvider>(s => new InSightDataProvider("IikEzlLMvmy4dPeIoT70cdzsIwvYiGKWjsuKUQCq"));
            services.AddTransient<IRepository<Sol>, SolWeekRepository>();
            services.AddTransient<IMarsWeatherService, MarsWeatherService>();
            
            services.AddHangfire(configuration => configuration
               .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
               .UseSimpleAssemblyNameTypeSerializer()
               .UseRecommendedSerializerSettings()
               .UseSqlServerStorage("Data Source=.\\SQLEXPRESS;Initial Catalog=MarsWeather;Integrated Security=True", new SqlServerStorageOptions
               {
                   CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                   SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                   QueuePollInterval = TimeSpan.Zero,
                   UseRecommendedIsolationLevel = true,
                   DisableGlobalLocks = true
               }));

            // Add the processing server as IHostedService
            services.AddHangfireServer();

            var sqlStorage = new SqlServerStorage("Data Source=.\\SQLEXPRESS;Initial Catalog=MarsWeather;Integrated Security=True");
            var options = new BackgroundJobServerOptions
            {
                ServerName = "Test Server"
            };

            var marsService = services.BuildServiceProvider().GetService<IMarsWeatherService>();

            JobStorage.Current = sqlStorage;
            

            //RecurringJob.AddOrUpdate(() => services.BuildServiceProvider().GetService<IMarsWeatherService>().UpdateWeatherAsync(), Cron.Hourly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

            app.UseHangfireDashboard();
            BackgroundJob.Enqueue(() => new WeatherDataRetrivalService(provider.GetService<IMarsWeatherService>()).UpdateMarsWeather());
            //app.UseHangfireServer();

        }
    }
}
