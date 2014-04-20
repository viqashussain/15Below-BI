using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Configuration;

namespace UnitTests
{
    [TestFixture]
    class TransformTesting
    {

        [TearDown]
        public void TearDown()
        {
            //Remove all data from the StagingBD
            string command = "DELETE FROM FactTable;DELETE FROM ExtractsDim;DELETE FROM DataSourceDim;DELETE FROM NotificationsDim;DELETE FROM FlightsDim;DELETE FROM PaxDim;DELETE FROM RecipientsDim;DELETE FROM StagingTable;DELETE FROM TemplatesDim;";
            string connString = ConfigurationManager.ConnectionStrings["sqlConnStringSDBTEST"].ConnectionString;
            DBTestMethods.CleanDB(command, connString);
        }

        [SetUp]
        public void SetUp()
        {
            //Run the Extract Process to get 133 records into the StagingDB
            DataSinkApp.Extract.ExtractThread.ExtractData(true);
        }

        [Test]
        public void TestTransform()
        {
            //Run the Transform Process
            DataSinkApp.Transform.Transform.TransformData(true);

            //Data in the StagingDB should be transformed
            //Staging Dimension Tables and Fact Table should contain data:
            //DataSourceDim: 48
            //ExtractsDim: 58
            //FactTable: 133
            //FlightsDim: 104
            //NotificationsDim: 48
            //PaxDim: 0
            //RecipientsDim: 59
            //StagingTable: 133
            //TemplatesDim: 2

            //Assert DataSourceDim
            string command = "SELECT COUNT(0) FROM DataSourceDim";
            string sqlConnString = ConfigurationManager.ConnectionStrings["sqlConnStringSDBTEST"].ConnectionString;
            int numberOfRecords = DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(48, numberOfRecords);

            //Assert ExtractsDim
            command = "SELECT COUNT(0) FROM ExtractsDim";
            numberOfRecords = DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(58, numberOfRecords);

            //Assert FactTable
            command = "SELECT COUNT(0) FROM FactTable";
            numberOfRecords = DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(133, numberOfRecords);

            //Assert FlightsDim
            command = "SELECT COUNT(0) FROM FlightsDim";
            numberOfRecords = DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(104, numberOfRecords);

            //Assert NotificationsDim
            command = "SELECT COUNT(0) FROM NotificationsDim";
            numberOfRecords = DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(48, numberOfRecords);

            //Assert PaxDim
            command = "SELECT COUNT(0) FROM PaxDim";
            numberOfRecords = DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(0, numberOfRecords);

            //Assert RecipientsDim
            command = "SELECT COUNT(0) FROM RecipientsDim";
            numberOfRecords = DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(59, numberOfRecords);

            //Assert StagingTable
            command = "SELECT COUNT(0) FROM StagingTable";
            numberOfRecords = DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(133, numberOfRecords);

            //Assert TemplatesDim
            command = "SELECT COUNT(0) FROM TemplatesDim";
            numberOfRecords = DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(2, numberOfRecords);
        }
    }
}
