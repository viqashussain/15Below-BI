using System;
using NUnit.Framework;
using DataSinkApp;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace UnitTests
{
    class DBTestMethods
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger
       (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
                    cmd.CommandType = CommandType.Text;
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

        /// <summary>
        /// Static method that is used to remove the test data from the Test DBs
        /// </summary>
        /// <returns>
        /// boolean - success or fail
        /// </returns>
        /// <param name="command">
        /// The command to be run on the DB.
        /// </param>
        /// <param name="sqlConnString">
        /// The connection string for the database to connect to
        /// </param>
        public static void CleanDB(string command, string sqlConnString)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(sqlConnString))
                {
                    //use an sp to get the data back
                    using (SqlCommand cmd = new SqlCommand(command, myConnection))
                    {
                        cmd.CommandTimeout = 10000;
                        cmd.CommandType = CommandType.Text;
                        myConnection.Open();
                        Log.Debug("Executing Stored Procedure: " + command);
                        SqlDataReader dr = cmd.ExecuteReader();
                        Log.Debug("Finished Executing Stored Procedure: " + command);
                        dr.Read();
                        myConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}
