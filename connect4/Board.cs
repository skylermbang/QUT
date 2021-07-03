using System;


namespace IFN563_Assignment
{
  
    public class Board : AbstractBoard
    {

        /*public const int ROWS = 6;
        public const int COLUMNS = 7;
        public int[,] board = new int[ROWS, COLUMNS];
        public bool[] columnFull = new bool[COLUMNS];*/





        public override void InitializeBoard()
        {
            for (int i = 0; i < ROWS; i++)
            {

                for (int j = 0; j < COLUMNS; j++)
                {
                    board[i, j] = 0;
                }
            }

            //reset column full
            for (int i = 0; i < COLUMNS; i++)
            {
                columnFull[i] = false;
            }
        }


        public override string ToString()
        {
            string msg = ("     Columns\n");
            msg += ("      0123456\n");
            msg += ("    _________\n");

            for (int i = 0; i < ROWS; i++)
            {
                msg += ("Row ");
                msg += (i);
                msg += ("|");

                for (int j = 0; j < COLUMNS; j++)
                {
                    msg += (board[i, j]);
                }

                msg += "\n";
            }

            return msg;
        }

        public override bool BoardIsFull()
        {
            //check each column
            for (int i = 0; i < COLUMNS; i++)
            {
                if (!columnFull[i])
                {
                    return false;
                }
            }
            
            //board is full
            return true;
        }

        public override void UpdateBoard(AbstractBoard board)
        {
            Board curBoard = (Board)board;
            InitializeBoard();

            for (int i = 0; i < Cell._column.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Controller.PlaceInColumn(curBoard, Cell._column[i], 1);

                }
                else
                {
                    Controller.PlaceInColumn(curBoard, Cell._column[i], 2);
                    //PlaceInColumn( Cell._column[ i ], 2 );
                }
            }
        }


        
    }
}
