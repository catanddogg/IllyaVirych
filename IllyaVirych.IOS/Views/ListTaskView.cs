using Foundation;
using IllyaVirych.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using System;
using UIKit;

namespace IllyaVirych.IOS
{
    public partial class ListTaskView : MvxViewController<ListTaskViewModel>
    {
        private UIBarButtonItem _buttonAdd;

        public ListTaskView () : base (nameof(ListTaskView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.Gray;

            Title = "TaskyDrop";

            _buttonAdd = new UIBarButtonItem(UIBarButtonSystemItem.Add, null);
            NavigationItem.SetRightBarButtonItem(_buttonAdd, false);

            var set = this.CreateBindingSet<ListTaskView, ListTaskViewModel>();
            set.Bind(_buttonAdd).For("Clicked").To(vm => vm.TaskCreateCommand);
            set.Apply();
        }
    }
}