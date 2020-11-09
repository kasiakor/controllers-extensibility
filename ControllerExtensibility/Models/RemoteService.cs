using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace ControllerExtensibility.Models
{
    public class RemoteService
    {
        public string GetRemoteData()
        {
            //2s delay
            Thread.Sleep(2000);
            return  "Hello from the other side";
        }
    }
}