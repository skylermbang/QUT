using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _664_Assignment
{
    public class Menu
    {
        int registerNum = 0;
        Members currentMember;

     

        public Menu()
        {
        }

        public void ShowMainMenu(MemberCollection.Hashtable<int> members, ToolCollection tools)
        {
            
            var menu = new Menu();
            //var test = new test();
            //test.testTopThree();
            members.Register("staff", "staff", "staff", "today123", "000", 1);

            // this is testing purpose
            // each of adding new tool for the testing purpose , have to input anything to add next tool for the testing purpose

            //members.Register("sky", "sky", "sky", "sky", "111", 2);
            //members.Register("sky1", "sky1", "sky1", "sky1", "111", 3);
            //members.Register("man", "man", "man", "man", "112", 4);

            //members.Register("James", "Anthony", "key", "anth", "+049820402", 6);
            //tools.AddTool("Gardening", "Line Trimmers", 3, "tool11");
            //tools.AddTool("Flooring", "Scrapers", 3, "tool12");
            //tools.AddTool("Fencing", "Electric Fencing", 3, "tool3");
            //tools.AddTool("Measuring", "Laser Measurer", 3, "tool5");
            //tools.AddTool("Cleaning", "Car Cleaning", 3, "tool6");
            //tools.AddTool("Electronic", "Data Test Tool", 3, "tool7");
            //tools.AddTool("Electricity", "Basic hand Tools", 3, "tool8");
            //tools.AddTool("Automotive", "Braking", 3, "tool9");
            // testing purpose



            Console.WriteLine("*************************************************");
            Console.WriteLine("**                                             **");
            Console.WriteLine("**            IFN 664 Assignment 1             **");
            Console.WriteLine("**            TOOL MANGEMENT SYSTEM            **");
            Console.WriteLine("**                                             **");
            Console.WriteLine("**                                             **");
            Console.WriteLine("**           Type 1 : Staff Login              **");
            Console.WriteLine("**           Type 2 : Member Login             **");
            Console.WriteLine("**           Type 3 : EXIT                     **");
            Console.WriteLine("**                                             **");
            Console.WriteLine("*************************************************");
            string option;
            option = Console.ReadLine();
            Console.WriteLine("==================================================");

            Console.WriteLine("* the option chosen is *" + option);
            if (Convert.ToInt32(option) == 1)
            {

                Console.WriteLine("*************************************************");
                Console.WriteLine("**                                             **");
                Console.WriteLine("**               STAFF LOGIN                   **");
                
                Console.WriteLine("**                                             **");
                Console.WriteLine("**                                             **");

                bool loginS = false;

                while (loginS != true)
                {

                    Console.WriteLine("**              Type your ID >>>>               **");
                    string staffId = Console.ReadLine();
                    Console.WriteLine("**              Type your PW >>>>               **");
                    string staffPw = Console.ReadLine();

                    var response = members.Login(staffId, staffPw);
                    if (response == null)
                        Console.WriteLine("-----------Check Your ID or PW---------------");
                    else
                    {
                        Console.Clear();
                       
                        Console.WriteLine("welcome to system");
                        loginS = true;

                        StaffMenu();
                    }

                }


            }
            else if (Convert.ToInt32(option) == 2)
            {

                MemberMenu();

            }
            else
            {
                Console.WriteLine(" Wrong option terminating the application");

            }

            void MemberMenu()
            {
                Console.WriteLine("*************************************************");
                Console.WriteLine("**                                             **");
                Console.WriteLine("**               Member LOGIN                   **");

                Console.WriteLine("**                                             **");
                Console.WriteLine("**                                             **");

                bool loginM = false;

                while (loginM != true)
                {

                    Console.WriteLine("**              Type your ID >>>>               **");
                    string memberId = Console.ReadLine();
                    Console.WriteLine("**              Type your PW >>>>               **");
                    string memberPw = Console.ReadLine();

                    var response = members.Login(memberId, memberPw);
                    if (response == null)
                        Console.WriteLine("-----------Check Your ID or PW---------------");
                    else
                    {
                        Console.Clear();
                      
                        
                        loginM = true;
                    

                        this.currentMember = response;
                        
                        Console.WriteLine("welcome to system  {0}", currentMember.lastName);
                        MemberOptions();
                    }

                }
            }

            void RegisterMemberMenu()
            {
                Console.WriteLine("*********** Staff Menu ************");
                Console.WriteLine("**** Register New Member  ****");



                bool addMember = true;
                while (addMember == true)
                {

                    Console.WriteLine("**              Type new Member firstName >>>>               **");
                    string newUserFName = Console.ReadLine();
                    Console.WriteLine("**               Type new Member lastName     >>>>               **");
                    string newUserLName = Console.ReadLine();
                    Console.WriteLine("**               Type new Member Contact PhoneNumber     >>>>               **");
                    string newUserNumber = Console.ReadLine();
                    Console.WriteLine("**             Type new Member user ID    >>>>               **");
                    string newUserUserID = Console.ReadLine();
                    Console.WriteLine("**             Type new Member Password >>>>               **");
                    string newUserPw = Console.ReadLine();

                  
                    members.Register(newUserFName, newUserLName, newUserUserID, newUserPw, newUserNumber, 1);
                   
                    Console.WriteLine("**              new user registerd sucessfully             **");
                    Console.WriteLine("**              type 1 to add another member           **");
                   
                    Console.WriteLine("**              type 2 go back to staff menu    **");

                    string optionSelect = Console.ReadLine();
                    if (optionSelect == "2")
                    {
                        addMember = false;

                        Console.WriteLine("**              type anything to continue          **");
                        //MemberOptions();
                        StaffOptions();
                    }

                }
            }
            void StaffMenu()
            {
                Console.WriteLine(" Staff Login");
                Console.WriteLine(" +++++++++++++");
                StaffOptions();
            }

            string MemberOptions()
            {

                Console.WriteLine("*********** Member Menu ************");
                Console.WriteLine("**** Choose your options below ****");
                Console.WriteLine("1. Display tools of a type");
                Console.WriteLine("2. Borrow a tool");
                Console.WriteLine("3. Return a tool");
                Console.WriteLine("4. List tools I'm borrowing");
                Console.WriteLine("5. Display top three most frequently borrowed tools");
                Console.WriteLine("6. Return to main menu");
                Console.WriteLine("**********************************");
                string OptionsNum = Console.ReadLine();


                switch (Convert.ToInt16(OptionsNum))
                {

                    case 1:
                        DisplayToolMenu();
                        break;
                    case 2:
                        BurrowToolMenu();
                        break;
                    case 3:
                        ReturnToolMenu();
                        break;
                    case 4:
                        
                        ToolStatusMenu();
                        break;
                    case 5:
                        TopThreeMenu();
                        break;
                    case 6:
                        ShowMainMenu(members,tools);
                        break;
                    default:
                        Console.WriteLine("Invailed Value");

                        break;

                }



                return OptionsNum;

            }

            void TopThreeMenu()
            {

                // showing top three popular tool based on its burrowed number 

                Console.WriteLine("***********                                       ************");
                Console.WriteLine("**** top 3 popular tools ****");
                //Console.WriteLine(tools.TopThree());
                Console.WriteLine(tools.TopThree2());
                Console.WriteLine("***********                                       ************");
                Console.WriteLine("**** type anything to go back to menu ****");
                Console.ReadLine();
                MemberOptions();

            }


            void ToolStatusMenu()


            {
                // showing current user's renting tools
                Console.WriteLine(" Showing all the tools you are currently burrowing ");
          
                var currentTool = members.MyTool(currentMember.id, currentMember.firstName);


                Console.WriteLine("*********** Showing {0} , current burrowing tools ************", currentMember.firstName);
                for (int i=0; i < currentTool.Length; i++)
                {
                    if(currentTool[i] != null)
                    {
                        Console.WriteLine(currentTool[i]);
                    }
                    
                }

                Console.WriteLine("***********                                       ************");
                Console.WriteLine("***********                                       ************");
                Console.WriteLine("**** type anything to go back to menu ****");
                Console.ReadLine();
                MemberOptions();





            }
            void ReturnToolMenu()


            {
                // retunring tool
             
                bool checker = true;

                while (checker == true)
                {
                    Console.WriteLine("*********** Returning Tools  ************");
                    Console.WriteLine("**** type the tool name you wish to return ****");
                    string toolName = Console.ReadLine();
                    tools.ReturnTool(toolName);
                    members.Return(currentMember.id, currentMember.firstName, toolName);
                    Console.WriteLine("{0} is successfully returned ", toolName);


                    Console.WriteLine("*****type1 keep return another tool***");
                    Console.WriteLine("**** type2 return to menu ****");
                    string optionSelect = Console.ReadLine();
                    if (optionSelect == "2")
                    {
                        checker= false;

                        Console.WriteLine("**              type anything to continue          **");
                        
                        MemberOptions();
                    }
                }

               



            }
            void BurrowToolMenu()


            {
                // burrowing tools
                bool checker = true;

                while (checker == true)
                {
                    Console.WriteLine("*********** Burrowing Tools  ************");
                    Console.WriteLine("**** type the tool name you wish to burrow ****");
                    string toolName = Console.ReadLine();
                    tools.BurrowTool("_", "_", toolName);
                    members.Burrow(currentMember.id, currentMember.firstName, toolName);
                    Console.WriteLine("{0} is successfully burrowed ", toolName);
                    Console.WriteLine("*****type1  burrow another  tool***");
                    Console.WriteLine("**** type2 return to menu ****");
                    string optionSelect = Console.ReadLine();
                    if (optionSelect == "2")
                    {
                        checker = false;

                        Console.WriteLine("**              type anything to continue          **");

                        MemberOptions();
                    }
                }


            }

            void DisplayToolMenu()
            {

                Console.WriteLine("*********** Showing the popular top 3 tools  ************");
                Console.WriteLine("***********                                  ************");
                tools.ShowAllTool();
                Console.WriteLine("***********                                  ************");
                Console.WriteLine("**** type anything to go back to menu ****");
                Console.ReadLine();
                MemberOptions();

            }

            string StaffOptions()
            {

                Console.WriteLine("*********** Staff Menu ************");
                Console.WriteLine("**** Choose your options below ****");
                Console.WriteLine("1. Add a tool");
                Console.WriteLine("2. Remove a tool");
                Console.WriteLine("3. Register a new member");
                Console.WriteLine("4. Remove a member");
                Console.WriteLine("5. Display all the members who are borrwoing a tool");
                Console.WriteLine("6. Find member's phone number");
                Console.WriteLine("0. Return to main menu");
                Console.WriteLine("**********************************");
                string OptionsNum = Console.ReadLine();


                switch (Convert.ToInt16(OptionsNum))
                {

                    case 1:
                        AddToolMenu();
                        break;
                    case 2:
                        RemoveToolMenu();
                        break;
                    case 3:
                        RegisterMemberMenu();
                        break;
                    case 4:
                        RemoveMemberMenu();
                        break;
                    case 5:
                        ShowMemberMenu();
                        break;
                    case 6:
                        SearchPhoneMenu();
                        break;
                    case 0:
                        ShowMainMenu(members, tools);
                        break;
                    default:
                        Console.WriteLine("Invailed Value");

                        break;

                }



                return OptionsNum;

            }

            void SearchPhoneMenu()
            {

                // serach phone number of selected user 
                Console.WriteLine("**** serach phone number ****");


                var Checker = true;
                while (Checker == true)
                {
                    Console.WriteLine("**              Type user id >>>>               **");
                    string userId = Console.ReadLine();
                    Console.WriteLine("**              Type user first name>>>>               **");
                    string userName = Console.ReadLine();
                    var phoneNumber = (members.ShowPhone(userId, userName));

                    if (phoneNumber != null)
                    {
                        Console.WriteLine("**     user Id :{0}              **", userId);
                        Console.WriteLine("**     user Name :{0}              **", userName);
                        Console.WriteLine("**     user Phone Number :{0}              **", phoneNumber);
                        Console.WriteLine("**                                         **");
                    }
                    else
                    {
                        Console.WriteLine("**    Cant find your ID & name matching in the system ");
                        Console.WriteLine("**                                                    **");

                    }

                    Console.WriteLine("**              type 1 to serach phone number          **");
                    Console.WriteLine("**              type 2 to go back to menu    **");
  
                    string optionSelect = Console.ReadLine();
                    if (optionSelect == "2")
                    {
                       
                        Checker = false;
                        Console.WriteLine("**              type anything to continue          **");
                        StaffOptions();
                    }
                }
             
                
            }

            void ShowMemberMenu()
                //show all the member who currently burrowing the tools
            {
                Console.WriteLine("**** show current tool burrowing members ****");
                Console.WriteLine("****                                     ****");
                var CurrentUser= members.ShowEveryOne();
                if(CurrentUser != null)
                {
                    for (int i = 0; i < CurrentUser.Count; i++)
                    {
                        Console.WriteLine(CurrentUser[i]);
                    }
                }
                else
                {
                    Console.WriteLine("no one is currently burrowing the tools");
                }
                Console.WriteLine("****                                     ****");
                Console.WriteLine("**** type anything to go back to menu ****");
                Console.ReadLine();
                StaffOptions();

            }
            void RemoveMemberMenu()
                //removing members from the system
            {
                Console.WriteLine("*********** Remove user  ************");
                Console.WriteLine("**              Type user id >>>>               **");
                string userId = Console.ReadLine();
                Console.WriteLine("**              Type user firstName >>>>               **");
                string userName = Console.ReadLine();
                var result = members.RemoveUser(userId, userName);
                if(result == true)
                {
                    Console.WriteLine("**            User ID :{0}   is removed            **", userId);
                    Console.WriteLine("****                                     ****");
                    Console.WriteLine("**** type anything to go back to menu ****");
                    Console.ReadLine();
                    StaffOptions();
                }
                else
                {
                    Console.WriteLine("**            User {0} not available to remove check again          **", userId);
                    Console.WriteLine("****                                     ****");
                    Console.WriteLine("**** type anything to go back to menu ****");
                    Console.ReadLine();
                    StaffOptions();
                }
                Console.WriteLine("****                                     ****");
                Console.WriteLine("**** type anything to go back to menu ****");
                Console.ReadLine();
                StaffOptions();

            }

            void AddToolMenu()
                //add new tool
            {

                Console.WriteLine("*********** Staff Menu ************");
                Console.WriteLine("**** Add tool  ****");



                bool addContinue = true;
                while (addContinue == true)
                {

                    Console.WriteLine("**              Type new tool Category >>>>               **");
                    string toolCategory = Console.ReadLine();
                    Console.WriteLine("**              Type new tool Type     >>>>               **");
                    string toolType = Console.ReadLine();
                    Console.WriteLine("**              Type Quantity of the new tool   >>>>               **");
                    string toolQnt = Console.ReadLine();
                    Console.WriteLine("**              Type the name of the new tool   >>>>               **");
                    string toolName = Console.ReadLine();
                    //Tool skyler = new Tool("Gardening", "Line Trimmers", 3, "skyler");
                    //var tools = new ToolCollection();

                    tools.AddTool(toolCategory, toolType, Int16.Parse(toolQnt), toolName);
                    Console.WriteLine("**              tool added sucessfully             **");
                    Console.WriteLine("**              type 1 to add another tool           **");
                    Console.WriteLine("**              type 2 to see all the registerd tools     **");
                    Console.WriteLine("**              type 3 go back to staff menu    **");

                    string optionSelect = Console.ReadLine();
                    if (optionSelect == "2")
                    {
                        tools.ShowAllTool();
                        addContinue = false;
                        Console.WriteLine("**              type anything to continue          **");
                        StaffOptions();
                    }
                    else if (optionSelect == "3")
                    {
                        addContinue = false;
                        StaffOptions();
                    }
                
                }



            }


            void RemoveToolMenu()
                //remove the tool from system

            {
                Console.WriteLine("Removing tool");
               
              
                tools.ShowAllTool();
                Console.WriteLine("**              Type tool name to remove >>>>               **");
                string toolName = Console.ReadLine();
                tools.RemoveTool(toolName);
                Console.WriteLine("**              tool: {0} successfuly removed                **", toolName);
                Console.WriteLine("**                                                           **");
                Console.WriteLine("**       updated tool list as shown below                    **");
                tools.ShowAllTool();
                Console.WriteLine("**                                                           **");
                Console.WriteLine("**** type anything to go back to menu ****");
                Console.ReadLine();
                StaffOptions();


            }
     


        }

  
    }


}
