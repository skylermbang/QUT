using System;

namespace Assignment1_PartB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("###########################");
            Console.WriteLine("#                         #");
            Console.WriteLine("# Make your things smooth #");
            Console.WriteLine("#                         #");
            Console.WriteLine("###########################\r\n\r\n\r\n\r\n\r\n");
            /* This is task1*/




            string firstname, lastname, street_address, city, zip, quantity;
            int qunatity_value;

            Console.WriteLine("Please input your first name >>");
            firstname = Console.ReadLine();

            Console.WriteLine("Please input your Last  name >>");
            lastname = Console.ReadLine();

            Console.WriteLine("Please input your Street Address>>");
            street_address = Console.ReadLine();


            Console.WriteLine("Please input your City>>");
            city = Console.ReadLine();


            Console.WriteLine("Please input your zip>>");
            zip = Console.ReadLine();


            Console.WriteLine("Please input your the quantity of the blender you want (each blender price of $35.50 )>>");
            quantity= Console.ReadLine();
            qunatity_value = Convert.ToInt16(quantity);
            /* This is task2*/

            double total = qunatity_value * 35.50;
            double tax = total * 0.05;
            double total_due = total + tax;

            Console.WriteLine("---------------------Task3---------------------");
            Console.WriteLine("Recipt for");
            Console.WriteLine("Your name is {0}_{1}" ,firstname,lastname);
            Console.WriteLine("Your address is {0}_{1}_{2}", street_address,city,zip);
            Console.WriteLine("You have orderd {0} blender(s)", quantity);
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("{0}'s blenders ordered at $35.50 each \r\n", firstname);
           
            Console.WriteLine("Total:            ${0:0.00} ", total);
            Console.WriteLine("Tax:              ${0:0.00} ", tax);
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Total Due:        ${0:0.00} ",total_due);
            /* This is part3*/


            Console.WriteLine($" The totla due is over $500.00: {total_due > 500}");

            /* This is part4*/

        }
    }
}
