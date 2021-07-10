using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleSchoolApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentsRepository repository;

        public StudentsController(IStudentsRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("reset")]
        public async Task Reset()
        {
            await this.repository.Clear();
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            var students = await this.repository.GetStudents();

            return students;
        }

        [HttpPost]
        public async Task<Student> AddStudent(Student student)
        {
            return await this.repository.AddStudent(student);
        }

        [HttpDelete("{id}")]
        public async Task RemoveStudent(Guid id)
        {
            await this.repository.RemoveStudent(id);
        }
    }
}
