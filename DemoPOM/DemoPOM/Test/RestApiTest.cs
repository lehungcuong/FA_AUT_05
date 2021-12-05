using DemoPOM.RestSharpAPI;
using RestSharp;
using System.Collections.Generic;
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
                                    ""id"": ""1"",
                                    ""name"": ""anna"",
                                    ""job"": ""member""
                                }";
            RestApiHelper<CreateUser> restApi = new RestApiHelper<CreateUser>();
            var restUrl = restApi.SetUrl("users");
            var request = restApi.CreatePostRequest(jsString);
            var respone = restApi.GetResponse(restUrl, request);
            CreateUser content = restApi.GetContent<CreateUser>(respone);
            Assert.Equal("1", content.id);
            Assert.Equal("anna", content.name);
            Assert.Equal("member", content.job);
        }

        // Get a user in database by id
        [Fact]
        public void GetUsers()
        {

            RestApiHelper<CreateUser> restApi = new RestApiHelper<CreateUser>();
            var restUrl = restApi.SetUrl("users/3");
            var request = restApi.CreateGetRequest();
            var respone = restApi.GetResponse(restUrl, request);
            IRestResponse<List<CreateUser>> restResponse = restUrl.Get<List<CreateUser>>(request);
            if (respone.IsSuccessful)
            {
                output.WriteLine("id: {0}", restResponse.Data[0].id);
                output.WriteLine("name: {0}", restResponse.Data[0].name);
                output.WriteLine("job: {0}", restResponse.Data[0].job);

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

            RestApiHelper<CreateUser> restApi = new RestApiHelper<CreateUser>();
            var restUrl = restApi.SetUrl("users/6");
            var request = restApi.CreateDeleteRequest();
            var respone = restApi.GetResponse(restUrl, request);
            //IRestResponse<List<CreateUser>> restResponse = restUrl.Get<List<CreateUser>>(request);
            if (respone.IsSuccessful)
            {
                output.WriteLine("Status code: {0}", respone.StatusCode);
                output.WriteLine("Response content: {0}", respone.Content);
            }
            else output.WriteLine("Delete user unsuccessful!");
        }
    }

}
