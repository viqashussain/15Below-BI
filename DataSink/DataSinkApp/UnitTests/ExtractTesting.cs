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

        [TestCase]
        public void TestExtractData()
        {
            //Test Extract.ExtractData Method
            //Run the Extract Process
            DataSinkApp.Extract.ExtractThread.ExtractData(true);

            //59 records should be added to the TESTStagingDB
            string command = "SELECT COUNT(0) FROM StagingTable";
            string sqlConnString = ConfigurationManager.ConnectionStrings["sqlConnStringSDBTEST"].ConnectionString;
            int numberOfRecords = AssertDBTable(command, sqlConnString);
            Assert.AreEqual(59, numberOfRecords);
        }

        [TestCase]
        public void TestGetLastRecipientID()
        {
            //Test Extract.GetLastRecipientID Method
            //RecipientID returned should be 0 if DataWarehouse is empty (TestDataWarehouse is empty)
            int recipientID = DataSinkApp.Extract.ExtractThread.GetLastRecipientID(true);
            Assert.AreEqual(0, recipientID);
        }

        /// <summary>
        /// Static method that is used to get count of rows from a DB
        /// from a specific table.
        /// </summary>
        /// <returns>
        /// int - number of records in the table
        /// </returns>
        /// <param name="command">
        /// The command to be run on the DB.
        /// </param>
        /// <param name="sqlConnString">
        /// The connection string for the database to connect to
        /// </param>
        public static int AssertDBTable(string command, string sqlConnString)
        {
            int countofrows = 0;
            using (SqlConnection myConnection = new SqlConnection(sqlConnString))
            {
                //use an sp to get the data back
                using (SqlCommand cmd = new SqlCommand(command, myConnection))
                {
                    cmd.CommandTimeout = 10000;
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    Log.Debug("Executing Stored Procedure: " + command);
                    SqlDataReader dr = cmd.ExecuteReader();
                    Log.Debug("Finished Executing Stored Procedure: " + command);
                    dr.Read();
                    countofrows = (int)dr[0];
                    myConnection.Close();
                }
            }
            return countofrows;
        }
    }
}
