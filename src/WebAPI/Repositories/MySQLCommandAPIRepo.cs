using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.DatabaseContexts;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class MySQLCommandAPIRepo : ICommandAPIRepo
    {

        private readonly MainDbContext _dbContext;
        
        public MySQLCommandAPIRepo(MainDbContext ctx)
        {
            this._dbContext = ctx;
        }
        
        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return this._dbContext.Commands
                .AsNoTracking()
                .ToList();
        }

        public Command GetCommandById(int id)
        {
            throw new System.NotImplementedException();
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