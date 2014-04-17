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
    
    public class ExtractThread
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //This is the method that will control everything in the Extract Process
        public static Dictionary<int, RDataTypes> ExtractMain(int montharg, int yeararg)
        {
            //Dictionary<int, RDataTypes> dataDic = Retrieve(montharg, yeararg);

            //return dataDic;
            return null;
        }

        //get the data from the database 
        public static Dictionary<int, RDataTypes> Retrieve(int montharg, int yeararg)
        {
            Log.Info("Started Retrieve from PASNGR Database Process");

            Dictionary<int, RDataTypes> retrievedData = new Dictionary<int, RDataTypes>();

            string sqlConnString = ConfigurationManager.ConnectionStrings["sqlConnString"].ConnectionString;

            using (SqlConnection myConnection = new SqlConnection(sqlConnString)) 
            {
                    //use an sp to get the data back
                using (SqlCommand cmd = new SqlCommand("GetmyTableData", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter month = new SqlParameter("@month", montharg);
                    SqlParameter year = new SqlParameter("@year", yeararg);

                    cmd.Parameters.Add(month);
                    cmd.Parameters.Add(year);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        Log.Info("Reading Records from PASNGR DB");
                        //this id will be used in the data dictionary 
                        int id = 0;
                        while (dr.Read())
                        {
                            Log.Debug("reading record");

                            RDataTypes record = new RDataTypes();

                            record.recipientid = (int)dr["RecipientID"];
                            record.extractid = (int)dr["ExtractID"];
                            record.datasourceid = (int)dr["data_sourceID"];
                            record.notificationid = (int)dr["notificationid"];
                            record.paxid = (int)dr["paxid"];
                            record.flightid = (int)dr["flight_legid"];
                            record.templateid = (int)dr["templateid"];

                            record.timeadded = (DateTime)dr["timeadded"];
                            record.notificationsentdate = (DateTime)dr["notificationsentdate"];
                            record.notificationsent = (Boolean)dr["notificationsent"];
                            record.notificationsentto = (String)dr["notificationsentto"];
                            record.notificationSentType = (String)dr["notificationSentType"];
                            record.sendto = (String)dr["sendto"];
                            record.PasngrCreateDate = (String)dr["PasngrCreateDate"];
                            record.PasngrRenderDate = (String)dr["PasngrCreateDate"];
                            record.pnr = (String)dr["pnr"];
                            record.booking_date = (String)dr["booking_date"];
                            record.language_code = (String)dr["language_code"];
                            record.address_name = (String)dr["address_name"];
                            record.address1 = (String)dr["address1"];
                            record.address2 = (String)dr["address2"];
                            record.address3 = (String)dr["address3"];
                            record.city = (String)dr["city"];
                            record.postcode = (String)dr["postcode"];
                            record.country = (String)dr["country"];
                            record.emailaddress = (String)dr["emailaddress"];
                            record.homephone = (String)dr["homephone"];
                            record.otherphone = (String)dr["otherphone"];
                            record.total_passengers = (String)dr["total_passengers"];
                            record.dateadded = (DateTime)dr["dateadded"];
                            record.notification_desc = (String)dr["notification_desc"];
                            record.language_type = (String)dr["language_type"];
                            record.notificationSendOption = (String)dr["notificationSendOption"];
                            record.createDate = (DateTime)dr["createDate"];
                            record.sentDate = (DateTime)dr["sentDate"];
                            record.flight_leg = (String)dr["flight_leg"];
                            record.flight_number = (String)dr["flight_number"];
                            record.flight_code = (String)dr["flight_code"];
                            record.dept_date = (DateTime)dr["dept_date"];
                            record.dept_day = (String)dr["dept_day"];
                            record.dept_month = (String)dr["dept_month"];
                            record.dept_year = (String)dr["dept_year"];
                            record.dept_time = (String)dr["dept_time"];
                            record.dept_city = (String)dr["dept_city"];
                            record.dept_country = (String)dr["dept_country"];
                            record.arrv_date = (String)dr["arrv_date"];
                            record.arrv_day = (String)dr["arrv_day"];
                            record.arrv_month = (String)dr["arrv_month"];
                            record.arrv_year = (String)dr["arrv_year"];
                            record.arrv_time = (String)dr["arrv_time"];
                            record.arrv_city = (String)dr["arrv_city"];
                            record.arrv_country = (String)dr["arrv_country"];
                            record.schedulechange = (String)dr["schedulechange"];
                            record.ServiceClass = (String)dr["ServiceClass"];
                            record.CheckInTime = (DateTime)dr["CheckInTime"];
                            record.aircrafttype = (String)dr["aircrafttype"];
                            record.FlightFacilities = (String)dr["FlightFacilities"];
                            record.duration = (String)dr["duration"];
                            record.arrival_terminal = (String)dr["arrival_terminal"];
                            record.flightstatus = (String)dr["flightstatus"];
                            record.numberofstops = (String)dr["numberofstops"];
                            record.pax_first = (String)dr["pax_first"];
                            record.pax_last = (String)dr["pax_last"];
                            record.pax_middle = (String)dr["pax_middle"];
                            record.pax_title = (String)dr["pax_title"];
                            record.PaxGender = (String)dr["PaxGender"];
                            record.PaxType = (String)dr["PaxType"];
                            record.pax_dob = (String)dr["pax_dob"];
                            record.template_desc = (String)dr["template_desc"];
                            record.template_style = (String)dr["template_style"];
                            record.data_source_name = (String)dr["data_source_name"];
                            record.data_source_type = (String)dr["data_source_type"];
                            record.upload_complete = (Boolean)dr["upload_complete"];
                            record.dscreateDate = (String)dr["dscreateDate"];


                            //add the record to the dictionary
                            retrievedData.Add(id, record);
                            id++;
                            
                        }
                        Log.Info("Finished reading records from PASNGR database");

                        Log.Debug("Number of records returned: " + retrievedData.Count);

                        Log.Debug("debuglog() starting - -- - - - - ");

                        Log.Debug("Records returned were: ");

                        foreach (KeyValuePair<int, RDataTypes> entry in retrievedData)
                        {
                            Log.Debug("RecipientID: " + entry.Value.recipientid);
                            
                        }

                    }
                }
            }
            return retrievedData;
        }

        public static void ExtractData()
        {
            String conn = ConfigurationManager.ConnectionStrings["sqlConnStringS"].ConnectionString;
            string sp = "GetData";
            using (SqlConnection con = new SqlConnection(conn))
            {
                Log.Info("Starting Extract of Data");
                Log.Info("Executing Stored Procedure: " + sp);
                SqlCommand cmd = new SqlCommand(sp, con);
                cmd.CommandTimeout = 10000;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                Log.Info("Finished Executing Stored Procedure: " + sp);
                // Initializing an SqlBulkCopy object
                SqlBulkCopy sbc = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["sqlConnStringD"].ConnectionString);
                sbc.BulkCopyTimeout = 10000;
                #region Column Mappings

                // Copying data to destination
                sbc.DestinationTableName = "StagingTable";
                SqlBulkCopyColumnMapping mapID1 = new SqlBulkCopyColumnMapping("recipientid", "recipientid");
                sbc.ColumnMappings.Add(mapID1);
                SqlBulkCopyColumnMapping mapID2 = new SqlBulkCopyColumnMapping("extractID", "extractid");
                sbc.ColumnMappings.Add(mapID2);
                SqlBulkCopyColumnMapping mapID3 = new SqlBulkCopyColumnMapping("data_sourceid", "datasourceid");
                sbc.ColumnMappings.Add(mapID3);
                SqlBulkCopyColumnMapping mapID4 = new SqlBulkCopyColumnMapping("notificationid", "notificationid");
                sbc.ColumnMappings.Add(mapID4);
                
                SqlBulkCopyColumnMapping mapID5 = new SqlBulkCopyColumnMapping("paxid", "paxid");
                sbc.ColumnMappings.Add(mapID5);
                SqlBulkCopyColumnMapping mapID6 = new SqlBulkCopyColumnMapping("flight_legid", "flightid");
                sbc.ColumnMappings.Add(mapID6);

                SqlBulkCopyColumnMapping mapID7 = new SqlBulkCopyColumnMapping("templateID", "templateid");
                sbc.ColumnMappings.Add(mapID7);
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

                SqlBulkCopyColumnMapping mapID39 = new SqlBulkCopyColumnMapping("flight_leg", "flight_leg");
                //sbc.ColumnMappings.Add(mapID39);
                SqlBulkCopyColumnMapping mapID40 = new SqlBulkCopyColumnMapping("flight_number", "flight_number");
                //sbc.ColumnMappings.Add(mapID40);
                SqlBulkCopyColumnMapping mapID41 = new SqlBulkCopyColumnMapping("flight_code", "flight_code");
                //sbc.ColumnMappings.Add(mapID41);
                SqlBulkCopyColumnMapping mapID78 = new SqlBulkCopyColumnMapping("dept_date", "dept_date");
                //sbc.ColumnMappings.Add(mapID78);
                SqlBulkCopyColumnMapping mapID42 = new SqlBulkCopyColumnMapping("dept_day", "dept_day");
                //sbc.ColumnMappings.Add(mapID42);
                SqlBulkCopyColumnMapping mapID43 = new SqlBulkCopyColumnMapping("dept_month", "dept_month");
                //sbc.ColumnMappings.Add(mapID43);
                SqlBulkCopyColumnMapping mapID44 = new SqlBulkCopyColumnMapping("dept_year", "dept_year");
                //sbc.ColumnMappings.Add(mapID44);
                SqlBulkCopyColumnMapping mapID45 = new SqlBulkCopyColumnMapping("dept_time", "dept_time");
                //sbc.ColumnMappings.Add(mapID45);
                SqlBulkCopyColumnMapping mapID46 = new SqlBulkCopyColumnMapping("dept_city", "dept_city");
                //sbc.ColumnMappings.Add(mapID46);
                SqlBulkCopyColumnMapping mapID47 = new SqlBulkCopyColumnMapping("dept_country", "dept_country");
                //sbc.ColumnMappings.Add(mapID47);
                SqlBulkCopyColumnMapping mapID48 = new SqlBulkCopyColumnMapping("arrv_date", "arrv_date");
                //sbc.ColumnMappings.Add(mapID48);
                SqlBulkCopyColumnMapping mapID49 = new SqlBulkCopyColumnMapping("arrv_day", "arrv_day");
                //sbc.ColumnMappings.Add(mapID49);
                SqlBulkCopyColumnMapping mapID50 = new SqlBulkCopyColumnMapping("arrv_month", "arrv_month");
                //sbc.ColumnMappings.Add(mapID50);
                SqlBulkCopyColumnMapping mapID51 = new SqlBulkCopyColumnMapping("arrv_year", "arrv_year");
                //sbc.ColumnMappings.Add(mapID51);
                SqlBulkCopyColumnMapping mapID52 = new SqlBulkCopyColumnMapping("arrv_time", "arrv_time");
                //sbc.ColumnMappings.Add(mapID52);
                SqlBulkCopyColumnMapping mapID53 = new SqlBulkCopyColumnMapping("arrv_city", "arrv_city");
                //sbc.ColumnMappings.Add(mapID53);
                SqlBulkCopyColumnMapping mapID54 = new SqlBulkCopyColumnMapping("arrv_country", "arrv_country");
                //sbc.ColumnMappings.Add(mapID54);
                SqlBulkCopyColumnMapping mapID55 = new SqlBulkCopyColumnMapping("schedule_change", "schedulechange");
                //sbc.ColumnMappings.Add(mapID55);
                SqlBulkCopyColumnMapping mapID56 = new SqlBulkCopyColumnMapping("ServiceClass", "ServiceClass");
                //sbc.ColumnMappings.Add(mapID56);
                SqlBulkCopyColumnMapping mapID57 = new SqlBulkCopyColumnMapping("deptTerminal", "deptterminal");
                //sbc.ColumnMappings.Add(mapID57);
                SqlBulkCopyColumnMapping mapID58 = new SqlBulkCopyColumnMapping("CheckInTime", "CheckInTime");
                //sbc.ColumnMappings.Add(mapID58);
                SqlBulkCopyColumnMapping mapID59 = new SqlBulkCopyColumnMapping("AircraftType", "aircrafttype");
                //sbc.ColumnMappings.Add(mapID59);
                SqlBulkCopyColumnMapping mapID60 = new SqlBulkCopyColumnMapping("FlightFacilities", "FlightFacilities");
                //sbc.ColumnMappings.Add(mapID60);
                SqlBulkCopyColumnMapping mapID61 = new SqlBulkCopyColumnMapping("duration", "duration");
                //sbc.ColumnMappings.Add(mapID61);
                SqlBulkCopyColumnMapping mapID62 = new SqlBulkCopyColumnMapping("arrival_terminal", "arrival_terminal");
                //sbc.ColumnMappings.Add(mapID62);
                SqlBulkCopyColumnMapping mapID63 = new SqlBulkCopyColumnMapping("flightStatus", "flightstatus");
                //sbc.ColumnMappings.Add(mapID63);
                SqlBulkCopyColumnMapping mapID64 = new SqlBulkCopyColumnMapping("number_of_stops", "numberofstops");
                //sbc.ColumnMappings.Add(mapID64);

                SqlBulkCopyColumnMapping mapID65 = new SqlBulkCopyColumnMapping("pax_first", "pax_first");
                //sbc.ColumnMappings.Add(mapID65);
                SqlBulkCopyColumnMapping mapID66 = new SqlBulkCopyColumnMapping("pax_last", "pax_last");
                //sbc.ColumnMappings.Add(mapID66);
                SqlBulkCopyColumnMapping mapID67 = new SqlBulkCopyColumnMapping("pax_middle", "pax_middle");
                //sbc.ColumnMappings.Add(mapID67);
                SqlBulkCopyColumnMapping mapID68 = new SqlBulkCopyColumnMapping("pax_title", "pax_title");
                //sbc.ColumnMappings.Add(mapID68);
                SqlBulkCopyColumnMapping mapID69 = new SqlBulkCopyColumnMapping("PaxGender", "PaxGender");
                //sbc.ColumnMappings.Add(mapID69);
                SqlBulkCopyColumnMapping mapID70 = new SqlBulkCopyColumnMapping("PaxType", "PaxType");
                //sbc.ColumnMappings.Add(mapID70);
                SqlBulkCopyColumnMapping mapID71 = new SqlBulkCopyColumnMapping("pax_dob", "pax_dob");
                //sbc.ColumnMappings.Add(mapID71);

                SqlBulkCopyColumnMapping mapID72 = new SqlBulkCopyColumnMapping("template_desc", "template_desc");
                sbc.ColumnMappings.Add(mapID72);
                SqlBulkCopyColumnMapping mapID73 = new SqlBulkCopyColumnMapping("template_style", "template_style");
                sbc.ColumnMappings.Add(mapID73);
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
                    Log.Error(Ex);
                }

                sbc.Close();
                rdr.Close();
                con.Close();
                Log.Info("Finished Extracting of Data");
            }
            
        }
       
    };
}