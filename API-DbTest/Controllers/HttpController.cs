using API_DbTest.Modals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_DbTest.Controllers
{

    [Authorize] 
    [Route("api/[controller]")]
    [ApiController]
    public class HttpController : ControllerBase
    {
        // Link for Postman: https://localhost:7002/api/Http
        public Student student = new Student();
        
        private readonly StudentDB _context;


        public HttpController(StudentDB context)
        {
            _context = context;

        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student data is null.");
            }

            _context.Students.Add(student);
            _context.SaveChanges();

            return Ok(student);
        }


        [HttpGet]
        public IActionResult GetAllStudentsNormal()
        {
          
            var allStudents = _context.Students.ToList();

            if(allStudents.Count == 0)
            {
                return Ok("No Students in Database");
            }
            return Ok(allStudents);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student studentUpdate)
        {
            if (studentUpdate == null || id != studentUpdate.ID)
            {
                return BadRequest("Student data is invalid.");
            }

            var existingStudent = _context.Students.FirstOrDefault(x => x.ID == id);
            if (existingStudent == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            
            existingStudent.FirstName = studentUpdate.FirstName;
            existingStudent.SecondName = studentUpdate.SecondName;
            existingStudent.Age = studentUpdate.Age;
            existingStudent.EMail = studentUpdate.EMail;
          

            _context.Students.Update(existingStudent);
            _context.SaveChanges();

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var studentToDelete = _context.Students.FirstOrDefault(x => x.ID == id);
            if (studentToDelete == null)
            {
                return NotFound("Student not found.");
            }

            _context.Students.Remove(studentToDelete);
            _context.SaveChanges();

            return Ok($"Student with ID {id} deleted.");
        }
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.ID == id);

            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            return Ok(student);
        }



    }
}
