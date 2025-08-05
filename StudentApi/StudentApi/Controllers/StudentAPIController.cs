using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]  //attibute based conventional
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly MydbContext context;

        public StudentAPIController(MydbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await context.Students.ToListAsync(); 
            return Ok(data);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentsById(int id)
        {
            var data = await context.Students.FindAsync(id);
            if(data == null)
            {
                return NotFound();
            }
            return data;

        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);

        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
        {
            if (id != std.Id)
            {
                return BadRequest();
            }

            var existingStudent = await context.Students.FindAsync(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            // Manually update fields to avoid issues with tracking and disconnected entities
            existingStudent.StudentName = std.StudentName;
            existingStudent.StudentGender = std.StudentGender;
            existingStudent.Age = std.Age;
            existingStudent.Standard = std.Standard;

            await context.SaveChangesAsync();
            return Ok(existingStudent);
        }




        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var std = await context.Students.FindAsync(id);

            if(std == null)
            {
                return NotFound();
            }
            context.Students.Remove(std);
            await context.SaveChangesAsync();
            return Ok(std);

        }



    }
}
