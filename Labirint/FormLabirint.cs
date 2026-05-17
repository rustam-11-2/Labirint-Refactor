using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Labirint.Properties;

namespace Labirint
{
    public partial class FormLabirint : Form
    {
        SoundManager soundManager;
        string lvl;
        int countCorrectAnswer = 0;
        PictureBox[] pictureBoxes;
        GameField gameField;

        public FormLabirint(int lev)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
            gameField = new GameField(lev);
            soundManager = new SoundManager();
            lvl = $"lvl{lev}";
            pictureBoxes = this.Controls.OfType<PictureBox>().Reverse().ToArray(); ;
        }

        private void FormLabirint_Load(object sender, EventArgs e)
        {
            dataGridViewLabirint.RowTemplate.Height = 49;
            CreateField(dataGridViewLabirint);
            ShowField(dataGridViewLabirint, gameField);
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
        public void CreateField(DataGridView dG)
        {
            dG.Height = 5 * 40;
            dG.Width = 6 * 40;

            for (int i = 0; i < 5; i++)
            {
                var columns = new DataGridViewImageColumn();
                columns.ImageLayout = DataGridViewImageCellLayout.Zoom;
               dG.Columns.Add(columns);
            }
            dG.RowCount = 4;
        }

        void ShowField(DataGridView dG, GameField f)
        {
            pictureBoxes[0].Image = Bitmap.FromFile($"ImagesMeaningsOfWords/{gameField.Level.PictureBoxImages[0]}.png");
            pictureBoxes[1].Image = Bitmap.FromFile($"ImagesMeaningsOfWords/{gameField.Level.PictureBoxImages[1]}.png");
            pictureBoxes[2].Image = Bitmap.FromFile($"ImagesMeaningsOfWords/{gameField.Level.PictureBoxImages[2]}.png");

            for (int i = 0; i < GameField.GAMEMATRIXROWCOUNT; i++)
            {
                for(int j = 0; j < f.Level.LvlWord.Length; j++)
                {
                    if (gameField.Cells[i,j].Type == CellType.LetterButInvis)
                        dG.Rows[i].Cells[j].Value = Resources.emptyCell;
                    else
                        dG.Rows[i].Cells[j].Value = Resources.ResourceManager.GetObject(f.Matrix(i, j));
                }
            }       
        }

        bool IsCorrectChoice(string objName)
        {
            if(objName == pictureBoxes[gameField.Level.PictureBoxCorrextIndex].Name)
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

            MessageBox.Show(gameField.Cells[e.RowIndex, e.ColumnIndex].Type.ToString() + e.RowIndex + e.ColumnIndex );
            if (dataGridViewLabirint.SelectedCells.Count == 2)
            {
                var selectedCellFirst = dataGridViewLabirint.SelectedCells[0];
                var selectedCellSecond = dataGridViewLabirint.SelectedCells[1];

                int rowIndFirst = selectedCellFirst.RowIndex;
                int colIndFirst = selectedCellFirst.ColumnIndex;

                int rowIndSec = selectedCellSecond.RowIndex;
                int colIndSec = selectedCellSecond.ColumnIndex;

                if (gameField.Cells[rowIndFirst, colIndFirst].Type == CellType.Letter && ( gameField.Matrix(rowIndFirst, colIndFirst) == gameField.Matrix(rowIndSec, colIndSec)) && (rowIndFirst != rowIndSec))
                {
                    countCorrectAnswer++;
                    soundManager.PlayCorrect();
                    dataGridViewLabirint.Rows[rowIndFirst].Cells[colIndFirst].Value = Resources.ResourceManager.GetObject(gameField.Matrix(rowIndFirst, colIndFirst));
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
