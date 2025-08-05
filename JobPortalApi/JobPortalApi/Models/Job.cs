using System.ComponentModel.DataAnnotations;

namespace JobPortalAPI.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime PostedOn { get; set; } = DateTime.Now;
    }
}
