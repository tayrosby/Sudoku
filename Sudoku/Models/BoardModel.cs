using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sudoku.Models
{
    public class BoardModel
    {
        public List<Cell> GameBoard { get; set; }

        public BoardModel()
        {
            GameBoard = new List<Cell>();
        }
    }
}