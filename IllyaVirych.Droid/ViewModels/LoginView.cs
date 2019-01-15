using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using IllyaVirych.Core.ViewModels;
using IllyaVirych.Droid.Models;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Auth;

namespace IllyaVirych.Droid.ViewModels
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame)]
    public class LoginView : BaseFragment<LoginViewModel>
    {      
        protected override int FragmentId => Resource.Layout.LoginView;
        private ImageButton _imageButton;
        private InstagramId _user;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            
            _imageButton = view.FindViewById<ImageButton>(Resource.Id.image_button);
            
            _imageButton.Click += delegate
            {
                InstagramLogin();
            };
            
            return view;
        }
        //access token ("https://api.instagram.com/v1/users/self/follows?access_token=8496248657.f23b40b.fbb30e8c10ff4214ad833e2ea3035deb")
        public void InstagramLogin()
        {            
            var auth = new OAuth2Authenticator
                (
                clientId: "f23b40bebe784ea6b1f1bd095a60b496",
                scope: "relationships",
                authorizeUrl: new Uri("https://www.instagram.com/oauth/authorize/?client_id=f23b40bebe784ea6b1f1bd095a60b496&redirect"),
                redirectUrl: new Uri("https://www.google.com.ua/")
                );            
            auth.AllowCancel = true;
            StartActivity(auth.GetUI(this.Context));
            
            auth.Completed += async (sender, eventArgs) =>
            {
            if (eventArgs.IsAuthenticated)
            {
                Account loggedInAccount = eventArgs.Account;
                var request = new OAuth2Request("GET",
                    new Uri("https://api.instagram.com/v1/users/self/?access_token=8496248657.f23b40b.fbb30e8c10ff4214ad833e2ea3035deb"),
                    null,
                    eventArgs.Account);
                    var response = await request.GetResponseAsync();
                    var json = response.GetResponseText();
                    var jobject = JObject.Parse(json);
                    var id_user = jobject["data"]["id"]?.ToString();
                    var username = jobject["data"]["username"]?.ToString();
                    _user = JsonConvert.DeserializeObject<InstagramId>(json);                 
                    Toast.MakeText(this.Context, "Authenticated!", ToastLength.Long).Show();
                }            
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