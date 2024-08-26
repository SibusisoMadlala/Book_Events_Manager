using Company.Project.Core.AppServices;
using Company.Project.Core.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.CommentDomain.AppServices.DTOs
{
    public class CommentDTO : DomainBase
    {
        public string comment { get; set; }
        public string UserId { get; set; }

        public int EventId { get; set; }
    }
}
