namespace DataBaseLogic.Groups
{
    public class GroupManager : IGroupManager
    {
        private readonly UniversityContext _context;
        public GroupManager(UniversityContext context)
        {
            _context = context;
        }
        public async Task Create(string name)
        {
            var group = new Group { Name = name };
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var group = _context.Groups.FirstOrDefault(g => g.Id == id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<Group>> GetAll() => await _context.Groups.ToListAsync();
    }
}
