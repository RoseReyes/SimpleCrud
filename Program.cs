using System;
using DbConnection;
using System.Collections.Generic;


namespace consoledb
{
    public class Program
    {
     public static void Read()
      {          
        var query = "SELECT * FROM user";
        var result = DbConnector.Query(query);

        foreach (var user in result)
            {
                Console.WriteLine("ID: " + user["id"] + ", " + user["firstname"] + " " + user["lastname"] + "'s favorite number is " + user["favnum"]);
            }
      }
       public static void Create()
       {              
            Console.WriteLine("Enter your first name:");
            string user_fname = Console.ReadLine();
            Console.WriteLine("Enter your last name:");
            string user_lname = Console.ReadLine();
            Console.WriteLine("Enter your favorite number:");
            string user_num = Console.ReadLine();
            string query = $"INSERT INTO user (firstname, lastname, favnum, created_at, updated_at) VALUES (\"{user_fname}\", \"{user_lname}\", \"{user_num}\", NOW(), NOW());";
            DbConnector.Execute(query);
            Read();
        }
        public static void Update()
        {   
            Console.WriteLine("Enter the ID of the user whose information you would like to update:");
            string user_Id = Console.ReadLine();
            Console.WriteLine("Updated first name:");
            string user_fname = Console.ReadLine();
            Console.WriteLine("Updated last name:");
            string user_lname = Console.ReadLine();
            Console.WriteLine("Updated favorite number:");
            string user_num = Console.ReadLine();
            string query = $"UPDATE users SET first_name=\"{user_fname}\", last_name=\"{user_lname}\", favorite_number=\"{user_num}\", updated_at=NOW() WHERE id={user_Id}";
            DbConnector.Execute(query);
            Read();
       }
        public static void Main(string[] args)
        {
            Create();
        }
    }
}

