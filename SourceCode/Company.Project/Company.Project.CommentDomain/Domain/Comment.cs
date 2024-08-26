using Company.Project.Core.Domain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.CommentDomain.Domain
{
    public class Comment : DomainBase
    {
        [Required]
        public string comment {  get; set; }
        public string UserId { get; set; }

        public int EventId { get; set; }

    }
}
