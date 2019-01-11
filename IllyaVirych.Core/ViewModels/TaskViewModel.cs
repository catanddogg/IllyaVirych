using IllyaVirych.Core.Interface;
using IllyaVirych.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IllyaVirych.Core.ViewModels
{
    public class TaskViewModel : BaseViewModel<TaskItem>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ITaskService _iTaskService;
        public IMvxCommand SaveTaskCommand { get; set; }
        public IMvxCommand DeleteTaskCommand { get; set; }
        public IMvxCommand BackTaskCommand { get; set; }
        private int _idTask;
        private string _nameTask;
        private string _descriptionTask;
        private bool _statusTask;
        private bool _enableStatusNameTask;

        public TaskViewModel(IMvxNavigationService navigationService, ITaskService iTaskService)
        {
            _navigationService = navigationService;
            _iTaskService = iTaskService;
            SaveTaskCommand = new MvxAsyncCommand(SaveTask);
            DeleteTaskCommand = new MvxAsyncCommand(DeleteTask);
            BackTaskCommand = new MvxAsyncCommand(BackTask);
        }

        private async Task BackTask()
        {
            var result = await _navigationService.Close(this);
        }

        private async Task DeleteTask()
        {
            _iTaskService.DeleteTask(IdTask);
            await _navigationService.Close(this);
        }

        private async Task SaveTask()
        {
            if (NameTask == null & NameTask != string.Empty)
            {
                return;
            }
            if (NameTask != null & NameTask != string.Empty)
            {
                TaskItem taskItem = new TaskItem(IdTask, NameTask, DescriptionTask, StatusTask);
                _iTaskService.InsertTask(taskItem);
            }
            await _navigationService.Close(this);
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

        public override void Prepare(TaskItem parameter)
        {
            if (parameter != null)
            {
                EnableStatusNameTask = false;
                IdTask = parameter.Id;
                NameTask = parameter.NameTask;
                DescriptionTask = parameter.DescriptionTask;
                StatusTask = parameter.StatusTask;
                return;
            }
            EnableStatusNameTask = true;
        }

        public int IdTask
        {
            get => _idTask;
            set
            {
                _idTask = value;
                RaisePropertyChanged(() => IdTask);
            }
        }

        public string NameTask
        {
            get => _nameTask;
            set
            {
                _nameTask = value;
                RaisePropertyChanged(() => NameTask);
            }
        }

        public string DescriptionTask
        {
            get => _descriptionTask;
            set
            {
                _descriptionTask = value;
                RaisePropertyChanged(() => DescriptionTask);
            }
        }

        public bool StatusTask
        {
            get => _statusTask;
            set
            {
                _statusTask = value;
                RaisePropertyChanged(() => StatusTask);
            }
        }

        public bool EnableStatusNameTask
        {
            get => _enableStatusNameTask;
            set
            {
                _enableStatusNameTask = value;
                RaisePropertyChanged(() => EnableStatusNameTask);
            }
        }
    }
}
