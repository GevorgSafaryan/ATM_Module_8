using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions_And_JS.Utils
{
    public static class JsonConvertor
    {
        public static TestData GetTestData()
        {
            if (File.Exists(@"D:\ATM_Module_7\POM_Implementation\Utils\TestData.json"))
            {
                string data = File.ReadAllText(@"D:\ATM_Module_7\POM_Implementation\Utils\TestData.json");
                return JsonConvert.DeserializeObject<TestData>(data);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
