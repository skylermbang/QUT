
using System.IO;
using static System.Console;

namespace Review
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "/Users/skylerbang/Downloads/QUT/QUT_Programming/QUT/563/tutorial2";

            string[] files;
            int x;
            files = Directory.GetFiles(path);

            if (Directory.Exists(path))
            {
                
                if (files.Length == 0)
                    WriteLine("There are no files in this directory: " +
                   path);
                else
                {
                    WriteLine(path + " contains the following files");
                    for (x = 0; x < files.Length; ++x)
                        WriteLine(" " + files[x]);
                }

            }
            else
            {
                WriteLine("whaat? ");
            }
            WriteLine("-----------------------");
            WriteLine(files[1]);
            WriteLine(files[2]);


            WriteLine("-----------------------");

            string rtf_File = files[1];
            string word_File = files[2];

            FileInfo rtf = new FileInfo(rtf_File);
            FileInfo word = new FileInfo(word_File);

            long rtf_size = rtf.Length;
            long word_size = word.Length;

            WriteLine("word file size is {0} and the text file size is {1}", word_size, rtf_size);



        }
    }
};
