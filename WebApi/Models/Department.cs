using WebApi.Validations;

namespace WebApi.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Unique]
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<Student>? Students { get; set; }= new HashSet<Student>();

    }
}
