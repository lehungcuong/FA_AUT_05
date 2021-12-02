using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace XunitPOM.Utilities
{
    public class JsonHelper
    {
        private static readonly string SolutionPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private static readonly string ConfigPath = SolutionPath + @"\Config\testhost.json";

        /// <summary>
        /// Load json and parse to dictionary
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string>? LoadJson()
        {
            // check file exist or not
            if (File.Exists(ConfigPath))
            {
                try
                {
                    // read file into a string and deserialize JSON to a type
                    Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(ConfigPath));
                    return data;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                } // end try-catch

            }
            return default;
        }

        /// <summary>
        /// Get value by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string getValue(string key) => LoadJson()[key];

    }
}
