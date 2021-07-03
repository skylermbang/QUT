using System;
namespace IFN563_Assignment
{
    abstract public class AbstractBoard
    {
        public const int ROWS = 6;
        public const int COLUMNS = 7;
        public int[,] board = new int[ROWS, COLUMNS];
        public bool[] columnFull = new bool[COLUMNS];

        public AbstractBoard()
        {
            InitializeBoard();
        }

        abstract public void InitializeBoard();

        abstract public bool BoardIsFull();

        abstract public void UpdateBoard(AbstractBoard board);


        
        

    }
}
