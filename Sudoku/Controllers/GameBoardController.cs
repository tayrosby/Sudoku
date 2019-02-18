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
        // GET: GameBoard
        public ActionResult Index()
        {
            FullBoard board = new FullBoard() { GameBoard = SudokuService.buildBoard() };
            
            return View("GameBoard", board);
        }
    }
}