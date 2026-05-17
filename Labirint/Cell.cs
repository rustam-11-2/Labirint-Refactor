using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirint
{
    public enum CellType
    {
        Letter,
        Thread,
        LetterButInvis
    }

    public class Cell
    {
        public string Letter { get; set; }

        public CellType Type { get; set; }
    }
}
