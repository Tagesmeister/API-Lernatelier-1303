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
        // Link for Postman: https://localhost:7002/api/Http
        public Student student = new Student();
        
        private readonly StudentDB _context;

        private bool _isLoggedIn
        {
            set { student.IsLoggedIn = value; }
            get { return _isLoggedIn; }
        }





        public HttpController(StudentDB context)
        {
            _context = context;
            
        }


        [HttpPost("register")]
        public ActionResult<Student> RegisterStudent(Student request)
        {
            
            student.FirstName = request.FirstName;
            student.SecondName = request.SecondName;
            student.EMail = request.EMail;
            student.Age = request.Age;
            student.UserName = request.UserName;
            student.Password = request.Password;
            student.UserName = request.UserName;
            student.Password = request.Password;
            _context.Students.Add(student);
            _context.SaveChangesAsync();

            return Ok(student);
        }
        [HttpPost("login")]
        public async Task<ActionResult<Student>> LoginStudent(StudentDTO request)
        {
            
            var student = await _context.Students
                                        .FirstOrDefaultAsync(s => s.UserName == request.UserName);

            _isLoggedIn = true;
            if (student.UserName == null)
            {
                _isLoggedIn = false;
                return BadRequest("User not found");
                
            }
           
            else if (student.Password != request.Password)
            {
                _isLoggedIn = false;
                return BadRequest("User not found");
            }

            
            return Ok(student);
        }


        [HttpGet]
        public IActionResult GetAllStudentsNormal()
        {
            if (_isLoggedIn == false)
            {
                return BadRequest("Not logged in");
            }
            var allStudents = _context.Students.ToList();

            if(allStudents.Count == 0)
            {
                return Ok("No Students in Database");
            }
            return Ok(allStudents);
        }

    }
}
