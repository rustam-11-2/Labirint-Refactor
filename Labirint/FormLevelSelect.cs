using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Labirint
{
    public partial class FormLevelSelect : Form
    {
        Button[] buttons;
        public FormLevelSelect()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            buttons = tableLayoutPanelLevels.Controls.OfType<Button>().ToArray();
        }

        private void buttonlvl1_Click(object sender, EventArgs e)
        {
            Control button = sender as Control;
            this.Hide();
            FormLabirint formLabirint = new FormLabirint(button.TabIndex+1);
            formLabirint.Show();
        }

        private void buttonBackToMenu_Click(object sender, EventArgs e)
        {
            GameMainMenu gameMainMenu = new GameMainMenu();
            this.Close();
            gameMainMenu.Show();
        }

        private void FormLevelSelect_Load(object sender, EventArgs e)
        {
            labelLvl.BackColor = Color.Transparent;
            string progressFile = @"GameLvls\\progress.txt";
            string[] completedLevels = new string[0];

            if (File.Exists(progressFile))
                completedLevels = File.ReadAllLines(progressFile);

            for(int i = 0; i<completedLevels.Length; i++)
            {
                string levelName = completedLevels[i];
                for(int j = 0; j < buttons.Length; j++)
                {
                    if (buttons[j].Tag.ToString() == levelName)
                    {
                        buttons[j].Text += " ✔";
                        buttons[j].BackColor = Color.LightGreen;
                        break;
                    }
                }
            }
        }
    }
}
