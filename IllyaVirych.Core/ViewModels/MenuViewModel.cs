using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IllyaVirych.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public IMvxCommand TaskCreateViewCommand { get; set; }
        public IMvxCommand AboutViewCommand { get; set; }

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            TaskCreateViewCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TaskViewModel>());
            AboutViewCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<AboutTaskViewModel>());
        }
    }
}
