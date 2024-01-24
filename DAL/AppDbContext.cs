using Contracts;
using Microsoft.EntityFrameworkCore;


namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public AppDbContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{
        //    Database.EnsureDeleted();
        //    Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=notes.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
