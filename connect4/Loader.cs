
using System;
using System.IO;

namespace IFN563_Assignment
{
    public class Loader
    {
        public Loader()
        {
        }
        private static Controller controller = new Controller();

        public static void Load(Board board)
        {
        
            int SavedPlayer = 0;
            int SavedMode;
            int SavedLevel;
            



            StreamReader sr = new StreamReader( new FileStream( "saveFile.dat", FileMode.Open ) );

            string loadStr = string.Empty;

            loadStr = sr.ReadLine();

            string[] LoadData = loadStr.Split( ',' );
          

            Cell.LoadedColumn.Clear();
            LoadData.Initialize();
            int[] LoadDataInt = Array.ConvertAll(LoadData, s => int.Parse(s));
            //Cell.LoadedColumn = new System.Collections.Generic.List<int>();

            if (LoadDataInt[0] == 2)
            {
                //Console.WriteLine("this is game mode {0} : Player1 vs Player2  Mode ", LoadDataInt[0]);
                SavedMode = 2;
                SavedLevel = 0;


                Cell._column.Clear();
                //Cell.LoadedColumn.Clear();
                for( int i = 3; i < LoadDataInt.Length; i++)
                {
                    //Cell.LoadedColumn.Add(LoadDataInt[i]);
                    Cell._column.Add(LoadDataInt[i]);
                }

                if (LoadDataInt[2] == 1) SavedPlayer = 1;
                else if (LoadDataInt[2] == 2) SavedPlayer = 2;

        
                board.UpdateBoard(board);
                Console.WriteLine(board.ToString());
                Console.WriteLine("This is game mode {0} : Player1 vs Player2  the level is {1}  ", LoadDataInt[0], LoadDataInt[1]);

                controller.PlayerMode2(board, 6, 1, SavedPlayer, 0, false, 0);
           

            }

            else if (LoadDataInt[0] == 1 && LoadDataInt[1] == 1)
            {
               
                SavedMode = 1;
                SavedLevel = 1;
                SavedPlayer = 1;
              
                Cell._column.Clear();
                //Cell.LoadedColumn.Clear();
                for (int i = 3; i < LoadDataInt.Length; i++)
                {
                    //Cell.LoadedColumn.Add(LoadDataInt[i]);
                    Cell._column.Add(LoadDataInt[i]);
                }


                board.UpdateBoard(board);
                Console.WriteLine(board.ToString());
                Console.WriteLine("This is game mode {0} : Player vs Computer  the level is {1} : Easy mode ", LoadDataInt[0], LoadDataInt[1]);
                controller.PlayerMode1(board, 6, 1, 0, 0, false, 1, 0);
           


            }




            else if (LoadDataInt[0] == 1 && LoadDataInt[1] == 2)
            {
               
                SavedMode = 1;
                SavedLevel = 2;
                SavedPlayer = 1;
                Cell._column.Clear();
                //Cell.LoadedColumn.Clear();
                for (int i = 3; i < LoadDataInt.Length; i++)
                {
                    //Cell.LoadedColumn.Add(LoadDataInt[i]);
                    Cell._column.Add(LoadDataInt[i]);
                }
              


        
                board.UpdateBoard(board);
                Console.WriteLine(board.ToString());
                Console.WriteLine("This is game mode {0} : Player vs Computer  the level is {1} : Normal mode  ", LoadDataInt[0], LoadDataInt[1]);
                controller.PlayerMode1(board, 6, 1, 0, 0, false, 2, 0);
            }

            /*
            foreach ( int data in LoadDataInt )
            {
                Console.WriteLine(data);
                //Console.WriteLine(LoadData.GetType());
                // Cell.LoadedColumn.Add( int.Parse( element ) );
               
            }*/

         

            sr.Close();
           // Console.WriteLine(loadStrSplit[0]);
        }
    }
}
