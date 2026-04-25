using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.Repositry;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepositry<DepartmentWithEmpsDTO> _repositry;
        public DepartmentController(IRepositry<DepartmentWithEmpsDTO> repositry)
        {
            _repositry = repositry;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var departments = _repositry.GetAll();
            return Ok(departments);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var department = _repositry.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }
        [HttpPost]
        public IActionResult Add(DepartmentWithEmpsDTO department)
        {
            _repositry.Add(department);
            return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, DepartmentWithEmpsDTO department)
        {
            var existingDepartment = _repositry.GetById(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }
            department.Id = id;
            _repositry.Update(department);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var existingDepartment = _repositry.GetById(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }
            _repositry.Delete(id);
            return NoContent();
        }

    }
}
