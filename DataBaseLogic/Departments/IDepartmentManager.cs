namespace DataBaseLogic.Departments
{
    public interface IDepartmentManager
    {
        Task<IList<Department>> GetAll();
        Task Create(string name, string email, string phonenumber, int audiencenumber);
        Task Delete(int id);
    }
}
