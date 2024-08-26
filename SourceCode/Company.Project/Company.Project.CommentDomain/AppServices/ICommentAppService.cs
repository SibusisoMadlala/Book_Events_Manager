using Company.Project.CommentDomain.AppServices.DTOs;
using Company.Project.Core.AppServices;
using Company.Project.Core.Data.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.CommentDomain.AppServices
{
    public interface ICommentAppService : IAppService
    {
        public IEnumerable<CommentDTO> getCommentsByEventId(int eventId);
        public CommentDTO Create(CommentDTO eventDTO);
    }
}
