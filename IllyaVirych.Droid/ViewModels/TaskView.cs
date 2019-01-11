﻿using System;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using IllyaVirych.Core.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Android.Widget;

namespace IllyaVirych.Droid.ViewModels
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    public class TaskView : BaseFragment<TaskViewModel>
    {
        protected override int FragmentId => Resource.Layout.TaskView;
        
        private LinearLayout _linearLayoutMain;
        private Android.Support.V7.Widget.Toolbar _toolbar;
        private View _view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            _view = view;
            var buttonTextSaveTask = view.FindViewById<Button>(Resource.Id.Savetask);
            buttonTextSaveTask.Click += ButtonSaveTaskClick;
            _linearLayoutMain = view.FindViewById<LinearLayout>(Resource.Id.test_layout);
            _toolbar = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar1);
            _linearLayoutMain.Click += delegate
            {
                HideSoftKeyboard();
            };
            _toolbar.Click += delegate
            {
                HideSoftKeyboard();
            };
            var txtTaskView = view.FindViewById<TextView>(Resource.Id.task_text);
            var txtNameTaskView = view.FindViewById<TextView>(Resource.Id.name_text);
            Typeface tf = Typeface.CreateFromAsset(Activity.Assets, "13185.ttf");
            txtTaskView.SetTypeface(tf, TypefaceStyle.Normal);
            txtNameTaskView.SetTypeface(tf, TypefaceStyle.Normal);
            return view;
        }
        private void ButtonSaveTaskClick(object sender, EventArgs e)
        {
            var nameTask = this.ViewModel.NameTask;
            if (nameTask == null)
            {
                Toast.MakeText(this.Context, "Enter Name Task!", ToastLength.Short).Show();
            }
        }

        public void HideSoftKeyboard()
        {
            InputMethodManager close = (InputMethodManager)Activity.GetSystemService(Context.InputMethodService);
            close.HideSoftInputFromWindow(_linearLayoutMain.WindowToken, 0);
        }
    }
}