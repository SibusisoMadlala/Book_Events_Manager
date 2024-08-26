using Company.Project.Core.WebMVC;
using System.ComponentModel.DataAnnotations;

namespace BookWeb.Models
{
    public class EventViewModel : ViewModel
    {
        [Required()]
        [Range(1, 20, ErrorMessage = "Please Enter Valid title")]
        public string Title { get; set; }

        [Required()]
        public DateTime Date { get; set; }

        [Required()]
        public string Location { get; set; }

        [Required()]
        public TimeOnly StartTime { get; set; }
        public string Type { get; set; } = "Public";

        
        public int DurationInHours { get; set; }

        [StringLength(50, ErrorMessage = "Description Should be 50 charactera")]
        public string Description { get; set; }

        [StringLength(500, ErrorMessage = "other details Should be 500 charactera")]
        public string OtherDetails { get; set; }
    }
}
