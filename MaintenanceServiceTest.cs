using AppEnergy.Models;
using AppEnergy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEnergyTests
{
    public class MaintenanceServiceTest
    {
        [Fact]
        public void CreateMaintenance_ThrowErrorIfNoEquipment () {


            MaintenanceService maintenanceService = new();


            Maintenance maintenance = new Maintenance();
            maintenance.Id = 55;
            maintenance.Date = DateTime.Now;
            maintenance.Status = "OK";
          //  maintenance.IdEquipment = 1;

            Assert.Throws<ArgumentException>(()=> maintenanceService.CreateMaintenance(maintenance));



        }

        [Fact]
        public void CreateMaintenance_ThrowErrorIfNoDate() {

            MaintenanceService maintenanceService = new();


            Maintenance maintenance = new Maintenance();
            maintenance.Id = 55;
//            maintenance.Date = DateTime.Now;
            maintenance.Status = "OK";
            maintenance.IdEquipment = 1;

             Assert.Throws<ArgumentException>(()=> maintenanceService.CreateMaintenance(maintenance));

        }

        [Fact]
        public void CreateMaintenance_ThrowErrorIfNoStatus() {
        
            
            MaintenanceService maintenanceService = new();


            Maintenance maintenance = new Maintenance();
            maintenance.Id = 55;
            maintenance.Date = DateTime.Now;
            //maintenance.Status = "OK";
            maintenance.IdEquipment = 1;

            Assert.Throws<ArgumentException>(() => maintenanceService.CreateMaintenance(maintenance));
        }
        [Fact]
        public void CreateMaintenance_ThrowErrorIfYearlyMainteananceAlreadyScheduled() {
           
            MaintenanceService maintenanceService = new();

            Maintenance maintenance = new Maintenance();
            maintenance.Id = 55;
            maintenance.Date = DateTime.Now;
            maintenance.Status = "OK";
            maintenance.IdEquipment = 2;

            maintenanceService.CreateMaintenance(maintenance);

            Maintenance maintenance2 = new Maintenance();
            maintenance2.Id = 88;
            maintenance2.Date = DateTime.Now.AddMonths(6);
            maintenance2.Status = "OK";
            maintenance2.IdEquipment = 2;

            Assert.Throws<Exception>(() => maintenanceService.CreateMaintenance(maintenance2)); 


        }
        [Fact]
        public void CreateMaintenance_SuccessfullyCreateMaintenance() {
            MaintenanceService maintenanceService = new();

            Maintenance maintenance = new Maintenance();
            maintenance.Id = 55;
            maintenance.Date = DateTime.Now;
            maintenance.Status = "OK";
            maintenance.IdEquipment = 1;

            var exception = Record.Exception( ()=> maintenanceService.CreateMaintenance(maintenance));
            Assert.Null(exception);
        }

        [Fact]
        public void EditMaintenance_SuccessfullyEditMaintenance() {

            MaintenanceService maintenanceService = new();

            Maintenance maintenance = maintenanceService.GetAllMiantenances().First();
            maintenance.Status = "Testing ...";

            maintenanceService.EditMaintenance(maintenance);

            Maintenance editedMaintenance = maintenanceService.GetAllMiantenances().Find(x => x.Id == maintenance.Id);

            Assert.Equal("Testing ...", editedMaintenance.Status);



        }

        [Fact]
        public void DeleteMaintenance_SuccessfullyDeleteMaintenance() {


            MaintenanceService maintenanceService = new();

            Maintenance maintenance = new Maintenance();
            maintenance.Id = 55;
            maintenance.Date = DateTime.Now;
            maintenance.Status = "OK";
            maintenance.IdEquipment = 2;

            maintenanceService.CreateMaintenance(maintenance);




            maintenanceService.DeleteMaintenance(maintenance);

            Maintenance deletedMaintenance = maintenanceService.GetAllMiantenances().Find(x => x.Id == maintenance.Id);

            Assert.Null(deletedMaintenance);

        }
    }
}
