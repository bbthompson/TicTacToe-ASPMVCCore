using System.Diagnostics.Eventing.Reader;

namespace TicTacToe.Models
{
    public class TicTacToeModel
    {
        public string[] Cells { get; set; } = { "", "", "", "", "", "", "", "", "" };

        public string Player { get; set; } = "X";
        public bool GameOver { get; set; } = false;
        public string GameOverMessage { get; set; } = "";
        
        public bool CheckWinner(string mark)
        {
            // check first row for win 
            if (Cells[0] == mark && Cells[1] == mark && Cells[2] == mark)
            {
                return true;
            }

            // check second row for win 
            if (Cells[3] == mark && Cells[4] == mark && Cells[5] == mark)
            {
                return true;
            }

            // check third row for win 
            if (Cells[6] == mark && Cells[7] == mark && Cells[8] == mark)
            {
                return true;
            }

            // check first column for win 
            if (Cells[0] == mark && Cells[3] == mark && Cells[6] == mark)
            {
                return true;
            }

            // check second column for win 
            if (Cells[1] == mark && Cells[4] == mark && Cells[7] == mark)
            {
                return true;
            }

            // check third column for win
            if (Cells[2] == mark && Cells[5] == mark && Cells[8] == mark)
            {
                return true;
            }

            // check for diagonal win 
            if (Cells[0] == mark && Cells[4] == mark && Cells[8] == mark)
            {
                return true;
            }
            if (Cells[2] == mark && Cells[4] == mark && Cells[6] == mark)
            {
                return true;
            }

            return false;

        }

        public bool CheckTie()
        {

            if (Cells.Contains(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
   
       

    }
}
