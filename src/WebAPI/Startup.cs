using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPI.Configurations;
using WebAPI.DatabaseContexts;
using WebAPI.Interfaces;
using WebAPI.Migrations;
using WebAPI.Repositories;


namespace WebAPI
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            // Inject Repository implementation
            services.AddScoped<DbContext, MainDbContext>();
            services.AddScoped<ICommandAPIRepo, MySQLCommandAPIRepo>();
            
            // Inject database context
            this.ConfigureDatabase(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
        private void ConfigureDatabase(IServiceCollection services)
        {
            IConfigurationSection configurationSection = this.Configuration.GetSection("Database");
            DatabaseConfiguration databaseConfiguration = 
                configurationSection.Get<DatabaseConfiguration>() ?? new DatabaseConfiguration();
            
            string connectionString = databaseConfiguration.ConnectionString;
            int dbVersion = databaseConfiguration.Version;
            
            // Injecting database context
            services.AddDbContext<MainDbContext>(options => { options.UseMySQL(connectionString); });
            
            // Process migrations
            MigrationManager databaseManager = new MigrationManager(connectionString);
            databaseManager.UpdateDbToVersion(dbVersion);
        }
    }
}
