using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace IllyaVirych.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public IMvxCommand ShowListTaskViewCommand { get; set; }        

        public LoginViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;            
            ShowListTaskViewCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<ListTaskViewModel>());
        }
    }
}
