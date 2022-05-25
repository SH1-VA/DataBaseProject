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

            return View(students);
        }

        [HttpGet]
        [Route("students")]
        public Task<IList<Student>> GetAll() => _manager.GetAll();

        [HttpGet]
        //[Route("students")]
        //public Task Create([FromBody] CreateStudentRequest request) => _manager.Create(request.Name, request.LastName, request.Email, request.PhoneNumber, request.SubGroup/*, request.Number, request.GroupId, request.Group*/);
        public IActionResult Create(string name, string lastname, string email, string phonenumber, bool subgroup, string groupidstring)
        {
            _manager.Create(name, lastname, email, phonenumber, subgroup, groupidstring);
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