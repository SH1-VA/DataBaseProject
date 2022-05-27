namespace DataBase.Models
{
    public class CreateStudentRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool SubGroup { get; set; }
        public string GroupIdString { get; set; }
        //public int Number { get; set; }
        //public Group Group { get; set; }
        //string name, string lastname, string email, string phonenumber, bool subgroup, int number, int groupid, Group group
    }
}
