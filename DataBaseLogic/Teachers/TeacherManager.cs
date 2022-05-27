namespace DataBaseLogic.Teachers
{
    public class TeacherManager : ITeacherManager
    {
        private readonly UniversityContext _context;
        public TeacherManager(UniversityContext context)
        {
            _context = context;
        }
        public async Task Create(string name, string lastname, string email, string phonenumber, string hoursstring)
        {
            var hours = System.Convert.ToInt32(hoursstring);
            var teacher = new Teacher { Name = name, LastName = lastname, Email = email, PhoneNumber = phonenumber, Hours = hours};
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

        public async Task<IList<Teacher>> GetAll() => await _context.Teachers.ToListAsync();
    }
}
