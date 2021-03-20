using WebAPI.Models;

namespace WebAPI.DatabaseContexts
{
    using Microsoft.EntityFrameworkCore;
    
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Command>()
                .HasKey(dc => new { dc.Id });
            
        }
        #region Database Entity Sets 
        
        public virtual DbSet<Command> Commands { get; set; }
        
        #endregion
    }
}