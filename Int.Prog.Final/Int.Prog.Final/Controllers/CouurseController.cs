using Microsoft.AspNetCore.Mvc;
using Int.Prog.Final.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Int.Prog.Final.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public IActionResult Index()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var courses = ctx.Courses.ToList();
                return View(courses);
            }
        }

        // GET: Course/Create
        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCourse(Course course)
        {
            if (course != null)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Courses.Add(course);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Course/Edit/5
        [HttpGet]
        public IActionResult EditCourse(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var course = ctx.Courses.Find(id);
                return View(course);
            }
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCourse(Course course)
        {
            if (course != null)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Entry(course).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Course/Delete/5
        public IActionResult DeleteCourse(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var course = ctx.Courses.Find(id);
                if (course != null)
                {
                    ctx.Courses.Remove(course);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
