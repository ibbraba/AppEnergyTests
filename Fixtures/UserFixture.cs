using AppEnergy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEnergy.Fixtures
{
    static class UserFixture
    {

        public static List<User> users = GetUsers();  


        private static User User1()
        {

            User administration = new();

            administration.Id = 1;
            administration.Name = "Jane";
            administration.LastName = "Hevlet";
            administration.Login = "administratorService";
            //TODO: HASH Password
            administration.Password = "AEadminPassword";
            administration.Role = "Administration Service"; 

            return administration;

            
         }


        private static User User2()
        {
            User engineer = new();
            engineer.Id = 2;
            engineer.Name = "John";
            engineer.LastName = "Doe";
            engineer.Login = "JohnDoe";
            //TODO: HASH Password
            engineer.Password = "AEDoeJohn";
            engineer.Role = "Engineer";

            return engineer;

        }
       

        public static List<User> GetUsers()
        {

            User user1 = User1();
            User user2 = User2();

            List<User> users = new();
            users.Add(user1);
            users.Add(user2);   

            return users;   
                    

        }






     }   
}
