using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace LoiDV4_Final.Common
{
    public class JSONReader : DataAttribute
    {
        private readonly string _filePath;
        private readonly string _node;

        public JSONReader(string filePath, string node)
        {
            _filePath = filePath;
            _node = node;
        }

        public JSONReader(string filePath) : this(filePath, null) { }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), _filePath);

            var json = File.ReadAllText(jsonFilePath);

            var allData = JObject.Parse(json);

            var data = allData[_node];

            return data.ToObject<List<object[]>>();
        }
    }
}
