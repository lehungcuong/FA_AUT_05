using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;


namespace TestPOM
{
    public class JsonReader : DataAttribute
    {
        
        private readonly string key;

      // key in file Json
        public JsonReader( string propertyName = null)
        {
           
            key = propertyName;
        }

        
        public override IEnumerable <object[]> GetData (MethodInfo testMethod)
        {
            // path file
            var jsonFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string fullPathfile = jsonFilePath + @"\ReadInformationUserByJson.json";
            var json = File.ReadAllText (fullPathfile);
            var allData = JObject.Parse(json);
            //read data in key
            var data = allData[key];
            return data.ToObject<List<object[]>>();
        }
    }
}
