using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace QuyenLLP_FinalTest.Utilities
{
    public class ReadDataFromJson : DataAttribute
    {
        private readonly string filePath;
        private readonly string node;

        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="node"></param>
        public ReadDataFromJson(string filePath, string node = null)
        {
            this.filePath = filePath;
            this.node = node;
        }

        
        public ReadDataFromJson(string filePath) : this(filePath, node: null) { }

        /// <summary>
        /// Read all Data From Json
        /// </summary>
        /// <param name="filePath"></param>
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), filePath);
            var json = File.ReadAllText(jsonFilePath);
            var allData = JObject.Parse(json);
            var data = allData[node];
            return data.ToObject<List<object[]>>();
        }
    }
}
