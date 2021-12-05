using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using WebDriver;
using Xunit;
using XunitPOM.Utilities;
using Parameter = RestSharp.Parameter;

namespace XunitPOM.Test
{
    public class ApiTest
    {
        ApiHelper apiHelper;

        public ApiTest() 
        {
            // Create new constructor
            apiHelper = new ApiHelper(ConfigHelper.GetValue("HostPath"));
        }

        [Fact(DisplayName = "Api Test")]
        public void ApiRawTest()
        {
            // Create new paramter
            var parameter = new Parameter(
                name: ConfigHelper.GetValue("ApplicationType"),
                value: JsonConvert.SerializeObject(JsonHelper.LoadJson()),
                type: ParameterType.RequestBody);

            // Create new user by API and add to Jsondata
            var CreateNewUser = apiHelper.SendPostRequest<Dictionary<string, string>>(ConfigHelper.GetValue("PathPostUser"), parameter);
            BrowserFactory.AssertValueBool(CreateNewUser.ContainsKey("userID"), AssertType.True, "Can't find userID in data");
            foreach ( var element in CreateNewUser)
            {
                if (element.Key == "userID")
                {
                    JsonHelper.SetValueByKeyJson(element.Value, element.Key);
                }  
            }

            // Create new Token by API and add to Jsondata
            var CreateToken = apiHelper.SendPostRequest<Dictionary<string, string>>(ConfigHelper.GetValue("PathToken"), parameter);
            BrowserFactory.AssertValueBool(CreateToken.ContainsKey("token"), AssertType.True, "Can't find token in data");
            foreach (var element in CreateToken)
            {
                if (element.Key == "token")
                {
                    JsonHelper.SetValueByKeyJson(element.Value, element.Key);
                }
                    
            }

            // Save token and uuid into JsonData
            JsonHelper.SaveJson();

            // Get user information by API and compare with value in TestData
            var GetUserInformation = apiHelper.SendGetRequest<Dictionary<string, string>>(ConfigHelper.GetValue("PathGetUser"), JsonHelper.GetValueByKeySavedData("userID"));
            BrowserFactory.AssertValueBool(GetUserInformation.ContainsKey("userID") && GetUserInformation.ContainsKey("username"), AssertType.True, "Can't find userID or userName");
            foreach (var element in GetUserInformation)
            {
                if (element.Key == "userID")
                {
                    BrowserFactory.AssertValueEqual(element.Value, JsonHelper.GetValueByKeySavedData("userID"), "Wrong userid from API !");
                }
                else if (element.Key == "username")
                {
                    BrowserFactory.AssertValueEqual(element.Value, JsonHelper.GetValueByKeyRawData("userName"), "Wrong username from API !");
                }
            }

            // Delete user by API and compare return content
            BrowserFactory.AssertValueEmpty(apiHelper.SendDeleteRequest(ConfigHelper.GetValue("PathGetUser"), JsonHelper.GetValueByKeySavedData("userID")), "Return data not null !!");

        }
    }
}
