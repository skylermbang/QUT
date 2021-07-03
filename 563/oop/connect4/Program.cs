using System;

namespace IFN563_Assignment
{

    public class Connect4Game
    {

        private static int currentplayerSymbol;
        private static int chosenColumn = 0;
        private static bool done = false; //win
        public static int gameMode;
        public static int level=0;
        public static int sequence = 0;

        //public static Board board = new Board();
        //private static Controller controller = new Controller();
        //public static int gua;

    
        static void Main(string[] args)
        {

            UserInterface.Welcom();
          
            gameMode = Convert.ToInt32(Console.ReadLine());
            switch (gameMode)
            {
                case 1:

              
                    UserInterface.ChooseLevel(level);
                    level = Convert.ToInt32(Console.ReadLine());



                    break;
                case 2:

                    UserInterface.Mode2();
               

                    break;

                default:

                    UserInterface.ErrorHandle();
              
                    break;

            }



        }

    }
}
