using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Sudoku.Services.Business
{
    public class PuzzleSaver
    {
        public void SaveGame(List<Cell> cellList, int puzzleNumber)
        {
            XDocument savedGame = InitializeSavedGameXDoc();
            savedGame.Save(@"C:\Users\tay\source\repos\Sudoku\Sudoku\SavedPuzzles.xml");

            SavePuzzle(cellList, savedGame, puzzleNumber);

        }

        public void SavePuzzleSetup(List<Cell> cellList, ref int puzzleNumber)
        {
            var xml = XDocument.Load(@"C:\Users\tay\source\repos\Sudoku\Sudoku\SavedPuzzles.xml");

            bool puzzleExists = (puzzleNumber > 0);
                if (puzzleExists)
                {
                    OverwritePuzzle(cellList, xml, puzzleNumber);
                }
                else
                {
                    puzzleNumber = FindNextAvailablePuzzleNumber(xml);
                    SavePuzzle(cellList, xml, puzzleNumber);
                }
        }

        private XDocument InitializeSavedGameXDoc()
        {
            XDocument savedGameXDoc = new XDocument();
            savedGameXDoc.Declaration = new XDeclaration("1.0", "utf-8", "true");
            savedGameXDoc.Add(new XElement("SudokuPuzzles"));

            return savedGameXDoc;
        }

        private void OverwritePuzzle(List<Cell> cellList, XDocument puzzleSetupXDoc, int puzzleNumber)
        {
            XElement cellsXElement = puzzleSetupXDoc.Descendants("Puzzle").First(b => (int)b.Element("Number") == puzzleNumber).Element("Cells");
            cellsXElement.ReplaceWith(CreateCells(cellList));

            puzzleSetupXDoc.Save(@"C:\Users\tay\source\repos\Sudoku\Sudoku\SavedPuzzles.xml");
        }

        private int FindNextAvailablePuzzleNumber(XDocument existingPuzzleXDoc)
        {
            return existingPuzzleXDoc.Descendants("Puzzle").Max(b => (int)b.Element("Number")) + 1;
        }

        private static void SavePuzzle(List<Cell> cellList, XDocument saveXDoc, int puzzleNumber)
        {
            saveXDoc.Element("SudokuPuzzles").Add(
                new XElement("Puzzle",
                    new XElement("Number", puzzleNumber),
                    CreateCells(cellList)));

            saveXDoc.Save(@"C:\Users\tay\source\repos\Sudoku\Sudoku\SavedPuzzles.xml");
        }

        private static XElement CreateCells(List<Cell> cellList)
        {
            return new XElement("Cells",
                cellList.Select((c, i) => c.value.HasValue ?
                                          new XElement("Cell", new XAttribute("index", i), new XAttribute("value", c.value.Value)) :
                                          null));
        }
    }
}