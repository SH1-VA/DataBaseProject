namespace DataBaseLogic.Departments
{
    public interface IDepartmentManager
    {
        Task<IList<Department>> GetAll();
        Task Create(string name, string email, string phonenumber, string audiencenumberString);
        Task Delete(int id);
    }
}
