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
        PuzzleLoader puzzle = new PuzzleLoader();
        // GET: GameBoard
        public ActionResult Index()
        {
            FullBoard board = new FullBoard() { GameBoard = SudokuService.buildBoard() };
            int puzzleNumber;
            puzzle.LoadNewPuzzle(board.GameBoard, out puzzleNumber);
            board.BoardNumber = puzzleNumber;
            return View("GameBoard", board);
        }
    }
}