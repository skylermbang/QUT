using System;
using System.Linq;
using System.Collections.Generic;

namespace _664_Assignment
{
    public class ToolCollection
    {
        // tool collection using array. 
        public int n = 1;
        public Tool[] tools;

        public ToolCollection()
        {
            
            this.tools = new Tool[n];          
        }



        // add new tool
        public void AddTool(string category, string type,int qnt, string name)



        {
      
            Tool[] newTools = new Tool[n];
            if (this.n == 1)
            {
                tools[0]= new Tool(category, type, qnt, name);
                this.n = n + 1;
                Console.WriteLine(this.n);
            }
            else if(this.n >= 2)
            {
                Console.WriteLine("aready {0} number of tool is registerd", this.tools.Length+1);
                //Console.WriteLine(" n value is {0} ", n);
                for (int j = 0; j< this.tools.Length ; j++)
                {
                    newTools[j] = this.tools[j];
                }
                // copying the old array into new array
                for (int i = 0; i < n; i++)
                {
                    if (newTools[i] == null)
                    {
                        newTools[i] = new Tool(category, type, qnt, name);

                    }
                }
                // adding new tool in to empty

                this.tools = new Tool[n];
                this.tools = (Tool[])newTools.Clone();
            

                this.n = n + 1;
            }
        }


        //remove tool
        public void RemoveTool(string name)
        {
            List<int> savePosition = new List<int>();
            int removePostion = 0 ;

            for (int i = 0; i < this.n-1; i++)
            {

                if(this.tools[i].name != name)
                {
                    savePosition.Add(i);
                }else if(this.tools[i].name == name)
                {
                    removePostion = i;
                }

              
            }


          
            Console.WriteLine("item removed");
            this.n = n - 1;
            Tool[] newTools = new Tool[n];

            for(int j=0; j< savePosition.Count; j++)
            {
                newTools[j] = tools[j];
            }
            this.tools = newTools;

           
        
     

        }


        // show all the tools registered in the system
        public void ShowAllTool()

        {
            Console.WriteLine("showing all the tools");
            Console.WriteLine("total tools registerd are :{0}", this.tools.Length);
          

            for(int k=0; k<this.n-1; k++)
            {
                if (this.tools[k].name != null)
                {
                    Console.WriteLine(" tool name {0} | tool category{1} | tool type{2} | tool quantity {3}", this.tools[k].name, this.tools[k].category, this.tools[k].type, this.tools[k].Qnt);
                }
                else
                {
                    Console.WriteLine("tool registred {0} is null ", k);
                }
            }
        }


        // burrow tool 
        public void BurrowTool(string category, string type, string name)

        {
            int indexNum=0;

            Console.WriteLine("burrowing tools");
            for(int i=0; i<tools.Length; i++)
            {
                if(this.tools[i].name == name)
                {
                    Console.WriteLine("found the tool");
                    indexNum = i;

                }
               
            }

            tools[indexNum].currentQnt--;
            tools[indexNum].current = true;
            if(tools[indexNum].Qnt == 0)
            {
                tools[indexNum].availbility = false;
                
            }

            tools[indexNum].BurrowNum++;

          
        }


        // return tool
        public void ReturnTool(string name)

        {
            int indexNum = 0;

            Console.WriteLine("returning tools");
            for (int i = 0; i < tools.Length; i++)
            {
                if (this.tools[i].name == name)
                {
                    Console.WriteLine("found the tool");
                    indexNum = i;

                }
                else
                {
                    Console.WriteLine("cant find the tool");
                }
            }

            tools[indexNum].currentQnt++;
            if(tools[indexNum].currentQnt == tools[indexNum].Qnt)
            {
                tools[indexNum].current = true;
            }
         
            if (tools[indexNum].currentQnt > 0)
            {
                tools[indexNum].availbility = true;

            }

            


        }


        public string TopThree()
            // showing top three popular tools by bubble sort

        {
            int n = this.tools.Length;
            Tool[] sortedTools = new Tool[n];

   
            for (int i =0; i< this.tools.Length; i++)
            {
                for(int j=0; j<this.tools.Length-1; j++)
                {
                    if(this.tools[j].BurrowNum > this.tools[j + 1].BurrowNum)
                    {

                        var temp = this.tools[j];
                        this.tools[j] = this.tools[j + 1];
                        this.tools[j + 1] = temp;


                    }
                }

             

                
            }
            return $"{this.tools[^1].name}-{this.tools[^2].name}-{this.tools[^3].name}";

        }

        public string TopThree2()

        // showing top three popular tools by quick sort



        {
            int i = this.tools.Length - 1;
            int j = 0;
            var pivot = this.tools[i].BurrowNum;


            while (i <= j)
            {
                while (this.tools[i].BurrowNum < pivot)
                {
                    i++;
                }
                while(this.tools[j].BurrowNum > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    var temp = this.tools[i];
                    this.tools[i] = this.tools[j];
                    this.tools[j] = temp;
                    i++;
                    j--;
                }
            }

            
            return $"{this.tools[^1].name}-{this.tools[^2].name}-{this.tools[^3].name}";

        }




    }




}
