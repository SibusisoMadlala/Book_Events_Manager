using Company.Project.Core.Data.Transaction;
using Company.Project.Core.ExceptionManagement;
using Company.Project.EventDomain.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.EventDomain.UoW
{
    public class EventUnitOfWorks : UnitOfWork, IEventUnitOfWorks
    {
        private readonly IServiceProvider ServiceProvider;
        public EventUnitOfWorks(EventDomainDbContext context, IExceptionManager exceptionManager) : base(context, exceptionManager)
        {
        }
    }
}
