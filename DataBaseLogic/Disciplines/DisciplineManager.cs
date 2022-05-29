namespace DataBaseLogic.Disciplines
{
    public class DisciplineManager: IDisciplineManager
    {
        private readonly UniversityContext _context;
        public DisciplineManager(UniversityContext context)
        {
            _context = context;
        }
        public async Task Create(string name, int hours, int deoartmentId)
        {
            var discipline = new Discipline { Name = name, Hours = hours, DepartmentId = deoartmentId};
            _context.Disciplines.Add(discipline);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var discipline = _context.Disciplines.FirstOrDefault(d => d.Id == id);
            if (discipline != null)
            {
                _context.Disciplines.Remove(discipline);
                await _context.SaveChangesAsync();
            }
        }

        public int SearchDepartment(string DepartmentIdString)
        {
            var Department = _context.Departments.FirstOrDefault(d => d.Name == DepartmentIdString);
            int DepartmentId = Department.Id;
            return DepartmentId;
        }

        public List<String> DepartmentNameList()
        {
            List<String> DepartmentString = new List<String>();
            var Departments = _context.Departments.ToList();

            foreach (var Department in Departments)
            {
                DepartmentString.Add(Department.Name);
            }
            return DepartmentString;
        }
        //string idstring, string name, string hours
        public async Task Edit(string idstring, string name, string hours, string departmentidstring)
        {
            int id = System.Convert.ToInt32(idstring);

            var discipline = _context.Disciplines.FirstOrDefault(d => d.Id == id);
            discipline.Name = name;
            discipline.Hours = System.Convert.ToInt32(hours);
            discipline.DepartmentId = SearchDepartment(departmentidstring);
            _context.Disciplines.Update(discipline);

            await _context.SaveChangesAsync();
        }
        public async Task<IList<Discipline>> GetAll() => await _context.Disciplines.ToListAsync();
    }
}
