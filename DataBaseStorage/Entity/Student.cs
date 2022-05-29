namespace DataBase.Storage.Entity
{
    public class Student: Person
    {    
        public bool Subgroup { get; set; }                  //Подгруппа студента; A - 0, B - 1
        //public int Number { get; set; }                     //Номер студента по списку

        [Required]
        public int GroupId { get; set; }

        [ForeignKey(nameof(GroupId))]
        public virtual Group Group { get; set; }                    //Группа студента
        //public Student(int id, string name, string lastName, string email, string phoneNumber, Group group, bool subgroup, ModularJournal modularJournal, int number): base(id, name, lastName, email, phoneNumber)
        //{
        //    Group = group;
        //    Subgroup = subgroup;
        //    ModularJournal = modularJournal;
        //    Number = number;
        //}
        public static List<Student> SortById(List<Student> students)
        {
            int min = 0;
            for (int i = 0; i < students.Count; i++)
            {
                for(int j = i; j < students.Count; j++)
                {
                    if (students[j].Id < students[min].Id)
                    {
                        min = j;
                    }    
                    var tempStudent = students[j];
                    students[j] = students[min];
                    students[min] = tempStudent;
                }
            }

            return students;
        }
    }
}
