using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using TicTacToe.Models;


namespace TicTacToe.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index(TicTacToeModel game)
        {
            // if game is in progress (not a new game) - set game model values with
            // session variables (this prevents the game from resetting and the resubmission
            // message from appearing if the user refreshes their browser) 
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Player"))) 
            {
                game.Player = HttpContext.Session.GetString("Player");
                game.Cells[0] = HttpContext.Session.GetString("Cell0");
                game.Cells[1] = HttpContext.Session.GetString("Cell1");
                game.Cells[2] = HttpContext.Session.GetString("Cell2");
                game.Cells[3] = HttpContext.Session.GetString("Cell3");
                game.Cells[4] = HttpContext.Session.GetString("Cell4");
                game.Cells[5] = HttpContext.Session.GetString("Cell5");
                game.Cells[6] = HttpContext.Session.GetString("Cell6");
                game.Cells[7] = HttpContext.Session.GetString("Cell7");
                game.Cells[8] = HttpContext.Session.GetString("Cell8");
                game.GameOverMessage = HttpContext.Session.GetString("GameOverMessage");
                game.GameOver = (HttpContext.Session.GetInt32("GameOver") == 1 ? true : false);

            }


            return View(game);
        }

        [HttpPost]
        public IActionResult PlayTurn(int CellNum, TicTacToeModel game)
        {
            for (int i = 0; i < game.Cells.Length; i++)
            {
                if (game.Cells[i] == null)
                {
                    game.Cells[i] = "";
                }
            }
            // set the selected game board cell to the current player 
            game.Cells[CellNum] = game.Player;

            // check for winner (3 in a row)
            game.GameOver = game.CheckWinner(game.Player);
            if (game.GameOver)
            {
                game.GameOverMessage = game.Player + " Wins!";
            }
            else
            {
                // check for tie (all spaces filled with no win)
                game.GameOver = game.CheckTie();
                if (game.GameOver)
                {
                    game.GameOverMessage = "It's a Tie!";
                }
            }
            // if no tie or no win - switch players 
            if (!game.GameOver)
            {
                game.Player = (game.Player == "X" ? "O" : "X");
            }


            // set session variables to game model variables and redirect
            // to index action method 
            HttpContext.Session.SetString("Cell0", game.Cells[0]);
            HttpContext.Session.SetString("Cell1", game.Cells[1]);
            HttpContext.Session.SetString("Cell2", game.Cells[2]);
            HttpContext.Session.SetString("Cell3", game.Cells[3]);
            HttpContext.Session.SetString("Cell4", game.Cells[4]);
            HttpContext.Session.SetString("Cell5", game.Cells[5]);
            HttpContext.Session.SetString("Cell6", game.Cells[6]);
            HttpContext.Session.SetString("Cell7", game.Cells[7]);
            HttpContext.Session.SetString("Cell8", game.Cells[8]);
            HttpContext.Session.SetString("Player", game.Player);
            HttpContext.Session.SetString("GameOverMessage", game.GameOverMessage);
            HttpContext.Session.SetInt32("GameOver", (game.GameOver ? 1 : 0));
            return RedirectToAction("Index");
        }

        public IActionResult NewGame() {
            // Set the session player to empty string to start a new game
            HttpContext.Session.SetString("Player", "");
            return RedirectToAction("Index");
        }

    }

}
