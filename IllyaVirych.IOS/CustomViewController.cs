using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace Blank
{
    public partial class CustomViewControllercs : UIViewController
    {
        public CustomViewControllercs()
        {
        }

        UITextField usernameField, passwordField;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.Gray;

            nfloat h = 31.0f;
            nfloat w = View.Bounds.Width;

            usernameField = new UITextField
            {
                Placeholder = "Enter your username",
                BorderStyle = UITextBorderStyle.RoundedRect,
                Frame = new CGRect(10, 82, w - 20, h)
            };
            passwordField = new UITextField
            {
                Placeholder = "Enter your password",
                BorderStyle = UITextBorderStyle.RoundedRect,
                Frame = new CGRect(10, 114, w - 20, h),
                SecureTextEntry = true
            };
            var loginVC = new UIViewController()
            {
                Title = "Login Success!"
            };
            loginVC.View.BackgroundColor = UIColor.Yellow;

            var submitButton = UIButton.FromType(UIButtonType.RoundedRect);

            submitButton.Frame = new CGRect(10, 170, w - 20, 44);
            submitButton.SetTitle("Submit", UIControlState.Normal);
            submitButton.BackgroundColor = UIColor.White;
            submitButton.Layer.CornerRadius = 5f;

            submitButton.TouchUpInside += (sender, e) =>
            {
                this.NavigationController.PushViewController ( loginVC, true);
            };           

            View.AddSubviews(new UIView[] { usernameField, passwordField, submitButton });

          
            //View.AddSubview(usernameField);
            //View.AddSubview(passwordField);
            //View.AddSubview(submitButton);
        }
        public CustomViewControllercs (IntPtr handle) : base (handle)
        {
        }
    }
}