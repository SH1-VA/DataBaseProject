namespace DataBaseLogic.Specialitys
{
    public interface ISpecialityManager
    {
        Task<IList<Speciality>> GetAll();
        Task Create(string name, string code, int number);
        Task Delete(int id);
    }
}
