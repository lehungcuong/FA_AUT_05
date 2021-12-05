using FluentAssertions;
using RestSharp;
using Xunit;
using XUnitTest_POM.APIRestSharp;
using XUnitTest_POM.Constraints;

namespace XUnitTest_POM.Test
{
    public class APITest
    {
        APIHelper aPIHelper;
        string x;

        public APITest()
        {
            aPIHelper = new APIHelper(ConfigHelper.GetValue("host"));
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
            foreach (var element in aPIHelper.SendPostRequest(ConfigHelper.GetValue(config), parameter))
            {
                if (element.Key == valueName)
                {
                    x = element.Value;
                }
            }
            return x;
        }

        /// <summary>
        /// Post Test
        /// </summary>
        [Fact(DisplayName ="Post API")]
        public void CallAPIPost()
        {
            var data = APIHelper.DataAPI("trang98542", "123-Apple-$$$");
            var parameter = new Parameter(
                name: ConfigHelper.GetValue("ApplicationType"),
                value: data,
                type: ParameterType.RequestBody);
            aPIHelper.SendPostRequest(ConfigHelper.GetValue("pathPost"), parameter);
        }

        /// <summary>
        /// Get Test
        /// </summary>
        [Fact(DisplayName ="Get API")]
        public void CallAPIGet()
        {
            var data = APIHelper.DataAPI("trang62112", "123-Apple-$$$");
            var parameter = new Parameter(
                name: ConfigHelper.GetValue("ApplicationType"),
                value: data,
                type: ParameterType.RequestBody);
            APIHelper.Id = returnValue("pathPost", "userID", parameter);
            APIHelper.Token = returnValue("token", "token", parameter);
            foreach (var element in aPIHelper.SendGetRequest(ConfigHelper.GetValue("pathGetDel")))
            {
                if(element.Key == "userID")
                {
                    APIHelper.Id.Should().Be(element.Value, "UserID wrong");
                }
            }
        }

        /// <summary>
        /// Delete Test
        /// </summary>
        [Fact(DisplayName ="Delete API")]
        public void CallAPIDelete()
        {
            var data = APIHelper.DataAPI("trang411523", "123-Apple-$$$");
            var parameter = new Parameter(
                name: APIConstants.ApplicationType,
                value: data,
                type: ParameterType.RequestBody);
            APIHelper.Id = returnValue("pathPost", "userID", parameter);
            APIHelper.Token = returnValue("token", "token", parameter);
            aPIHelper.SendDeleteRequest(ConfigHelper.GetValue("pathGetDel")).Should().BeNull();
        }
    }
}
