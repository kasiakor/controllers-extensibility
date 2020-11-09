using ControllerExtensibility.Infrastructure;
using ControllerExtensibility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllerExtensibility.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("Result", new Result
            {
                ControllerName = "Home",
                ActionName = "Index"
            });
        }

        //The current request for action 'Index' on controller type 'HomeController' is ambiguous between the following action methods
        //applying [Local] defined in Local Attribute.cs - method selection attribute 
        [Local]
        [ActionName("Index")]
        public ActionResult LocalIndex()
        {
            return View("Result", new Result
            {
                ControllerName = "Home",
                ActionName = "Localndex"
            });
        }

        //if action invoker will not find the action from request will throw a 404 error
        //to override this behaviour use HandleUnknownAction
        protected override void HandleUnknownAction(string actionName)
        {
            Response.Write(string.Format("You requested {0} that was not found", actionName));
        }
    }
}