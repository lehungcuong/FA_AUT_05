using Newtonsoft.Json;
using System;
using System.IO;

namespace LoiDV4_Final.Common
{
    public class ReadJSONConfig
    {
        static readonly string DirectoryPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        /// <summary>
        /// Get value from JSON file, return type JSONConfig
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static JSONConfig GetConfig(string path)
        {
            JSONConfig deserialized;
            string pathConfig = DirectoryPath + path;
            string output = File.ReadAllText(pathConfig);
            deserialized = JsonConvert.DeserializeObject<JSONConfig>(output);
            return deserialized;
        }
    }
}
