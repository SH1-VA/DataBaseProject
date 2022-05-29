using Microsoft.AspNetCore.Mvc;

namespace DataBase.Controllers
{
    public class DisciplinesController : Controller
    {
        private readonly IDisciplineManager _manager;
        public DisciplinesController(IDisciplineManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Main()
        {
            ViewBag.Departments = _manager.DepartmentNameList();
            var disciplines = await _manager.GetAll();

            return View(disciplines);
        }

        [HttpGet]
        [Route("disciplines")]
        public Task<IList<Discipline>> GetAll() => _manager.GetAll();

        public int AddDepartmentId(string DepartmentIdString)
        {
            int DepartmentId = _manager.SearchDepartment(DepartmentIdString);
            return DepartmentId;
        }

        [HttpGet]
        //[Route("students")]
        //public Task Create([FromBody] CreateStudentRequest request) => _manager.Create(request.Name, request.LastName, request.Email, request.PhoneNumber, request.SubGroup/*, request.Number, request.GroupId, request.Group*/);
        public IActionResult Create(CreateDisciplineRequest model)
        {
            int DepartmentId = AddDepartmentId(model.DepartmentIdString);
            _manager.Create(model.Name, model.Hours, DepartmentId);
            return RedirectToAction(nameof(Main));
        }

        [HttpPost]
        // [Route("students/{id:int}")]
        public IActionResult Delete(int id)
        {
            _manager.Delete(id);
            return RedirectToAction(nameof(Main));
        }

        [HttpPost]
        // [Route("students/{id:int}")]
        public IActionResult Edit(string idstring, string name, string hours, string departmentidstring)
        {
            _manager.Edit(idstring, name, hours, departmentidstring);
            return RedirectToAction(nameof(Main));
        }
    }
}
