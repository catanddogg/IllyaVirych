using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IllyaVirych.Core.ViewModels
{
    public class MainViewModel :MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public IMvxAsyncCommand ShowListTaskModelCommand { get; set; }
        public IMvxAsyncCommand ShowMenuViewModelCommand { get; set; }
        public IMvxAsyncCommand ShowAboutViewModelCommand { get; set; }

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowListTaskModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<ListTaskViewModel>());
            ShowAboutViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<AboutTaskViewModel>());
            ShowMenuViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<MenuViewModel>());
        }
    }
}
