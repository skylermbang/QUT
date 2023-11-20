using System;
using System.Diagnostics;
using System.Threading;

namespace _664_Assignment
{
    public class test
    {
        public test()
        {



         
        }

        public void testTopThree(MemberCollection.Hashtable<int> members, ToolCollection tools)
        {
            

            members.Register("sky", "sky", "sky", "sky", "111", 2);
            members.Register("sky2", "sky2", "sky2", "sky2", "111", 2);
            members.Register("sky3", "sky3", "sky3", "sky3", "111", 2);
            members.Register("sky4", "sky4", "sky4", "sky4", "111", 2);
            members.Register("sky5", "sky5", "sky5", "sky5", "111", 2);
            members.Register("sky6", "sky6", "sky6", "sky6", "111", 2);
            members.Register("sky7", "sky7", "sky7", "sky7", "111", 2);
            members.Register("sky8", "sky8", "sky8", "sky8", "111", 2);
            members.Register("sky9", "sky9", "sky9", "sky9", "111", 2);
            members.Register("sky10", "sky10", "sky10", "sky10", "111", 2);
            members.Register("sky11", "sky11", "sky11", "sky11", "111", 2);

            tools.AddTool("Gardening", "Line Trimmers", 3, "tool1");
            tools.AddTool("Flooring", "Scrapers", 3, "tool2");
            tools.AddTool("Fencing", "Electric Fencing", 3, "tool3");
            tools.AddTool("Fencing", "Electric Fencing", 3, "tool4");
            tools.AddTool("Fencing", "Electric Fencing", 3, "tool5");
            tools.AddTool("Fencing", "Electric Fencing", 3, "tool6");
            tools.AddTool("Fencing", "Electric Fencing", 3, "tool7");
            tools.AddTool("Fencing", "Electric Fencing", 3, "tool8");
            tools.AddTool("Fencing", "Electric Fencing", 3, "tool9");
            tools.AddTool("Fencing", "Electric Fencing", 3, "tool10");
            tools.AddTool("Fencing", "Electric Fencing", 3, "tool11");

            tools.AddTool("Fencing", "Electric Fencing", 3, "tool12");

            var response = members.Login("sky", "sky");
            var response2 = members.Login("sky2", "sky2");
            var response3 = members.Login("sky3", "sky3");
            var response4 = members.Login("sky4", "sky4");
            var response5 = members.Login("sky5", "sky5");
            var response6 = members.Login("sky6", "sky6");


           
            tools.BurrowTool("_", "_", "tool9");
            
            tools.BurrowTool("_", "_", "tool9");
            tools.BurrowTool("_", "_", "tool9");
            tools.BurrowTool("_", "_", "tool9");
            tools.BurrowTool("_", "_", "tool9");
            tools.BurrowTool("_", "_", "tool9");
            tools.BurrowTool("_", "_", "tool9");
            tools.BurrowTool("_", "_", "tool9");
            tools.BurrowTool("_", "_", "tool9");
            tools.BurrowTool("_", "_", "tool9");
            tools.BurrowTool("_", "_", "tool9");
            tools.BurrowTool("_", "_", "tool9");
            tools.BurrowTool("_", "_", "tool9");
            tools.BurrowTool("_", "_", "tool9");
            tools.BurrowTool("_", "_", "tool9");
            tools.BurrowTool("_", "_", "tool9");
            tools.BurrowTool("_", "_", "tool9");
            tools.BurrowTool("_", "_", "tool9");
            tools.BurrowTool("_", "_", "tool12");
            tools.BurrowTool("_", "_", "tool12");
            tools.BurrowTool("_", "_", "tool12");
            tools.BurrowTool("_", "_", "tool11");
 
        

            

            Console.Clear();
          

            Console.WriteLine("***********         time comparison                              ************");
            //Console.WriteLine(tools.TopThree());   //buble sort
            Console.WriteLine("***********         bubble sort                             ************");
            DateTime start = DateTime.Now;
            Thread.Sleep(5000);
            Console.WriteLine(tools.TopThree());   //buble sort
            DateTime end = DateTime.Now;

            TimeSpan ts = (end - start);
            Console.WriteLine("Elapsed Time is {0} ms", ts.TotalMilliseconds);
            Console.WriteLine("***********          quick sort                             ************");
            DateTime start2 = DateTime.Now;
            Thread.Sleep(5000);
            Console.WriteLine(tools.TopThree2());   //buble sort
            DateTime end2 = DateTime.Now;
            TimeSpan ts2 = (end2 - start2);
            Console.WriteLine("Elapsed Time is {0} ms", ts2.TotalMilliseconds);


        }



    }
}
