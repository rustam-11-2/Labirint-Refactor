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
        PictureBox[] pictureBoxes;
        GameField gameField;
        Cell selectedLetter;

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
            OnOffPicures();
        }

        void OnOffPicures()
        {
            for(int i = 0; i < pictureBoxes.Length; i++)
                pictureBoxes[i].Visible = pictureBoxes[i].Visible == true ? false : true;
        }

        public void CreateField(DataGridView dG)
        {
            dG.Height = 5 * 40;
            dG.Width = 6 * 40;

            for (int i = 0; i < gameField.Level.LvlRandomWord.Length; i++)
            {
                var columns = new DataGridViewImageColumn();
                dG.Columns.Add(columns);
            }

            dG.RowCount = gameField.GAMEMATRIXROWCOUNT;
        }

        void ShowField(DataGridView dG, GameField f)
        {
            for (int i = 0; i < pictureBoxes.Length; i++)
                pictureBoxes[i].Image = Bitmap.FromFile($"ImagesMeaningsOfWords\\{gameField.Level.PictureBoxImages[i]}.png");

            for (int i = 0; i < gameField.GAMEMATRIXROWCOUNT; i++)
            {
                for(int j = 0; j < f.Level.LvlWord.Length; j++)
                {
                    if (gameField.Cells[i,j].Type == CellType.EmptyCell)
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

                Level.SaveProgress(lvl);
            }
            else
                MessageBox.Show("Почти отгадал. Но это слово значит что-то другое");
        }

        private void dataGridViewLabirint_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Rectangle rec = dataGridViewLabirint.GetCellDisplayRectangle(0, 0, false);
            MessageBox.Show($"{rec.Height} {rec.Width}");
            if (e.RowIndex == 1 || e.RowIndex == 2)
            { 
                dataGridViewLabirint.ClearSelection();
                return;
            }

            Cell cell = new Cell();
            cell = gameField.Cells[e.RowIndex, e.ColumnIndex];

            if(cell.Type == CellType.Letter)
            {
                selectedLetter = cell;
                return;
            }

            if(cell.Type == CellType.EmptyCell)
                if (selectedLetter == null)
                    return;

            if(gameField.CheckAnswer(selectedLetter, cell))
            {
                soundManager.PlayCorrect();
                dataGridViewLabirint.Rows[cell.Y].Cells[cell.X].Value = Resources.ResourceManager.GetObject(selectedLetter.Letter);

                if (gameField.AllLetterWasFind())
                {
                    dataGridViewLabirint.Enabled = false;
                    MessageBox.Show("Поздравляю!! Вы собрали слово полностью. А теперь отгадайте, что значит это слово");
                    OnOffPicures();
                }
            }
            else
                soundManager.PlayWrong();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            NewFormSelectLvl newFormSelectLvl = new NewFormSelectLvl();
            this.Close();
            newFormSelectLvl.Visible = true;
        }
    }
}
