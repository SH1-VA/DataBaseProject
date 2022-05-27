namespace DataBaseLogic.Students
{
    public class StudentManager: IStudentManager
    {
        private readonly UniversityContext _context;
        public StudentManager(UniversityContext context)
        {
            _context = context;
        }
        public async Task Create(string name, string lastname, string email, string phonenumber, bool subgroup, string groupidstring/*, int number, int groupid, Group group*/)
        {
            int groupid = System.Convert.ToInt32(groupidstring);
            var student = new Student { Name = name, LastName = lastname, Email = email, PhoneNumber = phonenumber, Subgroup = subgroup, GroupId = groupid/*, Number = number, GroupId = groupid*/};
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public List<Student> Search(string LastName)
        {
            var sameStudent = _context.Students;

            List<Student> students = new List<Student>();
            foreach (var oneStudent in sameStudent)
            {
                if (oneStudent.LastName == LastName)
                {
                    students.Add(oneStudent);
                }
            }
            return students;
        }

        public async Task<IList<Student>> GetAll() => await _context.Students.ToListAsync();
    }
}
