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
        public string[] PictureBoxImagesName { get ; set; }
        public PictureBox[] PictureBoxes { get; set; }
        public int LevelType { get; private set; }

        
        public void LoadLevel(int lvlName)
        {
            string[] lines = File.ReadAllLines($"GameLvls//lvl{lvlName}.txt");
            LvlRandomWord = lines[0].TrimEnd().Split();
            LvlWord = lines[3].TrimEnd().Split();
            PictureBoxCorrextIndex = Convert.ToInt32(lines[4].TrimEnd());
            PictureBoxImagesName = lines[5].TrimEnd().Split();
            LevelType = GetLevelType(LvlWord);
        }

        private int GetLevelType(string[] word)
        {
            switch (word.Length)
            {
                case 5: return 1; 
                case 6: return 2;
                case 7: return 3;
            }
            return 0;
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
