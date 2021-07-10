using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleSchoolApi
{
    public class StudentsRepository : IStudentsRepository
    {
        List<Student> students = new List<Student>();

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return students;
        }

        public async Task<Student> GetStudentById(Guid id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Student> AddStudent(Student student)
        {
            student.Id = Guid.NewGuid();
            students.Add(student);

            return student;
        }

        public async Task RemoveStudent(Guid id)
        {
            students.Remove(students.First(x => x.Id == id));
        }

        public async Task Clear()
        {
            students.Clear();
        }
    }
}
