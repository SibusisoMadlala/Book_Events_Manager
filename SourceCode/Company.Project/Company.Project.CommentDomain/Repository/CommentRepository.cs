using Company.Project.CommentDomain.AppServices.DTOs;
using Company.Project.Core.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.CommentDomain.Repository
{
    public class CommentRepository : Repository<CommentDTO>, ICommentRepository
    {
        public CommentRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<CommentDTO> getCommentsByEventId(int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
