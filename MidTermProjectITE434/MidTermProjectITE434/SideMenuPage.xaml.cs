using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MidTermProjectITE434
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideMenuPage : ContentPage
    {
        public SideMenuPage()
        {
            InitializeComponent();

            numCateBtn.Clicked += NumCateBtn_Clicked;
            craditCateBtn.Clicked += CraditCateBtn_Clicked;
            HomeBtn.Clicked += HomeBtn_Clicked;
            timeCateBtn.Clicked += TimeCateBtn_Clicked;
            direcCateBtn.Clicked += DirecCateBtn_Clicked;
            nounCateBtn.Clicked += NounCateBtn_Clicked;
            peopleCateBtn.Clicked += PeopleCateBtn_Clicked;
            adjCateBtn.Clicked += AdjCateBtn_Clicked;
            natureCateBtn.Clicked += NatureCateBtn_Clicked;
            organCateBtn.Clicked += OrganCateBtn_Clicked;
            verbCateBtn.Clicked += VerbCateBtn_Clicked;
        }

        private void VerbCateBtn_Clicked(object sender, EventArgs e)
        {
            var fp = Parent as FlyoutPage;
            fp.Detail = new NavigationPage(new VerbPage());
            fp.IsPresented = false;
        }

        private void OrganCateBtn_Clicked(object sender, EventArgs e)
        {
            var fp = Parent as FlyoutPage;
            fp.Detail = new NavigationPage(new OrganPage());
            fp.IsPresented = false;
        }

        private void NatureCateBtn_Clicked(object sender, EventArgs e)
        {
            var fp = Parent as FlyoutPage;
            fp.Detail = new NavigationPage(new NaturePage());
            fp.IsPresented = false;
        }

        private void AdjCateBtn_Clicked(object sender, EventArgs e)
        {
            var fp = Parent as FlyoutPage;
            fp.Detail = new NavigationPage(new AdjectivePage());
            fp.IsPresented = false;
        }

        private void PeopleCateBtn_Clicked(object sender, EventArgs e)
        {
            var fp = Parent as FlyoutPage;
            fp.Detail = new NavigationPage(new PeoplePage());
            fp.IsPresented = false;
        }

        private void NounCateBtn_Clicked(object sender, EventArgs e)
        {
            var fp = Parent as FlyoutPage;
            fp.Detail = new NavigationPage(new NounPage());
            fp.IsPresented = false;
        }

        private void DirecCateBtn_Clicked(object sender, EventArgs e)
        {
            var fp = Parent as FlyoutPage;
            fp.Detail = new NavigationPage(new DirectionPage());
            fp.IsPresented = false;
        }

        private void TimeCateBtn_Clicked(object sender, EventArgs e)
        {
            var fp = Parent as FlyoutPage;
            fp.Detail = new NavigationPage(new TimePage());
            fp.IsPresented = false;
        }

        private void HomeBtn_Clicked(object sender, EventArgs e)
        {
            var fp = Parent as FlyoutPage;
            fp.Detail = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#3C6AA0"),
                BarTextColor = Color.White
            };
            fp.IsPresented = false;
        }

        private void NumCateBtn_Clicked(object sender, EventArgs e)
        {
            var fp = Parent as FlyoutPage;
            fp.Detail = new NavigationPage(new NumberPage());
            fp.IsPresented = false;
        }

        private void CraditCateBtn_Clicked(object sender, EventArgs e)
        {
            var fp = Parent as FlyoutPage;
            fp.Detail = new NavigationPage(new CreditPage());
            fp.IsPresented = false;
        }
    }
}