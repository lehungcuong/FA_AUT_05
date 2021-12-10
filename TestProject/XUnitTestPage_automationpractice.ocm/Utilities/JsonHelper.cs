using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace XUnitTestPage_automationpractice.com.Utilities
{
    internal class JsonHelper
    {
        private static Dictionary<string, string> _DataDictionary;
        private readonly static string SolutionPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private readonly static string ConfigPath = SolutionPath + @"\Config\config.json";

        /// <summary>
        /// Load Json parse to Dictionary<stirng,string>
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> LoadJson()
        {
            Dictionary<string, string> data;
            if (File.Exists(ConfigPath))
            {
                try
                {
                    //read file as string and deserialize Json to a type
                    data = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(ConfigPath));
                    _DataDictionary = data;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return _DataDictionary;
        }
        /// <summary>
        /// get value by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            return LoadJson()[key];
        }
    }
}
