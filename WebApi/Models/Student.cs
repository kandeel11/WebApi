using Microsoft.SqlServer.Server;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Validations;

namespace WebApi.Models
{
    public class Student
    {
        [Key]
        public int ssn { get; set; }
        [MinLength(6), MaxLength(15)]
        public string Name { get; set; }
        public string? Address { get; set; }
        [Range(18,22)]
        public int? Age { get; set; }
        [RegularExpression(@"\w+\.(jpg||png)$", ErrorMessage = "Invalid image format.")]
        public string? ImageUrl { get; set; }
        [Column(TypeName = "date")]
        [DateBirthDay]
        public DateTime? DOB { get; set; }
        [ForeignKey("Department")]
        public int ? DeptId {  get; set; }

        public Department? Department { get; set; }

    }
}
