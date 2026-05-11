using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Labirint
{
    public class Level
    {
        public LevelData Data { get; private set; }

        public Level()
        {
            Data = new LevelData();
        }

        public void LoadLevel(int lvlName)
        {
            string[] lines = File.ReadAllLines($"GameLvls//lvl{lvlName}.txt");
            Data.LvlRandomWord = lines[0].Split(' ');
            Data.LvlWord = lines[3].Split(' ');
            Data.PictureBoxCorrextIndex = Convert.ToInt32(lines[4]);
            Data.PictureBoxImages = lines[5].Split(' ');
        }


    }
}
