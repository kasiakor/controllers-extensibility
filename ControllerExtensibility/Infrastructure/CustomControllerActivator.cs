using ControllerExtensibility.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControllerExtensibility.Infrastructure
{
    public class CustomControllerActivator : IControllerActivator
    {
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            //when product controller is requesed an instance of customer controller in created
            if (controllerType == typeof(ProductController))
            {
                controllerType = typeof(CustomerController);
            }
            //dependency resolver creates an instance of the controller
            return (IController)DependencyResolver.Current.GetService(controllerType); ;
        }
    }
}