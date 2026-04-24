using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositry;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IRepositry<Student> _repositry;

        public StudentController(IRepositry<Student> repositry)
        {
            _repositry = repositry;
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_repositry.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            {
                var student = _repositry.GetById(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
        }
        [HttpPost]
        public IActionResult Add(Student student)
        {
            _repositry.Add(student);
            return CreatedAtAction(nameof(Details), new { id = student.ssn }, student);
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, Student student)
        {
            var existingStudent = _repositry.GetById(id);
            if (existingStudent == null)
            {
                return NotFound();
            }
            student.ssn = id;
            _repositry.Update(student);
            return Ok(new {status="Updated",data=student});
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingStudent = _repositry.GetById(id);
            if (existingStudent == null)
            {
                return NotFound();
            }
            _repositry.Delete(id);
            return Ok(new {status="Deleted",data=existingStudent} );
        }
    }
}
