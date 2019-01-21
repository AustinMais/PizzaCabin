using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PizzaCabin1
{
    class Program
    {
        static void Main(string[] args)
        {
            string json;
            Test WebServiceTest = new Test();
            WebServiceTest.TestMe();
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("http://pizzacabininc.azurewebsites.net/PizzaCabinInc.svc/schedule/2015-12-14");
            }
            //json = WebServiceTest.TestMe();
            Rootobject example = JsonConvert.DeserializeObject<Rootobject>(json);
            Console.WriteLine(example.ScheduleResult.Schedules[0].Projection[0].minutes);
            Console.ReadLine();
        }
    }
}