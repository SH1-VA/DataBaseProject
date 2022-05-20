namespace DataBase.Storage.Entity
{
    public class Group
    {
        [Key]
        public int Id { get; set; }                    //Id для работы
        public string Name { get; set; }                //Название группы
        public string Orientation { get; set; }         //Название направления подготовки
        public int NumberOfStudents { get; set; }       //Кол-во студентов в группе

        public int SpecialityId { get; set; }
        [ForeignKey(nameof(SpecialityId))]
        public virtual Speciality Speciality { get; set; } //Специализация группы
        //public List<Student> Students { get; set; }     //Список студентов группы
        //public Group(int id, string name, string orientation, int numberOfStudents, List<Student> students)
        //{
        //    Id = id;
        //    Name = name;
        //    Orientation = orientation;
        //    NumberOfStudents = numberOfStudents;
        //    Students = students;
        //}
    }
}
