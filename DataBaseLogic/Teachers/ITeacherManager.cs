namespace DataBaseLogic.Teachers
{
    public interface ITeacherManager
    {
        Task<IList<Teacher>> GetAll();
        Task Create(string name, string lastname, string email, string phonenumber, int hours);
        Task Delete(int id);
    }
}
