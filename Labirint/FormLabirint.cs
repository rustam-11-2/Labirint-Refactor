using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Labirint
{
    public partial class FormLabirint : Form
    {
        SoundManager soundManager;
        Level level;
        string lvl;
        int countCorrectAnswer = 0;
        PictureBox[] pictureBoxes;

        public FormLabirint(int lev)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            level = new Level();
            level.LoadLevel(lev);
            soundManager = new SoundManager();
            lvl = $"lvl{lev}";
            pictureBoxes = this.Controls.OfType<PictureBox>().Reverse().ToArray(); ;
        }

        private void FormLabirint_Load(object sender, EventArgs e)
        {
            dataGridViewLabirint.RowTemplate.Height = 49;
            CreateField();
            ShowField();
            dataGridViewLabirint.ClearSelection();
            HidePicures();
            toolTip1.SetToolTip(labelToolTip, "Используйте ctrl");
        }

        void HidePicures()
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }

        void ShowField()
        {
            pictureBoxes[0].Image = Bitmap.FromFile($"ImagesMeaningsOfWords/{level.Data.PictureBoxImages[0]}.png");
            pictureBoxes[1].Image = Bitmap.FromFile($"ImagesMeaningsOfWords/{level.Data.PictureBoxImages[1]}.png");
            pictureBoxes[2].Image = Bitmap.FromFile($"ImagesMeaningsOfWords/{level.Data.PictureBoxImages[2]}.png");
            for(int j = 0; j < 5; j++)
            {
                dataGridViewLabirint.Rows[0].Cells[j].Value = Bitmap.FromFile($"Images/{level.Data.LvlRandomWord[j]}.png");
                dataGridViewLabirint.Rows[0].Cells[j].Tag = level.Data.LvlRandomWord[j];
                dataGridViewLabirint.Rows[1].Cells[j].Value = Bitmap.FromFile($"ImageThreadsTypeOne/{j + 1}.png");
                dataGridViewLabirint.Rows[2].Cells[j].Value = Bitmap.FromFile($"ImageThreadsTypeOne/{j + 6}.png");
                dataGridViewLabirint.Rows[3].Cells[j].Value = Bitmap.FromFile($"Images/6.png");
                dataGridViewLabirint.Rows[3].Cells[j].Tag = level.Data.LvlWord[j];
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
            if(objName == pictureBoxes[level.Data.PictureBoxCorrextIndex].Name)
                return true;
            else
                return false;
        }

        private void GetWin(object sender, EventArgs e)
        {
            Control clickObj = sender as Control;
            if (IsCorrectChoice(clickObj.Name))
            {
                soundManager.PlayCompletedLevel();
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
                    soundManager.PlayCorrect();
                    dataGridViewLabirint.Rows[selectedCellFirst.RowIndex].Cells[selectedCellFirst.ColumnIndex].Value = Bitmap.FromFile($"Images/{level.Data.LvlRandomWord[selectedCellSecond.ColumnIndex]}.png");
                    dataGridViewLabirint.ClearSelection();
                    if (countCorrectAnswer == 5)
                    {
                        dataGridViewLabirint.Enabled = false;
                        MessageBox.Show("Поздравляю!! Вы собрали слово полностью. А теперь отгадайте, что значит слово");
                        ShowPictures();
                    }
                }
                else
                {
                    soundManager.PlayWrong();
                    dataGridViewLabirint.ClearSelection();
                }
            }
        }

        void ShowPictures()
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormLevelSelect formLevel = new FormLevelSelect();
            this.Close();
            formLevel.Visible = true;
        }
    }
}
