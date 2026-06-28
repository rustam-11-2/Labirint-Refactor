using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Labirint
{
    public partial class CreateNewLevelForm : Form
    {
        public CreateNewLevelForm()
        {
            InitializeComponent();
        }

        string ShuffleStringTypeOne(string word)
        {
            char[] chars = word.ToCharArray();

            (chars[0], chars[4]) = (chars[4], chars[0]);
            (chars[1], chars[2]) = (chars[2], chars[1]);

            return new string(chars);
        }

        void CreateNewLvl()
        {
            int countLvl = Directory.GetFiles(@"GameLvls").Length;
            string answer = textBoxAnswer.Text;
            if (!string.IsNullOrEmpty(answer))
            {
                string randomWord = "";
                switch (answer.Length)
                {
                    case 5: randomWord = ShuffleStringTypeOne(answer); break;
                }

                File.AppendAllText(@$"GameLvls\\lvl{countLvl}.txt", string.Join(" ", randomWord) + Environment.NewLine);
                File.AppendAllText(@$"GameLvls\\lvl{countLvl}.txt", answer + Environment.NewLine);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNewLvl(); 
        }

        private void buttonSaveImageFirst_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Изображения (*.png)|*.png";
            openFileDialog1.FileName = "";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string destFileName = $"ImagesMeaningsOfWords\\{openFileDialog1.SafeFileName}";
                File.Copy(openFileDialog1.FileName, destFileName, true);
                pictureBox1.Image = Bitmap.FromFile(destFileName);
            }
        }
    }
}
