using System;
using System.IO;
using Newtonsoft.Json;

namespace PageObjectModel.Utilities
{
    
    public class JsonHelper
    {
        public JsonHelper()
        {
        }
        public void ReadDataJson()
        {

            using (var stream = File.OpenRead("Config.Json"))
            {
                var reader = new StreamReader(stream);
                var serializer = new JsonSerializer();
                var readDataJson = serializer.Deserialize(reader, typeof(String));
            }
        }

        
    }
   
  
}
