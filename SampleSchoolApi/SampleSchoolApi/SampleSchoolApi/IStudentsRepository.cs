using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleSchoolApi
{
    public interface IStudentsRepository
    {
        Task<Student> AddStudent(Student student);
        Task<Student> GetStudentById(Guid id);
        Task<IEnumerable<Student>> GetStudents();
        Task RemoveStudent(Guid id);
        Task Clear();
    }
}