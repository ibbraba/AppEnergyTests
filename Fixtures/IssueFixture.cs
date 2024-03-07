using AppEnergy.Helpers;
using AppEnergy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEnergy.Fixtures
{
    static class IssueFixture
    {

        public static List<Issue> Issues = GetIssues();  
 

        public static Issue Client1Issue()
        {
            Issue issue = new();
            issue.IdEquipment = 3; 
            issue.ReportDate = DateTime.Now.AddDays(-11);
            issue.Description = "Baloon out of service, error code :d5707";
            issue.Status = StatusIssueEnum.NotFixed;



            return issue;
        }


        public static List<Issue> GetIssues() {
        
            List<Issue> issues = new(); 
            issues.Add(Client1Issue());


            return issues;
        }

    }
}
