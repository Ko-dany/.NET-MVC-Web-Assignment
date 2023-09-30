using Assignment_1_Dahyun_Ko.Models;
using Microsoft.AspNetCore.Mvc;

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
            var students = _studentContext.Students.OrderBy(s=>s.StudentId).ToList();
            return View(students);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
