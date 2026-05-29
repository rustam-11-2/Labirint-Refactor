using System;
using System.Collections.Generic;

namespace Labirint
{
    public class GameField
    {
        public int GAMEMATRIXROWCOUNT { get { return 4; } }
        
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
                    Cells[i, j].X = j;
                    Cells[i, j].Y = i;
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
                Cells[3, i].Type = CellType.EmptyCell;
            }
        }

        public string Matrix(int x, int y)
        {
            return Cells[x, y].Letter;
        }

        public bool CheckAnswer(Cell selectedLetter, Cell answer)
        {
            if(selectedLetter.Letter == answer.Letter)
            {
                Cells[answer.Y, answer.X].Type = CellType.Letter;
                return true;
            }
            return false;
        }

        public bool AllLetterWasFind()
        {
            int count = 0;

            for(int i = 0; i < gameMatrixColumnCount; i++)
                if (Cells[3,i].Type == CellType.Letter)
                    count++;

            if(count == gameMatrixColumnCount)
                return true;
            return false;
        }
    }
}
