using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Labirint
{
    public partial class CreateNewLevelForm : Form
    {
        PictureBox[] pictureBoxes;
        RadioButton[] radioButtons;
        List<string> imageNames;
        public CreateNewLevelForm()
        {
            InitializeComponent();
            imageNames = new List<string>();
            radioButtons = this.Controls.OfType<RadioButton>().Reverse().ToArray();
            pictureBoxes = this.Controls.OfType<PictureBox>().Reverse().ToArray();
        }

        string[] ShuffleStringTypeOne(string[] word)
        {
            (word[0], word[4]) = (word[4], word[0]);
            (word[1], word[2]) = (word[2], word[1]);

            return word;
        }
        string[] ShuffleStringTypeTwo(string[] word)
        {
            (word[0], word[5]) = (word[5], word[0]);
            (word[1], word[3]) = (word[3], word[1]);
            (word[2], word[4]) = (word[4], word[2]);


            return word;
        }
        string[] ShuffleStringTypeThree(string[] word)
        {
            (word[0], word[6]) = (word[6], word[0]);
            (word[1], word[3]) = (word[3], word[1]);
            (word[4], word[5]) = (word[5], word[4]);

            return word;
        }

        void CreateNewLvl()
        {
            int countLvl = Directory.GetFiles(@"GameLvls").Length;
            
            string rowTwo = "";
            string rowThree = "";
            string symbols = textBoxAnswer.Text;

            if (!string.IsNullOrEmpty(symbols))
            {
                string[] answer = symbols.Split();

                string[] randomWord = new string[answer.Length];
                switch (answer.Length)
                {
                    case 5: randomWord = ShuffleStringTypeOne(answer); answer = symbols.Split(); rowTwo = "1 2 3 4 5"; rowThree = "6 7 8 9 10"; break;
                    case 6: randomWord = ShuffleStringTypeTwo(answer); answer = symbols.Split(); rowTwo = "1 2 3 4 5 6"; rowThree = "7 8 9 10 11 12"; break;
                    case 7: randomWord = ShuffleStringTypeThree(answer); answer = symbols.Split(); rowTwo = "1 2 3 4 5 6 7"; rowThree = "8 9 10 11 12 13 14"; break;
                }

                File.AppendAllText(@$"GameLvls\\lvl{countLvl}.txt", string.Join(" ", randomWord) + Environment.NewLine);
                File.AppendAllText(@$"GameLvls\\lvl{countLvl}.txt", rowTwo + Environment.NewLine);
                File.AppendAllText(@$"GameLvls\\lvl{countLvl}.txt", rowThree + Environment.NewLine);
                File.AppendAllText(@$"GameLvls\\lvl{countLvl}.txt", string.Join(" ", answer) + Environment.NewLine);


                for(int i = 0; i < 3; i++)
                {
                    if (radioButtons[i].Checked)
                    {
                        File.AppendAllText(@$"GameLvls\\lvl{countLvl}.txt", radioButtons[i].Tag.ToString() + Environment.NewLine);
                        break;
                    }
                }

                for(int i = 0; i < 3; i++)
                {
                    imageNames.Add(pictureBoxes[i].Name);
                }
                File.AppendAllText(@$"GameLvls\\lvl{countLvl}.txt", string.Join(" ", imageNames) + Environment.NewLine);
                imageNames.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNewLvl(); 
        }

        private void buttonSaveImageFirst_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            openFileDialog1.Filter = "Изображения (*.png)|*.png";
            openFileDialog1.FileName = "";
            int indPicBox = Convert.ToInt32(btn.Tag.ToString());

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string destFileName = $"ImagesMeaningsOfWords\\{openFileDialog1.SafeFileName}";
                File.Copy(openFileDialog1.FileName, destFileName, true);
                pictureBoxes[indPicBox].Image = Bitmap.FromFile(destFileName);
                pictureBoxes[indPicBox].Name = openFileDialog1.SafeFileName;
                //string fileName = openFileDialog1.SafeFileName;
                //imageNames.Add(fileName);
            }
        }
    }
}
