namespace DataBaseLogic.Specialitys
{
    public class SpecialityManager: ISpecialityManager
    {
        private readonly UniversityContext _context;
        public SpecialityManager(UniversityContext context)
        {
            _context = context;
        }
        public async Task Create(string name, string code, int number)
        {
            var speciality = new Speciality { Name = name, Code = code, NumberOfStudents = number};
            _context.Specialities.Add(speciality);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var speciality = _context.Specialities.FirstOrDefault(s => s.Id == id);
            if (speciality != null)
            {
                _context.Specialities.Remove(speciality);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<Speciality>> GetAll() => await _context.Specialities.ToListAsync();
    }
}
