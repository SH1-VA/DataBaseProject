namespace DataBase.Models
{
    public class CreateGroupRequest
    {
        public string Name { get; set; }                //Название группы
        public string Orientation { get; set; }         //Название направления подготовки
        public int NumberOfStudents { get; set; }       //Кол-во студентов в группе
        public string SpecialityIdString { get; set; }
    }
}
