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
        public ActionResult GroupNameList()
        {
            //var bag = _manager.GroupNameList();
            //ViewBag.Groups = new List<string>();
            ViewBag.bag = _manager.GroupNameList();
            return View();
        }

        [HttpGet]
        //[Route("students")]
        //public Task Create([FromBody] CreateStudentRequest request) => _manager.Create(request.Name, request.LastName, request.Email, request.PhoneNumber, request.SubGroup/*, request.Number, request.GroupId, request.Group*/);
        public IActionResult Create(CreateStudentRequest model)
        {
            _manager.Create(model.Name, model.LastName, model.Email, model.PhoneNumber, model.GroupIdString, model.SubGroup);
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
    }
}