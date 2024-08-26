using EventDomain.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDomain.Data
{
    internal class EventDbContext : DbContext 
    {
        DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-WebLayer-79076070-6c46-46c3-9e38-50aa10b94ed7;Trusted_Connection=True;");
        }
    }
}
