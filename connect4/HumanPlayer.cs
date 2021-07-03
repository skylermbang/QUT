using System;
namespace IFN563_Assignment
{
    public class HumanPlayer :Player
    {




        public override  void showScore(int currentPlayerSymbol)
        {
            int Player1Score = 0;
            int Player2Score = 0;
             if (currentPlayerSymbol == 1)
            {

                Player1Score++;
                Console.WriteLine(" player 1 score is {0} and player2 score is {1}", Player1Score, Player2Score);
            }

        }
    }
}
