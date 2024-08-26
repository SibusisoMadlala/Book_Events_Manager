using Company.Project.EventDomain.AppServices.DTOs;
using Company.Project.EventDomain.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.EventDomain.Data.DBContext
{
    public class EventDomainDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-BookWeb-8a78703a-efcc-4e69-824a-d9fccc8bcd95;Trusted_Connection=True;");
        }
    }
}
