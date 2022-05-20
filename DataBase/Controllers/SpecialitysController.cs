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

        [HttpPut]
        [Route("specialitys")]
        public Task Create([FromBody] CreateSpecialityRequest request) => _manager.Create(request.Name, request.Code, request.NumberOfStudents);

        [HttpDelete]
        [Route("specialitys/{id:int}")]
        public Task Delete(int id) => _manager.Delete(id);
    }
}
