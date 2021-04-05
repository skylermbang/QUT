
using System.IO;
using static System.Console;

namespace Review
{
    class Program
    {
        static void Main(string[] args)
        {
            string endPoint = "Y";
            string input = "Y";

            while (input == endPoint)
            {
                WriteLine(" Input the directory to see the files or 'n' to exit : ");

                input = ReadLine();


                if (input == "n")
                {
                    input = "N";
                }
                else
                {
                    //폴더 경로를 입력

                    string Path = input;

                    //해당 폴더가 존재하는지 확인

                    if (System.IO.Directory.Exists(Path))

                    {

                        //DirectoryInfo 객체 생성

                        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Path);

                        //해당 폴더에 있는 파일이름을 출력

                        foreach (var item in di.GetFiles())

                        {

                            WriteLine(item.Name);

                        }

                    }
                    input = "Y";



                }

            }
            WriteLine("bye");






        }
        int myAge = 20;
            Write"My age is ");
            WriteLine(myAge);
        }
    };
