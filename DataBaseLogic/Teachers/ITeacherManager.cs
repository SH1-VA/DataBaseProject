namespace DataBaseLogic.Teachers
{
    public interface ITeacherManager
    {
        Task<IList<Teacher>> GetAll();
        Task Create(string name, string lastname, string email, string phonenumber, string hours);
        Task Delete(int id);
    }
}
