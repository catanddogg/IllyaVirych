using IllyaVirych.Core.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IllyaVirych.Core
{
    public class AppStart : MvxAppStart 
    {
        public AppStart(IMvxApplication app, IMvxNavigationService navigationService)
            :base(app, navigationService)
        {
        }
        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            return NavigationService.Navigate<MainViewModel>();
        }
    }
}
