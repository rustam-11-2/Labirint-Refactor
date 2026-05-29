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
        }

        private void NewFormSelectLvl_Load(object sender, EventArgs e)
        {
            int countLevels = Directory.GetFiles("GameLvls", ".txt").Length; ;
        }
    }
}
