namespace DataBaseLogic.Groups
{
    public interface IGroupManager
    {
        Task<IList<Group>> GetAll();
        Task Create(string name, int number, string Orientation);
        Task Delete(int id);
    }
}
