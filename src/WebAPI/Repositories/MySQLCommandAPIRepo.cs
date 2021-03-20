using System;
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
            return (_dbContext.SaveChanges() >= 0);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return this._dbContext.Commands
                .AsNoTracking()
                .ToList();
        }

        public Command GetCommandById(int id)
        {
            return this._dbContext.Commands
                .AsNoTracking()
                .Where(c => c.Id.Equals(id))
                .ToList()
                .FirstOrDefault();
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _dbContext.Commands.Add(cmd);
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