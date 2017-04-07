using MeduzaClient.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace MeduzaClient.Database
{
    public class DataContext : DbContext
    {
        internal DbSet<DocumentEntity> DocumentEntity { get; set; }
        public DataContext() : base()
        { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Mobile.db");
        }
    }
}
