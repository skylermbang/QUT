using System;
using System.Threading;

namespace IFN563_Assignment
{
    public class UserInterface
    {

        private static Board board = new Board();
        private static Controller controller = new Controller();

        public static void Welcom()
        {
            Console.WriteLine("        IFN 563 Game  by Minsu Bang (10664581)   ");
            Console.WriteLine("              Welcome to Connect 4 Game          ");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Choose the game mode :  [1] Player1 vs Computer  ");
            Console.WriteLine("                     :  [2] Player1 vs Player 2  ");
            Console.WriteLine("-------------------------------------------------");
        }


        public static Board PlayAgainPrompt()
        {
            Board board = null;

            Console.WriteLine("Do you want to play again?  Press Y to play again N to finish the game");
            if (Console.ReadLine().ToUpper().StartsWith("Y"))
            {
                board = new Board();
                //print board
                Console.WriteLine(board.ToString());
            }

            return board;
        }

        internal static void ErrorHandle()
        {
            Console.WriteLine(" <<  User input error >> ");
            Thread.Sleep(2000);
      
        }

        internal static void Mode2()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("    This is Game mode 2  :  Player1 vs Player2  \n\n");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(board.ToString());
            controller.PlayerMode2(board, 6, 1, 0, 0, false, 0);
        }

        internal static void ChooseLevel(int level)
        {

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("   This is Game mode 1  :  Player vs Computer    \n\n");

            Console.WriteLine("   Choose the difficulty :  [1] Easy Mode ");
            Console.WriteLine("                         :  [2] Normal Mode ");
           
          
            Console.WriteLine("-------------------------------------------------");
            level = Convert.ToInt32(Console.ReadLine());


            if (level == 1)
            {
                Console.WriteLine(board.ToString());
                controller.PlayerMode1(board, 6, 1, 0,  0, false, 1, 0);
            }
            else
            {
                Console.WriteLine(board.ToString());
                controller.PlayerMode1(board, 6, 1, 0,  0, false, 2, 0);

            }


       


        }
    }
}
