using Foundation;
using IllyaVirych.Core.ViewModels;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using System;
using WebKit;

namespace IllyaVirych.IOS
{
    [MvxModalPresentation(WrapInNavigationController = true)]
    public partial class TestLoginView : MvxViewController<TestLoginViewModel>, IWKNavigationDelegate

    {
        public TestLoginView() : base(nameof(TestLoginView), null)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var configuration = new WKWebViewConfiguration();
            var cgRect = new CoreGraphics.CGRect(0, 0, 400, 700);
            var webView = new WKWebView(cgRect, configuration);
            webView.TranslatesAutoresizingMaskIntoConstraints = false;
            //WKNavigation  navigation  = new WKNavigation();
            webView.NavigationDelegate = (IWKNavigationDelegate)this;
            View.AddSubview(webView);
            var url = new NSUrl("https://www.instagram.com/oauth/authorize/?client_id=f0c8c1093c06475dbeadba39c6b3ac80&redirect_uri=https://www.google.com.ua/&response_type=token&scope=basic");
            var reqvest = new NSUrlRequest(url);
            webView.LoadRequest(reqvest); 

        }
        //https://www.instagram.com/oauth/authorize/?client_id=f0c8c1093c06475dbeadba39c6b3ac80&redirect_uri=http://localhost:3000/&response_type=token&scope=basic

        [Export("webView:didFinishNavigation:")]
        public void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
        {
            Console.WriteLine("DidFinishNavigation");
            NSUrl token = webView.Url;
            token.LoadData.
        }
        [Export("webView:didFailNavigation:withError:")]
        public void DidFailNavigation( WKWebView webView, WKNavigation navigation, NSError error )
        {
            // If navigation fails, this gets called
            Console.WriteLine("DidFailNavigation");
        }
        //[Export("webView:didFailProvisionalNavigation:withError:")]
        //public void DidFailProvisionalNavigation(WKWebView webView, WKNavigation navigation, NSError error)
        //{
        //    // If navigation fails, this gets called
        //    Console.WriteLine("DidFailProvisionalNavigation");
        //}

        //[Export("webView:didStartProvisionalNavigation:")]
        //public void DidStartProvisionalNavigation(WKWebView webView, WKNavigation navigation)
        //{
        //    // When navigation starts, this gets called
        //    Console.WriteLine("DidStartProvisionalNavigation");
        //}

        //[Export("webView:decidePolicyForNavigationAction:decisionHandler:")]
        //public void DecidePolicy(WKWebView webView, WKNavigationAction navigationAction, Action<WKNavigationActionPolicy> decisionHandler)
        //{
        //    Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        //}

        //[Export("webView:decidePolicyForNavigationResponse:decisionHandler:")]
        //public void DecidePolicy(WKWebView webView, WKNavigationResponse navigationResponse, Action<WKNavigationResponsePolicy> decisionHandler)
        //{
        //    Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        //}
    }
}