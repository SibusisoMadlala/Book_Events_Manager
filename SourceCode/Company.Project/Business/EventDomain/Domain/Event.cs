using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDomain.Domain
{
    internal class Event
    {
        public string Title { get; set; }

        public string Description { get; set; } 

        public string Type { get; set; }
        public int EventId { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public int Duration { get; set; }

        public string OtherDetails { get; set; }

    }
}
