using Microsoft.EntityFrameworkCore;

namespace _12._1.Models
{
    /// <summary>
    /// History of assemblies and tests
    /// </summary>
    public class History : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<AssembyInfo> Assemblies { get; set; }
        public System.Data.Entity.DbSet<TestInfo> Tests { get; set; }

        protected internal virtual void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestHistory;Trusted_Connection=True;");
        }
    }
}
