using Microsoft.AspNetCore.Mvc;

namespace DataBase.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentManager _manager;
        public DepartmentsController(IDepartmentManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Main()
        {
            var departments = await _manager.GetAll();

            return View(departments);
        }

        [HttpGet]
        [Route("departments")]
        public Task<IList<Department>> GetAll() => _manager.GetAll();

        [HttpGet]
        //[Route("departments")]
        //public Task Create([FromBody] CreateDepartmentRequest request) => _manager.Create(request.Name, request.Email, request.PhoneNumber, request.AudienceNumber);
        public IActionResult Create(string name, string email, string phonenumber, string audiencenumberString)
        {
            _manager.Create(name, email, phonenumber, audiencenumberString);
            return RedirectToAction(nameof(Main));
        }

        [HttpPost]
        //[Route("departments/{id:int}")]
        //public Task Delete(int id) => _manager.Delete(id);
        public IActionResult Delete(int id)
        {
            _manager.Delete(id);
            return RedirectToAction(nameof(Main));
        }

        [HttpPost]
        // [Route("students/{id:int}")]
        public IActionResult Edit(string idstring, string name, string email, string phonenumber, string audiencenumberString)
        {
            _manager.Edit(idstring, name, email, phonenumber, audiencenumberString);
            return RedirectToAction(nameof(Main));
        }
    }
}
