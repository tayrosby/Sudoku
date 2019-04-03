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

        private static bool IsPuzzleValid(List<Cell> cellList)
        {
            bool isValid = AreRowsValid(cellList);
            isValid &= AreColumnsValid(cellList);
            isValid &= AreBlocksValid(cellList);

            return isValid;
        }

        private static bool AreRowsValid(List<Cell> cellList)
        {
            bool isValid = true;

            cellList.GroupBy(c => c.Row).Select(g => g.ToList()).ToList().ForEach(s => isValid &= IsValueUniqueInSet(s));

            return isValid;
        }

        private static bool AreColumnsValid(List<Cell> cellList)
        {
            bool isValid = true;

            cellList.GroupBy(c => c.Column).Select(g => g.ToList()).ToList().ForEach(s => isValid &= IsValueUniqueInSet(s));

            return isValid;
        }

        private static bool AreBlocksValid(List<Cell> cellList)
        {
            bool isValid = true;

            cellList.GroupBy(c => c.blockNumber).Select(g => g.ToList()).ToList().ForEach(s => isValid &= IsValueUniqueInSet(s));

            return isValid;
        }

        private static bool IsValueUniqueInSet(List<Cell> cellGroup)
        {
            return cellGroup.Where(c => c.value.HasValue).GroupBy(c => c.value.Value).All(g => g.Count() <= 1);
        }
    }
}