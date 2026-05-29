using System;
using System.IO;
using System.Linq;
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
            LvlRandomWord = lines[0].TrimEnd().Split();
            LvlWord = lines[3].TrimEnd().Split();
            PictureBoxCorrextIndex = Convert.ToInt32(lines[4].TrimEnd());
            PictureBoxImages = lines[5].TrimEnd().Split();

        }

        public static void SaveProgress(string lvl)
        {
            string progressFile = @"GameLvls\\progress.txt";

            string[] completed = File.ReadAllLines(progressFile);
            if (!completed.Contains(lvl))
                File.AppendAllText(progressFile, lvl + Environment.NewLine);
        }
       
    }
}
