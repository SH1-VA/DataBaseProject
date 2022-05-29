namespace DataBase.Storage.Entity
{
    public class Teacher: Person
    {
        //public Enum Classes { get; set; }                   //Вид занятий, который ведёт. (Лекции - 1, Семинары - 2, Лабораторные - 3)
        public int Hours { get; set; }                      //Кол-во рабочих часов за курс
        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; } //Кафедра преподавателя
        //public Teacher(int id, string name, string lastName, string email, string phoneNumber, Enum classes, int hours): base(id, name, lastName, email, phoneNumber)
        //{
        //    Classes = classes;
        //    Hours = hours;
        //}

        public static List<Teacher> SortById(List<Teacher> teachers)
        {
            int min = 0;
            for (int i = 0; i < teachers.Count; i++)
            {
                for (int j = i; j < teachers.Count; j++)
                {
                    if (teachers[j].Id < teachers[min].Id)
                    {
                        min = j;
                    }
                    var tempStudent = teachers[j];
                    teachers[j] = teachers[min];
                    teachers[min] = tempStudent;
                }
            }

            return teachers;
        }
    }
}
