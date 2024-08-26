
using Company.Project.Core.Data.DataAccess;
using Company.Project.EventDomain.Data.DBContext;
using Company.Project.EventDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.EventDomain.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(EventDomainDbContext dbContext) : base(dbContext)
        {
           

        }
    }
}
