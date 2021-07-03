using System;

namespace IFN563_Assignment
{
    /// <summary>
    /// Board class represents a board
    /// </summary>
    public class Board
    {
     
        public const int ROWS = 7;
        public const int COLUMNS = 6;         
        public int[,] board = new int[ROWS, COLUMNS];
        public bool[] columnFull = new bool[COLUMNS];

        public Board()
        {
            InitializeBoard();
        }



        private void InitializeBoard()
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
            msg += ("      012345\n");
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

        public bool BoardIsFull()
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

    }
}
