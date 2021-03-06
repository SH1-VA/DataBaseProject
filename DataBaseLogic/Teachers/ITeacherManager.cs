namespace DataBaseLogic.Teachers
{
    public interface ITeacherManager
    {
        Task<IList<Teacher>> GetAll();
        Task Create(string lastname, string name, string Middlename, string email, string phonenumber, string hours, int departmentidstring);
        Task Delete(int id);
        public int SearchDepartment(string DepartmentIdString);
        Task Edit(string idstring,string lastname, string name, string Middlename, string email, string phonenumber, int hours, string departmentidstring);
        List<Teacher> Search(string LastName);
        List<Teacher> SortById();
        List<Teacher> SortByLastName();
        List<String> DepartmentNameList();
    }
}
