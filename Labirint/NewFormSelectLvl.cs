using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Labirint
{
    public partial class NewFormSelectLvl : Form
    {
        public NewFormSelectLvl()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void buttonlvl1_Click(object sender, EventArgs e)
        {
            Control button = sender as Control;
            this.Hide();
            FormLabirint formLabirint = new FormLabirint(int.Parse(button.Text));
            formLabirint.Show();
        }

        private void NewFormSelectLvl_Load(object sender, EventArgs e)
        {

            int countLevels = Directory.GetFiles("GameLvls").Length-1;

            string progressFile = @"GameLvls\\progress.txt";
            string[] completedLevels = new string[0];

            if (File.Exists(progressFile))
            {
                completedLevels = File.ReadAllLines(progressFile);

                for (int i = 1; i <= countLevels; i++)
                {
                    Button btn = new Button();
                    btn.TabStop = false;
                    btn.Size = new Size(50, 50);
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.Text = i.ToString();
                    btn.Tag = $"lvl{i}";
                    btn.Click += buttonlvl1_Click;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = Color.White;
                    btn.Font = new Font("Century", 12);
                    for (int j = 0; j < completedLevels.Length; j++)
                    {
                        if (btn.Tag.ToString() == completedLevels[j])
                        {
                            btn.BackColor = Color.LightGreen;
                            break;
                        }
                    }
                    flowLayoutPanelLvls.Controls.Add(btn);
                }
            }
        }

        private void buttonBackToMenu_Click(object sender, EventArgs e)
        {
            GameMainMenu gameMainMenu = new GameMainMenu();
            this.Close();
            gameMainMenu.Show();
        }
    }
}
