using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        //asynchronous method
        //working thread is not tided up while waiting for GetRemoteData to complete as above
        public async Task<string> GetRemoteDataAsync()
        {
            return await Task<string>.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                return "Hello from the asynchronous method";
            });
        }
    }
}