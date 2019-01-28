using Foundation;
using IllyaVirych.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
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
            set.Bind(NameTask).To(vm => vm.NameTask);
            set.Bind(StatusTask).To(vm => vm.StatusTask);
            set.Bind(DescriptionTask).To(vm => vm.DescriptionTask);
            set.Bind(SaveTaskButton).To(vm => vm.SaveTaskCommand);
            set.Bind(tt).To(vm => vm.BackTaskCommand);           
            set.Apply();
        }            
    }
}