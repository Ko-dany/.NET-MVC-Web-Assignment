using Assignment_1_Dahyun_Ko.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment_1_Dahyun_Ko.Controllers
{
    public class StudentController : Controller
    {
        private StudentContext? _studentContext { get; set; }

        public StudentController(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public IActionResult List()
        {
            var students = _studentContext.Students
                .Include(s=>s.Program)
                .OrderBy(s=>s.StudentId)
                .ToList();
            // Get Program Class data using 'Include' method so that we can access '@student.Program.Name'

            return View(students);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Programs = _studentContext.Programs.ToList();
            return View("Edit", new Student());
        }


        [HttpGet] 
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Programs = _studentContext.Programs.ToList();
            var studentInfo = _studentContext.Students.Find(id);
            return View(studentInfo);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                if (student.StudentId == 0) _studentContext.Students.Add(student);
                else _studentContext.Students.Update(student);

                _studentContext.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = (student.StudentId == 0) ? "Add" : "Edit";
                ViewBag.Programs = _studentContext.Programs.ToList();
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var studentInfo = _studentContext.Students.Find(id);
            _studentContext.SaveChanges();
            return View(studentInfo);
        }
    }
}
