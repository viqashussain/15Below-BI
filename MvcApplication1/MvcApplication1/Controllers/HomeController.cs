using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        ///  Method for the Home Page
        /// </summary>
        /// <returns>
        /// View - Home Page
        /// </returns>
        public ActionResult SelectReport()
        {
            ViewBag.Message = "15Below Reporting";

            return View();
        }
    }
}
