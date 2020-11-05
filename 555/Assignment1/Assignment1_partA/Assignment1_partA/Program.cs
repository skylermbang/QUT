using System;

namespace Assignment1_partA
{
    class Program
    {
        static void Main(string[] args)
        {
            string test1_score,test2_score,test3_score,test4_score,test5_score;

            Console.WriteLine("This is part A from the Assingment 1");
            Console.Write("Enter the test 1 score (allowed to input up to two decimal  ex) 89.51)>> ");
            test1_score = Console.ReadLine();
            if (test1_score == "")
            {
                Console.WriteLine("Please input your test1 score");
                Console.Write("Enter the test 1 score (allowed to input up to two decimal  ex) 89.51)>> ");
                test1_score = Console.ReadLine();
            }
        
                Double test1 = Convert.ToDouble(test1_score);
                Console.WriteLine("Your test1 Score is : {0}", test1);
            

            Console.Write("Enter the test 2 score (allowed to input up to two decimal  ex) 89.51 ");
            test2_score = Console.ReadLine();
            if (test2_score == "")
            {
                Console.WriteLine("Please input your test2 score");
                Console.Write("Enter the test 2 score (allowed to input up to two decimal  ex) 89.51)>> ");
                test2_score = Console.ReadLine();
            }
            Double test2 = Convert.ToDouble(test2_score);
            Console.WriteLine("Your test2 Score is : {0}", test2);

            
    
            Console.Write("Enter the test 3 score (allowed to input up to two decimal  ex) 89.51) >> ");
            test3_score = Console.ReadLine();
            if (test3_score == "")
            {
                Console.WriteLine("Please input your test3 score");
                Console.Write("Enter the test 3 score (allowed to input up to two decimal  ex) 89.51)>> ");
                test3_score = Console.ReadLine();
            }
            Double test3 = Convert.ToDouble(test3_score);
            Console.WriteLine("Your test3 Score is : {0}", test3);

            
            Console.Write("Enter the test 4 score (allowed to input up to two decimal  ex) 89.51) >> ");
            test4_score = Console.ReadLine();
            if (test4_score == "")
            {
                Console.WriteLine("Please input your test4 score");
                Console.Write("Enter the test 4 score (allowed to input up to two decimal  ex) 89.51)>> ");
                test4_score = Console.ReadLine();
            }
            Double test4 = Convert.ToDouble(test4_score);
            Console.WriteLine("Your test4 Score is : {0}", test4);


            Console.Write("Enter the test 5 score (allowed to input up to two decimal  ex) 89.51) >> ");
            test5_score = Console.ReadLine();
            if (test5_score == "")
            {
                Console.WriteLine("Please input your test5 score");
                Console.Write("Enter the test 5 score (allowed to input up to two decimal  ex) 89.51)>> ");
                test5_score = Console.ReadLine();
            }
            Double test5 = Convert.ToDouble(test5_score);
            Console.WriteLine("Your test5 Score is : {0}", test5);

            Double average = (test1 + test2 +test3 + test4 + test5) / 5;
            Console.WriteLine("Your average scores is :{0:0.00}", average);

        }
    }
}
