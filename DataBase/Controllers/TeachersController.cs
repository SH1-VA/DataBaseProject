using Microsoft.AspNetCore.Mvc;

namespace DataBase.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherManager _manager;
        public TeachersController(ITeacherManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Main()
        {
            ViewBag.Departments = _manager.DepartmentNameList();
            var teachers = await _manager.GetAll();

            return View(teachers);
        }

        [HttpGet]
        [Route("teachers")]
        public Task<IList<Teacher>> GetAll() => _manager.GetAll();
        public int AddDepartmentId(string DepartmentIdString)
        {
            int DepartmentId = _manager.SearchDepartment(DepartmentIdString);
            return DepartmentId;
        }

        [HttpGet]
        public async Task<IActionResult> ViewSearch()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string LastName)
        {
            var teacher1 = _manager.Search(LastName);
            return View(teacher1);
        }

        [HttpPost]
        public async Task<IActionResult> SortByLastName()
        {
            var teachers1 = _manager.SortByLastName();
            return View(teachers1);
        }

        [HttpPost]
        public async Task<IActionResult> SortById()
        {
            var teachers1 = _manager.SortById();
            return View(teachers1);
        }

        [HttpGet]
        public IActionResult Create(CreateTeacherRequest model)
        {
            int DepartmentId = AddDepartmentId(model.DepartmentIdString);
            _manager.Create(model.Name, model.LastName, model.Email, model.PhoneNumber, model.Hours, DepartmentId);
            return RedirectToAction(nameof(Main));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _manager.Delete(id);
            return RedirectToAction(nameof(Main));
        }

        [HttpPost]
        //[Route("students/{id:int}")]
        public IActionResult Edit(string idstring, string name, string lastname, string email, string phonenumber, int hours, string departmentidstring)
        {
            _manager.Edit(idstring, name, lastname, email, phonenumber, hours, departmentidstring);
            return RedirectToAction(nameof(Main));
        }
    }
}
