using DataBaseLogic.Students;

namespace DataBase.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentManager _manager;

        public StudentsController(IStudentManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Main()
        {
                var students = await _manager.GetAll();
            ViewBag.bag = _manager.GroupNameList();
            return View(students);
        }

        [HttpGet]
        [Route("students")]
        public Task<IList<Student>> GetAll() => _manager.GetAll();

        [HttpGet]
        public async Task<IActionResult> ViewSearch()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string LastName)
        {
            var students1 = _manager.Search(LastName);
            return View(students1);
        }

        [HttpPost]
        public async Task<IActionResult> SortByLastName()
        {
            var students1 = _manager.SortByLastName();
            return View(students1);
        }

        public int AddGroupId(string GroupIdString)
        {
            int GroupId = _manager.SearchGroup(GroupIdString);
            return GroupId;
        }

        [HttpGet]
        //[Route("students")]
        //public Task Create([FromBody] CreateStudentRequest request) => _manager.Create(request.Name, request.LastName, request.Email, request.PhoneNumber, request.SubGroup/*, request.Number, request.GroupId, request.Group*/);
        public IActionResult Create(CreateStudentRequest model)
        {
            int GroupId = AddGroupId(model.GroupIdString);
            _manager.Create(model.Name, model.LastName, model.Email, model.PhoneNumber, GroupId, model.SubGroup);
            return RedirectToAction(nameof(Main));
        }
        //string name, string lastname, string email, string phonenumber, bool subgroup, int number, int groupid, Group group

        [HttpPost]
        // [Route("students/{id:int}")]
        public IActionResult Delete(int id)
        {
            _manager.Delete(id);
            return RedirectToAction(nameof(Main));
        }

        [HttpPost]
        // [Route("students/{id:int}")]
        public IActionResult Edit(string idstring, string name, string lastname, string email, string phonenumber, string groupidstring, bool subgroup)
        {
            _manager.Edit(idstring, name, lastname, email, phonenumber, groupidstring, subgroup);
            return RedirectToAction(nameof(Main));
        }
    }
}