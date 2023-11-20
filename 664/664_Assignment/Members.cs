using System;
namespace _664_Assignment
{
    public class Members
    {


        public string firstName;
        public string lastName;
        public string id;
        public string pw;
        public string phoneNumber;
        public string[] tools = new string[5];
        public static int registerCount = 0;
        public Boolean current;




        public Members(string firstName, string lastName, string id, string pw, string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.current = false;
                
            this.id = id;
            this.pw = pw;

            registerCount++;
        }

        public void Burrow(string tool)
        {
            for(int i=0; i< tools.Length; i++)
            {
                if(tools[i] == null)
                {
                    tools[i] = tool;
                    break;
                }
              
            }
            Check();
        }


        public void Return(string tool)
        {
            for (int i = 0; i < tools.Length; i++)
            {
                if (tools[i] == tool)
                {   
                   
                    tools[i] = null;
                    break;
                }
                
            }
            Check();
        }

        public void Check()


        {
            for (int i = 0; i < tools.Length; i++)
            {
                if (tools[i] != null)
                {

                    this.current = true;
                    break;
                }
            }
      
        }


    }
}
