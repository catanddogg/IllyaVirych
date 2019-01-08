using SQLite;

namespace IllyaVirych.Core.Services
{
    public class TaskItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NameTask { get; set; }
        public string DescriptionTask { get; set; }
        public bool StatusTask { get; set; }


        public TaskItem(int id, string nameTask, string descriptionTask, bool statusTaask)
        {
            Id = id;
            NameTask = nameTask;
            DescriptionTask = descriptionTask;
            StatusTask = statusTaask;
        }
        public TaskItem()
        {

        }
    }
}
