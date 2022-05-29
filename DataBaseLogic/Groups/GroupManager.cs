namespace DataBaseLogic.Groups
{
    public class GroupManager : IGroupManager
    {
        private readonly UniversityContext _context;
        public GroupManager(UniversityContext context)
        {
            _context = context;
        }
        public async Task Create(string name, string orientation, int numberofstudents, int specialityid)
        {
            var group = new Group { Name = name, Orientation = orientation, NumberOfStudents = numberofstudents, SpecialityId = specialityid};
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

        public int SearchSpeciality(string SpecialityIdString)
        {
            var Speciality = _context.Specialities.FirstOrDefault(s => s.Name == SpecialityIdString);
            int SpecialityId = Speciality.Id;

            return SpecialityId;
        }

        public List<String> SpecialitysNameList()
        {
            List<String> SpecialitysString = new List<String>();
            var Specialitys = _context.Specialities.ToList();

            foreach (var Speciality in Specialitys)
            {
                SpecialitysString.Add(Speciality.Name);
            }
            return SpecialitysString;
        }

        public async Task Edit(string idstring, string name, string orientation, int numberofstudents, string specialityidstring)
        {
            int id = System.Convert.ToInt32(idstring);

            var Group = _context.Groups.FirstOrDefault(g => g.Id == id);
            Group.Name = name;
            Group.Orientation = orientation;
            Group.NumberOfStudents = numberofstudents;
            Group.SpecialityId = SearchSpeciality(specialityidstring);
            _context.Groups.Update(Group);

            await _context.SaveChangesAsync();
        }
        //string idstring, string name, string orientation, int numberofstudents, string specialityidstring

        public async Task<IList<Group>> GetAll() => await _context.Groups.ToListAsync();
    }
}
