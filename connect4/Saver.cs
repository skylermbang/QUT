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

       
        public static void Save(Board board, int Sequence)
        {
            StreamWriter sw = new StreamWriter(new FileStream("saveFile.dat", FileMode.Create));

            string saveStr = string.Empty;

            saveStr = Connect4Game.gameMode.ToString() + "," + Connect4Game.level.ToString() + "," + Controller.CurrentPlayerSymbol.ToString() + "," + Cell.ShowCellHistory().ToString();  
            sw.WriteLine(saveStr);
            
      
            sw.Close();
            Console.WriteLine(" The game successfully saved");
        }

    
    }
}
