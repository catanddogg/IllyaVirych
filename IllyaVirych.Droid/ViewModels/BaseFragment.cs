using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using Android.Support.V7.Widget;
using Android.Content.Res;
using MvvmCross.ViewModels;

namespace IllyaVirych.Droid.ViewModels
{
    public abstract class BaseFragment : MvxFragment
    {
        private Toolbar toolbar;
        private MvxActionBarDrawerToggle _drawerToggle;
        protected abstract int FragmentId { get; }
        //private int _currentCheckPosition = 0;

        public MvxAppCompatActivity ParentActivity
        {
            get
            {
                return (MvxAppCompatActivity)Activity;
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(FragmentId, null);

            //toolbar = view.FindViewById<Toolbar>(Resource.Id.toolbar1);
            //if (toolbar != null)
            //{
            //    ParentActivity.SetSupportActionBar(toolbar);
            //    ParentActivity.SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            //    _drawerToggle = new MvxActionBarDrawerToggle(
            //        Activity,
            //        ((MainView)ParentActivity).DrawerLayout,
            //        toolbar,
            //        Resource.String.drawer_open,
            //        Resource.String.drawer_close
            //        );
            //    _drawerToggle.DrawerOpened += (object sender, ActionBarDrawerEventArgs e) => ((MainView)Activity)?.HideSoftKeyboard();
            //    ((MainView)ParentActivity).DrawerLayout.AddDrawerListener(_drawerToggle);
            //}

            return view;
        }
        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            if (toolbar != null)
            {
                _drawerToggle.OnConfigurationChanged(newConfig);
            }
        }
        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            //outState.PutInt("current_choice", _currentCheckPosition);

        }
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            //_currentCheckPosition = savedInstanceState.GetInt("current_choice", 0);
            //_drawerToggle.SyncState();
        }
    }
    public abstract class BaseFragment<TViewModel> : BaseFragment where TViewModel : class, IMvxViewModel
    {
        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}