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
	public partial class VerbPage : ContentPage
	{
        public string[] kanji = { "会", "入", "出", "書", "行", "聞", "見", "言", "読", "話", "買", "来", "立", "食", "飲", "生", "休" };
        public string[] kanjiimi = { "พบเจอ", "เข้า", "ออก", "เขียน", "ไป/จัดขึ้น/ดำเนินการ", "ฟัง/ได้ยิน", "มอง/ดู/เห็น", "พูด", "อ่าน", "พูดคุย/เรื่องราว", "ซื้อ", "มา/อนาคต", "ยืน/ลุก", "กิน", "ดื่ม", "เกิด/มีชีวิต/ดิบ/สด", "พัก" };
        public string[] onyomi = { "kai, e", "nyuu", "shutsu", "sho", "kou", "bun, mon", "ken", "gen, gon", "doku", "wa", "bai", "rai", "ritsu", "shoku", "in", "sei, shou", "kyuu" };
        public string[] kunyomi = { "a(u)", "hai(ru), i(ru), i(reru)", "da(su), de(ru)", "ka(ku)", "i(ku), yu(ku), okona(u)", "ki(ku), ki(koeru)", "mi(ru), mi(eru), mi(seru)", "i(u)", "yo(mu)", "hanashi, hana(su)", "ka(u)", "ku(ru), kita(ru), kita(su)", "ta(tsu), ta(teru)", "ta(beru), ku(ru), ku(rau)", "no(mu)", "i(kuru), u(mu), ha(yasu), nama, ki", "yasu(mu)" };

        public int setRandomKanji;

        public bool opened = false;

        public VerbPage ()
		{
            InitializeComponent();

            Genrnd();

            kanjiCard.Clicked += NumCard_Clicked;
            nextBtn.Clicked += NextBtn_Clicked;
            resetBtn.Clicked += ResetBtnfornum_Clicked;
        }

        private void ResetBtnfornum_Clicked(object sender, EventArgs e)
        {
            kanji = new string[] { "会", "入", "出", "書", "行", "聞", "見", "言", "読", "話", "買", "来", "立", "食", "飲", "生", "休" };
            kanjiimi = new string[] { "พบเจอ", "เข้า", "ออก", "เขียน", "ไป/จัดขึ้น/ดำเนินการ", "ฟัง/ได้ยิน", "มอง/ดู/เห็น", "พูด", "อ่าน", "พูดคุย/เรื่องราว", "ซื้อ", "มา/อนาคต", "ยืน/ลุก", "กิน", "ดื่ม", "เกิด/มีชีวิต/ดิบ/สด", "พัก" };
            onyomi = new string[] { "kai, e", "nyuu", "shutsu", "sho", "kou", "bun, mon", "ken", "gen, gon", "doku", "wa", "bai", "rai", "ritsu", "shoku", "in", "sei, shou", "kyuu" };
            kunyomi = new string[] { "a(u)", "hai(ru), i(ru), i(reru)", "da(su), de(ru)", "ka(ku)", "i(ku), yu(ku), okona(u)", "ki(ku), ki(koeru)", "mi(ru), mi(eru), mi(seru)", "i(u)", "yo(mu)", "hanashi, hana(su)", "ka(u)", "ku(ru), kita(ru), kita(su)", "ta(tsu), ta(teru)", "ta(beru), ku(ru), ku(rau)", "no(mu)", "i(kuru), u(mu), ha(yasu), nama, ki", "yasu(mu)" };

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