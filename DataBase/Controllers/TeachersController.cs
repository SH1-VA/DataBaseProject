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

        [HttpPut]
        [Route("teachers")]
        public Task Create([FromBody] CreateTeacherRequest request) => _manager.Create(request.Name, request.LastName, request.Email, request.PhoneNumber, request.Hours);

        [HttpDelete]
        [Route("teachers/{id:int}")]
        public Task Delete(int id) => _manager.Delete(id);
    }
}
