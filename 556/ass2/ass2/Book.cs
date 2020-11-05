using System;
using System.Collections.Generic;
using System.Text;

namespace Books
{
    // Part B:
    class Book
    {
        //1.
        public static string[] categoryCodes = new string[] { "CS", "IS", "SE", "SO", "MI" };

        public static string[] categoryNames = new string[] { "Computer Science", "Information System", "Security", "Society", "Miscellaneous" };
        //2.
        private string _bookId;

        private string _categoryNameOfBook;

        //3.
        public string BookTitle { get; set; }
        public int NumOfPages { get; set; }
        public double Price { get; set; }

        //4.
        public string bookId
        {
            get => _bookId;
            set
            {
                int index = -1;
                //if the code has a valid format
                if (Program.IsValid(value))
                {
                    //search for the category code
                    for (int i = 0; i < categoryCodes.Length; i++)
                    {
                        //value.Substring(0, 2) get the category code in the value
                        //if the category code is equal categoryCodes in position i
                        if (categoryCodes[i].Equals(value.Substring(0, 2)))
                        {
                            //save the index
                            index = i;
                            //assign the value
                            _bookId = value;
                            //assing the category name Miscellaneous
                            _categoryNameOfBook = categoryNames[i]; //assing the category name in the index i

                        }
                    }

                    //if we didn't find the category code the index will be -1 
                    if (index == -1)
                    {
                        //assing to the category MI and keep the numeric part
                        _bookId = "MI" + value.Substring(2);
                        _categoryNameOfBook = categoryNames[4]; //assing the category name Miscellaneous
                    }




                }
            }
        }
        //read only property
        public string categoryNameOfBook
        {
            get => _categoryNameOfBook;
        }

        //5.
        public Book()
        {

        }
        public Book(string bookId, string bookTitle, int numPages, double price)
        {
            this.bookId = bookId;
            this.BookTitle = bookTitle;
            this.NumOfPages = numPages;
            this.Price = price;
        }

        //6.  
        public override string ToString()
        {
            return bookId + "  " + BookTitle + "  " + NumOfPages + "  $" + string.Format("{0:0.00}", Price);
        }

    }
}