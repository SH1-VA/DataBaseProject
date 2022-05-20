﻿namespace DataBaseLogic.Departments
{
    public class DepartmentManager
    {
        private readonly UniversityContext _context;
        public DepartmentManager(UniversityContext context)
        {
            _context = context;
        }
        public async Task Create(string name, string email, string phonenumber, int audiencenumber)
        {
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

        public async Task<IList<Department>> GetAll() => await _context.Departments.ToListAsync();
    }
}