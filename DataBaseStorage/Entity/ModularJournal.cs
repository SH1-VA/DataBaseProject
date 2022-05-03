namespace DataBase.Storage.Entity
{
    public struct JournalDiscipline
    {
        int Module1;    //Оценка за 1-ый модуль
        int Module2;    //Оценка за 2-ый модуль
        bool Test;      //Оценка за зачёт
        int Exam;       //Оценка за экзамен


    }
    public class ModularJournal
    {

        public List<JournalDiscipline> JournalDisciplines { get; set; }     //Список дисциплин с оценками
        public JournalDiscipline AverageGrade { get; set; }                 //Средние значения
        public ModularJournal(List<JournalDiscipline> journalDisciplines)
        {
            JournalDisciplines = journalDisciplines;
        }
    }
}
