using IllyaVirych.Core.Interface;
using IllyaVirych.Core.Models;
using IllyaVirych.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IllyaVirych.Core.ViewModels
{
    public class MapsViewModel : BaseViewModel<TaskItem>
    {        
        private readonly IMvxNavigationService _navigationService;
        private readonly ITaskService _iTaskService; 
        public IMvxCommand BackTaskCommand { get; set; }
        public IMvxCommand SaveGoogleMapPointCommand { get; set; }
        private double _lalitudeGoogelMarker;
        private double _longitudeGoogleMarker;
        private int _idTask;
        private int _id;
        
        public MapsViewModel(IMvxNavigationService navigationService, ITaskService iTaskService)
        {
            _navigationService = navigationService;
            _iTaskService = iTaskService;

            BackTaskCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TaskViewModel>());
            SaveGoogleMapPointCommand = new MvxAsyncCommand(SaveGoogleMapPoint);
        }
        private async Task SaveGoogleMapPoint()
        {
            if (LalitudeGoogleMarker == 0 & LongitudeGoogleMarker == 0)
            {
                return;
            }
            if (LalitudeGoogleMarker != 0 & LongitudeGoogleMarker != 0)
            {
                TaskInGoogleMap taskInGoogleMap = new TaskInGoogleMap(Id, IdTask, LalitudeGoogleMarker, LongitudeGoogleMarker);
                _iTaskService.InsertMarkerGoogleMap(taskInGoogleMap);
            }
            await _navigationService.Navigate<TaskViewModel>();
        }  
        
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChanged(() => Id);
            }
        }
        public int IdTask
        {
            get
            {
                return _idTask;
            }
            set
            {
                _idTask = value;
                RaisePropertyChanged(() => IdTask);
            }
        }
        
        public double LalitudeGoogleMarker
        {
            get
            {
                return _lalitudeGoogelMarker;
            }
            set
            {
                _lalitudeGoogelMarker = value;
                RaisePropertyChanged(() => LalitudeGoogleMarker);
            }
        }

        public double LongitudeGoogleMarker 
        {
            get
            {
                return _longitudeGoogleMarker;
            }
            set
            {
                _longitudeGoogleMarker = value;
                RaisePropertyChanged(() => LongitudeGoogleMarker);
            }
        }

        public override void Prepare(TaskItem parameter)
        {
            if (parameter != null)
            {
                IdTask = parameter.Id;
            }
        }
    }
}
