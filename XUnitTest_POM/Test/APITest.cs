using FluentAssertions;
using RestSharp;
using Xunit;
using XUnitTest_POM.APIRestSharp;
using XUnitTest_POM.Constraints;

namespace XUnitTest_POM.Test
{
    public class APITest
    {
        APIHelper apiHelper;

        public APITest()
        {
            apiHelper = new APIHelper(ConfigHelper.GetValue("host"));
        }

        /// <summary>
        /// Return value by key
        /// </summary>
        /// <param name="config"></param>
        /// <param name="valueName"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public string returnValue(string config, string valueName, Parameter parameter)
        {
            foreach (var element in apiHelper.SendPostRequest(ConfigHelper.GetValue(config), parameter))
            {
                if (element.Key == valueName)
                {
                    return element.Value;
                }
            }
            return "Not Found";
        }

        /// <summary>
        /// Post Test
        /// </summary>
        [Trait("Category","Example")]
        [Fact(DisplayName ="Test Method API")]
        public void CallAPIPost()
        {
            //Get Data to send
            var data = APIHelper.DataToSend(ConfigHelper.GetValue("userName"), ConfigHelper.GetValue("password"));
            var parameter = new Parameter( name: ConfigHelper.GetValue("ApplicationType"), value: data, type: ParameterType.RequestBody);

            //API Post User
            APIHelper.Id = returnValue("pathPost", "userID", parameter);

            //API Generate Token
            APIHelper.Token = returnValue("token", "token", parameter);

            //API Get User
            foreach (var element in apiHelper.SendGetRequest(ConfigHelper.GetValue("pathGetDel")))
            {
                if (element.Key == "userID")
                {
                    APIHelper.Id.Should().Be(element.Value, "UserID wrong");
                }
            }

            //API Delete User
            apiHelper.SendDeleteRequest(ConfigHelper.GetValue("pathGetDel")).Should().BeNull();
        }
    }
}
