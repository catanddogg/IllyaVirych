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
    [Register ("TaskView")]
    partial class TaskView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DeleteTaskButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SaveTaskButton { get; set; }

        [Action ("SaveTaskButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SaveTaskButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (DeleteTaskButton != null) {
                DeleteTaskButton.Dispose ();
                DeleteTaskButton = null;
            }

            if (SaveTaskButton != null) {
                SaveTaskButton.Dispose ();
                SaveTaskButton = null;
            }
        }
    }
}