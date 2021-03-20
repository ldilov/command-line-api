using System;
using FluentMigrator;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Migrations.Migrations;

namespace WebAPI.Migrations
{
    public class MigrationManager
    {
        
        private string connectionString;
        private readonly IServiceProvider mainServiceProvider;

        public MigrationManager(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.mainServiceProvider = this.CreateServices();
        }
        
        public string ConnectionString
        {
            get => this.connectionString;
            private set => this.connectionString = string.IsNullOrEmpty(value)
                ? throw new ArgumentNullException(nameof(value), "Connection string cannot be null or empty.")
                : value;
        }

        public void UpdateDbToVersion(int version)
        {
            using (var scope = this.mainServiceProvider.CreateScope())
            {
                this.ProcessMigrationRun(scope.ServiceProvider.GetRequiredService<IMigrationRunner>(), version);
            }
        }
        private IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddMySql5()
                    .WithGlobalConnectionString(this.ConnectionString)
                    .ScanIn(typeof(AbstractMigration).Assembly).For.Migrations()
                )
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }
        
        private void ProcessMigrationRun(IMigrationRunner migrationRunner, long targetVersion)
        {
            if (migrationRunner.HasMigrationsToApplyUp(targetVersion))
            {
                migrationRunner.MigrateUp(targetVersion);
            }
            else if (migrationRunner.HasMigrationsToApplyDown(targetVersion))
            {
                migrationRunner.MigrateDown(targetVersion);
            }
        }
    }
}