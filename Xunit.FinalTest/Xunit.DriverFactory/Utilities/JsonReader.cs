using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Xunit.DriverFactory.Utilities
{
    public class JsonReader : DataAttribute
    {
        private readonly string FilePath;
        private readonly string Node;
        public JsonReader(string fileName, string node)
        {
            FilePath = Path.Combine(DataConstant.BinPath + @"\TestData\", fileName);
            Node = node;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            // Load file
            var fileData = File.ReadAllText(FilePath);

            var allData = JObject.Parse(fileData);

            var data = allData[Node];

            return data.ToObject<List<object[]>>();
        }
    }
}
