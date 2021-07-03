using System;
namespace IFN563_Assignment
{
    public class AiPlayer : Player
    {




        public override void showScore(int currentPlayerSymbol)
        {
            int AiScore = 0;
            
            if (currentPlayerSymbol == 2)
            {

                AiScore++;
                Console.WriteLine(" Ai Score is {0})", AiScore);
            }

        }
    }
}