using Microsoft.AspNetCore.Mvc;

namespace DataBase.Controllers
{
    public class SpecialitysController : Controller
    {
        private readonly ISpecialityManager _manager;
        public SpecialitysController(ISpecialityManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Main()
        {
            var specialitys = await _manager.GetAll();

            return View(specialitys);
        }

        [HttpGet]
        [Route("specialitys")]
        public Task<IList<Speciality>> GetAll() => _manager.GetAll();

        [HttpGet]
        //[Route("students")]
        //public Task Create([FromBody] CreateStudentRequest request) => _manager.Create(request.Name, request.LastName, request.Email, request.PhoneNumber, request.SubGroup/*, request.Number, request.GroupId, request.Group*/);
        public IActionResult Create(CreateSpecialityRequest model)
        {
            _manager.Create(model.Name, model.Code, model.NumberOfStudents);
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
        public IActionResult Edit(string idstring, string code, string name)
        {
            _manager.Edit(idstring, code, name);
            return RedirectToAction(nameof(Main));
        }
    }
}
