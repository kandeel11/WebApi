namespace WebApi.DTOs
{
    public class DepartmentWithEmpsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Location { get; set; }
        public int StudentCount { get; set; }
        public ICollection<StudentDto> Students { get; set; } = new HashSet<StudentDto>();
    }
}
