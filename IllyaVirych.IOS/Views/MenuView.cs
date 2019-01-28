using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using IllyaVirych.Core.ViewModels;
using IllyaVirych.IOS.CustomControls;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views.Gestures;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using TZStackView;
using UIKit;

namespace IllyaVirych.IOS
{
    public partial class MenuView : MvxViewController<MenuViewModel>
    {
        public MenuView () : base (nameof(MenuView), null)
        {
        }
        private StackView _options;
        private MenuOption _listTaskMenu, _aboutTaskMenu, _layoutMenu;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //View.BackgroundColor = UIColor.Black;

            Title = "Menu";
            
            //ImageViewMenu = new UIImageView();
            //ImageViewMenu.Frame =  new CGRect(0, 0, 40, 40);
            ImageViewMenu.Image = UIImage.FromBundle("mqse9xro.jpg");

            StackViewMenu = new UIStackView
            {
                Axis = UILayoutConstraintAxis.Vertical
            };

            _listTaskMenu = new MenuOption();
            _listTaskMenu.Image.Image = UIImage.FromBundle("iconsdelete48");
            _listTaskMenu.Label.Text = "Create Task";
            _aboutTaskMenu = new MenuOption();
            _aboutTaskMenu.Image.Image = UIImage.FromBundle("iconsdelete48");
            _aboutTaskMenu.Label.Text = "About Task";
            _layoutMenu = new MenuOption();
            _layoutMenu.Image.Image = UIImage.FromBundle("iconsdelete48");
            _layoutMenu.Label.Text = "Logout";

            //View.AddSubviews(_options);
            //View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            StackViewMenu.AddArrangedSubview(_listTaskMenu);
            StackViewMenu.AddArrangedSubview(_aboutTaskMenu);
            StackViewMenu.AddArrangedSubview(_layoutMenu);
        }
    }
}