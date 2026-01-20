//using Microsoft.AspNetCore.Mvc;

//namespace StudentRegistration.Web.Controllers
//{
//    public class StudentController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Application.Services;
using StudentRegistration.Domain.Entities;

namespace StudentRegistration.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _service;

        public StudentController(StudentService service)
        {
            _service = service;
        }

        // LIST students
        public IActionResult Index()
        {
            var students = _service.GetStudents();
            return View(students);
        }

        // SHOW create form
        public IActionResult Create()
        {
            return View();
        }

        // SAVE student
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            _service.AddStudent(student);
            TempData["SuccessMessage"] = "Student added successfully!";
            return RedirectToAction(nameof(Index));

        }

        // SHOW edit form
        public IActionResult Edit(int id)
        {
            var student = _service.GetStudent(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // UPDATE student
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            _service.UpdateStudent(student);
            TempData["SuccessMessage"] = "Student updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        // SOFT DELETE
        public IActionResult Delete(int id)
        {
            _service.DeleteStudent(id);
            TempData["SuccessMessage"] = "Student deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
