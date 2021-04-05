using System;
using System.Linq;


namespace IFN563_Assignment
{
    class Program
    {

        private const int numColsRows = 7;
        private const int numColsColumn = 6;
        private static int[,] board = new int[numColsRows, numColsColumn];
        private static bool[] columnFull = new bool[numColsRows];
        private static int currentplayerSymbol;
        private static int chosenColumn = 0;
        private static bool done = false; //win

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Connect 4 game !");
            InitializeBoard();
            DisplayBoard();


            int determineFirstPlayer = 0; //  payer 1 = 0 ;  payer 2 = 1;


            if( determineFirstPlayer == 0) currentplayerSymbol = 1; 
            else currentplayerSymbol = 2;


            do
            {
                if (currentplayerSymbol == 1) Console.WriteLine("player 1 :"); else Console.WriteLine("Player 2 :");
                Console.WriteLine("Choose your coulmn number  from 0 to 6");


                try
                {

                    
                    chosenColumn = int.Parse(Console.ReadLine());


                    if (chosenColumn >= 0 && chosenColumn <= 6)
                    {

                        PlaceInColumn(chosenColumn, currentplayerSymbol);

                    }

                    if (WinCondition(currentplayerSymbol))
                    {

                        Console.WriteLine("player {0} has won !  \n\n", currentplayerSymbol);
                        PlayAgainPrompt();
                    }


                    else {
                         if (!columnFull[chosenColumn])
                       { currentplayerSymbol = (currentplayerSymbol == 1 ? 2 : 1);
                        }
                    }




                    if (BoardIsFull())
                    {
                        Console.WriteLine(" All the board is full");
                        PlayAgainPrompt();
                    }
                     



                }
                catch (Exception)
                {
                    Console.WriteLine(" Unknwon Error  Please try again");
                }

              
            


            } while (!done); // do -while loop continuous til done = true;



        }

        private static bool WinCondition(int currentplayerSymbol)
        {
            bool win_vertical = false;
            bool win_horizontal = false;
            bool win_digo1 = false;
            bool win_digo2 = false;
            bool win = false;

            for (int i=0; i< numColsRows; i++)
            {
                for (int j=0; j< numColsColumn -3;  j++)

           
                {
                    if (

                        board[i, j] == currentplayerSymbol && board[i, j + 1] == currentplayerSymbol &&
                        board[i, j + 2] == currentplayerSymbol && board[i, j + 3] == currentplayerSymbol
                        )
                    {

                        Console.WriteLine(" \n\n Horizontal Connect 4  ");
                        win_horizontal = true;

                    }
                }


            }


            for (int i = 0; i < numColsRows -3; i++)
            {
                for (int j = 0; j < numColsColumn; j++)
                {

                    if (

                        board[i, j] == currentplayerSymbol && board[i+1, j ] == currentplayerSymbol &&
                        board[i+2, j ] == currentplayerSymbol && board[i+3, j ] == currentplayerSymbol
                        )
                    {

                        Console.WriteLine(" \n\n Vertical Connect 4  ");
                        win_horizontal = true;

                    }




                }


            }

            for (int i = 0; i < numColsRows - 3; i++)
            {
                for (int j = 0; j < numColsColumn -3; j++)
                {

                    if (

                        board[i, j] == currentplayerSymbol && board[i + 1, j+1] == currentplayerSymbol &&
                        board[i + 2, j+2] == currentplayerSymbol && board[i + 3, j+3] == currentplayerSymbol
                        )
                    {

                        Console.WriteLine(" \n\n Uppder Digonal Connect 4  ");
                        win_digo1= true;

                    }
                }
            }

            for (int i = 6; i >3; i--)
            {
                for (int j = 0; j < 3 ; j++)
                {


                    if (
                         board[i, j] == currentplayerSymbol && board[i-1, j + 1] == currentplayerSymbol &&
                         board[i-2, j+2] == currentplayerSymbol && board[i - 3, j + 3] == currentplayerSymbol
                        )

                    {

                       Console.WriteLine(" \n\n Uppder Digonal Connect 4  ");
                        win_digo2 = true;

                    }
                }
            }



            if (win_vertical || win_horizontal || win_digo1 || win_digo2)
            {
                win = true;
            }

            return win;
        }

        private static void PlayAgainPrompt()
        {
            Console.WriteLine("Do you want to play again?  Press Y to play again N to finish the game");
            if (Console.ReadLine().ToUpper().StartsWith("Y"))
            {
                InitializeBoard();
                DisplayBoard();
            }
        }

        private static bool BoardIsFull()
        {
            bool boardFull = false;
            if (columnFull[0]== true && columnFull[1] == true && columnFull[2] == true && columnFull[3] == true && columnFull[4] == true && columnFull[5] == true) boardFull = true;
         
            if (boardFull) DisplayBoard();

            return boardFull;
        }

        private static void PlaceInColumn(int columnNumber, int symbol)
        {
            int index = numColsRows - 1;  // index = 0 is the top 
            int cc = Program.board[index, columnNumber];
            while((cc== 1 || cc== 2)&& index >= 0)
            {
                index--;
                if (index >= 0) cc = Program.board[index, columnNumber];
            }

            if (index < 0) columnFull[columnNumber] = true;
             
            if (!columnFull[columnNumber])
            {
                Program.board[index, columnNumber] = symbol;
                DisplayBoard();
            }
            else{
                Console.WriteLine(" The column is full please try again. ");
            }
        }

        private static void DisplayBoard()
        {

            Console.WriteLine("     Columns");
            Console.WriteLine("      012345");
            Console.WriteLine("    _________");

            for(int i=0; i< numColsRows; i++)
            {
                Console.Write("Row ");
                Console.Write(i);
                Console.Write("|");

                for (int j = 0; j< numColsColumn; j++)
                {
                    Console.Write(Program.board[i, j]);

                }

            
                Console.WriteLine();
            }





        }

        private static void InitializeBoard()
        {
            for (int i = 0; i < numColsRows; i++)
            {
                columnFull[i] = false;
                for(int j =0; j< numColsColumn; j++)
                {
                    board[i, j] = 0;
                }
            }
        }
    }
} 
