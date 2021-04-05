using static System.Console;

namespace Review
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int myAge = 20;
            WriteLine("My age is {0} years old ", myAge);
            */


            /*
            double num = 123;
            string numString;
            numString = num.ToString("F2");
            WriteLine(numString); /// 123.00;

            string numString2;
            numString2 = num.ToString("F3");
            WriteLine(numString2);  /// 123.000


            double money = 123123;
            string conversion;
            conversion = money.ToString("c");
            WriteLine(conversion);   /// currency format  $123,123.00
            */

            /*
            string name1 = "sky";
            string name2 = "sky";
            string name3 = "scar";

            WriteLine(" compare {0} to  {1} : {2}", name1, name2, name1 == name2);
            WriteLine(" compare {0} to  {1} : {2}", name1, name3, name2 == name3);
            */


            /*
            WriteLine(" Please input one number : ");
            int inputNum = int.Parse(ReadLine());
            int low = 2;
            int high = 7;

            //WriteLine(" Your input is : {0} ", inputNum);

            if (inputNum > low)
            {
                if(inputNum < high)
                {
                    WriteLine(" Your numer {0} is between {1} and {2}", inputNum, low, high);
                }
            }

            */


            /*
            Write(" Please input one number : ");
            int inputNum = int.Parse(ReadLine());
            int high = 7;
                if (inputNum < high)
                {
                    WriteLine(" Your numer {0} is lower than  {1}", inputNum,  high);
                }
                else {
                WriteLine(" Your numer {0} is higher than  {1}", inputNum,  high);
            }
            ReadKey();  // if you want your output freeze in the screen.  
            */

            /*
            Write(" Please write which year you in ? : ");
            int year = int.Parse(ReadLine());


            switch(year)
            {
                case 1:
                    WriteLine("Freshman");
                    break;
                case 2:
                    WriteLine("Sophomore");
                    break;
                case 3:
                    WriteLine("Juniore");
                    break;
                case 4:
                    WriteLine("Senior");
                    break;
                default:
                    WriteLine(" WTF you ?");
                    break;
            }
            */


            // Tutorial 2 Exercise 1


            /*
            Write(" input the size of inch you wish to convert in to centimeters : " );
            int inch = int.Parse(ReadLine());
            double cent = inch * 2.54;
            WriteLine(" {0}inch  is {1} cm", inch, cent);
            */

            //Tutorial2 Exerciese 2

            /*
            const double basePrice = 200;
            const double hourly = 150;
            const double RatePerMile = 2;

            Write(" Enter the estimated number of hours :");

            int hours = int.Parse(ReadLine());


            Write(" Enter the estimated distance in miles:");
            double miles = double.Parse(ReadLine());

            double totalCost = basePrice + (hours * hourly) + (miles * RatePerMile);
            WriteLine(" For a moving {0} hours and oging {1} miles ", hours, miles);
            WriteLine(" Total price is {0}", totalCost.ToString("C"));


            */

            //Tutorial2 Exerciese 4
            /*
            const int Twenties = 20;
            const int Tens = 10;
            const int Fives = 5;
            const int One = 1;

            int twenties, tens, fives, one;


            int dollar_input, dollar;

            Write("Houw much you have : ");
            dollar_input = int.Parse(ReadLine());

            dollar = dollar_input;
            twenties = dollar_input / Twenties;
            dollar = dollar % Twenties;
            tens = dollar / Tens;
            dollar = dollar % Tens;
            fives = dollar / Fives;
            dollar = dollar % Fives;
            one = dollar / One;
            

            WriteLine("you have total {0}", dollar_input.ToString("C"));
            WriteLine(" Convert into {0} Twenty ,  {1} Tens , {2} Fives {3} One", twenties, tens, fives, one);

            

            /Tutorial2 Exerciese 5
            const double factor = 5.0 / 9;
            const int difference = 32;
            double degreeF, degreeC;

            Write(" Enther Fahrenheit degree :");
            degreeF = double.Parse(ReadLine());

            degreeC = (degreeF - difference) * factor;
            WriteLine("Farenheit degree {0} is Celsius degree {1}", degreeF.ToString("F1"), degreeC.ToString("F1"));

            


            // lecture 4  //

               //while loop

            int number1 = 1;

            int limit = 5;

            while (number1 < limit)
            {
                number1++;
                WriteLine(" hi this is while loop {0}", number1);

            }
            WriteLine(" End of the loop" );
            ReadKey();

            //do- while loop

            int number1 = 1;

            int limit = 10;


         
            {
                WriteLine(" hi this is while loop {0}", number1);
                number1++;
            }

            while (number1 < limit);
          
            WriteLine(" End of the loop");
          
            

            // for loop


            int x;

            for (x=1; x < 5; x++){
                WriteLine("hi is is for loop {0}" , x);
             
            }

            


            //nested loops

            double bankBal;
            double rate;
            int year;
            const double START_BAL = 1000;
            const double START_INT = 0.04;
            const double INT_INCREASE = 0.02;
            const double LAST_INT = 0.08;
            const int END_YEAR = 5;
            for (rate = START_INT; rate <= LAST_INT; rate += INT_INCREASE)
            {
                bankBal = START_BAL;
                WriteLine("Starting bank balance is {0}", bankBal.ToString("C"));
                WriteLine(" Interest Rate : {0}", rate.ToString("P"));
                for(year = 1; year <= END_YEAR; ++year)
                {
                    bankBal = bankBal + bankBal * rate;
                    WriteLine(" After year {0}, bank balance is {1}", year, bankBal.ToString("C"));
                }
            }

            
            // odometer

            int pos100, pos10, pos1;
            int MAX = 10;

            for (pos100 = 0; pos100 < MAX; ++pos100)
            {

                for (pos10 = 0; pos10 < MAX; ++pos10)
                {
                    for (pos1 = 0; pos1 < MAX; ++pos1)
                    {
                        WriteLine("-----");
                        WriteLine("{0} :{1} : {2}" , pos100, pos10, pos1);
                        WriteLine("-----");
                        ReadLine();
                            
                        
                    }
                }
            }
            



            // array ;

            int[] myScores = { 100, 90, 80,70, 59 };
            WriteLine(" Array size is {0}", myScores.Length);
            for (int x = 0; x < myScores.Length; ++x)
                WriteLine(myScores[x]);


            int[] myScores2 = { 100, 90, 80, 70, 59 };
            WriteLine(" Array size is {0}", myScores.Length);
            foreach(int score in myScores2)
            {
                WriteLine("{0}", score.ToString());
            }
            */

            // searching array suing a loop
            /*
            NOT DONE YET;

            int[] scores = { 100, 90, 80, 70, 59, 20 , 50, 40 , 30, 87 };
            int[] failed = { };

            foreach ( int score in scores)
            {
                if (score < 50)
                {
                    WriteLine("loser's score is {0}", score.ToString());
                    failed[] = score;
                }
            }

            */

            string[] studentName = { "skyler", "youme", "joey", "adit", "louis", "simon" };
            int[] studentScore = { 90, 90, 40, 60, 50, 20 };
            string name;
            int score = 0;
            bool isPass = false;

            Write("  Plese input the  name of the studnet : ");
            name = ReadLine();

            for(int x = 0; x < studentName.Length; ++x)
            {
                if( name == studentName[x])
                {
                    isPass = true;
                    score = studentScore[x];
                    x = studentName.Length; // to improve the loop efficiency;
                }
            }
            if (isPass)
            {
                WriteLine(" The score of {0} is {1}", name, score);
            }
            else
            {
                WriteLine(" No student with that name");
            }
 


        }
    }
}
