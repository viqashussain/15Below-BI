using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Data;
using DataSinkApp;

namespace DataSinkApp.Transform
{
    /// <summary>
    /// Class which contains all the functionality for the Transform process
    /// which will transform the data as neccessary in the StagingDB.
    /// </summary>
    public class Transform
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Static method which we be called from Program.Main.
        /// This method will Tranform the data in the StagingDB accordingly
        /// by executing Stored Procedures in the StagingDB. This will also prepare
        /// the data for Transfer to the DataWarehouse.
        /// </summary>
        /// <returns>
        /// bool - success or failure, true for errors, false for no errors
        /// </returns>
        public static bool TransformData(bool testing = false)
        {
            Log.Info("Transforming Data");
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
                    String sp1 = "StageStagingData";
                    String sp2 = "TransformData";
                    using (SqlCommand cmd = new SqlCommand(sp1, myConnection))
                    {
                        cmd.CommandTimeout = 10000;
                        cmd.CommandType = CommandType.StoredProcedure;
                        myConnection.Open();
                        Log.Info("Executing Stored Procedure: " + sp1);
                        SqlDataReader dr = cmd.ExecuteReader();
                        Log.Info("Finished Executing Stored Procedure: " + sp1);
                        myConnection.Close();
                    }
                    using (SqlCommand cmd = new SqlCommand(sp2, myConnection))
                    {
                        cmd.CommandTimeout = 10000;
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
                Log.Error("Error occurred during Transform Process!");
                Log.Error(ex);
                return true;
            }
            Log.Info("Finished Transforming Data");
            return false;
        }
    }
}
