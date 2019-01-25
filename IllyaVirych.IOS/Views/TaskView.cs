using Foundation;
using IllyaVirych.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using System;

namespace IllyaVirych.IOS
{
    public partial class TaskView : MvxViewController<TaskViewModel>
    {
        public TaskView () : base (nameof(TaskView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<TaskView, TaskViewModel>();
            set.Bind(SaveTaskButton).To(vm => vm.BackTaskCommand);
            set.Bind(DeleteTaskButton).To(vm => vm.BackTaskCommand);
            set.Apply();
        }
            
    }
}