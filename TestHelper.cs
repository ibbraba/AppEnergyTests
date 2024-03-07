using AppEnergy.Fixtures;
using AppEnergy.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEnergyTests
{
    public static class TestHelper
    {
        public static void ReloadInitialFixtures()
        {
            ClientFixture.clients = ClientFixture.GetClients();
            Debug.WriteLine("Client number after reset :" + ClientFixture.clients.Count);
            EquipmentFixture.equipments = EquipmentFixture.GetAllEquipments();
            Debug.WriteLine("Equipment number after reset :" + EquipmentFixture.equipments.Count);
            MaintenanceFixture.Maintenances = new List<Maintenance>();
            Debug.WriteLine("Mainteance number after reset :" + MaintenanceFixture.maintenances.Count);
            IssueFixture.Issues = IssueFixture.GetIssues();
            Debug.WriteLine("Issue number after reset :" + IssueFixture.Issues.Count);

        }
    }
}
