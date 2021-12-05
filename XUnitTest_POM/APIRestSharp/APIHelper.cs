using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using XUnitTest_POM.Constraints;

namespace XUnitTest_POM.APIRestSharp
{
    class APIHelper
    {
        private IRestClient RestClient { get; set; }
        private IRestRequest RestRequest { get; set; }
        string Host { get; set; }
        public static string Token;
        public static string Id;

        public APIHelper(string host)
        {
            Host = host;
        }

        /// <summary>
        /// Send Post Request
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns> Dictionary </returns>
        public Dictionary<string, string> SendPostRequest (string path,params Parameter[] parameters)
        {
            InitializeAPIClient(Host, path);
            InitializePostRequest(parameters);
            return Execute();
        }

        /// <summary>
        /// Send Get Request
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Dictionary<string, string> SendGetRequest (string path) 
        {
            InitializeAPIClient(Host, path);
            InitializeGetRequest();
            return Execute();
        }

        /// <summary>
        /// Send Delete Request
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Dictionary<string, string> SendDeleteRequest (string path)
        {
            InitializeAPIClient(Host, path);
            InitializeDeleteRequest();
            return Execute();
        }

        /// <summary>
        /// Initialize API Client
        /// </summary>
        /// <param name="host"></param>
        /// <param name="path"></param>
        /// <param name="query"></param>
        private void InitializeAPIClient(string host, string path, string query = null)
        {
            var uriBuilder = new UriBuilder()
            {
                Scheme = ConfigHelper.GetValue("Scheme")
            };
            uriBuilder.Host = host;
            uriBuilder.Path = path;
            uriBuilder.Query = query;
            RestClient = new RestClient(baseUrl: uriBuilder.Uri);
        }

        /// <summary>
        /// Initialize Post Request
        /// </summary>
        /// <param name="parameters"></param>
        private void InitializePostRequest(params Parameter[] parameters)
        {
            RestRequest = new RestRequest(Method.POST);
            parameters.ToList().ForEach(p => RestRequest.AddParameter(p));
        }

        /// <summary>
        /// Initialize Get Request
        /// </summary>
        private void InitializeGetRequest()
        {
            RestRequest = new RestRequest(Method.GET);
            RestRequest.AddUrlSegment("Id", GetUserId());
            RestClient.AddDefaultHeader("Authorization", string.Format("Bearer {0}", GetToken()));
        }

        /// <summary>
        /// Initialize Delete Request
        /// </summary>
        private void InitializeDeleteRequest()
        {
            RestRequest = new RestRequest(Method.DELETE);
            RestRequest.AddUrlSegment("Id", GetUserId());
            RestClient.AddDefaultHeader("Authorization", string.Format("Bearer {0}", GetToken()));
        }

        /// <summary>
        /// Get User ID
        /// </summary>
        /// <returns></returns>
        public string GetUserId() => Id;

        /// <summary>
        /// Get Bearer Token
        /// </summary>
        /// <returns></returns>
        public string GetToken() => Token;

        /// <summary>
        /// Reponse data
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> Execute()
        {
            var reponse = RestClient.Execute<Dictionary<string, string>>(RestRequest);
            if (!reponse.IsSuccessful)
            {
                throw new Exception("FAIL");
            }
            return reponse.Data;
        }

        /// <summary>
        /// Get Data API
        /// </summary>
        /// <returns></returns>
        public static string DataAPI(string name, string password)
        {
            var dataToSend = new Dictionary<string, string>();
            dataToSend.Add("userName", name);
            dataToSend.Add("password", password);
            return JsonConvert.SerializeObject(dataToSend);
        }
    }
}
