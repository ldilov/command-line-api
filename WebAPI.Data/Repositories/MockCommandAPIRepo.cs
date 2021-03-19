using System.Collections.Generic;
using WebAPI.Data.Interfaces;
using WebAPI.Models;

namespace WebAPI.Data.Repositories
{
    public class MockCommandAPIRepo : ICommandAPIRepo
    {
        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{
                    Id=0, Description="How to generate a migration",
                    CommandLine="dotnet ef migrations add <Name of Migration>",
                    Platform=".Net Core EF"},
                new Command{
                    Id=1, Description="Run Migrations",
                    CommandLine="dotnet ef database update",
                    Platform=".Net Core EF"},
                new Command{
                    Id=2, Description="List active migrations",
                    CommandLine="dotnet ef migrations list",
                    Platform=".Net Core EF"}
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command {
                Id=0, Description="How to generate a migration",
                CommandLine="dotnet ef migrations add <Name of Migration>",
                Platform=".Net Core EF"};
        }

        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}