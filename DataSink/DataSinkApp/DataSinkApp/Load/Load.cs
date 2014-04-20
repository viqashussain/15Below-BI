using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSinkApp.Extract;
using DataSinkApp;

namespace DataSinkApp.Load
{
    /// <summary>
    /// Class which contains all the functionality for the Load Process which 
    /// will load the data into the DataWarehouse.
    /// </summary>
    public class Load
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Static method which we be called from Program.Main.
        /// This method will Load the data from the StagingDB into the
        /// DataWarehouse by executing a Stored Procedure in the StagingDB. 
        /// Once data loading is complete, another stored procedure
        /// will be executed in the StagingDB to clean up the StagingDB.
        /// </summary>
        /// <returns>
        /// bool - success or failure, true for errors, false for no errors
        /// </returns>
        public static bool LoadData(bool testing = false)
        {
            Log.Info("Loading Data into DW");
            //only connection for the staging DB is required
            string sqlConnString = "";
            if (testing == true)
            {
                sqlConnString = ConfigurationManager.ConnectionStrings["sqlConnStringSDBTEST"].ConnectionString;
            }
            else
            {
                sqlConnString = ConfigurationManager.ConnectionStrings["sqlConnStringSDB"].ConnectionString;
            }
            try
            {

                using (SqlConnection myConnection = new SqlConnection(sqlConnString))
                {
                    //use an sp to get the data back
                    String sp1 = "TransferData";
                    //stored procedure that will be used to clear all the data in the StagingDB
                    String sp2 = "CleanStagingDB";
                    using (SqlCommand cmd = new SqlCommand(sp1, myConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 10000;
                        myConnection.Open();
                        Log.Info("Executing Stored Procedure: " + sp1);
                        SqlDataReader dr = cmd.ExecuteReader();
                        Log.Info("Finished Executing Stored Procedure: " + sp1);
                        myConnection.Close();
                    }
                    using (SqlCommand cmd = new SqlCommand(sp2, myConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        myConnection.Open();
                        Log.Info("Executing Stored Procedure: " + sp2);
                        SqlDataReader dr = cmd.ExecuteReader();
                        Log.Info("Finished Executing Stored Procedure: " + sp2);
                        myConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred during the Load Process");
                Log.Error(ex);
                return true;
            }
            Log.Info("Finished Transforming Data");
            return false;
        }
    }
}
