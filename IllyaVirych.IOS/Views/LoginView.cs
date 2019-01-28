using Foundation;
using IllyaVirych.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using System;

namespace IllyaVirych.IOS.Views
{

    public partial class LoginView : MvxViewController<LoginViewModel>
    {
        public LoginView () : base (nameof(LoginView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //LoginButton.TouchUpInside += (sender, e) =>
            //{
            //    ViewModel.LoginCommand.Execute();
            //    var ui = ViewModel.Authhenticator.GetUI();                
            //    PresentedViewController(ui, true, null);
            //};

            var set = this.CreateBindingSet<LoginView, LoginViewModel>();            
            set.Apply();
        }
        partial void LoginViewButton(UIKit.UIButton sender)
        {
            ViewModel.LoginCommand.Execute();
            var ui = ViewModel.Authhenticator.GetUI();
            PresentViewController( ui, true, null ) ;
        }
    }
}