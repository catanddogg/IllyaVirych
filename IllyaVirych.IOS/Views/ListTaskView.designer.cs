// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace IllyaVirych.IOS
{
    [Register ("ListTaskView")]
    partial class ListTaskView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView TaskListCollectionView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (TaskListCollectionView != null) {
                TaskListCollectionView.Dispose ();
                TaskListCollectionView = null;
            }
        }
    }
}