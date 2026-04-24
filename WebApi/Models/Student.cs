using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Student
    {
        [Key]
        public int ssn { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
        public string? ImageUrl { get; set; }

    }
}
