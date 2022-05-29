namespace DataBaseLogic.Departments
{
    public class DepartmentManager: IDepartmentManager
    {
        private readonly UniversityContext _context;
        public DepartmentManager(UniversityContext context)
        {
            _context = context;
        }
        public async Task Create(string name, string email, string phonenumber, string audiencenumberString)
        {
            int audiencenumber = System.Convert.ToInt32(audiencenumberString);
            var department = new Department { Name = name, Email = email, PhoneNumber = phonenumber, AudienceNumber = audiencenumber};
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Edit(string idstring, string name, string email, string phonenumber, string audiencenumberString /*, int number, int groupid, Group group*/)
        {
            //int groupid = System.Convert.ToInt32(groupidstring);
            int id = System.Convert.ToInt32(idstring);

            var department = _context.Departments.FirstOrDefault(d => d.Id == id);
            department.Name = name;
            department.Email = email;
            department.PhoneNumber = phonenumber;
            department.AudienceNumber = System.Convert.ToInt32(audiencenumberString);
            _context.Departments.Update(department);

            await _context.SaveChangesAsync();
        }

        public async Task<IList<Department>> GetAll() => await _context.Departments.ToListAsync();
    }
}
