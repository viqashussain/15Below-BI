using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using DataSinkApp;

namespace DataSinkApp.Extract
{
    /// <summary>
    /// Class which contains all the functionality for the Extract process
    /// which will copy the neccessary data from the PASNGR database, and copy
    /// it to the StagingDB
    /// </summary>
    public class ExtractThread
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Static method which we be called from Program.Main.
        /// This method will extract the data from the PASNGR DB and copy it to
        /// the StagingDB using BulkCopy.
        /// </summary>
        /// <returns>
        /// bool - success or failure, true for errors, false for no errors
        /// </returns>
        public static bool ExtractData(bool testing = false)
        {
            string customer = ConfigurationManager.AppSettings["Customer"];
            String conn = "";
            if (testing == true)
            {
                conn = ConfigurationManager.ConnectionStrings["sqlConnString" + customer + "TEST"].ConnectionString;
            }
            else
            {
                conn = ConfigurationManager.ConnectionStrings["sqlConnString" + customer].ConnectionString;
            }
            string sp = "GetData";
            using (SqlConnection con = new SqlConnection(conn))
            {
                Log.Info("Starting Extract of Data");
                SqlCommand cmd = new SqlCommand(sp, con);
                cmd.CommandTimeout = 10000;
                DateTime enddate;
                try
                {
                    if (ConfigurationManager.AppSettings["RetrieveEndDate"] != "")
                    {
                        enddate = Convert.ToDateTime(ConfigurationManager.AppSettings["RetrieveEndDate"]);
                    }
                    else
                    {
                        enddate = System.DateTime.Now;
                    }
                }
                catch (System.FormatException)
                {
                    Log.ErrorFormat("ERROR: Invalid DateTime set in Config for RetrieveEndDate, will used current datetime");
                    enddate = System.DateTime.Now;
                }
                //parameters for the stored procedure
                SqlParameter recipientID = new SqlParameter("@recipientID", GetLastRecipientID());
                SqlParameter enddatep = new SqlParameter("@enddate", System.DateTime.Now);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(recipientID);
                cmd.Parameters.Add(enddatep);
                con.Open();
                Log.Info("Executing Stored Procedure: " + sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                Log.Info("Finished Executing Stored Procedure: " + sp);
                // Initializing an SqlBulkCopy object
                SqlBulkCopy sbc = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["sqlConnStringSDB"].ConnectionString);
                sbc.BulkCopyTimeout = 10000;
                #region Column Mappings

                // Copying data to destination
                sbc.DestinationTableName = "StagingTable";
                //fact table data
                SqlBulkCopyColumnMapping mapID1 = new SqlBulkCopyColumnMapping("recipientid", "recipientid");
                sbc.ColumnMappings.Add(mapID1);
                SqlBulkCopyColumnMapping mapID2 = new SqlBulkCopyColumnMapping("extractID", "extractid");
                sbc.ColumnMappings.Add(mapID2);
                SqlBulkCopyColumnMapping mapID3 = new SqlBulkCopyColumnMapping("data_sourceid", "datasourceid");
                sbc.ColumnMappings.Add(mapID3);
                SqlBulkCopyColumnMapping mapID4 = new SqlBulkCopyColumnMapping("notificationid", "notificationid");
                sbc.ColumnMappings.Add(mapID4);
                
                SqlBulkCopyColumnMapping mapID5 = new SqlBulkCopyColumnMapping("paxID", "paxid");
                sbc.ColumnMappings.Add(mapID5);
                SqlBulkCopyColumnMapping mapID6 = new SqlBulkCopyColumnMapping("flight_legid", "flightid");
                sbc.ColumnMappings.Add(mapID6);

                SqlBulkCopyColumnMapping mapID7 = new SqlBulkCopyColumnMapping("templateID", "templateid");
                sbc.ColumnMappings.Add(mapID7);

                //recipient data
                SqlBulkCopyColumnMapping mapID79 = new SqlBulkCopyColumnMapping("createDate", "NotificationSendDate");
                sbc.ColumnMappings.Add(mapID79);
                SqlBulkCopyColumnMapping mapID9 = new SqlBulkCopyColumnMapping("notificationSentDate", "RecipientSentDateTime");
                sbc.ColumnMappings.Add(mapID9);
                SqlBulkCopyColumnMapping mapID11 = new SqlBulkCopyColumnMapping("notificationSent", "notificationsent");
                sbc.ColumnMappings.Add(mapID11);
                SqlBulkCopyColumnMapping mapID12 = new SqlBulkCopyColumnMapping("notificationSentTo", "notificationsentto");
                sbc.ColumnMappings.Add(mapID12);
                SqlBulkCopyColumnMapping mapID13 = new SqlBulkCopyColumnMapping("notificationSentType", "notificationSentType");
                sbc.ColumnMappings.Add(mapID13);
                SqlBulkCopyColumnMapping mapID14 = new SqlBulkCopyColumnMapping("sendTo", "sendto");
                sbc.ColumnMappings.Add(mapID14);
                SqlBulkCopyColumnMapping mapID16 = new SqlBulkCopyColumnMapping("PasngrRenderDate", "PasngrRenderDate");
                sbc.ColumnMappings.Add(mapID16);

                //extracts data
                SqlBulkCopyColumnMapping mapID17 = new SqlBulkCopyColumnMapping("pnr", "pnr");
                sbc.ColumnMappings.Add(mapID17);
                SqlBulkCopyColumnMapping mapID18 = new SqlBulkCopyColumnMapping("booking_date", "booking_date");
                sbc.ColumnMappings.Add(mapID18);
                SqlBulkCopyColumnMapping mapID19 = new SqlBulkCopyColumnMapping("language_code", "language_code");
                sbc.ColumnMappings.Add(mapID19);
                SqlBulkCopyColumnMapping mapID20 = new SqlBulkCopyColumnMapping("address_name", "address_name");
                sbc.ColumnMappings.Add(mapID20);
                SqlBulkCopyColumnMapping mapID21 = new SqlBulkCopyColumnMapping("address1", "address1");
                sbc.ColumnMappings.Add(mapID21);
                SqlBulkCopyColumnMapping mapID22 = new SqlBulkCopyColumnMapping("address2", "address2");
                sbc.ColumnMappings.Add(mapID22);
                SqlBulkCopyColumnMapping mapID23 = new SqlBulkCopyColumnMapping("address3", "address3");
                sbc.ColumnMappings.Add(mapID23);
                SqlBulkCopyColumnMapping mapID24 = new SqlBulkCopyColumnMapping("city", "city");
                sbc.ColumnMappings.Add(mapID24);
                SqlBulkCopyColumnMapping mapID25 = new SqlBulkCopyColumnMapping("postcode", "postcode");
                sbc.ColumnMappings.Add(mapID25);
                SqlBulkCopyColumnMapping mapID26 = new SqlBulkCopyColumnMapping("country", "country");
                sbc.ColumnMappings.Add(mapID26);
                SqlBulkCopyColumnMapping mapID27 = new SqlBulkCopyColumnMapping("email_address", "emailaddress");
                sbc.ColumnMappings.Add(mapID27);
                SqlBulkCopyColumnMapping mapID28 = new SqlBulkCopyColumnMapping("home_phone", "homephone");
                sbc.ColumnMappings.Add(mapID28);
                SqlBulkCopyColumnMapping mapID29 = new SqlBulkCopyColumnMapping("other_phone", "otherphone");
                sbc.ColumnMappings.Add(mapID29);
                SqlBulkCopyColumnMapping mapID30 = new SqlBulkCopyColumnMapping("total_passengers", "total_passengers");
                sbc.ColumnMappings.Add(mapID30);
                SqlBulkCopyColumnMapping mapID31 = new SqlBulkCopyColumnMapping("Date_Added", "dateadded");
                sbc.ColumnMappings.Add(mapID31);
                SqlBulkCopyColumnMapping mapID33 = new SqlBulkCopyColumnMapping("PasngrCreateDate", "PasngrCreateDate");
                sbc.ColumnMappings.Add(mapID33);

                //notifications data
                SqlBulkCopyColumnMapping mapID34 = new SqlBulkCopyColumnMapping("notification_desc", "notification_desc");
                sbc.ColumnMappings.Add(mapID34);
                SqlBulkCopyColumnMapping mapID35 = new SqlBulkCopyColumnMapping("language_type", "language_type");
                sbc.ColumnMappings.Add(mapID35);
                SqlBulkCopyColumnMapping mapID36 = new SqlBulkCopyColumnMapping("notificationSendOption", "notificationSendOption");
                sbc.ColumnMappings.Add(mapID36);
                SqlBulkCopyColumnMapping mapID37 = new SqlBulkCopyColumnMapping("createDate", "createDate");
                sbc.ColumnMappings.Add(mapID37);
                SqlBulkCopyColumnMapping mapID38 = new SqlBulkCopyColumnMapping("sentDate", "sentDate");
                sbc.ColumnMappings.Add(mapID38);

                //flight data
                SqlBulkCopyColumnMapping mapID39 = new SqlBulkCopyColumnMapping("flight_leg", "flight_leg");
                sbc.ColumnMappings.Add(mapID39);
                SqlBulkCopyColumnMapping mapID40 = new SqlBulkCopyColumnMapping("flight_number", "flight_number");
                sbc.ColumnMappings.Add(mapID40);
                SqlBulkCopyColumnMapping mapID41 = new SqlBulkCopyColumnMapping("flight_code", "flight_code");
                sbc.ColumnMappings.Add(mapID41);
                SqlBulkCopyColumnMapping mapID78 = new SqlBulkCopyColumnMapping("dept_date", "dept_date");
                sbc.ColumnMappings.Add(mapID78);
                SqlBulkCopyColumnMapping mapID45 = new SqlBulkCopyColumnMapping("dept_time", "dept_time");
                sbc.ColumnMappings.Add(mapID45);
                SqlBulkCopyColumnMapping mapID46 = new SqlBulkCopyColumnMapping("dept_city", "dept_city");
                sbc.ColumnMappings.Add(mapID46);
                SqlBulkCopyColumnMapping mapID47 = new SqlBulkCopyColumnMapping("dept_country", "dept_country");
                sbc.ColumnMappings.Add(mapID47);
                SqlBulkCopyColumnMapping mapID48 = new SqlBulkCopyColumnMapping("arrv_date", "arrv_date");
                sbc.ColumnMappings.Add(mapID48);
                SqlBulkCopyColumnMapping mapID52 = new SqlBulkCopyColumnMapping("arrv_time", "arrv_time");
                sbc.ColumnMappings.Add(mapID52);
                SqlBulkCopyColumnMapping mapID53 = new SqlBulkCopyColumnMapping("arrv_city", "arrv_city");
                sbc.ColumnMappings.Add(mapID53);
                SqlBulkCopyColumnMapping mapID54 = new SqlBulkCopyColumnMapping("arrv_country", "arrv_country");
                sbc.ColumnMappings.Add(mapID54);
                SqlBulkCopyColumnMapping mapID55 = new SqlBulkCopyColumnMapping("schedule_change", "schedulechange");
                sbc.ColumnMappings.Add(mapID55);
                SqlBulkCopyColumnMapping mapID56 = new SqlBulkCopyColumnMapping("ServiceClass", "ServiceClass");
                sbc.ColumnMappings.Add(mapID56);
                SqlBulkCopyColumnMapping mapID57 = new SqlBulkCopyColumnMapping("deptTerminal", "deptterminal");
                sbc.ColumnMappings.Add(mapID57);
                SqlBulkCopyColumnMapping mapID58 = new SqlBulkCopyColumnMapping("CheckInTime", "CheckInTime");
                sbc.ColumnMappings.Add(mapID58);
                SqlBulkCopyColumnMapping mapID59 = new SqlBulkCopyColumnMapping("AircraftType", "aircrafttype");
                sbc.ColumnMappings.Add(mapID59);
                SqlBulkCopyColumnMapping mapID60 = new SqlBulkCopyColumnMapping("FlightFacilities", "FlightFacilities");
                sbc.ColumnMappings.Add(mapID60);
                SqlBulkCopyColumnMapping mapID61 = new SqlBulkCopyColumnMapping("duration", "duration");
                sbc.ColumnMappings.Add(mapID61);
                SqlBulkCopyColumnMapping mapID62 = new SqlBulkCopyColumnMapping("arrival_terminal", "arrival_terminal");
                sbc.ColumnMappings.Add(mapID62);
                SqlBulkCopyColumnMapping mapID63 = new SqlBulkCopyColumnMapping("flightStatus", "flightstatus");
                sbc.ColumnMappings.Add(mapID63);
                SqlBulkCopyColumnMapping mapID64 = new SqlBulkCopyColumnMapping("number_of_stops", "numberofstops");
                sbc.ColumnMappings.Add(mapID64);

                //pax data
                SqlBulkCopyColumnMapping mapID65 = new SqlBulkCopyColumnMapping("pax_first", "pax_first");
                sbc.ColumnMappings.Add(mapID65);
                SqlBulkCopyColumnMapping mapID66 = new SqlBulkCopyColumnMapping("pax_last", "pax_last");
                sbc.ColumnMappings.Add(mapID66);
                SqlBulkCopyColumnMapping mapID67 = new SqlBulkCopyColumnMapping("pax_middle", "pax_middle");
                sbc.ColumnMappings.Add(mapID67);
                SqlBulkCopyColumnMapping mapID68 = new SqlBulkCopyColumnMapping("pax_title", "pax_title");
                sbc.ColumnMappings.Add(mapID68);
                SqlBulkCopyColumnMapping mapID69 = new SqlBulkCopyColumnMapping("PaxGender", "PaxGender");
                sbc.ColumnMappings.Add(mapID69);
                SqlBulkCopyColumnMapping mapID70 = new SqlBulkCopyColumnMapping("PaxType", "PaxType");
                sbc.ColumnMappings.Add(mapID70);
                SqlBulkCopyColumnMapping mapID71 = new SqlBulkCopyColumnMapping("pax_dob", "pax_dob");
                sbc.ColumnMappings.Add(mapID71);

                //templates data
                SqlBulkCopyColumnMapping mapID72 = new SqlBulkCopyColumnMapping("template_desc", "template_desc");
                sbc.ColumnMappings.Add(mapID72);
                SqlBulkCopyColumnMapping mapID73 = new SqlBulkCopyColumnMapping("template_style", "template_style");
                sbc.ColumnMappings.Add(mapID73);

                //data sources data 
                SqlBulkCopyColumnMapping mapID74 = new SqlBulkCopyColumnMapping("data_source_name", "data_source_name");
                sbc.ColumnMappings.Add(mapID74);
                SqlBulkCopyColumnMapping mapID75 = new SqlBulkCopyColumnMapping("data_source_type", "data_source_type");
                sbc.ColumnMappings.Add(mapID75);
                SqlBulkCopyColumnMapping mapID76 = new SqlBulkCopyColumnMapping("upload_complete", "upload_complete");
                sbc.ColumnMappings.Add(mapID76);
                SqlBulkCopyColumnMapping mapID77 = new SqlBulkCopyColumnMapping("createDate", "dscreateDate");
                sbc.ColumnMappings.Add(mapID77);
                #endregion

                try
                {
                    Log.Info("Writing to Destination");
                    sbc.WriteToServer(rdr);
                }
                catch (Exception Ex)
                {
                    Log.Error("ERROR: error occured during writing data to StagingDB");
                    Log.Error(Ex);
                    //return error
                    return true;
                }

                sbc.Close();
                rdr.Close();
                con.Close();
                Log.Info("Finished Extracting of Data");
            }
            return false;
            
        }

