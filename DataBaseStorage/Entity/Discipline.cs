namespace DataBase.Storage.Entity
{
    public class Discipline
    {
        public Guid Id { get; set; }                    //Id для работы
        public string Name { get; set; }                //Название дисциплины
        public Department Department { get; set; }      //Кафедра
        public List<Teacher> Teachers { get; set; }     //Список преподавателей
        public int Hours { get; set; }                  //Кол-во учебных часов за курс
        public Discipline(Guid id, string name, Department department, List<Teacher> teachers, int hours)
        {
            Id = id;
            Name = name;
            Department = department;
            Teachers = teachers;
            Hours = hours;
        }
    }
}
