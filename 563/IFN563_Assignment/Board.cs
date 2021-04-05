using System;
using System.Linq;

namespace IFN563_Assignment
{
    public class Board
    {



        public  void InitializingBoard()
        {
            var board = new[]
                {
                    new[] {"0", "1", "2", "3", "4", "5", "6"},
                    new[] {"A", null, null, null,null, null,null},
                    new[] {"B", null, null, null,null, null,null},
                    new[] {"C", null, null, null,null, null,null},
                    new[] {"D", null, null, null,null, null,null},
                    new[] {"F", null, null, null,null, null,null},
                    new[] {"E", null, null, null,null, null,null},
                    new[] {"G", null, null, null,null, null,null},
                };                              
              

            var rows = board.Length;
            var cols = board.First().Length;
            var header = $"┌{string.Join("", Enumerable.Repeat("──┬", cols - 1))}──┐";
            var middle = $"├{string.Join("", Enumerable.Repeat("──┼", cols - 1))}──┤";
            var footer = $"└{string.Join("", Enumerable.Repeat("──┴", cols - 1))}──┘";

            Console.WriteLine(header);
            for (var i = 0; i < rows; ++i)
            {
                foreach (var cell in board[i])
                    Console.Write($"│ {cell ?? " "}");
                Console.WriteLine("│");
                if (i < rows - 1)
                    Console.WriteLine(middle);
            }
            Console.WriteLine(footer);

        }
        
    }
}
