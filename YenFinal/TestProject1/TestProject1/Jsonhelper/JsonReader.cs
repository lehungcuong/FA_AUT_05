using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace TestProject1.Test
{
    public class JsonReader : DataAttribute
    {
        private readonly string _filePath;
        private readonly string _node;
        public JsonReader(string filePath, string propertyName)
        {
            _filePath = filePath;
            _node = propertyName;
        }

        public JsonReader(string filePath) : this(filePath, propertyName: null) { }


        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            //Debug-bin-testproject1-Test-jsconfig.json
            var jsonFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + _filePath;

            var json = File.ReadAllText(jsonFilePath);

            var allData = JObject.Parse(json);

            var data = allData[_node];

            return data.ToObject<List<object[]>>();
        }
    }
}
