using Company.Project.Core.Domain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.EventDomain.Domain
{
    public class Event : DomainBase
    {
        [Required()]
        //[Range(1, 20, ErrorMessage = "Please Enter Valid title")]
        [ConcurrencyCheck]
        public string Title { get; set; }

        [Required()]
        public DateTime Date { get; set; }

        [Required()]
        public string? Location { get; set; }

        [Required()]
        public TimeOnly StartTime { get; set; }
        public string Type { get; set; } = "public";

        // [MaxLength(4, ErrorMessage = "Maximum duration is 4 hours")]
        public int DurationInHours { get; set; }

        [StringLength(50, ErrorMessage = "Description Should be 50 charactera")]
        public string? Description { get; set; }

        [StringLength(500, ErrorMessage = "other details Should be 500 charactera")]
        public string? OtherDetails { get; set; }

        
        public string? UserEmailID { get; set; }

        public string? Invites {  get; set; }

        


    }
}
