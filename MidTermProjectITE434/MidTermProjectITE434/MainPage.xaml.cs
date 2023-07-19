using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MidTermProjectITE434
{
    public partial class MainPage : ContentPage
    {
        public int setRandom;

        public MainPage()
        {
            InitializeComponent();

            randStrtBtn.Clicked += RandStrtBtn_Clicked;
        }

        async private void RandStrtBtn_Clicked(object sender, EventArgs e)
        {
            setRandom = new Random().Next(9);

            switch (setRandom)
            {
                case 8:await Navigation.PushModalAsync(new NumberPage());
                       break;
                case 7: await Navigation.PushModalAsync(new TimePage());
                    break;
                case 6: await Navigation.PushModalAsync(new DirectionPage());
                    break;
                case 5: await Navigation.PushModalAsync(new NounPage());
                    break;
                case 4: await Navigation.PushModalAsync(new PeoplePage());
                    break;
                case 3: await Navigation.PushModalAsync(new AdjectivePage());
                    break;
                case 2: await Navigation.PushModalAsync(new NaturePage());
                    break;
                case 1: await Navigation.PushModalAsync(new OrganPage());
                    break;
                default : await Navigation.PushModalAsync(new VerbPage());
                    break;
            }
        }
    }
}
