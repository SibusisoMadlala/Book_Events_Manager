using Company.Project.Core.AppServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Project.EventDomain.AppServices.DTOs
{
    public class EventDTO : DtoBase
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string? Location { get; set; }

        public TimeOnly StartTime { get; set; }
        public string Type { get; set; } = "Public";
        public int DurationInHours { get; set; }

        public string? Description { get; set; }
        public string? OtherDetails { get; set; }

        public string? UserEmailID { get; set; }

        public string? Invites { get; set; }
    }
}
