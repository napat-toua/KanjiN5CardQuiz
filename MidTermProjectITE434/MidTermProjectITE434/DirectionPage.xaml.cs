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
	public partial class DirectionPage : ContentPage
	{
        public string[] kanji = { "上","下","中","右","西","東","前","後","左","北","南","外","先","間" };
        public string[] kanjiimi = { "บน/ขึ้น", "ล่าง/ลง", "ข้างใน/กลาง/จีน", "ขวา", "ทิศตะวันตก", "ทิศตะวันออก", "ข้างหน้า", "หลัง", "ซ้าย", "ทิศเหนือ", "ทิศใต้", "ข้างนอก/เอาออก", "ก่อน", "ระหว่าง/ช่วงเวลา" };
        public string[] onyomi = { "shou, jou", "ka, ge", "chuu", "u, yuu", "sei, sai", "tou", "zen", "go, kou", "sa", "hoku", "nan", "gai, ge", "sen", "kan, ken" };
        public string[] kunyomi = { "ue, kami, a(geru), (garu)", "shimo, sa(geru), o(rosu), ku(daru)", "naka", "migi", "nishi", "higashi", "mae", "ato, oku(reru), nochi", "hidari", "kita", "minami", "sota, hoka, hazu(reru), hazu(ru)", "saki", "aida" };

        public int setRandomKanji;

        public bool opened = false;

        public DirectionPage ()
		{
            InitializeComponent();

            Genrnd();

            kanjiCard.Clicked += NumCard_Clicked;
            nextBtn.Clicked += NextBtn_Clicked;
            resetBtn.Clicked += ResetBtnfornum_Clicked;
        }

        private void ResetBtnfornum_Clicked(object sender, EventArgs e)
        {
            kanji = new string[] { "上", "下", "中", "右", "西", "東", "前", "後", "左", "北", "南", "外", "先", "間" };
            kanjiimi = new string[] { "บน/ขึ้น", "ล่าง/ลง", "ข้างใน/กลาง/จีน", "ขวา", "ทิศตะวันตก", "ทิศตะวันออก", "ข้างหน้า", "หลัง", "ซ้าย", "ทิศเหนือ", "ทิศใต้", "ข้างนอก/เอาออก", "ก่อน", "ระหว่าง/ช่วงเวลา" };
            onyomi = new string[] { "shou, jou", "ka, ge", "chuu", "u, yuu", "sei, sai", "tou", "zen", "go, kou", "sa", "hoku", "nan", "gai, ge", "sen", "kan, ken" };
            kunyomi = new string[] { "ue, kami, a(geru), (garu)", "shimo, sa(geru), o(rosu), ku(daru)", "naka", "migi", "nishi", "higashi", "mae", "ato, oku(reru), nochi", "hidari", "kita", "minami", "sota, hoka, hazu(reru), hazu(ru)", "saki", "aida" };

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