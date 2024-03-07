using AppEnergy.Helpers;
using AppEnergy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AppEnergy.Fixtures
{
   static class EquipmentFixture
    {

        public static List<Equipment> equipments = GetAllEquipments();
        


         static Equipment Equipment1()
        {
            HeatPump equipment = new HeatPump();
            equipment.Id = 1; 
            equipment.IdClient = 1;
            
            //StatusEnums
            equipment.Date = new DateTime(2021, 9, 4);
            equipment.Status = StatusEquipmentEnum.Functional;

            return equipment;
        }

         static Equipment Equipment2()
        {
            SolarPanel equipment = new SolarPanel();
            equipment.Id = 2;
            equipment.IdClient = 2;
            equipment.Color = "Full black";
            //StatusEnums
            equipment.Date = new DateTime(2019, 11, 21);
            equipment.Status = StatusEquipmentEnum.Functional;

            return equipment;
        }

         static Equipment Equipment3()
        {
            ThermodynamicBaloon equipment = new ();
            equipment.Id = 3;
            equipment.IdClient = 2;
            //StatusEnums
            equipment.Date = new DateTime(2018, 3, 25);
            equipment.Status = StatusEquipmentEnum.OutOfService;

            return equipment;
        }



         public static List<Equipment> GetAllEquipments()
        {
            List<Equipment> equipments = new List<Equipment>();
            Equipment equipment1 = Equipment1();
            Equipment equipment2 = Equipment2();
            Equipment equipment3 = Equipment3();

            equipments.Add(equipment1);
            equipments.Add(equipment2);
            equipments.Add(equipment3);

            return equipments;

        }

    }
}
