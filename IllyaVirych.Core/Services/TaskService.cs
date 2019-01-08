using IllyaVirych.Core.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IllyaVirych.Core.Services
{
    public class TaskService : ITaskService
    {
        private SQLiteConnection _sQLiteConnection;

        public TaskService(IDatabaseConnectionService sQLiteConnection)
        {
            _sQLiteConnection = sQLiteConnection.GetDatebaseConnection();
            _sQLiteConnection.CreateTable<TaskItem>();
        }

        public void DeleteTask(int _idTask)
        {
            _sQLiteConnection.Delete<TaskItem>(_idTask);
        }
        public void InsertTask(TaskItem task)
        {
            if (task.Id == 0)
            {
                _sQLiteConnection.Insert(task);
            }
            if (task.Id != 0)
            {
                _sQLiteConnection.Update(task);
            }
        }

        public List<TaskItem> GetAllConstantsData()
        {
            return (from data in _sQLiteConnection.Table<TaskItem>() select data).ToList();
        }
    }
}
