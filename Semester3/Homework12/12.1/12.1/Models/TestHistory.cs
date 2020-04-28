using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _12._1.Models
{
    public class TestHistory : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<Participant> Participants { get; set; }

        protected internal virtual void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestHistory;Trusted_Connection=True;");
        }
    }
}
