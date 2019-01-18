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
        public IMvxCommand CurrentMainViewCommand { get; set; }       

        public MainViewModel(IMvxNavigationService navigationService, ILoginService iLoginService)
        {
            _navigationService = navigationService;
            _iLoginService = iLoginService;
            
            CurrentMainViewCommand = new MvxAsyncCommand(CurrentMainView);
        }

        private async Task CurrentMainView()
        {
            if (_iLoginService.FindAccount == null)
            {
                await _navigationService.Navigate<LoginViewModel>();
            }
            if(_iLoginService.FindAccount != null)
            {
                await _navigationService.Navigate<ListTaskViewModel>();                
            }
        }     
   
    }
}
