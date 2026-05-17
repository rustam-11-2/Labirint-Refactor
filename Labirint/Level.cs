using System;
using System.IO;
using System.Windows.Forms;

namespace Labirint
{
    public class Level
    {
        public string[] LvlRandomWord { get ; set; }
        public string[] LvlWord { get ; set; }
        public int PictureBoxCorrextIndex { get; set; }
        public string[] PictureBoxImages { get ; set; }
        public PictureBox[] PictureBoxes { get; set; }

        
        public void LoadLevel(int lvlName)
        {
            string[] lines = File.ReadAllLines($"GameLvls//lvl{lvlName}.txt");
            LvlRandomWord = lines[0].Split(' ');
            LvlWord = lines[3].Split(' ');
            PictureBoxCorrextIndex = Convert.ToInt32(lines[4]);
            PictureBoxImages = lines[5].Split(' ');

        }

       
    }
}
