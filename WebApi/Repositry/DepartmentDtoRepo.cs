using Mapster;
using WebApi.Context;
using WebApi.DTOs;
using WebApi.Models;

namespace WebApi.Repositry
{
    public class DepartmentDtoRepo : IRepositry<DepartmentWithEmpsDTO>
    {
        private readonly ApiContext _context;
        public DepartmentDtoRepo(ApiContext context)
        {
            _context = context;
        }
        public void Add(DepartmentWithEmpsDTO entity)
        {
            var department = entity.Adapt<Department>();
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var department = _context.Departments.Find(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }
        public List<DepartmentWithEmpsDTO> GetAll()
        {
            return _context.Departments.ProjectToType<DepartmentWithEmpsDTO>().ToList();
        }

        public DepartmentWithEmpsDTO GetById(int id)
        {
            return _context.Departments.Where(d => d.Id == id).ProjectToType<DepartmentWithEmpsDTO>().FirstOrDefault();
        }

        public void Update(DepartmentWithEmpsDTO entity)
        {
            var department = _context.Departments.Find(entity.Id);
            if (department != null)
            {
                department.Name = entity.Name;
                department.Location = entity.Location;
                _context.SaveChanges();
            }

        }
    }
}