        /// <summary>
        /// Static method which is used to get the last recipientID added
        /// to the DataWarehouse. This is to ensure we don't retrieve any 
        /// duplicate recipients or miss any recipients.
        /// </summary>
        /// <returns>
        /// int - the recipientID (0 if no results returned)
        /// </returns>
        public static int GetLastRecipientID(bool testing = false)
        {
            Log.Info("Get Last RecipientID");
            string sqlConnString = "";
            if (testing == true)
            {
                sqlConnString = ConfigurationManager.ConnectionStrings["sqlConnStringDWTEST"].ConnectionString;
            }
            else
            {
                sqlConnString = ConfigurationManager.ConnectionStrings["sqlConnStringDW"].ConnectionString;
            }
            int recipientID = 0;
            using (SqlConnection myConnection = new SqlConnection(sqlConnString))
            {
                //use an sp to get the data back
                String sp1 = "GetLastRecipientID";
                using (SqlCommand cmd = new SqlCommand(sp1, myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    Log.Info("Executing Stored Procedure: " + sp1);
                    SqlDataReader dr = cmd.ExecuteReader();
                    Log.Info("Finished Executing Stored Procedure: " + sp1);
                    //if the data warehouse is empty or no recipientID is returned
                    if (dr.HasRows == false)
                    {
                        recipientID = 0;
                    }
                    else
                    {
                        dr.Read();
                        recipientID = (int)dr[0];
                    }
                    myConnection.Close();
                    dr.Close();
                }
            }
            Log.Debug("Finished Get Last RecipientID");
            return recipientID;
        }

    };
}