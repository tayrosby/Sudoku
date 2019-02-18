using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sudoku.Services.Business
{
    public class SudokuService
    {
        static public List<Cell> buildBoard()
        {
            List<Cell> board = new List<Cell>();

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    Cell newCell = new Cell()
                    {
                        Row = x + 1,
                        Column = y + 1,
                        blockNumber = 3 * (x / 3) + (y / 3) + 1
                    };
                    board.Add(newCell);
                }
            }

            return board;
        }
    }
}