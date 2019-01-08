using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using IllyaVirych.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Android.Support.V7.Widget;
using Android.Support.V7.App;

namespace IllyaVirych.Droid.ViewModels
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    public class AboutView : BaseFragment<AboutTaskViewModel>/*,NavigationView.IOnNavigationItemSelectedListener*/
    {
        protected override int FragmentId => Resource.Layout.AboutView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            
            //DrawerLayout drawer = view.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            //var toolbar = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar2);
            //ParentActivity.SetSupportActionBar(toolbar);
            //ParentActivity.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            //MvxActionBarDrawerToggle drawerToggle = new MvxActionBarDrawerToggle(
            //Activity, ((MainView)ParentActivity).DrawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            //drawerToggle.DrawerOpened += (object sender, ActionBarDrawerEventArgs e) => ((MainView)Activity)?.HideSoftKeyboard();
            //((MainView)ParentActivity).DrawerLayout.AddDrawerListener(drawerToggle);            
            //drawerToggle.SyncState();

            //NavigationView navigationView = view.FindViewById<NavigationView>(Resource.Id.nav_view);            
            //navigationView.SetNavigationItemSelectedListener(this);
            return view;
        }

        //public bool OnNavigationItemSelected(IMenuItem menuItem)
        //{
        //    return true;
        //}
    }
}