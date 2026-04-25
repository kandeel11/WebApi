namespace WebApi.DTOs
{
    public class StudentDto
    {
        public int ssn { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
        public string? DeptName { get; set; }
        public string? ImageUrl { get; set; }
        public int? DeptID { get; set; }
    }
}
