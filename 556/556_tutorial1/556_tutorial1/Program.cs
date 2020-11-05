using System;

namespace _556_tutorial1
{
    class Program
    {


         const double FINE_PER_DAY = 0.10;
         const double EXPENSIVE_FINE_FOR_DAY = 0.20;
         const int EXCESS_DAYS_THRESHOLD = 7;


         static double BookFine(int overdue_days)
         {
             if (overdue_days <= EXCESS_DAYS_THRESHOLD)
             {
                 return FINE_PER_DAY * overdue_days;
             }

             else
             {
                 return FINE_PER_DAY * EXCESS_DAYS_THRESHOLD + EXPENSIVE_FINE_FOR_DAY * (overdue_days - EXCESS_DAYS_THRESHOLD);
             }


         static double LibraryFine(int[] books)
             {
                 double total_fine = 0;
                 for (int i = 0; i < books.Length; i++)
                 {
                     total_fine += BookFine(books[i]);
                 }
                 return total_fine;
             }

         

        static void Main()
         {
                Console.Write("Number of books >>");
                int book_count = int.Parse(Console.ReadLine());

                int[] books = new int[book_count];
                for (int i = 0; i < book_count; i++)
                {
                    Console.Write($"Book {i} overdue for >> ");
                    books[i] = int.Parse(Console.ReadLine());


                }
                /*
                double fine = LibraryFine(books);
                Console.WriteLine($"Fine is {fine:C}");

*/
            }
        }
    }
}

