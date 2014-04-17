using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication1.Models
{

    public class NotificationsReportModel
    {
        [Required]
        [Display(Name = "NotificationID")]
        public List<string> NotificationID { get; set; }

        [Required]
        [Display(Name = "Notification Description")]
        public List<string> NotificationDescription { get; set; }

        [Required]
        [Display(Name = "Send Date/Time")]
        public List<string> SendDateTime { get; set; }

        [Required]
        [Display(Name = "Recipient Count")]
        public List<int> RecipientCount { get; set; }

        [Required]
        [Display(Name = "Language Type")]
        public List<string> LanguageType { get; set; }

        [Required]
        [Display(Name = "DataSourceName")]
        public string DataSourceName { get; set; }

        [Required]
        [Display(Name = "PNR")]
        public string PNR { get; set; }

        [Required]
        [Display(Name = "DataSourceID")]
        public int DataSourceID { get; set; }

        [Required]
        [Display(Name = "ExtractID")]
        public int ExtractID { get; set; }

        public NotificationsReportModel()
        {
            List<string> NotificationID = new List<string>();
            List<string> NotificationDescription = new List<String>();
            List<int> RecipientCount = new List<int>();
            List<string> SendDateTime = new List<string>();
            List<string> LanguageType = new List<string>();
            string PNR = "";
            string DataSourceName = "";
            int ExtractID = 0;
            int DataSourceID = 0;
        }
    }

    public class RecipientModel
    {
        [Required]
        [Display(Name = "RecipientID")]
        public List<string> RecipientID { get; set; }

        [Required]
        [Display(Name = "Sent To")]
        public List<string> SentTo { get; set; }

        [Required]
        [Display(Name = "Send Date Time")]
        public List<string> SendDateTime { get; set; }

        [Required]
        [Display(Name = "Notification Type")]
        public List<string> NotificationType { get; set; }

        [Required]
        [Display(Name = "Template Name")]
        public List<string> TemplateName { get; set; }

        [Required]
        [Display(Name = "NotificationName")]
        public string NotificationName { get; set; }

        [Required]
        [Display(Name = "PNR")]
        public string PNR { get; set; }

        [Required]
        [Display(Name = "NotificationID")]
        public int NotificationID { get; set; }

        [Required]
        [Display(Name = "ExtractID")]
        public int ExtractID { get; set; }

        public RecipientModel()
        {
            List<int> RecipientID = new List<int>();
            List<string> SentTo = new List<String>();
            List<string> SendDateTime = new List<string>();
            List<string> NotificationType = new List<string>();
            List<string> TemplateName = new List<string>();
            string PNR = "";
            string NotificationName = "";
            int ExtractID = 0;
            int NotificationID = 0;
        }
    }

    public class DataSourcesModel
    {
        [Required]
        [Display(Name = "DataSourceID")]
        public List<string> DataSourceID { get; set; }

        [Required]
        [Display(Name = "Data Source Name")]
        public List<string> DataSourceName { get; set; }

        [Required]
        [Display(Name = "Extracts Count")]
        public List<int> ExtractsCount { get; set; }

        [Required]
        [Display(Name = "Upload Date Time")]
        public List<string> UploadDateTime { get; set; }

        [Required]
        [Display(Name = "Data Source Type")]
        public List<string> DataSourceType { get; set; }

        [Required]
        [Display(Name = "NotificationName")]
        public string NotificationName { get; set; }

        [Required]
        [Display(Name = "PNR")]
        public string PNR { get; set; }

        public DataSourcesModel()
        {
            List<string> DataSourceID = new List<string>();
            List<string> DataSourceName = new List<string>();
            List<int> ExtractsCount = new List<int>();
            List<string> UploadDateTime = new List<string>();
            List<string> DataSourceType = new List<string>();
            string NotificationName = "";
            string PNR = "";
        }
    }

    public class ExtractsModel
    {
        [Required]
        [Display(Name = "ExtractID")]
        public List<string> ExtractID { get; set; }

        [Required]
        [Display(Name = "PNR")]
        public List<string> PNR { get; set; }

        [Required]
        [Display(Name = "Lead PAX Name")]
        public List<string> LeadPaxName { get; set; }

        [Required]
        [Display(Name = "Total Number of PAX")]
        public List<string> TotalPax { get; set; }

        [Required]
        [Display(Name = "Upload Date Time")]
        public List<string> UploadDateTime { get; set; }

        [Required]
        [Display(Name = "Booking Date")]
        public List<string> BookingDate { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public List<string> EmailAddress { get; set; }

        [Required]
        [Display(Name = "Other Phone #")]
        public List<string> OtherPhone { get; set; }

        [Required]
        [Display(Name = "Language Code")]
        public List<string> LanguageCode { get; set; }

        [Required]
        [Display(Name = "Number of Flights")]
        public List<int> NumberofFlights { get; set; }

        [Required]
        [Display(Name = "DataSourceName")]
        public string DataSourceName { get; set; }

        [Required]
        [Display(Name = "DataSourceID")]
        public int DataSourceID { get; set; }

        [Required]
        [Display(Name = "RecipientID")]
        public int RecipientID { get; set; }

        public ExtractsModel()
        {
            List<string> ExtractID = new List<string>();
            List<string> PNR = new List<string>();
            List<string> TotalPax = new List<string>();
            List<DateTime> UploadDateTime = new List<DateTime>();
            List<string> LeadPaxName = new List<string>();
            List<string> BookingDate = new List<string>();
            List<string> EmailAddress = new List<string>();
            List<string> OtherPhone = new List<string>();
            List<string> LanguageCode = new List<string>();
            List<int> NumberofFlights = new List<int>();
            string DataSourceName = "";
            string DataSourceID = "";
            string RecipientID = "";
        }
    }

    public class FlightsModel
    {
        [Required]
        [Display(Name = "FlightID")]
        public List<string> FlightID { get; set; }

        [Required]
        [Display(Name = "FlightLeg")]
        public List<string> FlightLeg { get; set; }

        [Required]
        [Display(Name = "FlightNumber")]
        public List<string> FlightNumber { get; set; }

        [Required]
        [Display(Name = "FlightCode")]
        public List<string> FlightCode { get; set; }

        [Required]
        [Display(Name = "DepartureDate")]
        public List<string> DepartureDate { get; set; }

        [Required]
        [Display(Name = "DepartureTime")]
        public List<string> DepartureTime { get; set; }

        [Required]
        [Display(Name = "DepartureCountry")]
        public List<string> DepartureCountry { get; set; }

        [Required]
        [Display(Name = "DepartureCity")]
        public List<string> DepartureCity { get; set; }

        [Required]
        [Display(Name = "ArrivalDate")]
        public List<string> ArrivalDate { get; set; }

        [Required]
        [Display(Name = "ArrivalTime")]
        public List<string> ArrivalTime { get; set; }

        [Required]
        [Display(Name = "ArrivalCountry")]
        public List<string> ArrivalCountry { get; set; }

        [Required]
        [Display(Name = "ArrivalCity")]
        public List<string> ArrivalCity { get; set; }

        [Required]
        [Display(Name = "ScheduleChange")]
        public List<string> ScheduleChange { get; set; }

        [Required]
        [Display(Name = "ServiceClass")]
        public List<string> ServiceClass { get; set; }

        [Required]
        [Display(Name = "Duration")]
        public List<string> Duration { get; set; }

        [Required]
        [Display(Name = "PNR")]
        public string PNR { get; set; }

        public FlightsModel()
        {
            List<string> FlightID = new List<string>();
            List<string> FlightLeg = new List<string>();
            List<string> FlightNumber = new List<string>();
            List<string> FlightCode = new List<string>();
            List<string> DepartureDate = new List<string>();
            List<string> DepartureTime = new List<string>();
            List<string> DepartureCountry = new List<string>();
            List<string> DepartureCity = new List<string>();
            List<string> ArrivalDate = new List<string>();
            List<string> ArrivalTime = new List<string>();
            List<string> ArrivalCountry = new List<string>();
            List<string> ArrivalCity = new List<string>();
            List<string> ScheduleChange = new List<string>();
            List<string> ServiceClass = new List<string>();
            List<string> Duration = new List<string>();
            string PNR = "";
        }
    }

    public class PaxModel
    {
        [Required]
        [Display(Name = "PaxID")]
        public List<string> PaxID { get; set; }

        [Required]
        [Display(Name = "PaxFirst")]
        public List<string> PaxFirst { get; set; }

        [Required]
        [Display(Name = "PaxMiddle")]
        public List<string> PaxMiddle { get; set; }

        [Required]
        [Display(Name = "PaxLast")]
        public List<string> PaxLast { get; set; }

        [Required]
        [Display(Name = "PaxTitle")]
        public List<string> PaxTitle { get; set; }

        [Required]
        [Display(Name = "PaxGender")]
        public List<string> PaxGender { get; set; }

        [Required]
        [Display(Name = "PaxType")]
        public List<string> PaxType { get; set; }

        [Required]
        [Display(Name = "PaxDOB")]
        public List<string> PaxDOB { get; set; }

        [Required]
        [Display(Name = "PNR")]
        public string PNR { get; set; }

        public PaxModel()
        {
            List<string> PaxID = new List<string>();
            List<string> PaxFirst = new List<string>();
            List<string> PaxMiddle = new List<string>();
            List<string> PaxLast = new List<string>();
            List<string> PaxTitle = new List<string>();
            List<string> PaxGender = new List<string>();
            List<string> PaxType = new List<string>();
            List<string> PaxDOB = new List<string>();
            string PNR = "";
        }
    }
}

