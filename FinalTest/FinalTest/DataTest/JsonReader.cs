using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace FinalTest.DataTest
{
    public class JsonReader : DataAttribute
    {
        private readonly static string SolutionPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\DataTest\";
        private readonly string FilePath;
        private readonly string Node;

        public JsonReader(string fileName, string node)
        {
            FilePath = SolutionPath + fileName;
            Node = node;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var json = File.ReadAllText(FilePath);
            var allData = JObject.Parse(json);
            var data = allData[Node];
            return data.ToObject<List<object[]>>();
        }
    }
}
