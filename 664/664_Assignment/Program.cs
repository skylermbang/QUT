using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 664 Assignment   SKyler Minsu Bang _N10664581 
namespace _664_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tool managment system");
            var menus = new Menu();
            var members = new MemberCollection.Hashtable<int>(4);
            var tools = new ToolCollection();
            menus.ShowMainMenu(members,tools);


            // testing for top three tools
            //var test = new test();
            //test.testTopThree(members, tools);





        }
    }
}

