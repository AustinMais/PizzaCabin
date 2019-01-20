using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCabin1
{
    class Test
    {
        public void TestMe()
        {
            ServiceReference1.PizzaCabinIncClient client = new ServiceReference1.PizzaCabinIncClient();

            // Use the 'client' variable to call operations on the service.

            // Always close the client.
            client.Close();
        }
    }
}
