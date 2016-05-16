using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiExcercise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        /// <summary>
        /// Supplier Page
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Supplier()
        {
            ViewBag.Title = "Supplier Page";

            return View();
        }

        /// <summary>
        /// User Page
        /// </summary>
        /// <returns>View</returns>
        public ActionResult User()
        {
            ViewBag.Title = "User Page";

            return View();
        }

        /// <summary>
        /// Product Page
        /// </summary>
        /// <returns>Product</returns>
        public ActionResult Product()
        {
            ViewBag.Title = "Product Page";

            return View();
        }

        /// <summary>
        /// Purchase Order Page
        /// </summary>
        /// <returns>View</returns>
        public ActionResult PurchaseOrder()
        {
            ViewBag.Title = "Purchase Order Page";

            return View();
        }

        /// <summary>
        /// SalesOrder Page
        /// </summary>
        /// <returns>View</returns>
        public ActionResult SalesOrder()
        {
            ViewBag.Title = "Sales Order Page";

            return View();
        }
    }
}