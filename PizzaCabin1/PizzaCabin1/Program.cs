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
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("http://pizzacabininc.azurewebsites.net/PizzaCabinInc.svc/schedule/2015-12-14");
            }
            Rootobject example = JsonConvert.DeserializeObject<Rootobject>(json);
            for(int i = 0; i < example.ScheduleResult.Schedules.Length; i++)
            {
                Console.WriteLine(example.ScheduleResult.Schedules[i].Name);
                for (int j = 0; j < example.ScheduleResult.Schedules[i].Projection.Length; j++)
                {
                    Console.WriteLine("  " + example.ScheduleResult.Schedules[i].Projection[j].Description + ": " + example.ScheduleResult.Schedules[i].Projection[j].minutes);
                }
            }
            Console.ReadLine();
        }
    }
}