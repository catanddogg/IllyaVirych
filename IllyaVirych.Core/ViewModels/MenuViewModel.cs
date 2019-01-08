using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IllyaVirych.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public IMvxCommand TaskCreateCommand { get; set; }

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            TaskCreateCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TaskViewModel>());
        }
    }
}
