using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using WebDriver;
using Xunit;
using Xunit.Abstractions;
using XunitPOM.Utilities;
using Parameter = RestSharp.Parameter;

namespace XunitPOM.Test
{
    public class ApiTest : BaseTest
    {
        ApiHelper apiHelper;

        public ApiTest(ITestOutputHelper output) : base(output)
        {
            // Create new constructor
            apiHelper = new ApiHelper(ConfigHelper.GetValue("HostPath"));
        }

        [Trait("Category", "RunningMan")]
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
            BrowserFactory.AssertValueBool(CreateNewUser.ContainsKey("userID"), AssertType.True, "Can't find userID in data", "Verify userID sucessfully");
            JsonHelper.SetValueByKeyJson(CreateNewUser["userID"], "userID");

            // Create new Token by API and add to Jsondata
            var CreateToken = apiHelper.SendPostRequest<Dictionary<string, string>>(ConfigHelper.GetValue("PathToken"), parameter);
            BrowserFactory.AssertValueBool(CreateToken.ContainsKey("token"), AssertType.True, "Can't find token in data", "Verify token sucessfully");
            JsonHelper.SetValueByKeyJson(CreateToken["token"], "token");

            // Save token and uuid into JsonData
            JsonHelper.SaveJson();

            // Get user information by API and compare with value in TestData
            var GetUserInformation = apiHelper.SendGetRequest<Dictionary<string, string>>(ConfigHelper.GetValue("PathGetUser"), JsonHelper.GetValueByKeySavedData("userID"));
            BrowserFactory.AssertValueBool(GetUserInformation.ContainsKey("userId") && GetUserInformation.ContainsKey("username"), AssertType.True, "Can't find userID or userName", "Verify userID and userName sucessfully");
            BrowserFactory.AssertValueEqual(GetUserInformation["userId"], JsonHelper.GetValueByKeySavedData("userID"), "Wrong userid from API !", "Verify userID from API successfully");
            BrowserFactory.AssertValueEqual(GetUserInformation["username"], JsonHelper.GetValueByKeyRawData("userName", @"\TestData\JsonData.json"), "Wrong username from API !", "Verify username from API successfully");

            // Delete user by API and compare return content
            BrowserFactory.AssertValueEmpty(apiHelper.SendDeleteRequest(ConfigHelper.GetValue("PathGetUser"), JsonHelper.GetValueByKeySavedData("userID")), "Return data not null !", "Verify user data delete success");

        }
    }
}
