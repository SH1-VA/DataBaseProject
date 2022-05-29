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
            ViewBag.Specialitys = _manager.SpecialitysNameList();
            return View(groups);
        }

        [HttpGet]
        [Route("groups")]
        public Task<IList<Group>> GetAll() => _manager.GetAll();

        [HttpGet]
        //[Route("students")]
        //public Task Create([FromBody] CreateStudentRequest request) => _manager.Create(request.Name, request.LastName, request.Email, request.PhoneNumber, request.SubGroup/*, request.Number, request.GroupId, request.Group*/);
        public IActionResult Create(CreateGroupRequest model)
        {
            int SpecialityId = AddSpecialityId(model.SpecialityIdString);
            _manager.Create(model.Name, model.Orientation, model.NumberOfStudents, SpecialityId);
            return RedirectToAction(nameof(Main));
        }

        public int AddSpecialityId(string SpecialityIdString)
        {
            int SpecialityId = _manager.SearchSpeciality(SpecialityIdString);
            return SpecialityId;
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
        public IActionResult Edit(string idstring, string name, string orientation, int numberofstudents, string specialityidstring)
        {
            _manager.Edit(idstring, name, orientation, numberofstudents, specialityidstring);
            return RedirectToAction(nameof(Main));
        }
    }
}
