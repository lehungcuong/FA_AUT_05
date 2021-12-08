using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using TestPOM.Pages;
using Xunit;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestPOM.Test
{
    public class APITest : IClassFixture<ContentRequest>
        //ke thua 1 lan su dung 1 lan
    {
        public APIHelper ApiHelper;
        public APITest()
        {
            ApiHelper = new APIHelper(ConfigHelper.GetValue("host"));
        }



        [Trait("Categogy", "Quang01")]
        [Fact(DisplayName = "Call API Post")]
        public void CallAPIPost()
        {
            ContentRequest.CreatTest("Test Case 1 ","Test Call API Post");


            var dataToSend = new Dictionary<string, string>();
            dataToSend.Add("userName", "Quang45125498732132");
            dataToSend.Add("password", "Quang123@");
            ContentRequest.CreatLogInfo("input User Name ");
            ContentRequest.CreatLogPass("input User Name successful");

            var data = JsonConvert.SerializeObject(dataToSend);
            var parameter = new Parameter(
                name: ConfigHelper.GetValue("ApplicationType"),
                value: data,
                type: ParameterType.RequestBody);
            foreach (var element in ApiHelper.SendPostRequest(ConfigHelper.GetValue("Pathpost"), parameter))
            {
                if (element.Key == "userID")
                {
                    APIHelper.Id = element.Value;
                    break;
                }
            }
            foreach (var element in ApiHelper.SendPostRequest(ConfigHelper.GetValue("Token"), parameter))
            {
              
                if (element.Key == "token")
                {
                    APIHelper.Token = element.Value;
                    break;
                }
            }

            ApiHelper.SendDeletePostRequest(ConfigHelper.GetValue("PathGet"));
            ContentRequest.CreatLogPass("Test Case 1 Pass");


        }


        [Trait("Categogy", "Quang01")]
        [Fact(DisplayName = "Call API Get")]
        public void CallAPIGet()
        {
            ContentRequest.CreatTest("Test Case 2", "Call API Get");
            var dataToSend = new Dictionary<string, string>();
            dataToSend.Add("userName", "Quang15021999999");
            dataToSend.Add("password", "Quang123@");
            ContentRequest.CreatLogInfo("input User Name");
            ContentRequest.CreatLogPass("input User Name successful");
            var data = JsonConvert.SerializeObject(dataToSend);
            var parameter = new Parameter(
                name: ConfigHelper.GetValue("ApplicationType"),
                value: data,
                type: ParameterType.RequestBody);

            ContentRequest.CreatLogInfo("taken useID ");
            foreach (var element in ApiHelper.SendPostRequest(ConfigHelper.GetValue("Pathpost"), parameter))
            {
                ContentRequest.CreatLogFail("taken useID Fail ");
                if (element.Key == "userID")
                {
                    APIHelper.Id = element.Value;
                    ContentRequest.CreatLogPass("taken useID Pass");
                    
                }
            }
            ContentRequest.CreatLogInfo("taken token Fail");
            foreach (var element in ApiHelper.SendPostRequest(ConfigHelper.GetValue("Token"), parameter))
            {
                ContentRequest.CreatLogFail("taken token Fail");
                if (element.Key == "token")
                {
                    APIHelper.Token = element.Value;
                    ContentRequest.CreatLogPass("taken token Pass");
                    
                }
            }
            ApiHelper.SendGetRequest(ConfigHelper.GetValue("PathGet"));
            //ApiHelper.SendGetRequest(ConfigHelper.GetValue("PathGet"));
            ContentRequest.CreatLogPass("Test Case 2 Pass");
            ApiHelper.SendDeleteGetRequest(ConfigHelper.GetValue("PathGet"));
            //ApiHelper.SendDeleteRequest(ConfigHelper.GetValue("PathGet"));
            ContentRequest.CreatLogInfo("Delete User Name successful");
        }


    }


}

