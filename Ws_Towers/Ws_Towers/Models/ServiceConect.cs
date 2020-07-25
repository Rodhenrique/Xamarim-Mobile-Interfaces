using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Ws_Towers.Models
{
    public static class ServiceConect
    {
        private static HttpClient client;

        public static HttpClient getClient
        {
            get
            {
                if (client == null)
                {
                    client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:51092/api/");
                }

                return client;
            }
        }
    }
}
