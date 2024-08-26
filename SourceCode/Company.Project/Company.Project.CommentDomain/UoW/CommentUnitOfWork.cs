using Company.Project.CommentDomain.Data.DBContext;
using Company.Project.Core.Data.Transaction;
using Company.Project.Core.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.CommentDomain.UoW
{
    public class CommentUnitOfWork : UnitOfWork, ICommentUnitOfWork
    {
        private readonly IServiceProvider ServiceProvider;
        public CommentUnitOfWork(CommentDbContext context, IExceptionManager exceptionManager) : base(context, exceptionManager)
        {
        }
    }
}
