using Int.Prog.Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Int.Prog.Final.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public IActionResult Index()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var students = ctx.Students.ToList();
                return View(students);
            }
        }

        // GET: Student/Create
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStudent(Student student)
        {
            if (student != null)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Students.Add(student);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Student/Edit/5
        public IActionResult EditStudent(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var student = ctx.Students.Find(id);
                return View(student);
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditStudent(Student student)
        {
            if (student != null)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Entry(student).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Student/Delete/5
        public IActionResult DeleteStudent(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var student = ctx.Students.Find(id);
                ctx.Students.Remove(student);
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Student/AssignCourses/5
        public IActionResult AssignCourses(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var student = ctx.Students
                    .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                    .FirstOrDefault(s => s.StudentId == id);

                if (student == null)
                {
                    return NotFound();
                }

                ViewBag.Courses = ctx.Courses.ToList();
                return View(student);
            }
        }

        // POST: Student/AssignCourses/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AssignCourses(int id, int[] selectedCourses)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var student = ctx.Students
                    .Include(s => s.StudentCourses)
                    .FirstOrDefault(s => s.StudentId == id);

                if (student == null)
                {
                    return NotFound();
                }

                student.StudentCourses.Clear();
                if (selectedCourses != null)
                {
                    foreach (var courseId in selectedCourses)
                    {
                        student.StudentCourses.Add(new StudentCourse { StudentId = id, CourseId = courseId });
                    }
                }

                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
