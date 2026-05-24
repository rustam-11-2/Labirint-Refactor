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
        EmptyCell
    }

    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Letter { get; set; }

        public CellType Type { get; set; }
    }
}
