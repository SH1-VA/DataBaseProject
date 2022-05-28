namespace DataBaseLogic.Students
{
    public interface IStudentManager
    {
        Task<IList<Student>> GetAll();
        Task Create(string name, string lastname, string email, string phonenumber, string groupidstring, bool subgroup/*, int number, int groupid, Group group*/);
        Task Delete(int id);
        List<Student> Search(string Lastname);
        List<String> GroupNameList();
    }
}
