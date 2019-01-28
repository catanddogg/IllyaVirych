using CoreGraphics;
using Foundation;
using IllyaVirych.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using System;
using UIKit;

namespace IllyaVirych.IOS
{
    [MvxModalPresentation(WrapInNavigationController = true/*, ModalTransitionStyle = UIModalTransitionStyle.CrossDissolve*/)]
    public partial class ListTaskView : MvxCollectionViewController<ListTaskViewModel>
    {
        private UIBarButtonItem _buttonAdd;
        private UIButton _buttonMenu;
        private bool _isInitialised;

        public ListTaskView () : base (nameof(ListTaskView), null)
        {
            _isInitialised = true;
            ViewDidLoad();
        }

        public sealed override void ViewDidLoad()
        {
            if (_isInitialised)
                return;

            base.ViewDidLoad();

            TaskListCollectionView.RegisterNibForCell(ListTaskName.Nib, ListTaskName.Key);
            var source = new MvxCollectionViewSource(TaskListCollectionView, ListTaskName.Key );
            TaskListCollectionView.Source = source;

            Title = "TaskyDrop";            

            //var data = this.ViewModel.Items;

            _buttonAdd = new UIBarButtonItem(UIBarButtonSystemItem.Add, null);
            NavigationItem.SetRightBarButtonItem(_buttonAdd, false);

            _buttonMenu = new UIButton(UIButtonType.Custom);
            _buttonMenu.Frame = new CGRect(0, 0, 40, 40);
            _buttonMenu.SetImage(UIImage.FromBundle("icons8-menu-filled-30.png"), UIControlState.Normal);
            this.NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem(_buttonMenu), false);

            //TaskListCollectionView.Source = new TaskListCollectionViewSource(this, data);
            //TaskListCollectionView.ReloadData();

            _buttonMenu.TouchUpInside += (sender, e) =>
            {
                ViewModel.ShowMenuViewModelCommand.Execute();                
            };

            var set = this.CreateBindingSet<ListTaskView, ListTaskViewModel>();
            set.Bind(_buttonAdd).For("Clicked").To(vm => vm.TaskCreateCommand);
            set.Bind(source).To(vm => vm.Items);
            set.Apply();

            TaskListCollectionView.ReloadData();
        }
    }
}