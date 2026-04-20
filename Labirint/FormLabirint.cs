using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Labirint
{
    public partial class FormLabirint : Form
    {
        SoundPlayer completedLevel;
        SoundPlayer corChoice;
        SoundPlayer wrongChoice;
        string lvl;
        string[] lvlRandomWord; 
        string[] lvlWord;
        int countCorrectAnswer = 0;
        string[] lines;
        PictureBox[] pictureBoxes;
        int pictureBoxCorrextIndex;
        string[] pictureBoxImages;

        public FormLabirint(int level)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            lvl = $"lvl{level}";
            pictureBoxes = this.Controls.OfType<PictureBox>().Reverse().ToArray(); ;
        }

        private void FormLabirint_Load(object sender, EventArgs e)
        {
            completedLevel = new SoundPlayer("Sounds//soundFinishedLevel.wav");
            corChoice = new SoundPlayer("Sounds//correct_choice.wav");
            wrongChoice = new SoundPlayer("Sounds//wrong_choice.wav");
            dataGridViewLabirint.RowTemplate.Height = 49;
            LoadLevel();
            CreateField();
            ShowField();
            dataGridViewLabirint.ClearSelection();
            //ToolTip toolTipDataGridView = new ToolTip();
            //toolTipDataGridView.SetToolTip(dataGridViewLabirint, "Зажмите ctrl чтобы выбрать 2 ячейки");
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            toolTip1.SetToolTip(labelToolTip, "Используйте ctrl");
        }

        void LoadLevel()
        {
            lines = File.ReadAllLines($"GameLvls//{lvl}.txt");
            lvlRandomWord = lines[0].Split(' ');
            lvlWord = lines[3].Split(' ');
            pictureBoxCorrextIndex = Convert.ToInt32(lines[4]);
            pictureBoxImages = lines[5].Split(' ');
        } 

        void ShowField()
        {
            for(int i = 0; i < 1; i++)
            {
                pictureBoxes[i].Image = Bitmap.FromFile($"ImagesMeaningsOfWords/{pictureBoxImages[i]}.png");
                pictureBoxes[i+1].Image = Bitmap.FromFile($"ImagesMeaningsOfWords/{pictureBoxImages[i+1]}.png");
                pictureBoxes[i+2].Image = Bitmap.FromFile($"ImagesMeaningsOfWords/{pictureBoxImages[i+2]}.png");
                for(int j = 0; j < 5; j++)
                {
                    dataGridViewLabirint.Rows[i].Cells[j].Value = Bitmap.FromFile($"Images/{lvlRandomWord[j]}.png");
                    dataGridViewLabirint.Rows[i].Cells[j].Tag = lvlRandomWord[j];
                    dataGridViewLabirint.Rows[i+1].Cells[j].Value = Bitmap.FromFile($"ImageThreadsTypeOne/{j + 1}.png");
                    dataGridViewLabirint.Rows[i+2].Cells[j].Value = Bitmap.FromFile($"ImageThreadsTypeOne/{j + 6}.png");
                    dataGridViewLabirint.Rows[i+3].Cells[j].Value = Bitmap.FromFile($"Images/6.png");
                    dataGridViewLabirint.Rows[i+3].Cells[j].Tag = lvlWord[j];
                }
            }

        }

        void CreateField()
        {
            dataGridViewLabirint.Height = 5 * 40;
            dataGridViewLabirint.Width = 6 * 40;

            for (int i = 0; i < 5; i++)
            {
                var columns = new DataGridViewImageColumn();
                columns.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dataGridViewLabirint.Columns.Add(columns);
            }
            dataGridViewLabirint.RowCount = 4;
        }

        bool IsCorrectChoice(string objName)
        {
            if(objName == pictureBoxes[pictureBoxCorrextIndex].Name)
                return true;
            else
                return false;
        }

        private void GetWin(object sender, EventArgs e)
        {
            Control clickObj = sender as Control;
            if (IsCorrectChoice(clickObj.Name))
            {
                completedLevel.Play();
                MessageBox.Show("Ты большой молодец!!. Ты правильно отгадал значение этого слова");

                string progressFile = @"GameLvls\\progress.txt";

                string[] completed = File.ReadAllLines(progressFile);
                if (!completed.Contains(lvl))
                    File.AppendAllText(progressFile, lvl + Environment.NewLine);
            }
            else
                MessageBox.Show("Почти отгадал. Но это слово значит что-то другое");
        }

        private void dataGridViewLabirint_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 1 || e.RowIndex == 2)
                dataGridViewLabirint.ClearSelection();
            if (dataGridViewLabirint.SelectedCells.Count == 2)
            {
                var selectedCellFirst = dataGridViewLabirint.SelectedCells[0];
                var selectedCellSecond = dataGridViewLabirint.SelectedCells[1];

                if ((selectedCellFirst.Tag.ToString() == selectedCellSecond.Tag.ToString()) && (selectedCellFirst.RowIndex != selectedCellSecond.RowIndex) )
                {
                    countCorrectAnswer++;
                    corChoice.Play();
                    dataGridViewLabirint.Rows[selectedCellFirst.RowIndex].Cells[selectedCellFirst.ColumnIndex].Value = Bitmap.FromFile($"Images/{lvlRandomWord[selectedCellSecond.ColumnIndex]}.png");
                    dataGridViewLabirint.ClearSelection();
                    if (countCorrectAnswer == 5)
                    {
                        dataGridViewLabirint.Enabled = false;
                        MessageBox.Show("Поздравляю!! Вы собрали слово полностью. А теперь отгадайте, что значит слово");
                        pictureBox1.Visible = true;
                        pictureBox2.Visible = true;
                        pictureBox3.Visible = true;
                    }
;
                }
                else
                {
                    wrongChoice.Play();
                    dataGridViewLabirint.ClearSelection();
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormLevelSelect formLevel = new FormLevelSelect();
            this.Close();
            formLevel.Visible = true;
        }

        
    }
}
