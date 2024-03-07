using AppEnergy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEnergy.Fixtures
{
    static class AppFixtures
    {

        public static List<User> users = UserFixture.GetUsers();

        public static List<Client> clients = ClientFixture.GetClients();

        public static List<Equipment> equipments = EquipmentFixture.GetAllEquipments();

        public static List<Issue> issues;

        public static List<Maintenance> maintenances; 




        

      
   }
}
