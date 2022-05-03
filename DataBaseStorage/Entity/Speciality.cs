namespace DataBase.Storage.Entity
{
    public class Speciality
    {
        public Guid Id { get; set; }                            //Id для работы
        public string Name { get; set; }                        //Название специальности
        public string Code { get; set; }                        //Код специальности
        public int NumberOfStudents { get; set; }               //Кол-во обучающихся студентов
        public List<Discipline> Disciplines { get; set; }       //Список дисциплин
        public List<Group> Groups { get; set; }                 //Список групп
        public Speciality(Guid id, string name, string code, int numberOfStudents, List<Discipline> disciplines, List<Group> groups)
        {
            Id = id;
            Name = name;
            Code = code;
            NumberOfStudents = numberOfStudents;
            Disciplines = disciplines;
            Groups = groups;
        }
    }
}
