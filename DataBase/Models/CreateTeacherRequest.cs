namespace DataBase.Models
{
    public class CreateTeacherRequest
    {
        public string Name { get; set; }
        public string MiddleName { get; set; }              //Отчество
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Hours    { get; set; }
        public string DepartmentIdString { get; set; }
    }
}
