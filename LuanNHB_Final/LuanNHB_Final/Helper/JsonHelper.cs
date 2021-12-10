using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LuanNHB_Final.Helper
{
    public class JsonHelper
    {
        private Dictionary<string, string> Data;

        /// <summary>
        /// The data filename,
        /// </summary>
        private readonly static string DATA_FILENAME = Directory.GetCurrentDirectory() + @"\Config\jsconfig1.json";
        // private const string DATA_FILENAME = @"D:\fpt train\aut\AutoMationTest\HomeWork\Page_PhpTavels_POM\Config\jsconfig1.json";
        /// <summary>
        /// get data from Json file
        /// </summary>
        /// <returns> Dictionary </returns>
        private Dictionary<string, string> LoadJsonFile()
        {
            try
            {

                string json = File.ReadAllText(DATA_FILENAME);
                Dictionary<string, string> json_Dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                Data = json_Dictionary;
                // string abc= JsonSerializer.Serialize(json_Dictionary);

                return Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Data;
        }
        /// <summary>
        /// Get Value By Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            LoadJsonFile();
            return Data[key];
        }

    }
}
