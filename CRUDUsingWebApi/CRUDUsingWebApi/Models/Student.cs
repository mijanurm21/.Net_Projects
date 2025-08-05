



using System.ComponentModel.DataAnnotations;

namespace CRUDUsingWebApi.Models
{
    public class Student
    {

        public int Id { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentGender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Standard { get; set; }
    }
}
