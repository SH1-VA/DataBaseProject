namespace DataBaseLogic.Teachers
{
    public class TeacherManager : ITeacherManager
    {
        private readonly UniversityContext _context;
        public TeacherManager(UniversityContext context)
        {
            _context = context;
        }

        public async Task Create(string lastname, string name, string Middlename, string email, string phonenumber, string hoursstring, int DepartmentId)
        {
            var hours = System.Convert.ToInt32(hoursstring);
            var teacher = new Teacher { LastName = lastname, Name = name, MiddleName = Middlename, Email = email, PhoneNumber = phonenumber, Hours = hours, DepartmentId = DepartmentId};
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
            }
        }

        public int SearchDepartment(string DepartmentIdString)
        {
            var Department = _context.Departments.FirstOrDefault(d => d.Name == DepartmentIdString);
            int DepartmentId = Department.Id;
            return DepartmentId;
        }

        public List<Teacher> Search(string LastName)
        {
            var sameTeacher = _context.Teachers;

            List<Teacher> teachers = new List<Teacher>();
            foreach (var oneTeacher in sameTeacher)
            {
                if (oneTeacher.LastName == LastName)
                {
                    teachers.Add(oneTeacher);
                }
            }
            return teachers;
        }

        public List<Teacher> SortByLastName()
        {
            var sameTeacher = _context.Teachers;

            List<Teacher> students = new List<Teacher>();
            foreach (var oneTeacher in sameTeacher.ToList())
            {
                students.Add(oneTeacher);
            }
            students.Sort((x, y) => String.Compare(x.LastName, y.LastName));
            return students;
        }

        public List<Teacher> SortById()
        {
            var sameTeacher = _context.Teachers;

            List<Teacher> teachers = new List<Teacher>();
            foreach (var oneTeacher in sameTeacher.ToList())
            {
                teachers.Add(oneTeacher);
            }

            var sortedTeachers = Teacher.SortById(teachers);

            sortedTeachers.Reverse();

            return sortedTeachers;
        }

        public async Task Edit(string idstring, string lastname, string name, string Middlename, string email, string phonenumber, int hours, string departmentidstring /*, int number, int groupid, Group group*/)
        {
            //int groupid = System.Convert.ToInt32(groupidstring);
            int id = System.Convert.ToInt32(idstring);

            var Teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            Teacher.LastName = lastname;
            Teacher.Name = name;
            Teacher.MiddleName = Middlename;
            Teacher.Email = email;
            Teacher.PhoneNumber = phonenumber;
            Teacher.DepartmentId = SearchDepartment(departmentidstring);
            Teacher.Hours = System.Convert.ToInt32(hours);
            _context.Teachers.Update(Teacher);

            await _context.SaveChangesAsync();
        }

        public List<String> DepartmentNameList()
        {
            List<String> DepartmentsString = new List<String>();
            var Departments = _context.Departments.ToList();

            foreach (var Department in Departments)
            {
                DepartmentsString.Add(Department.Name);
            }
            return DepartmentsString;
        }

        public async Task<IList<Teacher>> GetAll() => await _context.Teachers.ToListAsync();
    }
}
