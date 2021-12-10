using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace LuanNHB_Final.DataTest
{
    public class JsonReader : DataAttribute
    {

        private readonly string Node;
        private readonly string FilePath;
        private readonly static string pathFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\DataTest\";
        //D:\fpt train\aut\AutoMationTest\HomeWork\Page_PhpTavels_POM\DataTest\DataTest.json

        public JsonReader(string fileName, string node)
        {
            FilePath = Path.Combine(pathFolder, fileName);
            Node = node;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var Data = JObject.Parse(File.ReadAllText(FilePath));
            var DataByNode = Data[Node];
            return DataByNode.ToObject<List<object[]>>();

        }

        public void WriteDataToJson(string pathfile, string fileName, Dictionary<String, string> data)
        {
            string json = JsonConvert.SerializeObject(data);
            string DATA_FILENAME = Path.Combine(pathfile, fileName);
            using (FileStream fileStream = new FileStream(DATA_FILENAME, FileMode.Create, FileAccess.Write, FileShare.Read))
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.WriteLine(json);
            }
        }

    }
}
