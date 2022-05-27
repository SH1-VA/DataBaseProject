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
            var teachers = await _manager.GetAll();

            return View(teachers);
        }

        [HttpGet]
        [Route("teachers")]
        public Task<IList<Teacher>> GetAll() => _manager.GetAll();

        [HttpGet]
        public IActionResult Create(CreateTeacherRequest model)
        {
            _manager.Create(model.Name, model.LastName, model.Email, model.PhoneNumber, model.Hours);
            return RedirectToAction(nameof(Main));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _manager.Delete(id);
            return RedirectToAction(nameof(Main));
        }
    }
}
