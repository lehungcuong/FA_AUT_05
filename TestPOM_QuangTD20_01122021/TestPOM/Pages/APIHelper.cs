using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace TestPOM.Pages
{
    public class APIHelper
    {
        public IRestClient RestClient { get; set; }
        public IRestRequest RestRequest { get; set; }

        string Host { get; set; }
        public static string Token;
        public static string Id;
        public string GetUserId() => Id;
        public string GetToken() => Token;

        public APIHelper(string host)
        {

            Host = host;
        }

        public Dictionary<string, string> SendPostRequest(string path, params Parameter[] parameters)
        {
            APIClient(Host, path);
            PostRequest(parameters);
            return Excute();
        }

        public Dictionary<string, string> SendGetRequest(string path)
        {
            APIClient(Host, path);
            GetRequest();
            return Excute();
        }

        private void APIClient(string host, string path, string query = null)
        {
            var uriBuider = new UriBuilder()
            {
                Scheme = "https"
            };
            uriBuider.Host = host;
            uriBuider.Path = path;
            uriBuider.Query = query;
            RestClient = new RestClient(baseUrl: uriBuider.Uri);
        }

        //Excute request
       
        public void PostRequest(Parameter[] parameters)
        {
            RestRequest = new RestRequest(Method.POST);
            parameters.ToList().ForEach(p => RestRequest.AddParameter(p));
        }
        private void DeletePostRequest()
        {
            RestRequest = new RestRequest(Method.DELETE);
            RestRequest.AddUrlSegment("Id", GetUserId());
            RestClient.AddDefaultHeader("Authorization", string.Format("Bearer {0}", GetToken()));
        }
       public Dictionary<string, string> SendDeletePostRequest(string path)
        {
            APIClient(Host, path);
            DeletePostRequest();
            return Excute();
        }
        private void GetRequest()
        {
            RestRequest = new RestRequest(Method.GET);
            RestRequest.AddUrlSegment("Id", GetUserId());
            RestClient.AddDefaultHeader("Authorization", string.Format("Bearer {0}", GetToken()));
        }

        public Dictionary<string, string> SendDeleteGetRequest(string path)
        {
            APIClient(Host, path);
           DeleteGetRequest();
            return Excute();
        }
       
        private void DeleteGetRequest()
        {
            RestRequest = new RestRequest(Method.DELETE);
            RestRequest.AddUrlSegment("Id", GetUserId());
            RestClient.AddDefaultHeader("Authorization", string.Format("Bearer {0}", GetToken()));
        }


        private Dictionary<string, string> Excute()
        {
            var response = RestClient.Execute<Dictionary<string, string>>(RestRequest);
            if (!response.IsSuccessful)
            {
                throw new Exception("failt to Excute Api request");
            }
            return response.Data;
         }






    }
}


