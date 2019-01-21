using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCabin1
{
    class Test
    {
        public string TestMe()
        {
            ServiceReference1.PizzaCabinIncClient client = new ServiceReference1.PizzaCabinIncClient();
            var schedules = client.Schedule("2015/12/14").Schedules;
            // Use the 'client' variable to call operations on the service.

            // Always close the client.
            client.Close();
            return "test";
        }
    }
}
