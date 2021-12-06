using DemoPOM.RestSharpAPI;
using System;
using Xunit;
using Xunit.Abstractions;

namespace DemoPOM.Test
{
    public class RestApiTest
    {
        private readonly ITestOutputHelper output;

        public RestApiTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        // Create a new user
        [Fact]
        public void CreateUsers()
        {
            string jsString = @"{
                                    ""id"": ""9"",
                                    ""name"": ""hanna"",
                                    ""job"": ""member""
                                }";           
            RestApiHelper restApi = new RestApiHelper();
            var restUrl = restApi.SetUrl("users");
            var request = restApi.CreatePostRequest(jsString);
            var respone = restUrl.Execute(request);
            Console.WriteLine(respone);
        }

        // Get a user in database by id
        [Fact]
        public void GetUsers()
        {

            RestApiHelper restApi = new RestApiHelper();
            var restUrl = restApi.SetUrl("users/3");
            var request = restApi.CreateGetRequest();
            var respone = restUrl.Execute(request);

            if (respone.IsSuccessful)
            {
                output.WriteLine(respone.Content);
            }
            else
            {
                output.WriteLine("Get user unsuccessful!");
                output.WriteLine("Status code: {0}", respone.StatusCode);
                output.WriteLine("Response content: {0}", respone.Content);
            }
        }

        // Delete a user in database by id
        [Fact]
        public void DeleteUsers()
        {
            RestApiHelper restApi = new RestApiHelper();
            var restUrl = restApi.SetUrl("users/3");
            var request = restApi.CreateDeleteRequest();
            var respone = restUrl.Execute(request);

            if (respone.IsSuccessful)
            {
                output.WriteLine("Status code: {0}", respone.StatusCode);
                output.WriteLine("Response content: {0}", respone.Content);
            }
            else output.WriteLine("Delete user unsuccessful!");
        }
    }

}
