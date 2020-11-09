﻿using ControllerExtensibility.Models;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace ControllerExtensibility.Controllers
{
    public class RemoteDataController : Controller
    {
        // GET: RemoteData
        //public ActionResult Data()
        //{
            //RemoteService service = new RemoteService();
            //string data = service.GetRemoteData();
            //Task object calls GetRemoteData()
            public async Task<ActionResult> Data()
            {
                string data = await Task<string>.Factory.StartNew(() =>
               {
                   return new RemoteService().GetRemoteData();
               });

                return View((object)data);
            }

            //asynchrocous controller - async await keywords
            
        }
    }
//}