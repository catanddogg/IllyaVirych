using Foundation;
using IllyaVirych.Core.Services;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.ViewModels;
using System;
using UIKit;

namespace IllyaVirych.IOS
{
    public partial class ListTaskName : MvxCollectionViewCell
    {
        //public static string CellID = new NSString("ListTaskName");
        public static readonly UINib Nib = UINib.FromName("ListTaskName", NSBundle.MainBundle);
        public static readonly NSString Key = new NSString("ListTaskName");

        public ListTaskName (IntPtr handle) : base (handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<ListTaskName, TaskItem>();
                set.Bind(NameTaskLabel).To(vm => vm.NameTask);
                set.Apply();
            });
        }

        public static ListTaskName Create()
        {
            return (ListTaskName)Nib.Instantiate(null, null)[0];
        }

        //internal void UpdateRow(MvxObservableCollection<TaskItem> items, NSIndexPath indexPath)
        //{
        //    NameTaskLabel.Text = items[indexPath.Row].NameTask;
        //}
    }
}