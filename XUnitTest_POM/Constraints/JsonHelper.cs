using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace XUnitTest_POM.Constraints
{
    class JsonHelper
    {
        private readonly static string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private readonly static string jsonPath = path + @"\Config\json1.json";

        /// <summary>
        /// Return value from Json file
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValueJson(string key)
        {
            string json_file = File.ReadAllText(jsonPath);
            Dictionary<string, string> json_dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json_file);
            return json_dict[key];
        }
    }
}
