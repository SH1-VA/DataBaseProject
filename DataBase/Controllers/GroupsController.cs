namespace DataBase.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IGroupManager _manager;
        public GroupsController(IGroupManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Main()
        {
            var groups = await _manager.GetAll();

            return View(groups);
        }

        [HttpGet]
        [Route("groups")]
        public Task<IList<Group>> GetAll() => _manager.GetAll();

        [HttpPut]
        [Route("groups")]
        public Task Create([FromBody] CreateGroupRequest request) => _manager.Create(request.Name, request.NumberOfStudents, request.Orientation);

        [HttpDelete]
        [Route("groups/{id:int}")]
        public Task Delete(int id) => _manager.Delete(id);
    }
}
