using ControllerExtensibility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllerExtensibility.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.Disabled)]
    public class FastController : Controller
    {
        // GET: Fast

        // when we apply SessionState attr to the controller session message will be lost, mvc fr will through exception - use ViewBag instead
        //for value disabled HttpContext.Session is null
        public ActionResult Index()
        {
            //Session["Message"] = "Hello";
            ViewBag.Message = "Hello";
            return View("Result", new Result
            {
                ControllerName = "Fast",
                ActionName = "lndex"
            });
        }
    }
}