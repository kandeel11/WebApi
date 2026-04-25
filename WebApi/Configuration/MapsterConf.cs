using Mapster;
using WebApi.DTOs;
using WebApi.Models;
namespace WebApi.Configuration
{
    public class MapsterConf
    {
        public static void Register()
        {
            TypeAdapterConfig<Student, StudentDto>.NewConfig()
                .Map(dest => dest.DeptName, src => src.Department.Name)
                .Map(dest => dest.DeptID, src => src.DeptId)
                ;

            TypeAdapterConfig<Department, DepartmentWithEmpsDTO>.NewConfig()

            .Map(dest => dest.StudentCount, src => src.Students.Count)
            .Map(dest => dest.Students, src => src.Students)
            ;
        }


    }
}
