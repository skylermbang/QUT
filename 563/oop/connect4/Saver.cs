using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFN563_Assignment
{
    public class Saver
    {

        /*
        #region Private Variables

        private GameManager _manager;

        #endregion

        #region Constructors

        public Saver(GameManager manager)
        {
            _manager = manager;
        }

        #endregion

        #region Public Methods
        */
        public static void Save(Board board, int Sequence)
        {
            StreamWriter sw = new StreamWriter(new FileStream("saveFile.dat", FileMode.Create));


            string saveStr = string.Empty;

      

            saveStr = Cell.ShowCellHistory().ToString();
            sw.WriteLine(saveStr);


            
            /*
            for (int i = 0; i < Board.ROWS; i++)
            {
                string saveStr = string.Empty;

                for (int j = 0; j < Board.COLUMNS; j++)
                {
                    saveStr += board.board[i, j].ToString() + "," + Sequence.ToString() + ":";
                }

                sw.WriteLine(saveStr);
            }*/

            sw.Close();
            Console.WriteLine(" testing ");
        }

        //#endregion
    }
}
