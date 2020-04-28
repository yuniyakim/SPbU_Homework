using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceRegistration.Models
{
    public class Repository : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<Participant> Participants { get; set; }

        protected internal virtual void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ConferenceRegistration;Trusted_Connection=True;");
        }
    }
}
