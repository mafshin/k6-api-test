using System;

namespace SampleSchoolApi
{
    public class Student
    {
        public Guid Id { get; internal set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}