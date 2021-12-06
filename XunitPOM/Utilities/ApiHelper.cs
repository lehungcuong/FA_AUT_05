using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XunitPOM.Utilities
{
    public class ApiHelper
    {
        private IRestClient RestClient { get; set; }
        private IRestRequest RestRequest { get; set; }
        string Host { get; set; }
        public ApiHelper(string host)
        {
            Host = host;
        }

        /// <summary>
        /// Send post request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns> Generic Type </returns>
        public T SendPostRequest<T>(string path, params Parameter[] parameters) where T : new()
        {
            InitiallizeApiClient(Host, path);
            InitiallizePostRequest(parameters);
            return ExcuteGetData<T>();
        }

        /// <summary>
        /// Send get request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="option"></param>
        /// <returns> Generic Type </returns>
        public T SendGetRequest<T>(string path, string option = "") where T : new()
        {
            InitiallizeApiClient(Host, path, option);
            InitiallizeGetRequest();
            return ExcuteGetData<T>();
        }

        /// <summary>
        /// Send delete request
        /// </summary>
        /// <param name="path"></param>
        /// <param name="option"></param>
        /// <returns> Generic Type </returns>
        public string SendDeleteRequest(string path, string option = "")
        {
            InitiallizeApiClient(Host, path, option);
            InitiallizeDeleteRequest();
            return ExcuteGetContent();
        }

        /// <summary>
        /// Initialize api client 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="path"></param>
        /// <param name="option"></param>
        /// <param name="query"></param>
        private void InitiallizeApiClient(string host, string path, string option = "", string query = null)
        {
            var uriBuilder = new UriBuilder()
            {
                Scheme = "https"
            };
            uriBuilder.Host = host;
            uriBuilder.Path = path + option;
            uriBuilder.Query = query;

            RestClient = new RestClient(baseUrl: uriBuilder.Uri);
        }

        /// <summary>
        /// Initialize post request
        /// </summary>
        /// <param name="parameters"></param>
        private void InitiallizePostRequest(params Parameter[] parameters)
        {
            RestRequest = new RestRequest(Method.POST);
            parameters.ToList().ForEach(p => RestRequest.AddParameter(p));
        }

        /// <summary>
        /// Initialize get request
        /// </summary>
        private void InitiallizeGetRequest(params Parameter[] parameters)
        {
            RestRequest = new RestRequest(Method.GET);
            SetHeader();
        }

        /// <summary>
        /// Initialize delete request
        /// </summary>
        private void InitiallizeDeleteRequest()
        {
            RestRequest = new RestRequest(Method.DELETE);
            SetHeader();
        }
        
        /// <summary>
        /// Set header authorize by bearer key
        /// </summary>
        private void SetHeader()
        {
            RestClient.AddDefaultHeader("Authorization", string.Format("Bearer {0}", JsonHelper.GetValueByKeySavedData("token")));
        }

        /// <summary>
        /// Excute get data from API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns> Data by generic type </returns>
        /// <exception cref="Exception"></exception>
        private T ExcuteGetData<T>() where T: new()
        {
            var respone = RestClient.Execute<T>(RestRequest);
            if (!respone.IsSuccessful)
            {
                throw new Exception("Fail to excute API");
            }
            return respone.Data;
        }

        /// <summary>
        /// Excute get content from API
        /// </summary>
        /// <returns> Content from API </returns>
        /// <exception cref="Exception"></exception>
        private string ExcuteGetContent()
        {
            var respone = RestClient.Execute(RestRequest);
            if (!respone.IsSuccessful)
            {
                throw new Exception("Fail to excute API");
            }
            return respone.Content;
        }
    }
}
