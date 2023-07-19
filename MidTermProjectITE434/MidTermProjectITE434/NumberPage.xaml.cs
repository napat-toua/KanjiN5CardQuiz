using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MidTermProjectITE434
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NumberPage : ContentPage
    {    
        public string[] kanji    = { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十", "百", "千", "万", "円" };
        public string[] kanjiimi = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "ร้อย", "พัน", "หมื่น", "เยน/กลม"};
        public string[] onyomi       = { "ichi", "ni", "san", "shi", "go", "roku", "shichi", "hachi", "kyuu, ku", "juu, ji", "hyaku", "sen", "man, ban", "en" };
        public string[] kunyomi      = { "hito(tsu), hito-", "futa(tsu), futa-", "mi(tsu), mi-", "yo(tsu), yot(tsu), yo-, yon-", "itsu(tsu), itsu", "mut(tsu), mu(tsu), mu, mui", "nana(tsu), nana-, nano-", "yat(tsu), ya(tsu), ya-, you-", "kokono(tsu), kokono-", "ftoo, to-", "-", "chi", "-", "maru(i), maru" };

        public int setRandomKanji;

        public bool opened = false;

        public NumberPage()
        {
            InitializeComponent();

            Genrnd();

            kanjiCard.Clicked += NumCard_Clicked;
            nextBtn.Clicked += NextBtn_Clicked;
            resetBtn.Clicked += ResetBtnfornum_Clicked;
        }
        //Class1 c = new Class1();
        //testBTN.Text = c.Testclass();

        private void ResetBtnfornum_Clicked(object sender, EventArgs e)
        {
            kanji = new string[] { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十", "百", "千", "万", "円" };
            kanjiimi = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "ร้อย", "พัน", "หมื่น", "เยน/กลม" };
            onyomi = new string[] { "ichi", "ni", "san", "shi", "go", "roku", "shichi", "hachi", "kyuu, ku", "juu, ji", "hyaku", "sen", "man, ban", "en" };
            kunyomi = new string[] { "hito(tsu), hito-", "futa(tsu), futa-", "mi(tsu), mi-", "yo(tsu), yot(tsu), yo-, yon-", "itsu(tsu), itsu", "mut(tsu), mu(tsu), mu, mui", "nana(tsu), nana-, nano-", "yat(tsu), ya(tsu), ya-, you-", "kokono(tsu), kokono-", "ftoo, to-", "-", "chi", "-", "maru(i), maru" };

            Genrnd();
            opened = false;
            kanjiCard.BackgroundColor = Color.FromHex("#3C6AA0");
            kanjiCard.TextColor = Color.FromHex("#E5EDF5");
            kanjiCard.FontSize = 124;

            nextBtn.IsEnabled = true;
        }

        async private void NextBtn_Clicked(object sender, EventArgs e)
        {
            kanjiCard.FadeTo(0, 50);
            await kanjiCard.TranslateTo(-20, 0, 100);

            removeRandomed();

            if (kanji.Length == 1)
            {
                nextBtn.IsEnabled = false;
            }

            Genrnd();

            opened = false;
            kanjiCard.BackgroundColor = Color.FromHex("#3C6AA0");
            kanjiCard.TextColor = Color.FromHex("#E5EDF5");
            kanjiCard.FontSize = 124;

            kanjiCard.FadeTo(1, 50);
            await kanjiCard.TranslateTo(0, 0, 100);
        }

        async private void NumCard_Clicked(object sender, EventArgs e)
        {
            if (opened)
            {
                await kanjiCard.FadeTo(0, 100);
                kanjiCard.Text = kanji[setRandomKanji];
                kanjiCard.BackgroundColor = Color.FromHex("#3C6AA0");
                kanjiCard.TextColor = Color.FromHex("#E5EDF5");
                kanjiCard.FontSize = 124;
                await kanjiCard.FadeTo(1, 100);
                onTxt.Text = "";
                kunTxt.Text = "";
                opened = false;
            }
            else
            {
                await kanjiCard.FadeTo(0, 100);
                kanjiCard.Text = kanjiimi[setRandomKanji];
                kanjiCard.BackgroundColor = Color.FromHex("#769ECB");
                kanjiCard.TextColor = Color.FromHex("#203955");
                kanjiCard.FontSize = 48;
                await kanjiCard.FadeTo(1, 100);
                onTxt.Text = "Onyomi: " + onyomi[setRandomKanji];
                kunTxt.Text = "Kunyomi: " + kunyomi[setRandomKanji];
                opened = true;
            }
        }

        public void Genrnd()
        {
            Random rnd = new Random();

            setRandomKanji = rnd.Next(kanji.Length);
            kanjiCard.Text = kanji[setRandomKanji];
            onTxt.Text = "";
            kunTxt.Text = "";
        }
        public void removeRandomed()
        {
            for (int i = setRandomKanji; i < kanji.Length - 1; i++)
            {
                kanjiimi[i] = kanjiimi[i + 1];
                kanji[i] = kanji[i + 1];
                onyomi[i] = onyomi[i + 1];
                kunyomi[i] = kunyomi[i + 1];
            }
            Array.Resize(ref kanji, kanji.Length - 1);
            Array.Resize(ref kanjiimi, kanjiimi.Length - 1);
            Array.Resize(ref onyomi, onyomi.Length - 1);
            Array.Resize(ref kunyomi, kunyomi.Length - 1);
        }
    }
}