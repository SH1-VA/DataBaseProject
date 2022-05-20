namespace DataBaseLogic.Students
{
    public interface IStudentManager
    {
        Task<IList<Student>> GetAll();
        Task Create(string name, string lastname, string email, string phonenumber, bool subgroup, int number/*, int groupid, Group group*/);
        Task Delete(int id);
    }
}
