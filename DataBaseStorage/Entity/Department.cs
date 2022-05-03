namespace DataBase.Storage.Entity
{
    public class Department
    {
        public Guid Id { get; set; }                        //Id для работы
        public string Name { get; set; }                    //Название кафедры
        public string Email { get; set; }                   //Электронная почта кафедры
        public string PhoneNumber { get; set; }             //Телефонный номер кафедры
        public int AudienceNumber { get; set; }             //Номер аудитории
        public Department(Guid id, string name, string email, string phoneNumber, int audienceNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            AudienceNumber = audienceNumber;
        }
    }
}
