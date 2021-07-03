using System;
using System.Collections.Generic;

namespace IFN563_Assignment
{
    public class Cell
    {
        public static int _player = 0;
        public static int _turn = 0;
        public static List<int> _column = new List<int>();
        public static List<int> LoadedColumn = new List<int>();

        // player1 -> column 4: _column.Add(4)
        // player2 -> column 5: _column.Add(5)

        public static void CellHistory(int currentplayerSymbol, int sequence, int column)
            {
                _player = currentplayerSymbol;
                _turn = sequence;
                _column.Add(column);
        }



        public static string ShowCellHistory( )
        {
           foreach (int column in _column)
            {
                Console.WriteLine(column);
                
                
            }

            string result = string.Join(",", _column);

            return result;
        }
    }
}





