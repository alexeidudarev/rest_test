using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectReportingOOP.BasePage
{
    public class BaseApiObjects
    {
        public static string  getData()
        {
            var api = "https://reqres.in/";
            IRestClient client = new RestClient(api);
            IRestRequest request = new RestRequest("api/users?page=2", Method.GET);
            IRestResponse response =  client.Execute(request);
            Console.WriteLine(response.ErrorMessage);
            Console.WriteLine(response.ErrorException);
            Assert.True(response.StatusCode.ToString() == "200");
            Console.WriteLine(response.ToString());
            return response.ToString();
        }

        public static void postData()
        {


        }
    }
}
