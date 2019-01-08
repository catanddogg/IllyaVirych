using IllyaVirych.Core.Services;
using System.Collections.Generic;

namespace IllyaVirych.Core.Interface
{
    public interface ITaskService
    {
        List<TaskItem> GetAllConstantsData();
        void DeleteTask(int _idTask);
        void InsertTask(TaskItem task);
    }
}
