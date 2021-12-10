using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xunit.DriverFactory.Utilities
{
    public class JsonHelper
    {
        private static Dictionary<string, string> _SaveData;
        private static Dictionary<string, string> _RawData;


        /// <summary>
        /// Load json and parse to dictionary
        /// </summary>
        /// <returns> Dictionary </returns>
        public static Dictionary<string, string> LoadJson(string path = @"\TestData\JsonData.json")
        {
            // check file exist or not
            if (File.Exists(DataConstant.BinPath + path))
            {
                try
                {
                    Dictionary<string, string> RawData = new();
                    Dictionary<string, string> SaveData = new();

                    // read file into a string and deserialize JSON to a type
                    Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(DataConstant.BinPath + path));
                    foreach (var e in data)
                    {
                        if (e.Key == "Email" || e.Key == "Password" || e.Key == "Firstname" 
                            || e.Key == "Lastname" || e.Key == "Gender" || e.Key == "Dob")
                        {
                            SaveData.Add(e.Key, e.Value);
                        }
                        else
                        {
                            RawData.Add(e.Key, e.Value);
                        }

                        _RawData = RawData;
                        _SaveData = SaveData;

                    }
                    return RawData;
                }
                catch (Exception)
                {
                    throw;
                } // end try-catch

            }
            return default;
        }

        /// <summary>
        /// Set value by key json
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <param name="path"></param>
        public static void SetValueByKeyJson(string value = null, string key = null, string path = @"\TestData\JsonData.json") => _SaveData[key] = value;

        /// <summary>
        /// Combine and save data
        /// </summary>
        /// <param name="path"></param>
        public static void SaveJson(string path = @"\TestData\JsonData.json")
        {
            Dictionary<string, string> result = _RawData.Concat(_SaveData).GroupBy(p => p.Key).ToDictionary(g => g.Key, g => g.Last().Value);

            String output = JsonConvert.SerializeObject(result, Formatting.Indented);

            File.WriteAllText(DataConstant.BinPath + path, output);
        }

        /// <summary>
        /// Get value by key in raw data
        /// </summary>
        /// <param name="key"></param>
        /// <returns> return string with key raw data </returns>
        public static string GetValueByKeyRawData(string key, string path = @"\Config\testhost.json")
        {
            LoadJson(path);
            return _RawData[key];
        }
        /// <summary>
        /// Get value by key in save data
        /// </summary>
        /// <param name="key"></param>
        /// <param name="path"></param>
        /// <returns> return string with key save data </returns>
        public static string GetValueByKeySavedData(string key, string path = @"\TestData\JsonData.json") => _SaveData[key];


    }
}
