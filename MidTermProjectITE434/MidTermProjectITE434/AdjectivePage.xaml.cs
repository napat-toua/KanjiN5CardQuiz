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
	public partial class AdjectivePage : ContentPage
	{
        public string[] kanji = { "何", "古", "多", "大", "安", "少", "新", "白", "小", "早", "高", "長" };
        public string[] kanjiimi = { "อะไร/สิ่งไหน", "เก่า", "มาก", "ใหญ่", "สงบ/ถูก", "น้อย/เล็กน้อย", "ใหม่", "ขาว", "เล็ก", "เร็ว", "สูง/แพง", "ยาว/นาน" };
        public string[] onyomi = { "ka", "ko", "ta", "dat, tai", "an", "shou", "shin", "haku, byaku", "shou", "sou", "kou", "chou" };
        public string[] kunyomi = { "nani", "furu(i)", "oo(i)", "ou(kii), oo(i)", "yasu(i)", "suko(shi), saku(nai)", "atara(shi), ara(ta), nii-", "shiro(i), shiro", "chii(sai), ko-, o-", "haya(i)", "taka(i), taka(maru), taka(meru)", "naga(i)" };

        public int setRandomKanji;

        public bool opened = false;

        public AdjectivePage ()
		{
            InitializeComponent();

            Genrnd();

            kanjiCard.Clicked += NumCard_Clicked;
            nextBtn.Clicked += NextBtn_Clicked;
            resetBtn.Clicked += ResetBtnfornum_Clicked;
        }

        private void ResetBtnfornum_Clicked(object sender, EventArgs e)
        {
            kanji = new string[] { "何", "古", "多", "大", "安", "少", "新", "白", "小", "早", "高", "長" };
            kanjiimi = new string[] { "อะไร/สิ่งไหน", "เก่า", "มาก", "ใหญ่", "สงบ/ถูก", "น้อย/เล็กน้อย", "ใหม่", "ขาว", "เล็ก", "เร็ว", "สูง/แพง", "ยาว/นาน" };
            onyomi = new string[] { "ka", "ko", "ta", "dat, tai", "an", "shou", "shin", "haku, byaku", "shou", "sou", "kou", "chou" };
            kunyomi = new string[] { "nani", "furu(i)", "oo(i)", "ou(kii), oo(i)", "yasu(i)", "suko(shi), saku(nai)", "atara(shi), ara(ta), nii-", "shiro(i), shiro", "chii(sai), ko-, o-", "haya(i)", "taka(i), taka(maru), taka(meru)", "naga(i)" };

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