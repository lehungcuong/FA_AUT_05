using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace XunitPOM.Utilities
{
    public class JsonHelper
    {
        private readonly static string SolutionPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        private readonly static string configPath = SolutionPath + @"\Config\testhost.json";
        
        /// <summary>
        /// Load json and parse to dictionary
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> LoadJson()
        {
            // check file exist or not
            if (File.Exists(configPath))
            {

                try
                {
                    // read file into a string and deserialize JSON to a type
                    Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(configPath));
                    return data;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                } // end try-catch

            }
            return null;
        }

        /// <summary>
        /// Get value by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string getValue(string key) => LoadJson()[key];

    }
}
