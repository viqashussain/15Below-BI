using System;
using NUnit.Framework;
using MvcApplication1;

namespace UnitTesting
{

    [TestFixture]
    public class ReportUnitTests
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
    (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        MvcApplication1.Controllers.ReportController reportController = new MvcApplication1.Controllers.ReportController();

        [Test]
        public void TestViewRecipientsbyTopTen()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewRecipients() as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.RecipientModel)result.ViewData.Model;
            Assert.AreEqual("56169", model.RecipientID[0]);
            Assert.AreEqual("HNJ@FLSMIDTH.COM,JEAL@FLSMIDTH.COM,A.PRUSZYNSKA@CWT-ECENTER.COM", model.SentTo[0]);
            Assert.AreEqual("2013-12-05 14:34:20.207", model.SendDateTime[0]);
            Assert.AreEqual("EMAIL", model.NotificationType[0]);
            Assert.AreEqual("Ticketing confirmation", model.TemplateName[0]);
            Assert.AreEqual(10, model.RecipientID.Count);
        }

        [Test]
        public void TestViewRecipientsbyNotificationID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewRecipients(notificationID: 5969) as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.RecipientModel)result.ViewData.Model;
            Assert.AreEqual("56169", model.RecipientID[0]);
            Assert.AreEqual("HNJ@FLSMIDTH.COM,JEAL@FLSMIDTH.COM,A.PRUSZYNSKA@CWT-ECENTER.COM", model.SentTo[0]);
            Assert.AreEqual("2013-12-05 14:34:20.207", model.SendDateTime[0]);
            Assert.AreEqual("EMAIL", model.NotificationType[0]);
            Assert.AreEqual("Ticketing confirmation", model.TemplateName[0]);
            Assert.AreEqual(10, model.RecipientID.Count);
        }

        [Test]
        public void TestViewRecipientsbyExtractID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewRecipients(extractID: 55990) as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.RecipientModel)result.ViewData.Model;
            Assert.AreEqual("56169", model.RecipientID[0]);
            Assert.AreEqual("HNJ@FLSMIDTH.COM,JEAL@FLSMIDTH.COM,A.PRUSZYNSKA@CWT-ECENTER.COM", model.SentTo[0]);
            Assert.AreEqual("2013-12-05 14:34:20.207", model.SendDateTime[0]);
            Assert.AreEqual("EMAIL", model.NotificationType[0]);
            Assert.AreEqual("Ticketing confirmation", model.TemplateName[0]);
        }

        [Test]
        public void TestViewRecipientsbySentTo()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewRecipients(sentTo: "HNJ@FLSMIDTH.COM") as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.RecipientModel)result.ViewData.Model;
            Assert.AreEqual("56169", model.RecipientID[0]);
            Assert.AreEqual("HNJ@FLSMIDTH.COM,JEAL@FLSMIDTH.COM,A.PRUSZYNSKA@CWT-ECENTER.COM", model.SentTo[0]);
            Assert.AreEqual("2013-12-05 14:34:20.207", model.SendDateTime[0]);
            Assert.AreEqual("EMAIL", model.NotificationType[0]);
            Assert.AreEqual("Ticketing confirmation", model.TemplateName[0]);
        }

        [TestFixtureSetUp]
        public void SetUp()
        {
            //create a controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            
        }

        [Test]
        public void TestViewFlightsbyExtractID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewFlights(extractID: 18249) as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.FlightsModel)result.ViewData.Model;
            Assert.AreEqual("24063", model.FlightID[0]);
            Assert.AreEqual("1", model.FlightLeg[0]);
            Assert.AreEqual("1266", model.FlightNumber[0]);
            Assert.AreEqual("LX", model.FlightCode[0]);
            Assert.AreEqual("2013-11-27 00:00:00.000", model.DepartureDate[0]);
            Assert.AreEqual("0710", model.DepartureTime[0]);
            Assert.AreEqual("CH", model.DepartureCountry[0]);
            Assert.AreEqual("ZRH", model.DepartureCity[0]);
            Assert.AreEqual("2013-11-27 00:00:00.000", model.ArrivalDate[0]);
            Assert.AreEqual("0900", model.ArrivalTime[0]);
            Assert.AreEqual("DK", model.ArrivalCountry[0]);
            Assert.AreEqual("CPH", model.ArrivalCity[0]);
            Assert.AreEqual("N", model.ScheduleChange[0]);
            Assert.AreEqual("Q", model.ServiceClass[0]);
            Assert.AreEqual("0150", model.Duration[0]);
        }

        [Test]
        public void TestViewFlightsbyFlightID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewFlights(flightID: 24063) as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.FlightsModel)result.ViewData.Model;
            Assert.AreEqual("24063", model.FlightID[0]);
            Assert.AreEqual("1", model.FlightLeg[0]);
            Assert.AreEqual("1266", model.FlightNumber[0]);
            Assert.AreEqual("LX", model.FlightCode[0]);
            Assert.AreEqual("2013-11-27 00:00:00.000", model.DepartureDate[0]);
            Assert.AreEqual("0710", model.DepartureTime[0]);
            Assert.AreEqual("CH", model.DepartureCountry[0]);
            Assert.AreEqual("ZRH", model.DepartureCity[0]);
            Assert.AreEqual("2013-11-27 00:00:00.000", model.ArrivalDate[0]);
            Assert.AreEqual("0900", model.ArrivalTime[0]);
            Assert.AreEqual("DK", model.ArrivalCountry[0]);
            Assert.AreEqual("CPH", model.ArrivalCity[0]);
            Assert.AreEqual("N", model.ScheduleChange[0]);
            Assert.AreEqual("Q", model.ServiceClass[0]);
            Assert.AreEqual("0150", model.Duration[0]);
        }

        [Test]
        public void TestViewPaxbyExtractID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewPax(extractID: 18249) as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.PaxModel)result.ViewData.Model;
            Assert.AreEqual("18500", model.PaxID[0]);
            Assert.AreEqual("CAROLINE", model.PaxFirst[0]);
            Assert.AreEqual("-", model.PaxMiddle[0]);
            Assert.AreEqual("HAGSTRAND", model.PaxLast[0]);
            Assert.AreEqual("MS", model.PaxTitle[0]);
            Assert.AreEqual("F", model.PaxGender[0]);
            Assert.AreEqual("ADT", model.PaxType[0]);
            Assert.AreEqual("1900-01-01 00:00:00.000", model.PaxDOB[0]);
        }

        [Test]
        public void TestViewPaxbyPaxID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewPax(paxID: 18500) as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.PaxModel)result.ViewData.Model;
            Assert.AreEqual("18500", model.PaxID[0]);
            Assert.AreEqual("CAROLINE", model.PaxFirst[0]);
            Assert.AreEqual("-", model.PaxMiddle[0]);
            Assert.AreEqual("HAGSTRAND", model.PaxLast[0]);
            Assert.AreEqual("MS", model.PaxTitle[0]);
            Assert.AreEqual("F", model.PaxGender[0]);
            Assert.AreEqual("ADT", model.PaxType[0]);
            Assert.AreEqual("1900-01-01 00:00:00.000", model.PaxDOB[0]);
        }

        [Test]
        public void TestViewNotificationsbyTopTen()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewNotifications() as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.NotificationsReportModel)result.ViewData.Model;
            Assert.AreEqual("4091", model.NotificationID[0]);
            Assert.AreEqual("Galileo-Bookings-1G-BK-201311270605.XML", model.NotificationDescription[0]);
            Assert.AreEqual("2013-11-27 06:05:32.310", model.SendDateTime[0]);
            Assert.AreEqual("PNR", model.LanguageType[0]);
            Assert.AreEqual(5, model.RecipientCount[0]);
            Assert.AreEqual(10, model.NotificationID.Count);
        }

        [Test]
        public void TestViewNotificationsbyNotificationID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewNotifications(notificationID: 4091) as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.NotificationsReportModel)result.ViewData.Model;
            Assert.AreEqual("4091", model.NotificationID[0]);
            Assert.AreEqual("Galileo-Bookings-1G-BK-201311270605.XML", model.NotificationDescription[0]);
            Assert.AreEqual("2013-11-27 06:05:32.310", model.SendDateTime[0]);
            Assert.AreEqual("PNR", model.LanguageType[0]);
            Assert.AreEqual(5, model.RecipientCount[0]);
        }

        [Test]
        public void TestViewNotificationsbyDataSourceID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewNotifications(dataSourceID: 4233238) as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.NotificationsReportModel)result.ViewData.Model;
            Assert.AreEqual("4091", model.NotificationID[0]);
            Assert.AreEqual("Galileo-Bookings-1G-BK-201311270605.XML", model.NotificationDescription[0]);
            Assert.AreEqual("2013-11-27 06:05:32.310", model.SendDateTime[0]);
            Assert.AreEqual("PNR", model.LanguageType[0]);
            Assert.AreEqual(5, model.RecipientCount[0]);
        }

        [Test]
        public void TestViewNotificationsbyNotificationDescription()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewNotifications(notificationDesc: "Galileo-Bookings-1G-BK-201311270605.XML") as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.NotificationsReportModel)result.ViewData.Model;
            Assert.AreEqual("4091", model.NotificationID[0]);
            Assert.AreEqual("Galileo-Bookings-1G-BK-201311270605.XML", model.NotificationDescription[0]);
            Assert.AreEqual("2013-11-27 06:05:32.310", model.SendDateTime[0]);
            Assert.AreEqual("PNR", model.LanguageType[0]);
            Assert.AreEqual(5, model.RecipientCount[0]);
        }

        [Test]
        public void TestViewNotificationsbyRecipientID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewNotifications(recipientID: 18466) as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.NotificationsReportModel)result.ViewData.Model;
            Assert.AreEqual("4091", model.NotificationID[0]);
            Assert.AreEqual("Galileo-Bookings-1G-BK-201311270605.XML", model.NotificationDescription[0]);
            Assert.AreEqual("2013-11-27 06:05:32.310", model.SendDateTime[0]);
            Assert.AreEqual("PNR", model.LanguageType[0]);
            Assert.AreEqual(5, model.RecipientCount[0]);
        }

        [Test]
        public void TestViewNotificationsbyExtractID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewNotifications(extractID: 18249) as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.NotificationsReportModel)result.ViewData.Model;
            Assert.AreEqual("4091", model.NotificationID[0]);
            Assert.AreEqual("Galileo-Bookings-1G-BK-201311270605.XML", model.NotificationDescription[0]);
            Assert.AreEqual("2013-11-27 06:05:32.310", model.SendDateTime[0]);
            Assert.AreEqual("PNR", model.LanguageType[0]);
            Assert.AreEqual(5, model.RecipientCount[0]);
        }

        [Test]
        public void TestViewExtractsTbyopTen()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewExtracts() as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.ExtractsModel)result.ViewData.Model;
            Assert.AreEqual("55989", model.ExtractID[0]);
            Assert.AreEqual("8OAFK8", model.PNR[0]);
            Assert.AreEqual("MR JENS ALMDAL", model.LeadPaxName[0]);
            Assert.AreEqual("1", model.TotalPax[0]);
            Assert.AreEqual("05/12/2013", model.UploadDateTime[0]);
            Assert.AreEqual("20131119", model.BookingDate[0]);
            Assert.AreEqual("", model.EmailAddress[0]);
            Assert.AreEqual("", model.OtherPhone[0]);
            Assert.AreEqual("EN", model.LanguageCode[0]);
            Assert.AreEqual(10, model.NumberofFlights[0]);
            Assert.AreEqual(10, model.ExtractID.Count);
        }

        [Test]
        public void TestViewExtractsTbyDataSourceID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewExtracts(dataSourceID: 4365540) as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.ExtractsModel)result.ViewData.Model;
            Assert.AreEqual("55989", model.ExtractID[0]);
            Assert.AreEqual("8OAFK8", model.PNR[0]);
            Assert.AreEqual("MR JENS ALMDAL", model.LeadPaxName[0]);
            Assert.AreEqual("1", model.TotalPax[0]);
            Assert.AreEqual("05/12/2013", model.UploadDateTime[0]);
            Assert.AreEqual("20131119", model.BookingDate[0]);
            Assert.AreEqual("", model.EmailAddress[0]);
            Assert.AreEqual("", model.OtherPhone[0]);
            Assert.AreEqual("EN", model.LanguageCode[0]);
            Assert.AreEqual(10, model.NumberofFlights[0]);
        }

        [Test]
        public void TestViewExtractsTbyRecipientID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewExtracts(recipientID: 56170) as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.ExtractsModel)result.ViewData.Model;
            Assert.AreEqual("55989", model.ExtractID[0]);
            Assert.AreEqual("8OAFK8", model.PNR[0]);
            Assert.AreEqual("MR JENS ALMDAL", model.LeadPaxName[0]);
            Assert.AreEqual("1", model.TotalPax[0]);
            Assert.AreEqual("05/12/2013", model.UploadDateTime[0]);
            Assert.AreEqual("20131119", model.BookingDate[0]);
            Assert.AreEqual("", model.EmailAddress[0]);
            Assert.AreEqual("", model.OtherPhone[0]);
            Assert.AreEqual("EN", model.LanguageCode[0]);
            Assert.AreEqual(10, model.NumberofFlights[0]);
        }

        [Test]
        public void TestViewDataSourcesbyTopTen()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewDataSources() as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.DataSourcesModel)result.ViewData.Model;
            Assert.AreEqual("4247976", model.DataSourceID[0]);
            Assert.AreEqual("1G-BK-201311280928.XML", model.DataSourceID[0]);
            Assert.AreEqual("2013-11-28 09:28:31.217", model.UploadDateTime[0]);
            Assert.AreEqual("XML", model.DataSourceType[0]);
            Assert.AreEqual(16, model.ExtractsCount[0]);
            Assert.AreEqual(10, model.DataSourceID.Count);
        }

        [Test]
        public void TestViewDataSourcesbyNotificationID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewDataSources(notificationID: 5733) as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.DataSourcesModel)result.ViewData.Model;
            Assert.AreEqual("4247976", model.DataSourceID[0]);
            Assert.AreEqual("1G-BK-201311280928.XML", model.DataSourceID[0]);
            Assert.AreEqual("2013-11-28 09:28:31.217", model.UploadDateTime[0]);
            Assert.AreEqual("XML", model.DataSourceType[0]);
            Assert.AreEqual(16, model.ExtractsCount[0]);
        }

        [Test]
        public void TestViewDataSourcesbyDataSourceName()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewDataSources(datasourcename: "1G-BK-201311280928.XML") as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.DataSourcesModel)result.ViewData.Model;
            Assert.AreEqual("4247976", model.DataSourceID[0]);
            Assert.AreEqual("1G-BK-201311280928.XML", model.DataSourceID[0]);
            Assert.AreEqual("2013-11-28 09:28:31.217", model.UploadDateTime[0]);
            Assert.AreEqual("XML", model.DataSourceType[0]);
            Assert.AreEqual(16, model.ExtractsCount[0]);
        }

        [Test]
        public void TestViewDataSourcesbyExtractID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var result = controller.ViewDataSources(extractID: 51193) as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.DataSourcesModel)result.ViewData.Model;
            Assert.AreEqual("4247976", model.DataSourceID[0]);
            Assert.AreEqual("1G-BK-201311280928.XML", model.DataSourceID[0]);
            Assert.AreEqual("2013-11-28 09:28:31.217", model.UploadDateTime[0]);
            Assert.AreEqual("XML", model.DataSourceType[0]);
            Assert.AreEqual(16, model.ExtractsCount[0]);
        }

        [Test]
        public void TestSearchbyDataSourceName()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            var dsresult = controller.Search(datasourcename: "1G-BK-201311280928.XML") as System.Web.Mvc.ViewResult;
            //Cast the result as the appropriate Model
            var model = (MvcApplication1.Models.DataSourcesModel)dsresult.ViewData.Model;
            Assert.AreEqual("4247976", model.DataSourceID[0]);
            Assert.AreEqual("1G-BK-201311280928.XML", model.DataSourceID[0]);
            Assert.AreEqual("2013-11-28 09:28:31.217", model.UploadDateTime[0]);
            Assert.AreEqual("XML", model.DataSourceType[0]);
            Assert.AreEqual(16, model.ExtractsCount[0]);
        }

        [Test]
        public void TestSearchbyPNR()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            //PNR result
            var pnrresult = controller.Search(pnr: "8OAFK8") as System.Web.Mvc.ViewResult;
            var model = (MvcApplication1.Models.ExtractsModel)pnrresult.ViewData.Model;
            Assert.AreEqual("55989", model.ExtractID[0]);
            Assert.AreEqual("8OAFK8", model.PNR[0]);
            Assert.AreEqual("MR JENS ALMDAL", model.LeadPaxName[0]);
            Assert.AreEqual("1", model.TotalPax[0]);
            Assert.AreEqual("05/12/2013", model.UploadDateTime[0]);
            Assert.AreEqual("20131119", model.BookingDate[0]);
            Assert.AreEqual("", model.EmailAddress[0]);
            Assert.AreEqual("", model.OtherPhone[0]);
            Assert.AreEqual("EN", model.LanguageCode[0]);
            Assert.AreEqual(10, model.NumberofFlights[0]);
        }

        [Test]
        public void TestSearchbySentTo()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            //PNR result
            var rresult = controller.Search(sentto: "HNJ@FLSMIDTH.COM") as System.Web.Mvc.ViewResult;
            var model = (MvcApplication1.Models.RecipientModel)rresult.ViewData.Model;
            Assert.AreEqual("56169", model.RecipientID[0]);
            Assert.AreEqual("HNJ@FLSMIDTH.COM,JEAL@FLSMIDTH.COM,A.PRUSZYNSKA@CWT-ECENTER.COM", model.SentTo[0]);
            Assert.AreEqual("2013-12-05 14:34:20.207", model.SendDateTime[0]);
            Assert.AreEqual("EMAIL", model.NotificationType[0]);
            Assert.AreEqual("Ticketing confirmation", model.TemplateName[0]);
        }

        [Test]
        public void TestSearchbyNotificationName()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method to receive the result
            //PNR result
            var nresult = controller.Search(notificationdesc: "Galileo-Bookings-1G-BK-201311270605.XML") as System.Web.Mvc.ViewResult;
            var model = (MvcApplication1.Models.NotificationsReportModel)nresult.ViewData.Model;
            Assert.AreEqual("4091", model.NotificationID[0]);
            Assert.AreEqual("Galileo-Bookings-1G-BK-201311270605.XML", model.NotificationDescription[0]);
            Assert.AreEqual("2013-11-27 06:05:32.310", model.SendDateTime[0]);
            Assert.AreEqual("PNR", model.LanguageType[0]);
            Assert.AreEqual(5, model.RecipientCount[0]);
        }

        [Test]
        public void TestNotificationsReportbyNotificationID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            //Execute report by NotificationID[0]
            MvcApplication1.Models.NotificationsReportModel model = controller.NotificationsReport(notificationID:4091);
            Assert.AreEqual("4091", model.NotificationID[0]);
            Assert.AreEqual("Galileo-Bookings-1G-BK-201311270605.XML", model.NotificationDescription[0]);
            Assert.AreEqual("2013-11-27 06:05:32.310", model.SendDateTime[0]);
            Assert.AreEqual("PNR", model.LanguageType[0]);
            Assert.AreEqual(5, model.RecipientCount[0]);
        }

        [Test]
        public void TestNotificationsReportbyExtractID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            //Execute report by NotificationID[0]
            MvcApplication1.Models.NotificationsReportModel model = controller.NotificationsReport(extractID:18249);
            Assert.AreEqual("4091", model.NotificationID[0]);
            Assert.AreEqual("Galileo-Bookings-1G-BK-201311270605.XML", model.NotificationDescription[0]);
            Assert.AreEqual("2013-11-27 06:05:32.310", model.SendDateTime[0]);
            Assert.AreEqual("PNR", model.LanguageType[0]);
            Assert.AreEqual(5, model.RecipientCount[0]);
        }

        [Test]
        public void TestNotificationsReportbyNotificationDesc()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            //Execute report by NotificationID[0]
            MvcApplication1.Models.NotificationsReportModel model = controller.NotificationsReport(notificationDesc:"Galileo-Bookings-1G-BK-201311270605.XML");
            Assert.AreEqual("4091", model.NotificationID[0]);
            Assert.AreEqual("Galileo-Bookings-1G-BK-201311270605.XML", model.NotificationDescription[0]);
            Assert.AreEqual("2013-11-27 06:05:32.310", model.SendDateTime[0]);
            Assert.AreEqual("PNR", model.LanguageType[0]);
            Assert.AreEqual(5, model.RecipientCount[0]);
        }

        [Test]
        public void TestNotificationsReportbyRecipientID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            //Execute report by NotificationID[0]
            MvcApplication1.Models.NotificationsReportModel model = controller.NotificationsReport(recipientID:18466);
            Assert.AreEqual("4091", model.NotificationID[0]);
            Assert.AreEqual("Galileo-Bookings-1G-BK-201311270605.XML", model.NotificationDescription[0]);
            Assert.AreEqual("2013-11-27 06:05:32.310", model.SendDateTime[0]);
            Assert.AreEqual("PNR", model.LanguageType[0]);
            Assert.AreEqual(5, model.RecipientCount[0]);
        }

        [Test]
        public void TestNotificationsReportbyDataSourceID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            //Execute report by NotificationID[0]
            MvcApplication1.Models.NotificationsReportModel model = controller.NotificationsReport(dataSourceID: 4233238);
            Assert.AreEqual("4091", model.NotificationID[0]);
            Assert.AreEqual("Galileo-Bookings-1G-BK-201311270605.XML", model.NotificationDescription[0]);
            Assert.AreEqual("2013-11-27 06:05:32.310", model.SendDateTime[0]);
            Assert.AreEqual("PNR", model.LanguageType[0]);
            Assert.AreEqual(5, model.RecipientCount[0]);
        }

        public void TestNotificationsReportbyTopTen()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            //Execute report by NotificationID[0]
            MvcApplication1.Models.NotificationsReportModel model = controller.NotificationsReport();
            Assert.AreEqual("4091", model.NotificationID[0]);
            Assert.AreEqual("Galileo-Bookings-1G-BK-201311270605.XML", model.NotificationDescription[0]);
            Assert.AreEqual("2013-11-27 06:05:32.310", model.SendDateTime[0]);
            Assert.AreEqual("PNR", model.LanguageType[0]);
            Assert.AreEqual(5, model.RecipientCount[0]);
            Assert.AreEqual(10, model.NotificationID.Count);
        }

        [Test]
        public void TestRecipientsReportbyNotificationID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            MvcApplication1.Models.RecipientModel model = controller.RecipientsReport(notificationID: 5969);
            Assert.AreEqual("56169", model.RecipientID[0]);
            Assert.AreEqual("HNJ@FLSMIDTH.COM,JEAL@FLSMIDTH.COM,A.PRUSZYNSKA@CWT-ECENTER.COM", model.SentTo[0]);
            Assert.AreEqual("2013-12-05 14:34:20.207", model.SendDateTime[0]);
            Assert.AreEqual("EMAIL", model.NotificationType[0]);
            Assert.AreEqual("Ticketing confirmation", model.TemplateName[0]);
        }

        [Test]
        public void TestRecipientsReportbyExtractID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            MvcApplication1.Models.RecipientModel model = controller.RecipientsReport(extractID: 55990);
            Assert.AreEqual("56169", model.RecipientID[0]);
            Assert.AreEqual("HNJ@FLSMIDTH.COM,JEAL@FLSMIDTH.COM,A.PRUSZYNSKA@CWT-ECENTER.COM", model.SentTo[0]);
            Assert.AreEqual("2013-12-05 14:34:20.207", model.SendDateTime[0]);
            Assert.AreEqual("EMAIL", model.NotificationType[0]);
            Assert.AreEqual("Ticketing confirmation", model.TemplateName[0]);
        }

        [Test]
        public void TestRecipientsReportbySentTo()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            MvcApplication1.Models.RecipientModel model = controller.RecipientsReport(sentTo:"HNJ@FLSMIDTH.COM");
            Assert.AreEqual("56169", model.RecipientID[0]);
            Assert.AreEqual("HNJ@FLSMIDTH.COM,JEAL@FLSMIDTH.COM,A.PRUSZYNSKA@CWT-ECENTER.COM", model.SentTo[0]);
            Assert.AreEqual("2013-12-05 14:34:20.207", model.SendDateTime[0]);
            Assert.AreEqual("EMAIL", model.NotificationType[0]);
            Assert.AreEqual("Ticketing confirmation", model.TemplateName[0]);
        }

        [Test]
        public void TestRecipientsReportbyTopTen()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            MvcApplication1.Models.RecipientModel model = controller.RecipientsReport();
            Assert.AreEqual("56169", model.RecipientID[0]);
            Assert.AreEqual("HNJ@FLSMIDTH.COM,JEAL@FLSMIDTH.COM,A.PRUSZYNSKA@CWT-ECENTER.COM", model.SentTo[0]);
            Assert.AreEqual("2013-12-05 14:34:20.207", model.SendDateTime[0]);
            Assert.AreEqual("EMAIL", model.NotificationType[0]);
            Assert.AreEqual("Ticketing confirmation", model.TemplateName[0]);
            Assert.AreEqual(10, model.RecipientID.Count);
        }

        [Test]
        public void TestExtractsReportbyDataSourceID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            MvcApplication1.Models.ExtractsModel model = controller.ExtractsReport(dataSourceID: 4365540);
            Assert.AreEqual("55989", model.ExtractID[0]);
            Assert.AreEqual("8OAFK8", model.PNR[0]);
            Assert.AreEqual("MR JENS ALMDAL", model.LeadPaxName[0]);
            Assert.AreEqual("1", model.TotalPax[0]);
            Assert.AreEqual("05/12/2013", model.UploadDateTime[0]);
            Assert.AreEqual("20131119", model.BookingDate[0]);
            Assert.AreEqual("", model.EmailAddress[0]);
            Assert.AreEqual("", model.OtherPhone[0]);
            Assert.AreEqual("EN", model.LanguageCode[0]);
            Assert.AreEqual(10, model.NumberofFlights[0]);
        }

        [Test]
        public void TestExtractsReportbyRecipientID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            MvcApplication1.Models.ExtractsModel model = controller.ExtractsReport(recipientID: 56170);
            Assert.AreEqual("55989", model.ExtractID[0]);
            Assert.AreEqual("8OAFK8", model.PNR[0]);
            Assert.AreEqual("MR JENS ALMDAL", model.LeadPaxName[0]);
            Assert.AreEqual("1", model.TotalPax[0]);
            Assert.AreEqual("05/12/2013", model.UploadDateTime[0]);
            Assert.AreEqual("20131119", model.BookingDate[0]);
            Assert.AreEqual("", model.EmailAddress[0]);
            Assert.AreEqual("", model.OtherPhone[0]);
            Assert.AreEqual("EN", model.LanguageCode[0]);
            Assert.AreEqual(10, model.NumberofFlights[0]);
        }

        [Test]
        public void TestExtractsReportbyPNR()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            MvcApplication1.Models.ExtractsModel model = controller.ExtractsReport(pnr:"8OAFK8");
            Assert.AreEqual("55989", model.ExtractID[0]);
            Assert.AreEqual("8OAFK8", model.PNR[0]);
            Assert.AreEqual("MR JENS ALMDAL", model.LeadPaxName[0]);
            Assert.AreEqual("1", model.TotalPax[0]);
            Assert.AreEqual("05/12/2013", model.UploadDateTime[0]);
            Assert.AreEqual("20131119", model.BookingDate[0]);
            Assert.AreEqual("", model.EmailAddress[0]);
            Assert.AreEqual("", model.OtherPhone[0]);
            Assert.AreEqual("EN", model.LanguageCode[0]);
            Assert.AreEqual(10, model.NumberofFlights[0]);
        }

        [Test]
        public void TestExtractsReportbyTopTen()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            MvcApplication1.Models.ExtractsModel model = controller.ExtractsReport();
            Assert.AreEqual("55989", model.ExtractID[0]);
            Assert.AreEqual("8OAFK8", model.PNR[0]);
            Assert.AreEqual("MR JENS ALMDAL", model.LeadPaxName[0]);
            Assert.AreEqual("1", model.TotalPax[0]);
            Assert.AreEqual("05/12/2013", model.UploadDateTime[0]);
            Assert.AreEqual("20131119", model.BookingDate[0]);
            Assert.AreEqual("", model.EmailAddress[0]);
            Assert.AreEqual("", model.OtherPhone[0]);
            Assert.AreEqual("EN", model.LanguageCode[0]);
            Assert.AreEqual(10, model.NumberofFlights[0]);
            Assert.AreEqual(10, model.ExtractID.Count);
        }

        [Test]
        public void TestDataSourcesReportbyNotificationID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            MvcApplication1.Models.DataSourcesModel model = controller.DataSourcesReport(notificationID: 5733);
            Assert.AreEqual("4247976", model.DataSourceID[0]);
            Assert.AreEqual("1G-BK-201311280928.XML", model.DataSourceID[0]);
            Assert.AreEqual("2013-11-28 09:28:31.217", model.UploadDateTime[0]);
            Assert.AreEqual("XML", model.DataSourceType[0]);
            Assert.AreEqual(16, model.ExtractsCount[0]);
        }

        [Test]
        public void TestDataSourcesReportbyDataSourceName()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            MvcApplication1.Models.DataSourcesModel model = new MvcApplication1.Models.DataSourcesModel();
            model = controller.DataSourcesReport(datasourcename:"1G-BK-201311280928.XML");
            Assert.AreEqual("4247976", model.DataSourceID[0]);
            Assert.AreEqual("1G-BK-201311280928.XML", model.DataSourceID[0]);
            Assert.AreEqual("2013-11-28 09:28:31.217", model.UploadDateTime[0]);
            Assert.AreEqual("XML", model.DataSourceType[0]);
            Assert.AreEqual(16, model.ExtractsCount[0]);
        }

        [Test]
        public void TestDataSourcesReportbyExtractID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            MvcApplication1.Models.DataSourcesModel model = controller.DataSourcesReport(extractID: 51193);
            Assert.AreEqual("4247976", model.DataSourceID[0]);
            Assert.AreEqual("1G-BK-201311280928.XML", model.DataSourceID[0]);
            Assert.AreEqual("2013-11-28 09:28:31.217", model.UploadDateTime[0]);
            Assert.AreEqual("XML", model.DataSourceType[0]);
            Assert.AreEqual(16, model.ExtractsCount[0]);
        }

        [Test]
        public void TestDataSourcesReportbyTopTen()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            MvcApplication1.Models.DataSourcesModel model = controller.DataSourcesReport();
            Assert.AreEqual("4247976", model.DataSourceID[0]);
            Assert.AreEqual("1G-BK-201311280928.XML", model.DataSourceID[0]);
            Assert.AreEqual("2013-11-28 09:28:31.217", model.UploadDateTime[0]);
            Assert.AreEqual("XML", model.DataSourceType[0]);
            Assert.AreEqual(16, model.ExtractsCount[0]);
            Assert.AreEqual(10, model.DataSourceID.Count);
        }

        [Test]
        public void TestFlightsReportbyExtractID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            MvcApplication1.Models.FlightsModel model = controller.FlightsReport(extractID:18249);
            Assert.AreEqual("24063", model.FlightID[0]);
            Assert.AreEqual("1", model.FlightLeg[0]);
            Assert.AreEqual("1266", model.FlightNumber[0]);
            Assert.AreEqual("LX", model.FlightCode[0]);
            Assert.AreEqual("2013-11-27 00:00:00.000", model.DepartureDate[0]);
            Assert.AreEqual("0710", model.DepartureTime[0]);
            Assert.AreEqual("CH", model.DepartureCountry[0]);
            Assert.AreEqual("ZRH", model.DepartureCity[0]);
            Assert.AreEqual("2013-11-27 00:00:00.000", model.ArrivalDate[0]);
            Assert.AreEqual("0900", model.ArrivalTime[0]);
            Assert.AreEqual("DK", model.ArrivalCountry[0]);
            Assert.AreEqual("CPH", model.ArrivalCity[0]);
            Assert.AreEqual("N", model.ScheduleChange[0]);
            Assert.AreEqual("Q", model.ServiceClass[0]);
            Assert.AreEqual("0150", model.Duration[0]);
        }

        [Test]
        public void TestFlightsReportbyFlightID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            MvcApplication1.Models.FlightsModel model = controller.FlightsReport(flightID: 24063);
            Assert.AreEqual("24063", model.FlightID[0]);
            Assert.AreEqual("1", model.FlightLeg[0]);
            Assert.AreEqual("1266", model.FlightNumber[0]);
            Assert.AreEqual("LX", model.FlightCode[0]);
            Assert.AreEqual("2013-11-27 00:00:00.000", model.DepartureDate[0]);
            Assert.AreEqual("0710", model.DepartureTime[0]);
            Assert.AreEqual("CH", model.DepartureCountry[0]);
            Assert.AreEqual("ZRH", model.DepartureCity[0]);
            Assert.AreEqual("2013-11-27 00:00:00.000", model.ArrivalDate[0]);
            Assert.AreEqual("0900", model.ArrivalTime[0]);
            Assert.AreEqual("DK", model.ArrivalCountry[0]);
            Assert.AreEqual("CPH", model.ArrivalCity[0]);
            Assert.AreEqual("N", model.ScheduleChange[0]);
            Assert.AreEqual("Q", model.ServiceClass[0]);
            Assert.AreEqual("0150", model.Duration[0]);
        }

        [Test]
        public void TestPaxReportbyExtractID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            MvcApplication1.Models.PaxModel model = controller.PaxReport(extractID:18249);
            Assert.AreEqual("18500", model.PaxID[0]);
            Assert.AreEqual("CAROLINE", model.PaxFirst[0]);
            Assert.AreEqual("-", model.PaxMiddle[0]);
            Assert.AreEqual("HAGSTRAND", model.PaxLast[0]);
            Assert.AreEqual("MS", model.PaxTitle[0]);
            Assert.AreEqual("F", model.PaxGender[0]);
            Assert.AreEqual("ADT", model.PaxType[0]);
            Assert.AreEqual("1900-01-01 00:00:00.000", model.PaxDOB[0]);
        }

        [Test]
        public void TestPaxReportbyPaxID()
        {
            //Create the Controller for the test
            var controller = new MvcApplication1.Controllers.ReportController();
            //Execute the method in the controller which will return a report
            MvcApplication1.Models.PaxModel model = controller.PaxReport(PaxID:18500);
            Assert.AreEqual("18500", model.PaxID[0]);
            Assert.AreEqual("CAROLINE", model.PaxFirst[0]);
            Assert.AreEqual("-", model.PaxMiddle[0]);
            Assert.AreEqual("HAGSTRAND", model.PaxLast[0]);
            Assert.AreEqual("MS", model.PaxTitle[0]);
            Assert.AreEqual("F", model.PaxGender[0]);
            Assert.AreEqual("ADT", model.PaxType[0]);
            Assert.AreEqual("1900-01-01 00:00:00.000", model.PaxDOB[0]);
        }
    }
}
