using AppEnergy.Fixtures;
using AppEnergy.Helpers;
using AppEnergy.Models;
using AppEnergy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AppEnergyTests
{
    public class EquipmentSerciceTest
    {
        [Fact]
        public void CreateEquipment_ThrowsErrorIfNoClient()
        {

            HeatPump equipment = new HeatPump();
            equipment.Id = 1;
            

            //StatusEnums
            equipment.Date = new DateTime(2021, 9, 4);
            equipment.Status = StatusEquipmentEnum.Functional;

            EquipmentService _sut = new EquipmentService(); 

            Assert.Throws<ArgumentException>(() => _sut.CreateEquipment(equipment));



        }

        [Fact]

        public void CreateEquipment_ThrowsErrorIfNoStatus()
        {
            HeatPump equipment = new HeatPump();
            equipment.Id = 1;
            equipment.IdClient = 1;

            //StatusEnums
            equipment.Date = new DateTime(2021, 9, 4);

            EquipmentService _sut = new EquipmentService();

            Assert.Throws<ArgumentException>(() => _sut.CreateEquipment(equipment));


        }


        [Fact]

        public void CreateEquipment_THrowsErrorIfNoDate()
        {
            HeatPump equipment = new HeatPump();
            equipment.Id = 1;
            equipment.IdClient = 1;


            //StatusEnums
            equipment.Status = StatusEquipmentEnum.Functional;

            EquipmentService _sut = new EquipmentService();

            Assert.Throws<ArgumentException>(() => _sut.CreateEquipment(equipment));


        }

        [Fact]
        public void CreateEquipment_SuccessfullyCrreateAnEquipment()
        {
            HeatPump equipment = new HeatPump();
            equipment.Id = 1;
            equipment.IdClient = 1;


            //StatusEnums
            equipment.Status = StatusEquipmentEnum.Functional;
            equipment.Date = new DateTime(2021, 9, 4);


            EquipmentService _sut = new EquipmentService();

            var exception = Record.Exception(() => _sut.CreateEquipment(equipment));

            Assert.Null(exception);


        }



        [Fact]
        public void CreateEquipment_ThorwsErrorIfEquipmentLimitReached()
        {
            HeatPump equipment = new HeatPump();
            equipment.Id = 6;
            equipment.IdClient = 2;


            //StatusEnums
            equipment.Status = StatusEquipmentEnum.Functional;
            equipment.Date = new DateTime(2021, 9, 4);

            EquipmentService _sut = new EquipmentService();
            _sut.CreateEquipment(equipment);


            ThermodynamicBaloon thermodynamicBaloon = new();
            thermodynamicBaloon.Id = 8;
            thermodynamicBaloon.IdClient = 2;
            thermodynamicBaloon.Status = StatusEquipmentEnum.Functional;
            thermodynamicBaloon.Date = new DateTime(2021, 9, 4);

            Assert.Throws<Exception>(() => _sut.CreateEquipment(thermodynamicBaloon));



        }


        [Fact]
        public void EditEquipment_SuccesfullyEditEquipment()
        {
            //Select random equipment
            Equipment equipment = EquipmentFixture.equipments.First();
            equipment.Status = "Test in progress ...";

            //Edit
            EquipmentService _sut = new EquipmentService();
            _sut.EditEquipment(equipment);


            //Retrieve equipment and check changes
            Equipment Editedequipment = _sut.GetAllEquipments().Find(x => x.Id == equipment.Id);

            Assert.Equal("Test in progress ...", Editedequipment.Status);


        }
        [Fact]
        public void RemoveEquipment_RemovesAAllMaintenances()
        {
            EquipmentService _sut = new EquipmentService();
            Equipment equipment = _sut.GetAllEquipments().Find(x => x.Id == 1);

            MaintenanceService maintenanceService = new();


            Maintenance maintenance = new Maintenance();
            maintenance.Id = 55;
            maintenance.Date = DateTime.Now;
            maintenance.Status = "OK";
            maintenance.IdEquipment = 1;

            maintenanceService.CreateMaintenance(maintenance);

            Assert.Equal(1, maintenanceService.GetMaintenanceForEquipment(equipment.Id).Count);

            _sut.RemoveEquipment(equipment);
            Assert.Equal(0, maintenanceService.GetMaintenanceForEquipment(equipment.Id).Count);


        }


        [Fact]

        public void RemoveEquipment_RemovesAllIssue()
        {

            EquipmentService _sut = new EquipmentService();
            Equipment equipment = _sut.GetAllEquipments().Find(x => x.Id == 3);

            IssueService issueService = new();

            Assert.Equal(1, issueService.GetEquipmentIssues(equipment.Id).Count);

            _sut.RemoveEquipment(equipment);
            Assert.Equal(0, issueService.GetEquipmentIssues(equipment.Id).Count);

        }

        [Fact]
        public void RemoveEquiment_SuccessfullyRemovesEquipment()
        {
            EquipmentService _sut = new EquipmentService();
            Equipment equipment = _sut.GetAllEquipments().Find(x => x.Id == 1);


            _sut.RemoveEquipment(equipment);

            Equipment DeletedEquipment = _sut.GetAllEquipments().Find(x => x.Id == 1);

            Assert.Null(DeletedEquipment);

        }


        [Fact]

        public void GetEquipmentPerClient_SuccessfullyRetrievesTheRightAmountOfEquipments()
        {
            ClientService clientService = new();

            Client client = new Client();
            client.Name = "Mars";
            client.LastName = "Bruno";
            client.Adress = "6 rue des vents";
            client.ZipCode = 78100;
            client.City = "Saint-Germain-en-Laye";
            client.Mail = "mferrand@gmail.com";
            client.PhoneNumber = "0701012020";
            
            clientService.AddClient(client);


            EquipmentService _sut = new EquipmentService();


            //Equipment new Client 
            HeatPump equipment = new HeatPump();
            equipment.Id = 61;
            equipment.IdClient = client.Id;
            equipment.Date = new DateTime(2021, 9, 4);
            equipment.Status = StatusEquipmentEnum.Functional;
            _sut.CreateEquipment(equipment);


            //Equipment new CLient 1
            SolarPanel equipment2 = new SolarPanel();
            equipment2.Id = 62;
            equipment2.IdClient = client.Id; ;
            equipment2.Date = new DateTime(2021, 9, 4);
            equipment2.Status = StatusEquipmentEnum.Functional;
            _sut.CreateEquipment(equipment2);


            HeatPump equipment3 = new HeatPump();
            equipment3.Id = 63;
            equipment3.IdClient = 1;
            equipment3.Date = new DateTime(2021, 9, 4);
            equipment3.Status = StatusEquipmentEnum.Functional;
            _sut.CreateEquipment(equipment3);



            HeatPump equipment4 = new HeatPump();
            equipment4.Id = 63;
            equipment4.IdClient = 2;
            equipment4.Date = new DateTime(2021, 9, 4);
            equipment4.Status = StatusEquipmentEnum.Functional;
            _sut.CreateEquipment(equipment4);


            //Two created equipment for new client
            Assert.Equal(2, _sut.GetEquipmentPerClient(client).Count);
        }
    }

}
