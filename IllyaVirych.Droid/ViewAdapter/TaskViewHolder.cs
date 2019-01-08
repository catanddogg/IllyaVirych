using Android.Views;
using Android.Widget;
using IllyaVirych.Core.Services;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

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
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<TasksViewHolder, TaskItem>();
                set.Bind(this.NameTaskHolder).To(x => x.NameTask);
                //set.Bind(this.LinearLayoutTaskHolder).To(z => z.StatusTask);
                set.Apply();
            });
        }
    }
}