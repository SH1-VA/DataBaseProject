namespace DataBaseLogic.Groups
{
    public interface IGroupManager
    {
        Task<IList<Group>> GetAll();
        Task Create(string name, string orientation, int numberofstudents, int specialityid);
        Task Delete(int id);
        int SearchSpeciality(string SpecialityIdString);
        List<String> SpecialitysNameList();
        Task Edit(string idstring, string name, string orientation, int numberofstudents, string specialityidstring);
    }
}
