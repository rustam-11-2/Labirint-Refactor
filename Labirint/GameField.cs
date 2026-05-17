using System;
using System.Collections.Generic;

namespace Labirint
{
    public class GameField
    {
        public const int GAMEMATRIXROWCOUNT = 4;
        int gameMatrixColumnCount;
        
        public Cell[,] Cells;
        public Level Level { get; private set; }

        public GameField(int lvl)
        {
            Level = new Level();
            Level.LoadLevel(lvl);

            gameMatrixColumnCount = Level.LvlRandomWord.Length;
            Cells = new Cell[GAMEMATRIXROWCOUNT, gameMatrixColumnCount];

            FixMatrix();
            CreateMatrix();
        }

        void FixMatrix()
        {
            for (int i = 0; i < GAMEMATRIXROWCOUNT; i++)
            {
                for(int j = 0; j < gameMatrixColumnCount; j++)
                {
                    Cells[i, j] = new Cell();
                }
            }

        }
        
        void CreateMatrix()
        {
            for(int i = 0; i < gameMatrixColumnCount; i++)
            {
                Cells[0, i].Letter = Level.LvlRandomWord[i];
                Cells[0, i].Type = CellType.Letter;
                Cells[1, i].Letter = $"{i+1}";
                Cells[1, i].Type = CellType.Thread;
                Cells[2, i].Letter = $"{i+1 + gameMatrixColumnCount}";
                Cells[2, i].Type = CellType.Thread;
                Cells[3, i].Letter = Level.LvlWord[i];
                Cells[3, i].Type = CellType.LetterButInvis;
            }
        }

        public string Matrix(int x, int y)
        {
            return Cells[x, y].Letter;
        }
    }
}
