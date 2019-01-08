using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.Graphics.Drawable;
using Android.Views;
using IllyaVirych.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;


namespace IllyaVirych.Droid.ViewModels
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.navigation_frame)]
    public class MenuFragment : MvxFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        private NavigationView _navigationView;
        private IMenuItem _previousMenuItem;
        public MenuFragment()
        {
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.MenuView, null);

            _navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_menu_view);
            _navigationView.SetNavigationItemSelectedListener(this);
            _navigationView.Menu.FindItem(Resource.Id.nav_task).SetChecked(true);

            var iconTask = _navigationView.Menu.FindItem(Resource.Id.nav_task);
            iconTask.SetCheckable(false);
            iconTask.SetChecked(true);

            _previousMenuItem = iconTask;

            var iconPeople = _navigationView.Menu.FindItem(Resource.Id.nav_about);
            iconTask.SetCheckable(false);
            iconTask.SetChecked(true);

            return view;
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            if (_previousMenuItem != null)
            {
                _previousMenuItem.SetChecked(false);
            }
            item.SetChecked(true);
            item.SetCheckable(true);

            _previousMenuItem = item;

            Navigate(item.ItemId);

            return true;
        }
        private async Task Navigate(int itemId)
        {
            ((MainView)Activity).DrawerLayout.CloseDrawers();
            await Task.Delay(TimeSpan.FromMilliseconds(250));
            switch (itemId)
            {
                case Resource.Id.nav_task:
                    {
                        ViewModel.TaskCreateCommand.Execute(null);
                        break;
                    }
                case Resource.Id.nav_about:
                    {
                        ViewModel.TaskCreateCommand.Execute(null);
                        break;
                    }
            }
        }
    }
}