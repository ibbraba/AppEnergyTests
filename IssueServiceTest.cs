using AppEnergy.Helpers;
using AppEnergy.Models;
using AppEnergy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEnergyTests
{
    public class IssueServiceTest
    {

        [Fact]

        public void CreateIssue_ThrowsErrorIfNoDate()
        {

            IssueService _sut = new IssueService();

            Issue issue = new();
            issue.IdEquipment = 1;
            //issue.ReportDate = DateTime.Now.AddDays(-11);
            issue.Description = "Baloon out of service, error code :d5707";
            issue.Status = StatusIssueEnum.NotFixed;


            Assert.Throws<ArgumentException>(() => _sut.CreateIssue(issue));



        }

        [Fact]
        public void CreateIssue_ThrowsErrorIfNoStatus() {

            IssueService _sut = new IssueService();

            Issue issue = new();
            issue.IdEquipment = 1;
            issue.ReportDate = DateTime.Now.AddDays(-11);
            issue.Description = "Baloon out of service, error code :d5707";
            //issue.Status = StatusIssueEnum.NotFixed;


            Assert.Throws<ArgumentException>(() => _sut.CreateIssue(issue));

        }

        [Fact]
        public void CreateIssue_ThrowsErrorIfNoDescription() {
            IssueService _sut = new IssueService();

            Issue issue = new();
            issue.IdEquipment = 1;
            issue.ReportDate = DateTime.Now.AddDays(-11);
            //issue.Description = "Baloon out of service, error code :d5707";
            issue.Status = StatusIssueEnum.NotFixed;


            Assert.Throws<ArgumentException>(() => _sut.CreateIssue(issue));
        }


        [Fact]
        public void CreateIssue_ThrowsErrorIfMaxIssuesReached() {

            IssueService _sut = new IssueService();

            Issue issue = new();
            issue.IdEquipment = 3;
            issue.ReportDate = DateTime.Now.AddDays(-11);
            issue.Description = "out of service";
            issue.Status = StatusIssueEnum.NotFixed;


            _sut.CreateIssue(issue);

            Issue issue1 = new();
            issue1.IdEquipment = 3;
            issue1.ReportDate = DateTime.Now.AddDays(-11);
            issue1.Description = "out of service";
            issue1.Status = StatusIssueEnum.NotFixed;


            Assert.Throws<Exception>(() => _sut.CreateIssue(issue1));


        }


        [Fact]
        public void CreateIssue_SuccessfullyCreateIssue()
        {
            IssueService _sut = new IssueService();


            Issue issue = new();
            issue.IdEquipment = 3;
            issue.ReportDate = DateTime.Now.AddDays(-11);
            issue.Description = "out of service";
            issue.Status = StatusIssueEnum.NotFixed;


            var exception = Record.Exception(()=> _sut.CreateIssue(issue));
            Assert.Null(exception);

        }


        [Fact]
        public void EditIssue_SuccessfullyEditIssue()
        {
            IssueService _sut = new IssueService();
            Issue issue = _sut.GetAllIssues().First();

            issue.Status = "Testing ...";
            _sut.EditIssue(issue); 


            Issue EditedIssue = _sut.GetAllIssues().Find(x => x.Id == issue.Id);

            Assert.Equal("Testing ...", EditedIssue.Status);

        }
        [Fact]
        public void DeleteIssue_SuccessfullyDeleteIssue()
        {
            IssueService _sut = new IssueService();

            Issue issue = _sut.GetAllIssues().First();

            _sut.DeleteIssue(issue);

            Issue deletedIssue = _sut.GetAllIssues().Find(x => x.Id == issue.Id);
            Assert.Null(deletedIssue);
        }
    }
}
