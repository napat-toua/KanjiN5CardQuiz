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
	public partial class NaturePage : ContentPage
	{
        public string[] kanji = { "天","山","川","空","花","雨","魚","気","牛","馬","貝","木","力" };
        public string[] kanjiimi = { "ท้องฟ้า/สวรรค์","ภูเขา","ลำธาร","ท้องฟ้า/ว่างเปล่า","ดอกไม้","ฝน","ปลา","อากาศ/จิตใจ","วัว","ม้า","หอย","ต้นไม้","พลัง" };
        public string[] onyomi = { "ten", "san", "sen", "kuu", "ka", "u", "syo", "ki, ke", "gyuu", "ba", "-", "moku, boku", "ryoku, riki" };
        public string[] kunyomi = { "ame, ama", "yama", "kawa", "sora, a(keru), kara", "hana", "ame", "sakana, uo", "-", "ushi", "uma, ma", "kai", "ki, ko", "chikara" };

        public int setRandomKanji;

        public bool opened = false;

        public NaturePage ()
		{
            InitializeComponent();

            Genrnd();

            kanjiCard.Clicked += NumCard_Clicked;
            nextBtn.Clicked += NextBtn_Clicked;
            resetBtn.Clicked += ResetBtnfornum_Clicked;
        }

        private void ResetBtnfornum_Clicked(object sender, EventArgs e)
        {
            kanji = new string[] { "天", "山", "川", "空", "花", "雨", "魚", "気", "牛", "馬", "貝", "木", "力" };
            kanjiimi = new string[] { "ท้องฟ้า/สวรรค์", "ภูเขา", "ลำธาร", "ท้องฟ้า/ว่างเปล่า", "ดอกไม้", "ฝน", "ปลา", "อากาศ/จิตใจ", "วัว", "ม้า", "หอย", "ต้นไม้", "พลัง" };
            onyomi = new string[] { "ten", "san", "sen", "kuu", "ka", "u", "syo", "ki, ke", "gyuu", "ba", "-", "moku, boku", "ryoku, riki" };
            kunyomi = new string[] { "ame, ama", "yama", "kawa", "sora, a(keru), kara", "hana", "ame", "sakana, uo", "-", "ushi", "uma, ma", "kai", "ki, ko", "chikara" };
        
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