using System;
using NUnit.Framework;
using DataSinkApp;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace UnitTests
{
    [TestFixture]
    public class ExtractTesting
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [Test]
        public void TestExtractData()
        {
            //Test Extract.ExtractData Method
            //Run the Extract Process
            DataSinkApp.Extract.ExtractThread.ExtractData(true);

            //133 records should be added to the TESTStagingDB
            string command = "SELECT COUNT(0) FROM StagingTable";
            string sqlConnString = ConfigurationManager.ConnectionStrings["sqlConnStringSDBTEST"].ConnectionString;
            int numberOfRecords = DBTestMethods.AssertDBTable(command, sqlConnString);
            Assert.AreEqual(133, numberOfRecords);
        }

        [Test]
        public void TestGetLastRecipientID()
        {
            //Test Extract.GetLastRecipientID Method
            //RecipientID returned should be 0 if DataWarehouse is empty (TestDataWarehouse is empty)
            int recipientID = DataSinkApp.Extract.ExtractThread.GetLastRecipientID(true);
            Assert.AreEqual(0, recipientID);
        }

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
            //No SetUp Required
        }
    }
}
