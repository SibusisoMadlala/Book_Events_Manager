using Company.Project.CommentDomain.AppServices.DTOs;
using Company.Project.Core.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.CommentDomain.Repository
{
    public interface ICommentRepository : IRepository<CommentDTO>
    {
        public IEnumerable<CommentDTO> getCommentsByEventId(int eventId);
    }
}
