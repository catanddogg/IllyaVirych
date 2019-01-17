﻿using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using IllyaVirych.Core.Services;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using System.Runtime.Remoting.Contexts;

namespace IllyaVirych.Droid.ViewAdapter
{    
    public class TasksViewHolder : MvxRecyclerViewHolder
    {
        public TextView NameTaskHolder { get; set; }
        public LinearLayout LinearLayoutTaskHolder { get; set; }

        public TasksViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
        {            
            NameTaskHolder = itemView.FindViewById<TextView>(Resource.Id.txt_name);
            LinearLayoutTaskHolder = itemView.FindViewById<LinearLayout>(Resource.Id.layout_main);            
            Typeface tf = Typeface.CreateFromAsset(Application.Context.Assets, "13185.ttf");
            NameTaskHolder.SetTypeface(tf, TypefaceStyle.Normal);
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<TasksViewHolder, TaskItem>();
                set.Bind(this.NameTaskHolder).To(x => x.NameTask);                
                set.Apply();
            });
        }
    }
}