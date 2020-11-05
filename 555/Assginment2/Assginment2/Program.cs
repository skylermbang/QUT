using System;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {

            string children_ticket, adult_ticket, senior_ticket;
        

            Console.WriteLine("############## Task 1 #################");
            

            Console.WriteLine("Please input number of adult tickets");
            adult_ticket = Console.ReadLine();
            int adult = Convert.ToInt16(adult_ticket);
            while (adult < 0)
            {
                Console.WriteLine("Please input non-negative value for number of adult tickets>>");
                adult_ticket = Console.ReadLine();
                adult = Convert.ToInt16(adult_ticket);

            }

            Console.WriteLine("Please input number of children tickets >>");
            children_ticket = Console.ReadLine();
            int children = Convert.ToInt16(children_ticket);
            if (children < 0)
            {
                Console.WriteLine("Please input non-negative value for number of children tickets>>");
                children_ticket = Console.ReadLine();
                children = Convert.ToInt16(children_ticket);

            }
           

          
            Console.WriteLine("Please input number of senior tickets");
            senior_ticket = Console.ReadLine();
            int senior = Convert.ToInt16(senior_ticket);
            if (senior < 0)
            {
                Console.WriteLine("Please input non-negative value for number of senior tickets>>");
                senior_ticket = Console.ReadLine();
                senior = Convert.ToInt16(senior_ticket);

            };


            Console.WriteLine("############## Task 2 #################");

            Console.WriteLine($"Number of tickets for children is {children} , for adults is {adult} and for senior is {senior}");

            decimal adult_cost = 20 * adult;
            decimal children_cost = 10* children;
            decimal senior_cost = 15 * senior;

            string currency_formatted_adult= string.Format("{0:C2}", adult_cost);
                                           
            string currency_formatted_children = string.Format("{0:C2}", children_cost);
            string currency_formatted_senior = string.Format("{0:C2}", senior_cost);

            decimal total_cost = adult_cost + children_cost + senior_cost;
            string currency_formatted_total = string.Format("{0:C2}", total_cost);


            Console.WriteLine("Revenue from selling tickets is {0:C2}",total_cost);



            Console.WriteLine("############## Task 3 #################");

            if( adult <= children && adult <= senior)
            {
                Console.WriteLine("The event is becoming a festival for everyone!");
            }
            else if (senior <= children)
            {
                Console.WriteLine("The event is attracting more and more young people!");
            }
            else
            {
                Console.WriteLine("The event should have more space for kids!");
            }

            Console.WriteLine("############## Task 4 #################");

            string this_year;
            int year_total;
            bool success = false;
            




            while(!success)
            {
                Console.WriteLine("Enter number of participatns");
                this_year = Console.ReadLine();
                year_total = Convert.ToInt16(this_year);
                if(year_total>0 && year_total <=40)
                {
                    success = true;
                    Console.WriteLine("Number of participant is {0}",year_total);
                }
                else
                {
                    success = false;
                    Console.WriteLine("Invailed value {0}",year_total );
                }
            }


            Console.WriteLine("############## Task 5 #################");

            string name;
            bool real1 = true;
            bool real2 = false;
            string choose;

            
            
            while (real1=true)
            {

                Console.WriteLine("Entering participant name >>");
                name = Console.ReadLine();

                Console.WriteLine(" Your name : {0}", name);


                Console.WriteLine(" Event codes are :");
                Console.WriteLine("                   S for Swimming");
                Console.WriteLine("                   B for Badminton");
                Console.WriteLine("                   F for Football");



                while (!real2)
                {
                    Console.WriteLine("Enter event code for this participant");


                    choose = Console.ReadLine();

                    if (choose == "B" || choose == "S" || choose == "F")
                    {

                        real1 = false;
                        real2 = true;

                        Console.WriteLine(" You have choose enter the event code of {1} ", name, choose);
                     
                      
                    }
                    else 
                    {
                        real1 = true;
                        real2 = false;
                        Console.WriteLine("{0} is not a vaild code", choose);
                       
                    }
                }
            }

        }
    }
}
