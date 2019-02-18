using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sudoku.Models
{
    public class FullBoard
    {
        public List<Cell> GameBoard{ get; set; }
        public int BoardNumber { get; set; }

        public FullBoard()
        {
            GameBoard = new List<Cell>();
        }
    }
}