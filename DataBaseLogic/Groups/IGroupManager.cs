namespace DataBaseLogic.Groups
{
    public interface IGroupManager
    {
        Task<IList<Group>> GetAll();
        Task Create(string name);
        Task Delete(int id);
    }
}
