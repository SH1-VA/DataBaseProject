namespace DataBaseLogic.Students
{
    public interface IStudentManager
    {
        Task<IList<Student>> GetAll();
        Task Create(string lastname, string name, string Middlename, string email, string phonenumber, int groupid, bool subgroup);
        Task Delete(int id);
        List<Student> Search(string Lastname);
        List<String> GroupNameList();
        int SearchGroup(string GroupIdString);
        Task Edit(string idstring, string lastname, string name, string Middlename, string email, string phonenumber, string groupidstring, bool subgroup);
        List<Student> SortByLastName();
        List<Student> SortById();
    }
}
