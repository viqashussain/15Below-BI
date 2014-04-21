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
        [TestFixtureTearDown]
        public void TearDown()
        {
            //Remove all data from the StagingBD
            //The Load process should take care of this so we do not need to do it

            //Remove all data from DataWarehouse
            string command = "DELETE FROM FactTable;DELETE FROM ExtractsDim;DELETE FROM DataSourceDim;DELETE FROM NotificationsDim;DELETE FROM FlightsDim;DELETE FROM PaxDim;DELETE FROM RecipientsDim;DELETE FROM TemplatesDim;";
            string connString = ConfigurationManager.ConnectionStrings["sqlConnStringDWTEST"].ConnectionString;
            UnitTests.DBTestMethods.CleanDB(command, connString);
        }

        [TestFixtureSetUp]
        public void SetUp()
        {
            //Run the Extract Process to get 133 records into the StagingDB
            DataSinkApp.Extract.ExtractThread.ExtractData(true);

            //Run the Transform Process to get the data ready for Loading
            DataSinkApp.Transform.Transform.TransformData(true);
        }

        [Test]
        public void TestLoad()
        {
            //Run the Load Process
            DataSinkApp.Load.Load.LoadData(true);

            //Data Should have been loaded into the DataWarehouse
            //Dimension Tables and Fact Table should contain data:
            //DataSourceDim: 48
            //ExtractsDim: 58
            //FactTable: 133
            //FlightsDim: 104
            //NotificationsDim: 48
            //PaxDim: 0
            //RecipientsDim: 59
            //TemplatesDim: 2

            //Assert DataSourceDim
            string command = "SELECT COUNT(0) FROM DataSourceDim";
            string sqlConnString = ConfigurationManager.ConnectionStrings["sqlConnStringDWTEST"].ConnectionString;
            int numberOfRecords = UnitTests.DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(48, numberOfRecords);

            //Assert ExtractsDim
            command = "SELECT COUNT(0) FROM ExtractsDim";
            numberOfRecords = UnitTests.DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(58, numberOfRecords);

            //Assert FactTable
            command = "SELECT COUNT(0) FROM FactTable";
            numberOfRecords = UnitTests.DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(133, numberOfRecords);

            //Assert FlightsDim
            command = "SELECT COUNT(0) FROM FlightsDim";
            numberOfRecords = UnitTests.DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(104, numberOfRecords);

            //Assert NotificationsDim
            command = "SELECT COUNT(0) FROM NotificationsDim";
            numberOfRecords = UnitTests.DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(48, numberOfRecords);

            //Assert PaxDim
            command = "SELECT COUNT(0) FROM PaxDim";
            numberOfRecords = UnitTests.DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(0, numberOfRecords);

            //Assert RecipientsDim
            command = "SELECT COUNT(0) FROM RecipientsDim";
            numberOfRecords = UnitTests.DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(59, numberOfRecords);

            //Assert TemplatesDim
            command = "SELECT COUNT(0) FROM TemplatesDim";
            numberOfRecords = UnitTests.DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(2, numberOfRecords);

            //StagingDB should be empty now
            //Assert DataSourceDim
            command = "SELECT COUNT(0) FROM DataSourceDim";
            sqlConnString = ConfigurationManager.ConnectionStrings["sqlConnStringSDBTEST"].ConnectionString;
            numberOfRecords = UnitTests.DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(0, numberOfRecords);

            //Assert ExtractsDim
            command = "SELECT COUNT(0) FROM ExtractsDim";
            numberOfRecords = UnitTests.DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(0, numberOfRecords);

            //Assert FactTable
            command = "SELECT COUNT(0) FROM FactTable";
            numberOfRecords = UnitTests.DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(0, numberOfRecords);

            //Assert FlightsDim
            command = "SELECT COUNT(0) FROM FlightsDim";
            numberOfRecords = UnitTests.DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(0, numberOfRecords);

            //Assert NotificationsDim
            command = "SELECT COUNT(0) FROM NotificationsDim";
            numberOfRecords = UnitTests.DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(0, numberOfRecords);

            //Assert PaxDim
            command = "SELECT COUNT(0) FROM PaxDim";
            numberOfRecords = UnitTests.DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(0, numberOfRecords);

            //Assert RecipientsDim
            command = "SELECT COUNT(0) FROM RecipientsDim";
            numberOfRecords = UnitTests.DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(0, numberOfRecords);

            //Assert TemplatesDim
            command = "SELECT COUNT(0) FROM TemplatesDim";
            numberOfRecords = UnitTests.DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(0, numberOfRecords);

            //Assert StagingTable
            command = "SELECT COUNT(0) FROM StagingTable";
            numberOfRecords = UnitTests.DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(0, numberOfRecords);
        }
    }
}
