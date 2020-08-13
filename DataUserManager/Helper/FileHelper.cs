using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataUserManager.Helper
{
    class FileHelper
    {
        public static bool saveConfigFile(string nameDb,string nameDir,string path)
        {
            if (!File.Exists(path))
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
//          {
//              "nameDatabase" : "",
//	            "pathFile" : "",
//          }
            //neu file chua co du lieu
            string jsonString = JsonConvert.SerializeObject(new object { }, Formatting.Indented);

            using (var tw = new StreamWriter(path))
            {
                tw.WriteLine(jsonString);
                tw.Close();
            }
            return true;
        }
        public static bool readConfigFile(string path)
        {
            string jsonString = File.ReadAllText(path);
            JObject o = JObject.Parse(jsonString);
            return true;
        }
    }
}
