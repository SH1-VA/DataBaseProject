namespace DataBase.Storage.Entity
{
    public class Person
    {
        [Key]
        public int Id { get; set; }                        //Id для работы
        public string Name { get; set; }                    //Имя
        public string LastName { get; set; }                //Фамилия
        //public string Email { get; set; }                   //Электронная почта
        //public string PhoneNumber { get; set; }             //Телефонный номер
        //public Person(int id, string name, string lastName, string email, string phoneNumber)
        //{
        //    Id = id;
        //    Name = name;
        //    LastName = lastName;
        //    Email = email;
        //    PhoneNumber = phoneNumber;
        //}
    }
}
