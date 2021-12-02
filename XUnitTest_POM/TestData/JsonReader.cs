using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace XUnitTest_POM.Constraints
{
    public class JsonReader : DataAttribute
    {
        private readonly string _filePath;
        private readonly string name;

        /// <summary>
        /// Constructor of JsonReader
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="propertyName"></param>
        public JsonReader(string filePath, string propertyName = null)
        {
            _filePath = filePath;
            name = propertyName;
        }

        public JsonReader(string filePath) : this(filePath, propertyName: null) { }

        /// <summary>
        /// Read and return data from JsonFile
        /// </summary>
        /// <param name="testMethod"></param>
        /// <returns></returns>
        public override IEnumerable <object[]> GetData (MethodInfo testMethod)
        {
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), _filePath);
            var json = File.ReadAllText (jsonFilePath);
            var allData = JObject.Parse(json);
            var data = allData[name];
            return data.ToObject<List<object[]>> ();
        }
    }
}
