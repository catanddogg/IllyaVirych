using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IllyaVirych.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public IMvxAsyncCommand ShowLoginViewModelCommand { get; set; }
        public IMvxAsyncCommand ShowLoginViewModel1Command { get; set; }
        private bool _enableDrawerLayout = false;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowLoginViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<LoginViewModel>());
            ShowLoginViewModel1Command = new MvxAsyncCommand(async () => await _navigationService.Navigate<ListTaskViewModel>());
        }
        
        public bool EnableDrawerLayout
        {
            get
            {
                return EnableDrawerLayout = _enableDrawerLayout;
            }
            set
            {
                _enableDrawerLayout = value;
                RaisePropertyChanged(() => EnableDrawerLayout);
            }
        }
    }
}
