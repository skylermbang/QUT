using System;
using System.Text;
using System.Collections.Generic;

namespace _556_Assignment
{
    public class Book
    {

        //Part B-1. pubulic array field.

        public static string[] categoryCodes = new string[] { "CS", "IS", "SE", "SO", "MI" };
        public static string[] categoryNames = new string[] { "Computer Science", "Information System", "Security", "Soceity",  "Miscellaneous" };


        // Part B-2. private field
        private string BookID;
        private string CategorynameofBook;
       


        // Part-B 3. auto-implemented properties
        private string bookTitle;
        private int numOfPages;
        private double price;


       
         
        public string BookTitle
        {
            get { return bookTitle; }
            set { bookTitle = value; }
        }

        public int NumOfPages
        {
            get { return numOfPages; }
            set { numOfPages = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        // Part B-4.
        public string bookId
        {
            get
            {
                return BookID;
            }
            set
            {

                int ArrayChecker = -1;
                
                if (Program.IsValid(value))
                {
                    string categoryCode = value.Substring(0, 2);

                    int i = 0;
                    foreach (string cat in categoryCodes)
                    {
                       

                        if (cat == categoryCode)
                        {
                            
                            ArrayChecker = i;
                            BookID = value;
                            CategorynameofBook = categoryNames[i]; 

                        }
                        i++;
                    }

                    
                    if (ArrayChecker == -1)
                    {
                        
                        BookID = "MI" + value.Substring(2);
                        CategorynameofBook = categoryNames[4]; 
                    }




                }
            }



        }


        public string category
        {
            get
            {
                return CategorynameofBook;
            }
        }

        //Part B-5 Consturcutors

        public Book()
        {

        }


    
        
        public Book(string aBookId, string aBookTitle , int anumPages, double aPrice)
        {
            bookId = aBookId;
            bookTitle = aBookTitle;
            numOfPages = anumPages;
            price = aPrice;
        }
        


        // Part B-6 A ToString method
        public override string ToString()
        {
            return "\n"+"Book Title:" + bookTitle + "\n" + "Book Category:"+category +"\n" + "Book id:" + bookId +"\n" +  "Pages in the Book:" + NumOfPages + "\n" +"Price:" + "$" + String.Format("{0:0.00}", Price);
        }

    }
}
