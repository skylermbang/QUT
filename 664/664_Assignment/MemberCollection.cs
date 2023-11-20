using System;
using System.Collections.Generic;
using System.Linq;

namespace _664_Assignment
{

    ///  hashtable is implemented by myself not using original hashtable 
    public class MemberCollection
    {
        public MemberCollection()
        {
        }

     

       

        public class Node<T>
        {
            public Node<T> Next { get; set; }
            public Members User { get; set; }
            public  List<Node<Members>> UserList { get; set; } = new List<Node<Members>>();
         
            public T Value { get; set; }
        }

   
        public class Hashtable<T>
        {
            private readonly Node<T>[] _buckets;

            public Hashtable(int size)
            {
                _buckets  = new Node<T>[size];
            }

   


            public T Get(string id)
            {
         

                var (_, node) = GetNodeByKey(id);  // _ for the previous node. we dont use it 
                if (node == null) throw
                        new ArgumentNullException(
                            nameof(id), $"The user '{id}'is not registred");
                return node.Value;
            }





            // add new user
            public void Register(string firstName, string lastName, string id, string pw, string phone, T id_)
            {

                var User = new Members(firstName, lastName, id, pw, phone);
                var valueNode = new Node<Members> { User = User, /*Value = id_,*/ Next = null };
                int position = GetBucketByKey(id);
                Node<T> listNode = _buckets[position];


                if (null == listNode)
                {
          
                    
                    _buckets[position] = new Node<T>();
                    _buckets[position].UserList.Add(valueNode);

                }
                else
                {
                    listNode.UserList.Add(valueNode);
               
                }
            }
     

           




            protected (Node<T> previous, Node<T> current) GetNodeByKey(string id)
            {
                int position = GetBucketByKey(id);
                Node<T> listNode = _buckets[position];
                Node<T> previous = null;

                while (null != listNode)
                {
                    //if (listNode.id == id) return (previous, listNode);
                    if (listNode?.User.id == id) return (previous, listNode);
                    previous = listNode;
                    listNode = listNode.Next;
                }

                return (null, null);
            }

            public int GetBucketByKey(string id)

            {
                int place = id[0] % _buckets.Length; //eg. 115/4 R 3
                return place;
            }

            

            // login user 

            public Members Login(string Id, string pwd)
            {
                Console.WriteLine("log in test ");
                int position = GetBucketByKey(Id);
                Node<T> existingNode = _buckets[position];

                if (existingNode != null)
                {
                    var existUser=existingNode.UserList.Where(f => f.User.id == Id && f.User.pw == pwd).FirstOrDefault();
                    if (existUser?.User != null)
                        return existUser.User;
                    else
                        return null;
                }



                
                return null;
            }


            // burrow tools
            public Members Burrow(string Id, string firstName, string toolName)
            {



                Console.WriteLine("burrowing the tool ");
                int position = GetBucketByKey(Id);
                Node<T> existingNode = _buckets[position];
                if (existingNode != null)
                {
                    var existingUser= existingNode.UserList.Where(f => f.User.firstName == firstName).FirstOrDefault();
                    if(existingUser!=null)
                    {
                        existingUser.User.Burrow(toolName);
        
                        return existingUser.User;
                    }
                   
                }

                return null;
            }

            //rent tools

            public Members Return(string Id, string firstName, string toolName)
            {
                Console.WriteLine("returning the tool ");
                int position = GetBucketByKey(Id);
                Node<T> existingNode = _buckets[position];
                if (existingNode != null)
                {
                    var existingUser = existingNode.UserList.Where(f => f.User.firstName == firstName).FirstOrDefault();
                    if (existingUser != null)
               
                    {
                        existingUser.User.Return(toolName);
       
                        return existingUser.User;
                    }

                }

                return null;
            }


            public String[] MyTool(string Id, string firstName)
            {
                Console.WriteLine("showing  tools ");
                int position = GetBucketByKey(Id);
                Node<T> existingNode = _buckets[position];
                var existingUser = existingNode.UserList.Where(f => f.User.firstName == firstName).FirstOrDefault();
                     if (existingUser != null)
                    
                    {
                    if (existingUser.User.firstName == firstName)
                    {
               
                        return existingUser.User.tools;
                    }

                }

                return null;
            }

            // show currently burrowing tool usrs
            public List<string> ShowEveryOne()
            {
                Console.WriteLine("show everyone currently burrowing tools ");


                List<string> Users = new List<string>();

                for (int i=0; i<4; i++)
                {
                    Node<T> existingNode = _buckets[i];
                    if(existingNode != null){
                    var existingUser = existingNode.UserList.Where(f => f.User.current == true).FirstOrDefault();
                    if (existingUser != null) { Users.Add(existingUser.User.firstName); }
                    }
                }
                return Users;
                
            }


            // show phone number 
            public string ShowPhone(string Id, string firstName)
            {
                Console.WriteLine("searching phone number  ");


                Console.WriteLine("showing  tools ");
                int position = GetBucketByKey(Id);
                Node<T> existingNode = _buckets[position];
                var existingUser = existingNode.UserList.Where(f => f.User.firstName == firstName).FirstOrDefault();
                if (existingUser != null)

                {
                    if (existingUser.User.firstName == firstName)
                    {

                        return existingUser.User.phoneNumber;
                    }

                }

                return null;

            }

            // delete the user
            public Boolean RemoveUser(string Id, string firstName)
            {
                var removeResult = false;
                int position = GetBucketByKey(Id);
                Node<T> existingNode = _buckets[position];
                var existingUser = existingNode.UserList.Where(f => f.User.firstName == firstName).FirstOrDefault();
             
                if (existingUser != null)

                {
                    if (existingUser.User.firstName == firstName)
                    {

                        existingUser.User = null;
                        removeResult = true;
                        return removeResult;
                    }
                    

                }

                return removeResult;

            }


        }

    
    }
}
