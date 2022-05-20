namespace DataBaseLogic.Disciplines
{
    public interface IDisciplineManager
    {
        Task<IList<Discipline>> GetAll();
        Task Create(string name, int hours);
        Task Delete(int id);
    }
}
