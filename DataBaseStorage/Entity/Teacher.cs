namespace DataBase.Storage.Entity
{
    public class Teacher: Person
    {
        //public Enum Classes { get; set; }                   //Вид занятий, который ведёт. (Лекции - 1, Семинары - 2, Лабораторные - 3)
        public int Hours { get; set; }                      //Кол-во рабочих часов за курс

        //public int DepartmentId { get; set; }
        //[ForeignKey(nameof(DepartmentId))]
        //public virtual Department Department { get; set; } //Кафедра преподавателя
        //public Teacher(int id, string name, string lastName, string email, string phoneNumber, Enum classes, int hours): base(id, name, lastName, email, phoneNumber)
        //{
        //    Classes = classes;
        //    Hours = hours;
        //}
    }
}
