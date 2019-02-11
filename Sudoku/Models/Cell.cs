using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sudoku.Models
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int? value { get; set; }
        public int blockNumber { get; set; }
        public bool marked { get; set; }

        public Cell()
        {
            value = null;
        }

    }
}