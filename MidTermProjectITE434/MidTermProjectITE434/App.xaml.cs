using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MidTermProjectITE434
{
    public partial class App : Application
    {
        
        public App()
        { 
            InitializeComponent();

            
            var fp = new FlyoutPage();
            fp.Flyout = new SideMenuPage();
            fp.Detail = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#3C6AA0"),
                BarTextColor = Color.FromHex("#101E2D")
            };
            MainPage = fp;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
