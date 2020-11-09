using ControllerExtensibility.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace ControllerExtensibility.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        //requestContex - it contains information about the route that matched the current request in the RouteData property
        public IController CreateController(RequestContext requestContext,  
            string controllerName) { 

            Type targetType = null; 
            switch (controllerName) { 
                case "Product": 
                    targetType = typeof(ProductController); 
                    break; 
                case "Customer": 
                    targetType = typeof(CustomerController); 
                    break; 
                default: 
                    requestContext.RouteData.Values["controller"] = "Product"; 
                    targetType = typeof(ProductController); 
                    break; 
            } 

            return targetType == null ? null : 
                (IController)DependencyResolver.Current.GetService(targetType); 
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            //should session data be maintained for the controller
            switch(controllerName)
            {
                case "Home":
                    return SessionStateBehavior.ReadOnly;
  
                case "Product":
                    return SessionStateBehavior.Required;

                default:
                    return SessionStateBehavior.Default;
            }    
        }

        public void ReleaseController(IController controller)
        {
           IDisposable disposable = controller as IDisposable;
           // if idisposable interface is implemented by the class then call Dispose method to release controller object created by CreateController
           if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}