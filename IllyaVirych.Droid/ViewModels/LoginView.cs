using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using IllyaVirych.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Xamarin.Auth;

namespace IllyaVirych.Droid.ViewModels
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame)]
    public class LoginView : MvxFragment<LoginViewModel>
    {
       // private const string AuthorizeUrl = "https://api.instagram.com/oauth/authorize";

        //protected override int FragmentId => Resource.Layout.LoginView;
        private ImageButton _imageButton;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.LoginView, null);
            _imageButton = view.FindViewById<ImageButton>(Resource.Id.image_button);
            _imageButton.Click += delegate
            {
                InstagramLogin();
            };
            
            return view;
        }
        public void InstagramLogin()
        {
            //var auth = new OAuth1Authenticator
            //    (
            //    consumerKey: "0988f83913f043e7b528f5f2ad81e417",
            //    consumerSecret: "16f87c34ec28476693ace8992cd35d56",
            //    requestTokenUrl: new Uri(""),
            //    authorizeUrl: new Uri("https://api.instagram.com/oauth/authorize"),
            //    accessTokenUrl: new Uri(""),
            //    callbackUrl: new Uri ("")
            //    );
            var auth = new OAuth2Authenticator
                (
                clientId: "6cf8828f43fd4ff58c95c00fbcb0cacd",
                scope: "basic",
                authorizeUrl: new Uri("https://www.instagram.com/oauth/authorize/?client_id=c23d16f9a9854b36b5ccae7150023a29&redirect"),
                redirectUrl: new Uri("https://www.google.com.ua/")
                );
            auth.AllowCancel = true;
            StartActivity(auth.GetUI(this.Context));
            
            auth.Completed += (sender, evebtArgs) =>
            {
                if(evebtArgs.IsAuthenticated)
                {
                    Toast.MakeText(this.Context, "Authenticated!", ToastLength.Long).Show();
                }
                //StringBuilder stringBuilder = new StringBuilder();
                //if (evebtArgs.Account != null && evebtArgs.Account.Properties != null)
                //{
                //    stringBuilder.Append("Token = ").AppendLine($"{evebtArgs.Account.Properties["access_token"]}");
                //}
                //else
                //{
                //    stringBuilder.Append("Not authenticated").AppendLine($"Account.Properties does not exist");
                //}
                //return;
            };

        }
        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
        }
       
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);            
        }
    }
}