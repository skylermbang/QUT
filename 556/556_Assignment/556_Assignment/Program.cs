using System;
using System.Text;




namespace _556_Assignment

{

    class Program
    {

        // PartA -1 
        public static int InputValue(int min, int max)
        {
            int input = 0;
            bool input_check = false;
            string entryString;

            do
            {
                entryString = Console.ReadLine();
                int.TryParse(entryString, out input);
                if (input >= min && input <= max)
                {
                    input_check = true;
                }
                
                else
                {
                    Console.WriteLine("#### Out of range ####");
                    input_check = false;
                }

            } while (input_check == false);

            return input;
        }

        // Part A -2 
        public static bool IsValid(string id)
   
        {
            string ss = id;

            while (ss.Length == 5)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (ss[i] <= 'Z' && ss[i] >= 'A')
                    {
                        for (int j = 2; j < 5; j++)
                        {
                            if (ss[j] >= '0' && ss[j] <= '9')
                            {
                                continue;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;

        }






        //partC-1 

        private static void GetBookData(int num, Book[] books)
        {

            string bookId;
            string bookTitle;
            int numPages;
            double price;


            for (int i = 0; i < num; i++)
            {
                
                Console.Write("Enter Book Name : ");
                bookTitle = Console.ReadLine();
                Console.WriteLine("Category codes are:");

                
                for (int j = 0; j < Book.categoryCodes.Length; j++)
                {

                    Console.WriteLine(" " + Book.categoryCodes[j] + " " + Book.categoryNames[j]);
                }



                
                do
                {
                    Console.Write("Enter book id wich starts with a category code ane ends with 3-digit number : ");
                    bookId = Console.ReadLine();



                } while (!IsValid(bookId) );

                
                Console.Write("Enter book price:  ");
                price = double.Parse(Console.ReadLine());
                Console.Write("Enter book number of pages:  ");
                numPages = int.Parse(Console.ReadLine());

                
                books[i] = new Book(bookId, bookTitle, numPages, price);

            }



        }

        //Part C-2. display all book method
        public static void DisplayAllBooks(Book[] books)
        {

         

            for (int i = 0; i < books.Length; i++)
            {
                
                Console.WriteLine("####Book Information ####"  + books[i].ToString());

            }


        }




        //Parct C-3

        private static void GetLists(int num, Book[] books)
        {

            
            Console.WriteLine("Category codes are:");
            for (int j = 0; j < Book.categoryCodes.Length; j++)
            {

                Console.WriteLine(" " + Book.categoryCodes[j] + " " + Book.categoryNames[j]);
            }

            Console.WriteLine(" Enter category code or Z to quit");

            string userSearch = Console.ReadLine();

            int k ;
            switch (userSearch)
            {
                
               case "CS":

                    k = 0;
                    for (int l = 0; l < num; l++)
                    {
                        Console.WriteLine(" " + Book.categoryCodes[k] + " " + Book.categoryNames[k]);



                       
                        Console.WriteLine(books[l].ToString());
                        
                        
                        
                    }    
                    break;

               case "IS":
                    k = 1;
                    for (int l = 0; l < num; l++)
                    {
                        Console.WriteLine(" " + Book.categoryCodes[k] + " " + Book.categoryNames[k]);


                        Console.WriteLine(books[l].ToString());
                        
                        

                    }
                    break;

                case "SE":
                    k = 2; 
                    for (int l = 0; l < num; l++)
                    {
                        

                        Console.WriteLine(books[k].ToString());
                        k++;
                        

                    }
                    break;

                case "SO":
                    k = 3;
                    for (int l = 0; l < num; l++)
                    {
                        Console.WriteLine(" " + Book.categoryCodes[k] + " " + Book.categoryNames[k]);


                        Console.WriteLine(books[k].ToString());
                        k++;
                       

                    }
                    break;


                case "MI":
                    k = 4;
                    for (int l = 0; l < num; l++)
                    {
                        Console.WriteLine(" " + Book.categoryCodes[k] + " " + Book.categoryNames[k]);


                        Console.WriteLine(books[k].ToString());
                        k++;
                       

                    }
                    break;
                   

                case "Z":
                    Console.WriteLine("Thank you");
                    break;


                default:
                    Console.WriteLine("Wrong Code");
                    break;



            }


        }
            













        




        static void Main(string[] args)


            {

               // string bookId;
                Console.Write("#### Input nubmer range of 1 to 30 (inclusive)##### ");
                int InputChecker = InputValue(1, 30);


            Book[] books = new Book[InputChecker];

            Console.WriteLine("################################");

            GetBookData(InputChecker, books);
            Console.WriteLine("################################");

            DisplayAllBooks(books);
            Console.WriteLine("################################");

            GetLists(InputChecker, books);
            Console.WriteLine("################################");

        }

    }
}
