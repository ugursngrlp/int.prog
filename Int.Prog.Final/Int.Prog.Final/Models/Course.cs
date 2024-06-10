namespace Int.Prog.Final.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Credit { get; set; } // Kredi değeri
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
