using static System.Console;

namespace lecture1
{
    class Program
    {
        static void Main(string[] args)
        {
            double myPurchase = 12.99;
            double taxRate = 0.9;
            DisplaySalesTax(myPurchase, taxRate);
            DisplaySalesTax(45.33, taxRate);


            double hours = 10.6;
            double rate = 20.3;
            double payment = CalcPayx(hours, rate);
            WriteLine("I have workd {0}, and the rate is {1} , total gross pay is {2}" ,hours,rate,payment.ToString("C"));
        }

        private static void DisplaySalesTax(double saleAmount, double taxRate)
        {
            double tax;
      
            tax = saleAmount * taxRate;

            WriteLine("The tax on {0} is {1}", saleAmount.ToString("C"), tax.ToString("C"));
        }


        private static double  CalcPayx(double hours, double rate)
        {
            double gross;
            gross = hours * rate;
            return gross;
            
        }
    }
}
