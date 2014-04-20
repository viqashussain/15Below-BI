using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Configuration;

namespace UnitTests
{
    class LoadTesting
    {
        [TearDown]
        public void TearDown()
        {
            //Remove all data from the StagingBD
            string command = "DELETE FROM FactTable;DELETE FROM ExtractsDim;DELETE FROM DataSourceDim;DELETE FROM NotificationsDim;DELETE FROM FlightsDim;DELETE FROM PaxDim;DELETE FROM RecipientsDim;DELETE FROM StagingTable;DELETE FROM TemplatesDim;";
            string connString = ConfigurationManager.ConnectionStrings["sqlConnStringSDBTEST"].ConnectionString;
            DBTestMethods.CleanDB(command, connString);
            //Remove all data from DataWarehouse
            command = "DELETE FROM FactTable;DELETE FROM ExtractsDim;DELETE FROM DataSourceDim;DELETE FROM NotificationsDim;DELETE FROM FlightsDim;DELETE FROM PaxDim;DELETE FROM RecipientsDim;DELETE FROM TemplatesDim;";
            connString = ConfigurationManager.ConnectionStrings["sqlConnStringDWTEST"].ConnectionString;
            DBTestMethods.CleanDB(command, connString);

        }

        [SetUp]
        public void SetUp()
        {
            //Run the Extract Process to get 133 records into the StagingDB
            DataSinkApp.Extract.ExtractThread.ExtractData(true);

            //Run the Transform Process to get the data ready for Loading
            DataSinkApp.Load.Load.LoadData(true);
        }
    }
}
