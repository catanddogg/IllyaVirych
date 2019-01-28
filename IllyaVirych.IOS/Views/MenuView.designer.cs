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
    [Register ("MenuView")]
    partial class MenuView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ImageViewMenu { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStackView StackViewMenu { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ImageViewMenu != null) {
                ImageViewMenu.Dispose ();
                ImageViewMenu = null;
            }

            if (StackViewMenu != null) {
                StackViewMenu.Dispose ();
                StackViewMenu = null;
            }
        }
    }
}