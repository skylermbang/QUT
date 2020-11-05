using System;
using System.Text.RegularExpressions;
namespace Books
{
    // Part A: 
    class Program
    {

        //A.1. 
        public static int InputValue(int min, int max)
        {
            bool valid = false;
            int value = 0;
            do
            {
                try
                {
                    //try parse to int
                    value = int.Parse(Console.ReadLine());
                    //if the value is in the range
                    if (value >= min && value <= max)
                    {
                        valid = true;
                    }
                    //if the value is out of the range
                    else
                    {
                        Console.WriteLine("Invalid input: is out of the range");
                        valid = false;
                    }
                }
                //if the value is not numeric
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input: must be numeric");
                    valid = false;
                }
            } while (valid == false);

            return value;
        }


        //A.2.
        public static bool IsValid(string id)
        {

            //create a regular expression
            //^[A-Z]{2} begin with 2 Uppercase Characters
            //[0-9]{3} //followed by 3 Numbers
            //$ matches position just after the last character of the string means that the string must have only 3+2 = 5 characters
            Regex rx = new Regex("^[A-Z]{2}[0-9]{3}$");
            //return if the regular expression match the id
            return rx.IsMatch(id);


        }


        //Part C:

        ////C.1.
        private static void GetBookData(int num, Book[] books)
        {

            string bookId;
            string bookTitle;
            int numPages;
            double price;


            for (int i = 0; i < num; i++)
            {
                //ask the book name
                Console.Write("Enter Book name: >> ");
                bookTitle = Console.ReadLine();

                //show the category codes
                Console.WriteLine("Category codes are:");
                for (int j = 0; j < Book.categoryCodes.Length; j++)
                {

                    Console.WriteLine(" " + Book.categoryCodes[j] + " " + Book.categoryNames[j]);
                }



                //ask for the book id
                do
                {
                    Console.Write("Enter book id wich starts with a category code ane ends with 3-digit number >> ");
                    bookId = Console.ReadLine();



                } while (IsValid(bookId) == false);//do while the bookid is invalid 

                //ask the price
                Console.Write("Enter book price: >> ");
                price = double.Parse(Console.ReadLine());
                //ask the price
                Console.Write("Enter book number of pages: >> ");
                numPages = int.Parse(Console.ReadLine());

                //create and save the Book object in the index i
                books[i] = new Book(bookId, bookTitle, numPages, price);

            }



        }

        //C.2.
        public static void DisplayAllBooks(Book[] books)
        {

            Console.WriteLine("Information of all books\n");

            for (int i = 0; i < books.Length; i++)
            {
                //print the index + 1 and print the book in the index
                Console.WriteLine("Book:" + (i + 1) + "      " + books[i].ToString() + "\n");

            }


        }

        //C.3.
        private static void GetLists(int num, Book[] books)
        {
            string categoryCode;

            //show the category codes
            Console.WriteLine("Category codes are:");
            for (int i = 0; i < Book.categoryCodes.Length; i++)
            {

                Console.WriteLine(" " + Book.categoryCodes[i] + " " + Book.categoryNames[i]);
            }

            while (true)
            {
                Console.Write("\nEnter a category code or z to quit >> ");

                categoryCode = Console.ReadLine();

                //if the user enter z
                if (categoryCode.Equals("z"))
                {
                    Console.WriteLine("\nThank you for using the book system");
                    break;
                }


                int index = -1;
                //check if the category is valid
                for (int i = 0; i < Book.categoryCodes.Length; i++)
                {
                    //if the array categoryCodes in the index is equal categoryCode
                    if (Book.categoryCodes[i].Equals(categoryCode))
                    {
                        index = i;
                        break;
                    }
                }
                //if we find the category code
                if (index != -1)
                {

                    Console.WriteLine("\nBook with the category code " + categoryCode + " are:");

                    //count the elements with the category
                    int count = 0;

                    for (int i = 0; i < num; i++)
                    {
                        //each book have a categoryNameOfBook we compare with categoryNames array in the index
                        //if is equal
                        if (books[i].categoryNameOfBook.Equals(Book.categoryNames[index]))
                        {
                            //increase the counter
                            count++;
                            //print the book

                            Console.WriteLine(books[i].ToString());

                        }

                    }
                    //if there is not books with that category Name
                    if (count == 0)
                    {
                        Console.WriteLine("No book in the category " + Book.categoryNames[index]);
                    }
                    //if there at least a book
                    else
                    {
                        //print the counter
                        Console.WriteLine("Number of books in the category " + Book.categoryNames[index] + ": " + count);
                    }

                }

                else
                {//if the user enter a invalid category

                    Console.WriteLine(categoryCode + " is not a valid category code");
                }





            }
        }

        static void Main(string[] args)
        {

            //4.  

            Console.Write("Enter a number wich is the range od 1 and 30 >> ");

            int noOfBooks = InputValue(1, 30);
            //initialize the array of books
            Book[] books = new Book[noOfBooks];

            Console.WriteLine("******************** ******* ********************");

            GetBookData(noOfBooks, books);

            Console.WriteLine("******************** ******* ********************");

            DisplayAllBooks(books);

            Console.WriteLine("******************** ******* ********************");

            GetLists(noOfBooks, books);

        }
    }
}