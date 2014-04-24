using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;
using System.Data.SqlTypes;
using DataSinkApp.Extract;
using DataSinkApp.Transform;
using DataSinkApp.Load;
using log4net;
using Microsoft.AnalysisServices;
using Microsoft.AnalysisServices.AdomdClient;


[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace DataSinkApp
{
    /// <summary>
    /// Main class for the application which will control the 
    /// ETL (Extract, Transform, Load) Process and will
    /// then reprocess the CUBE</summary>
    class Program
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
    (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The entry point for the application. The Extract, Load and 
        /// Transform processes will be executed here, one after the other
        /// unless an error occurs at one during one of the processes, 
        /// in which case, the ETL process will stop.
        /// </summary>
        public static void Main()
        {
            log.Info("Data Sink Application Started");
            bool noerrors = false;
            while (noerrors == false)
            {
                //variable dt used to record how long each part of ETL process takes
                DateTime dt = System.DateTime.UtcNow;

                //call the Extract class which will retrieve all the data
                //and place this data in the staging database
                noerrors = ExtractThread.ExtractData();

                log.Info("EXTRACT Process took: " + (System.DateTime.UtcNow - dt) + " to complete");
                dt = System.DateTime.UtcNow;

                //call the transform class which will modify the data as neccessary
                //in the staging db and get it ready for transfer
                noerrors = Transform.Transform.TransformData();

                log.Info("TRANSFORM Process took: " + (System.DateTime.UtcNow - dt) + " to complete");
                dt = System.DateTime.UtcNow;

                //all the load class to load the data from the stagingdb to the data warehouse
                noerrors = Load.Load.LoadData();

                log.Info("LOAD Process took: " + (System.DateTime.UtcNow - dt) + " to complete");
                dt = System.DateTime.UtcNow;

                //Reprocess the cube so it is update with the data.
                noerrors = ProcessCube();

                log.Info("Process Cube took: " + (System.DateTime.UtcNow - dt) + " to complete");
                break;
            }

            if (noerrors == true)
            {
                log.Error("An error occured during the ETL process and it did not complete successfully");
            }

            log.Info("Data Sink Application Stopped");
            Console.WriteLine("END");
            //stop the console from closing
        }


        /// <summary>
        /// Static method which we be called from Main. This method
        /// is responsible for processing the cube, which will take 
        /// place one the ETL process is complete.
        /// </summary>
        /// <returns>
        /// bool - success or failure, true for errors, false for no errors
        /// </returns>
        public static bool ProcessCube()
        {
            log.Info("Starting Processing of CUBE");
            string cubeConnectionString = ConfigurationManager.ConnectionStrings["sqlConnStringOLAP"].ConnectionString;
            AdomdConnection conn = new AdomdConnection(cubeConnectionString);
            AdomdCommand cmd = new AdomdCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"<Batch xmlns=""http://schemas.microsoft.com/analysisservices/2003/engine""> <Parallel><Process xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:ddl2=""http://schemas.microsoft.com/analysisservices/2003/engine/2"" xmlns:ddl2_2=""http://schemas.microsoft.com/analysisservices/2003/engine/2/2"" xmlns:ddl100_100=""http://schemas.microsoft.com/analysisservices/2008/engine/100/100""><Object><DatabaseID>OLAP</DatabaseID><CubeID>Data Warehouse</CubeID></Object><Type>ProcessFull</Type><WriteBackTableCreation>UseExisting</WriteBackTableCreation></Process></Parallel></Batch>";
            try
            {
                conn.Open();
                log.Info("Executing Command to Process Cube: " + cmd.CommandText);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                log.Error("An Error occurred during the processing of the CUBE");
                log.Error(ex);
                return false;
            }
            log.Info("Finished Processing of CUBE");
            return true;
        }
    }
}