namespace DataBase.Storage.Entity
{
    public class Person
    {
        [Key]
        public int Id { get; set; }                        //Id для работы
        public string Name { get; set; }                    //Имя
        public string LastName { get; set; }                //Фамилия
        public string MiddleName { get; set; }              //Отчество
        public string Email { get; set; }                   //Электронная почта
        public string PhoneNumber { get; set; }             //Телефонный номер
    }
}
