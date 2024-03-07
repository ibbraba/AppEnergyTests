using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AppEnergy.Fixtures;
using AppEnergy.Models;
using AppEnergy.Services;
using AppEnergy.ViewModels;

namespace AppEnergyTests
{
    public class ClientServiceTest
    {


        [Fact]
        public void AddClient_SuccessfullyAddAClient()
        {
            TestHelper.ReloadInitialFixtures();

            ClientService _sut = new ClientService();





            Client client = new Client();
            client.Name = "Mars";
            client.LastName = "Bruno";
            client.Adress = "6 rue des vents";
            client.ZipCode = 78100;
            client.City = "Saint-Germain-en-Laye";
            client.Mail = "mferrand@gmail.com";
            client.PhoneNumber = "0701012020";




            var Exception = Record.Exception(() => _sut.AddClient(client));
            Assert.Null(Exception);


        }


        [Fact]
        public void Add_CLientThrowsErrorIfMaxClientLimitReached()
        {



            TestHelper.ReloadInitialFixtures();

            Client client = new Client();
            client.Name = "Mars";
            client.LastName = "Bruno";
            client.Adress = "6 rue des vents";
            client.ZipCode = 78100;
            client.City = "Saint-Germain-en-Laye";
            client.Mail = "mferrand@gmail.com";
            client.PhoneNumber = "0701012020";

            ClientService _sut = new ClientService();
            _sut.AddClient(client);

            Client client2 = new Client();
            client2.Name = "Mars";
            client2.LastName = "Bruno";
            client2.Adress = "6 rue des vents";
            client2.ZipCode = 78100;
            client2.City = "Saint-Germain-en-Laye";
            client2.Mail = "mferrand@gmail.com";
            client2.PhoneNumber = "0701012020";

            Assert.Throws<Exception>(() => _sut.AddClient(client2));


        }


        [Fact]
        public void AddClient_ThrowsErrorIfIncompleteName()
        {
            TestHelper.ReloadInitialFixtures();

            Client client = new Client();
            client.Name = "";
            client.LastName = "Bruno";
            client.Adress = "6 rue des vents";
            client.ZipCode = 78100;
            client.City = "Saint-Germain-en-Laye";
            client.Mail = "mferrand@gmail.com";
            client.PhoneNumber = "0701012020";


            ClientService _sut = new ClientService();

            Assert.Throws<ArgumentNullException>(() => _sut.AddClient(client));

          

        }

        [Fact]

        public void AddClient_ThrowsErrorIfIncompleteAdress()
        {

            TestHelper.ReloadInitialFixtures();

            Client client = new Client();
            client.Name = "Mars";
            client.LastName = "Bruno";
            client.Adress = "6 rue des vents";
            client.ZipCode = 78100;
            client.City = "";
            client.Mail = "mferrand@gmail.com";
            client.PhoneNumber = "0701012020";


            ClientService _sut = new ClientService();

            Assert.Throws<ArgumentNullException>(() => _sut.AddClient(client));

        }

        [Fact]

        public void AddClient_ThrowsErrorIfNoContactDetails()
        {

            TestHelper.ReloadInitialFixtures();

            Client client = new Client();
            client.Name = "Mars";
            client.LastName = "Bruno";
            client.Adress = "6 rue des vents";
            client.ZipCode = 78100;
            client.City = "Saint-Germain-en-Laye";


            ClientService _sut = new ClientService();

            Assert.Throws<ArgumentNullException>(() => _sut.AddClient(client));


        }


        [Fact]
        public void DeleteClient_RemovesAllInstancesOfMaintenances()
        {
            TestHelper.ReloadInitialFixtures();


            //CREATE MAINTEANCE 

            MaintenanceService maintenanceService = new();
            

            Maintenance maintenance = new Maintenance();
            maintenance.Id = 55;
            maintenance.Date = DateTime.Now;
            maintenance.Status = "OK"; 
            maintenance.IdEquipment = 1;

            maintenanceService.CreateMaintenance(maintenance);


            ClientService _sut = new ClientService();
            Client client = _sut.GetAllClients().Find(x => x.Id == 1);
      
            //DELETE CLIENT 

            _sut.DeleteClient(client);

            //CHECK IF MAINTENANCE IS DELETED

            List<MaintenanceVM> maintenanceVMs = maintenanceService.GetAllMaintenancesVM().Where(x => x.IdClient == 1).ToList();

            Assert.Equal(0, maintenanceVMs.Count);


        }


        [Fact] 
        public void DeleteLClient_RemovesAllInstancesOfEquipment()
        {
            TestHelper.ReloadInitialFixtures();


            EquipmentService equipmentService = new();

            HeatPump equipment = new();
            equipment.Id = 55;
            equipment.IdClient = 1;
            equipment.Date = DateTime.Now;
            equipment.Status = "OK";

            equipmentService.CreateEquipment(equipment);

            ClientService _sut = new ClientService();

            Client client = _sut.GetAllClients().Find(x => x.Id == 1);

   
            _sut.DeleteClient(client);


            List<Equipment> equipments = equipmentService.GetEquipmentPerClient(client);

            Assert.Equal(0, equipments.Count);



        }

        [Fact]
        public void DeleteClient_RemovesAllInstancesOfIssues()
        {
            TestHelper.ReloadInitialFixtures();


            IssueService issueService = new(); 
            List<IssueVM> issuesInit = issueService.GetAllIssuesVM().Where(x => x.IdClient == 2).ToList();
            Assert.Equal(1, issuesInit.Count);

            ClientService _sut = new ClientService();

            Client client = _sut.GetAllClients().Find(x => x.Id == 2);




            _sut.DeleteClient(client);

            List<IssueVM> issues = issueService.GetAllIssuesVM().Where(x => x.IdClient == 2).ToList();

            Assert.Equal(0, issues.Count);


        }


        

    }
}
