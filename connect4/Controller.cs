using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace IFN563_Assignment
{

    /// controller controls the logic of game

    public class Controller
    {
        public static int CurrentPlayerSymbol = 1;

      


        /// check win condition


        public bool WinCondition(Board board, int currentplayerSymbol)
        {
            bool win_vertical = false;
            bool win_horizontal = false;
            bool win_digo1 = false;
            bool win_digo2 = false;
            bool win = false;

            for (int i = 0; i < Board.ROWS; i++)
            {
                for (int j = 0; j < Board.COLUMNS - 3; j++)


                {
                    if (

                        board.board[i, j] == currentplayerSymbol && board.board[i, j + 1] == currentplayerSymbol &&
                        board.board[i, j + 2] == currentplayerSymbol && board.board[i, j + 3] == currentplayerSymbol
                        )
                    {

                        Console.WriteLine(" \n\n Horizontal Connect 4  ");
                        win_horizontal = true;
                       
                    }
                }


            }


            for (int i = 0; i < Board.ROWS - 3; i++)
            {
                for (int j = 0; j < Board.COLUMNS; j++)
                {

                    if (

                        board.board[i, j] == currentplayerSymbol && board.board[i + 1, j] == currentplayerSymbol &&
                        board.board[i + 2, j] == currentplayerSymbol && board.board[i + 3, j] == currentplayerSymbol
                        )
                    {

                        Console.WriteLine(" \n\n Vertical Connect 4  ");
                        win_horizontal = true;

                    }




                }


            }

            for (int i = 0; i < Board.ROWS - 3; i++)
            {
                for (int j = 0; j < Board.COLUMNS - 3; j++)
                {

                    if (

                        board.board[i, j] == currentplayerSymbol && board.board[i + 1, j + 1] == currentplayerSymbol &&
                        board.board[i + 2, j + 2] == currentplayerSymbol && board.board[i + 3, j + 3] == currentplayerSymbol
                        )
                    {

                        Console.WriteLine(" \n\n Downward Digonal Connect 4  ");
                        win_digo1 = true;

                    }
                }
            }

            for (int i = 0; i <Board.ROWS - 3; i++)
            {
                for (int j = 6; j > 2; j--)
                {


                    if (
                          board.board[i, j] == currentplayerSymbol && board.board[i + 1, j - 1] == currentplayerSymbol &&
                         board.board[i + 2, j - 2] == currentplayerSymbol && board.board[i + 3, j - 3] == currentplayerSymbol
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
                //Cell.ShowCellHistory();
                
            }

            return win;
        }


        /// place in column
        
        public static void PlaceInColumn(Board board, int columnNumber, int symbol )
        {
            int index = Board.ROWS - 1;  // index = 0 is the top 
            int cc = board.board[index, columnNumber];
            while ((cc == 1 || cc == 2) && index >= 0)
            {
                index--;
                if (index >= 0) cc = board.board[index, columnNumber];
            }

            if (index < 0) board.columnFull[columnNumber] = true;

            if (!board.columnFull[columnNumber])
            {
                board.board[index, columnNumber] = symbol;
                //print board
                Console.WriteLine(board.ToString());


            }
            else
            {
                Console.WriteLine(" The column is full please try again. ");
            }
        }
        

        public void PlaceInColumnAI(Board board, int columnNumber, int symbol)
        {
            int index = Board.ROWS - 1;  // index = 0 is the top 
            int cc = board.board[index, columnNumber];
            while ((cc == 1 || cc == 2) && index >= 0)
            {
                index--;
                if (index >= 0) cc = board.board[index, columnNumber];
            }

            if (index < 0) board.columnFull[columnNumber] = true;

            if (!board.columnFull[columnNumber])
            {
                board.board[index, columnNumber] = symbol;
                //print board
                Console.WriteLine(board.ToString());
            }
            else
            {
                Console.WriteLine(" \n " );
            }
        }

        public void PlayerMode2(Board board, int columnNumber, int symbol, int determineFirstPlayer, int chosenColumn, bool done, int sequence)
        {
            if (determineFirstPlayer == 0) CurrentPlayerSymbol = 1;
            else CurrentPlayerSymbol = 2;

            do
            {
                if ( CurrentPlayerSymbol == 1) Console.WriteLine("player 1 :"); else Console.WriteLine("Player 2 :");

                Console.WriteLine("Choose your coulmn number  from 0 to 6 ( -1: Go Back / -2 : Save / -3 : Load)");

                try
                {
                    chosenColumn = int.Parse( Console.ReadLine() );

                    if ( chosenColumn >= 0 && chosenColumn <= 6 )
                    {
                      
                        PlaceInColumn(board, chosenColumn, CurrentPlayerSymbol);
                        sequence++;

                        //Console.WriteLine("{0} sequence", sequence);

                        Cell.CellHistory( CurrentPlayerSymbol, sequence, chosenColumn );
                        //Console.WriteLine( "player is  {0} , and it was {1}th turn", Cell._player, Cell._turn );
                        //Saver.Save( board, sequence );
                    }
                    else if ( chosenColumn == -1 )
                    {
                        GoBack();
                        board.UpdateBoard(board);
                        Console.WriteLine(" Last turn has removed");
                        Console.WriteLine( board.ToString() );
                    }
                    else if (chosenColumn == -2)
                    {
                        Saver.Save( board, sequence );
                    }
                    else if (chosenColumn == -3)
                    {
                        Loader.Load(board);

                    }/*
                    else if (chosenColumn == -4)
                    {
                        Process.Start("http://www.google.com");
                        //Process.Start("https://en.wikipedia.org/wiki/Connect_Four");


                    }*/


                    if (WinCondition(board, CurrentPlayerSymbol))
                    {
                        Console.WriteLine( "player {0} has won !  \n\n", CurrentPlayerSymbol );
                        //HumanPlayer.showScore(CurrentPlayerSymbol);
                        board = UserInterface.PlayAgainPrompt();


                        //player wants to exit
                        if ( board == null )
                        {
                            break;
                        }
                    }
                    else
                    {
                        if ( chosenColumn != -1 && chosenColumn != -2 && chosenColumn != -3 )
                        {
                            if ( !board.columnFull[ chosenColumn ] )
                            {
                                CurrentPlayerSymbol = ( CurrentPlayerSymbol == 1 ? 2 : 1 );
                            }
                        }
                    }


                    if ( board.BoardIsFull() )
                    {
                        Console.WriteLine( " All the board is full" );
                        board = UserInterface.PlayAgainPrompt();


                        //player wants to exit
                        if ( board == null )
                        {
                            Console.WriteLine( " Bye " );
                            break;

                        }
                    }
                }
                catch ( Exception ex )
                {
                    Console.WriteLine( " Unknwon Error  Please try again" );
                }

            } while (!done); // do -while loop continuous til done = true;
        }
   
        public void PlayerMode1(Board board, int columnNumber, int symbol, int determineFirstPlayer, int chosenColumn, bool done, int level, int sequence)
        {
            int smart = 0;
            int smartColumn = 0;

            if (determineFirstPlayer == 0) CurrentPlayerSymbol = 1;
            else CurrentPlayerSymbol = 2;

            do
            {
                if (CurrentPlayerSymbol == 1) Console.WriteLine("player 1 :"); else Console.WriteLine("Player 2 :");
                Console.WriteLine("Choose your coulmn number  from 0 to 6 ( -1: Go Back / -2 : Save / -3 : Load)");

                try
                {
                    chosenColumn = int.Parse(Console.ReadLine());
                    sequence++;

                    //Console.WriteLine("{0} sequence", sequence);

                    Cell.CellHistory(CurrentPlayerSymbol, sequence, chosenColumn);

                    if (chosenColumn >= 0 && chosenColumn <= 6)
                    {
                        PlaceInColumn(board, chosenColumn, CurrentPlayerSymbol );
                        //board.PlaceInColumn(chosenColumn, CurrentPlayerSymbol);
                    }
                    else if (chosenColumn == -1)
                    {
                        GoBack();
                        board.UpdateBoard(board);
                        Console.WriteLine(" Last turn has removed");
                        Console.WriteLine(board.ToString());
                    }
                    else if (chosenColumn == -2)
                    {
                        Saver.Save(board, sequence);
                    }
                    else if (chosenColumn == -3)
                    {
                        Loader.Load(board);

                    }

                    if (WinCondition(board, 1))
                    {
                        Console.WriteLine("player has won !  \n\n");
                        board = UserInterface.PlayAgainPrompt();

                        //player wants to exit
                        if (board == null)
                        {
                            break;
                        }
                    }
                    /*  else
                    {
                        if ( chosenColumn != -1 && chosenColumn != -2 && chosenColumn != -3)
                        {
                            if ( !board.columnFull[ chosenColumn ] )
                            {
                                CurrentPlayerSymbol = ( CurrentPlayerSymbol == 1 ? 2 : 1 );
                            }
                        }
                    }*/
                    else
                    {
                        if (chosenColumn != -1 && chosenColumn != -2 && chosenColumn != -3)
                        {
                            if (!board.columnFull[chosenColumn])
                            {
                                CurrentPlayerSymbol = (CurrentPlayerSymbol == 1 ? 2 : 1);

                                if (CurrentPlayerSymbol == 2 && level == 1)
                                {




                                    chosenColumn = new Random().Next(6);
                                    PlaceInColumnAI(board, chosenColumn, CurrentPlayerSymbol);
                           
                                    if (board.columnFull[chosenColumn])
                                    {
                                        chosenColumn = new Random().Next(6);
                                        PlaceInColumnAI(board, chosenColumn, CurrentPlayerSymbol);
                                    }

                                    if (WinCondition(board, 2))
                                    {
                                        Console.WriteLine("Computer has won !  \n\n");
                                        board = UserInterface.PlayAgainPrompt();


                                        //player wants to exit
                                        if (board == null)
                                        {
                                            break;
                                        }
                                    }


                                    if (board.BoardIsFull())
                                    {
                                        Console.WriteLine(" All the board is full");
                                        board = UserInterface.PlayAgainPrompt();

                                        //player wants to exit
                                        if (board == null)
                                        {
                                            Console.WriteLine(" Bye ");
                                            break;

                                        }
                                    }

                                    sequence++;


                                    Cell.CellHistory(CurrentPlayerSymbol, sequence, chosenColumn);
                                    CurrentPlayerSymbol = 1;


                                }







                                else if (CurrentPlayerSymbol == 2 && level == 2)
                                {




                                    for (int i = 0; i < Board.ROWS; i++)
                                    {
                                        for (int j = 0; j < 3; j++)


                                        {


                                            if (board.board[i, j] == 1 && board.board[i, j + 1] == 1 && board.board[i, j + 2] == 0)
                                            {

                                                smart = 1;
                                                Console.WriteLine("smart is   1");


                                            }
                                            else if (chosenColumn == 5)
                                            {
                                                smart = new Random().Next(-2, 1);
                                            }
                                            else if (chosenColumn == 0)
                                            {
                                                smart = new Random().Next(0, 3);
                                            }
                                            else
                                            {
                                                smart = new Random().Next(-1, 1);

                                            }




                                        }

                                    }



                                    smartColumn = chosenColumn + smart;
                                    Console.WriteLine("smart column is  {0}", smartColumn);
                                    PlaceInColumnAI(board, smartColumn, CurrentPlayerSymbol);
                                    if (board.columnFull[smartColumn])
                                    {
                                        chosenColumn = new Random().Next(6);
                                        PlaceInColumnAI(board, chosenColumn, CurrentPlayerSymbol);
                                    }
                                    if (WinCondition(board, 2))
                                    {
                                        Console.WriteLine("Computer has won !  \n\n");
                                        board = UserInterface.PlayAgainPrompt();


                                        //player wants to exit
                                        if (board == null)
                                        {
                                            break;
                                        }
                                    }
                                    if (board.BoardIsFull())
                                    {
                                        Console.WriteLine(" All the board is full");
                                        board = UserInterface.PlayAgainPrompt();

                                        //player wants to exit
                                        if (board == null)
                                        {
                                            Console.WriteLine(" Bye ");
                                            break;

                                        }
                                    }
                                    sequence++;


                                    Cell.CellHistory(CurrentPlayerSymbol, sequence, chosenColumn);
                                    CurrentPlayerSymbol = 1;





                                }
                            }
                        }
                    }


                    if (board.BoardIsFull())
                    {
                        Console.WriteLine(" All the board is full");
                        board = UserInterface.PlayAgainPrompt();

                        //player wants to exit
                        if (board == null)
                        {
                            Console.WriteLine(" Bye ");
                            break;

                        }
                    }

                }


                catch (Exception)
                {
                    Console.WriteLine(" Unknwon Error  Please try again");
                }

            } while (!done); // do -while loop continuous til done = true;
        }

        public void GoBack()
        {
            if ( Cell._column == null || Cell._column.Count < 2)
            {
                return;
            }
            else
            {
                Cell._column.Remove( Cell._column.Last() );
                Cell._column.Remove( Cell._column.Last() );
            }
        }
    }
}
