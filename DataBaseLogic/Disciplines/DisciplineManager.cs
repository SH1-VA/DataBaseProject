namespace DataBaseLogic.Disciplines
{
    public class DisciplineManager: IDisciplineManager
    {
        private readonly UniversityContext _context;
        public DisciplineManager(UniversityContext context)
        {
            _context = context;
        }
        public async Task Create(string name, int hours)
        {
            var discipline = new Discipline { Name = name, Hours = hours};
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

        public async Task<IList<Discipline>> GetAll() => await _context.Disciplines.ToListAsync();
    }
}
