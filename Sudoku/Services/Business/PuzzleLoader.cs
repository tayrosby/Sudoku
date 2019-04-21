using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Sudoku.Services.Business
{
    public class PuzzleLoader
    {
        public int RandomPuzzleNumber()
        {
            Random rnd = new Random();

            var xml = XDocument.Load(@"C:\Users\tay\source\repos\Sudoku\Sudoku\SudokuPuzzles.xml");

            int puzzleNB = rnd.Next(1, 9);
            return puzzleNB;
        }

        public void LoadPuzzleFromXML(int puzzleNumber, List<Cell> cellList)
        {
            var xml = XDocument.Load(@"C:\Users\tay\source\repos\Sudoku\Sudoku\SudokuPuzzles.xml");

            XElement x = xml.Descendants("Puzzle").First(b => (int)b.Element("Number") == puzzleNumber);
            LoadCellListFromPuzzleXElement(x, cellList);
        }

        public void LoadNewPuzzle(List<Cell> cellList, out int puzzleNumber)
        {
            puzzleNumber = RandomPuzzleNumber();
            LoadPuzzleFromXML(puzzleNumber, cellList);
        }

        private void LoadCellListFromPuzzleXElement(XElement puzzleXElement, List<Cell> cellList)
        {
            var y = puzzleXElement.Descendants("Cells").Descendants("Cell").ToList();
            y.ForEach(c => cellList[(int)c.Attribute("index")].value = (int?)c.Attribute("value"));
        }

        public void LoadSavedPuzzle(List<Cell> cellList, out int puzzleNumber)
        {
            var xml = XDocument.Load(@"C:\Users\tay\source\repos\Sudoku\Sudoku\SavedPuzzles.xml");
            XElement x = xml.Descendants("Puzzle").FirstOrDefault();
            puzzleNumber = (int)x.Element("Number");
            LoadCellListFromPuzzleXElement(x, cellList);
        }


    }
}