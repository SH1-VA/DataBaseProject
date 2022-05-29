namespace DataBaseLogic.Disciplines
{
    public interface IDisciplineManager
    {
        Task<IList<Discipline>> GetAll();
        Task Create(string name, int hours, int deoartmentId);
        Task Delete(int id);
        int SearchDepartment(string DepartmentIdString);
        List<String> DepartmentNameList();
        Task Edit(string idstring, string name, string hours, string departmentidstring);
    }
}
