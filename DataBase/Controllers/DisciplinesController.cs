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
            var disciplines = await _manager.GetAll();

            return View(disciplines);
        }

        [HttpGet]
        [Route("disciplines")]
        public Task<IList<Discipline>> GetAll() => _manager.GetAll();

        [HttpPut]
        [Route("disciplines")]
        public Task Create([FromBody] CreateDisciplineRequest request) => _manager.Create(request.Name, request.Hours);

        [HttpDelete]
        [Route("disciplines/{id:int}")]
        public Task Delete(int id) => _manager.Delete(id);
    }
}
