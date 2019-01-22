using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCabin1
{
    class WebServiceCall
    {
        public string CallService()
        {
            ServiceReference1.PizzaCabinIncClient client = new ServiceReference1.PizzaCabinIncClient("ScheduleResult");
            ServiceReference1.TeamSchedule teamSchedule = new ServiceReference1.TeamSchedule();
            //ServiceReference1.Schedule schedule = new ServiceReference1.Schedule();
            client.Open();
            Console.WriteLine(client.ClientCredentials);
            Console.WriteLine(client.State);
            Console.WriteLine("EndPoint: " + client.Endpoint);
            DateTime value = new DateTime(12/13/20151700);
            Console.WriteLine(value.ToString("MM/dd/yyyyhh:mmtt"));
            teamSchedule = client.Schedule(value.ToString());
            //schedule = teamSchedule.Schedules[0];
            // Use the 'client' variable to call operations on the service.

            // Always close the client.
            client.Close();
            return "test";
        }
    }
}
