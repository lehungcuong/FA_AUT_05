using Newtonsoft.Json;
using RestSharp;
using System.Configuration;
using System.IO;

namespace DemoPOM.RestSharpAPI
{
    public class RestApiHelper<T>
    {
        public RestClient restClient;
        public static RestRequest restRequest;
        public string baseUrl = ConfigurationManager.AppSettings["path"].ToString();
        // Create Client
        public RestClient SetUrl(string resourceUrl)
        {
            var uri = Path.Combine(baseUrl, resourceUrl);
            var restClient = new RestClient(uri);
            return restClient;
        }

        // Create body
        public RestRequest CreatePostRequest(string jsString)
        {
            restRequest = new RestRequest(Method.POST);
            restRequest.AddParameter("application/json", jsString, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreateGetRequest()
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public RestRequest CreateDeleteRequest()
        {
            restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        // Get the response
        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DTO GetContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO deserializeObj = JsonConvert.DeserializeObject<DTO>(content);
            return deserializeObj;
        }
    }
}
