using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLogic.Students
{
    public class StudentManager : IStudentManager
    {
        private readonly UniversityContext _context;
        public StudentManager(UniversityContext context)
        {
            _context = context;
        }
        public async Task Create(string name, string lastname, string email, string phonenumber, bool subgroup, int number/*, int groupid, Group group*/)
        {
            var student = new Student { Name = name, LastName = lastname, Email = email, PhoneNumber = phonenumber, Subgroup = subgroup, Number = number/*, GroupId = groupid, Group = group */};
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var student = _context.Groups.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _context.Groups.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<Student>> GetAll() => await _context.Students.ToListAsync();
    }
}
