using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirint
{
    public class LevelData
    {
        string[] lvlRandomWord;
        string[] lvlWord;
        int pictureBoxCorrextIndex;
        string[] pictureBoxImages;
        PictureBox[] pictureBoxes;

        public string[] LvlRandomWord { get; set; }
        public string[] LvlWord { get; set; }
        public int PictureBoxCorrextIndex { get; set; }
        public string[] PictureBoxImages { get; set; }
        public PictureBox[] PictureBoxes { get; set; }
    }
}
