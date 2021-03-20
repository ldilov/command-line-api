using FluentMigrator;

namespace WebAPI.Migrations.Migrations
{
    public abstract class AbstractMigration: Migration
    {
        public abstract override void Up();
        public abstract override void Down();
    }
}