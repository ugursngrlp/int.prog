﻿namespace Int.Prog.Final.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
