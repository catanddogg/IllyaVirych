using IllyaVirych.Core.Interface;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IllyaVirych.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ILoginService _iLoginService; 
        public IMvxAsyncCommand ShowLoginViewModelCommand { get; set; }
        public IMvxAsyncCommand ShowListTaskViewModelCommand { get; set; }
        public IMvxCommand CurrentMainViewCommand { get; set; }       

        public MainViewModel(IMvxNavigationService navigationService, ILoginService iLoginService)
        {
            _navigationService = navigationService;
            _iLoginService = iLoginService;

            ShowLoginViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<LoginViewModel>());
            ShowListTaskViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<ListTaskViewModel>());
            CurrentMainViewCommand = new MvxAsyncCommand(CurrentMainView);
        }

        public async Task CurrentMainView()
        {
            if (_iLoginService.FindAccount == null)
            {
                ShowLoginViewModelCommand.Execute(null);
            }
            if(_iLoginService.FindAccount != null)
            {
                ShowListTaskViewModelCommand.Execute(null);
            }
        }     
   
    }
}
