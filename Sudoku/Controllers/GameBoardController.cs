using Sudoku.Models;
using Sudoku.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sudoku.Controllers
{
    public class GameBoardController : Controller
    {
        SudokuService sudoku = new SudokuService();
        PuzzleLoader load = new PuzzleLoader();
        PuzzleSaver save = new PuzzleSaver();
        // GET: GameBoard
        public ActionResult Index()
        {
            FullBoard board = new FullBoard() { GameBoard = sudoku.buildBoard() };
            int puzzleNumber;
            load.LoadNewPuzzle(board.GameBoard, out puzzleNumber);
            board.BoardNumber = puzzleNumber;
            return View("GameBoard", board);
        }

        public ActionResult UpdateGame(FullBoard board)
        {
            board.Status = sudoku.GetPuzzleStatus(board.GameBoard);
            return View("GameBoard", board);
        }

        public ActionResult SaveGame(FullBoard board)
        {
            save.SaveGame(board.GameBoard, board.BoardNumber);
            board.Status = sudoku.GetPuzzleStatus(board.GameBoard);
            return View("GameBoard", board);
        }

        public ActionResult LoadGame()
        {
            FullBoard board = new FullBoard() { GameBoard = sudoku.buildBoard() };
            int puzzleNumber;
            load.LoadSavedPuzzle(board.GameBoard, out puzzleNumber);
            board.Status = sudoku.GetPuzzleStatus(board.GameBoard);
            board.BoardNumber = puzzleNumber;
            return View("GameBoard", board);
        }
    }
}