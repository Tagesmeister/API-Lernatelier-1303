using API_DbTest.Modals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_DbTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpController : ControllerBase
    {
        // localhost:44325/api/Student

        private readonly StudentDB _context;

        public HttpController(StudentDB context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult PostStudentNormal(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChangesAsync();

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

    }
}
