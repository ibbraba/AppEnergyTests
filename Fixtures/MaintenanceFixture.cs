using AppEnergy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppEnergy.Fixtures
{
    class MaintenanceFixture
    {

       public static List<Maintenance> maintenances = new List<Maintenance>();    


        public static List<Maintenance> Maintenances { get { return maintenances; } set { maintenances = value; } }

        


    }
}
