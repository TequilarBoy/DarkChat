using MaxMind.Db;
using MaxMind.GeoIP2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DarkChat.Helpers
{
    public static class GeoLocate
    {
        private static string dbCityPath = "./Data/GeoLite2-City.mmdb";

        public static string Locate(string strIP)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string cityResName = "DarkChat.Resources.GeoLite2-City.mmdb";

            // Create resource directory
            string dir = "./Data";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            // Release city information database
            if (!File.Exists(dbCityPath))
            {
                using (Stream stream = assembly.GetManifestResourceStream(cityResName))
                {
                    if (null != stream)
                    {
                        using (FileStream fs = new FileStream(dbCityPath, FileMode.Create))
                        {
                            stream.CopyTo(fs);
                        }
                    }
                }
            }

            // Query corresponding city of IP
            string result = "Unknown";
            try
            {
                using (var reader = new DatabaseReader(dbCityPath))
                {
                    var city = reader.City(strIP);
                    result = $"{city.Country.Name} {city.MostSpecificSubdivision.Name}";
                }
            }
            catch (Exception ex)
            {

            }
            

            return result;
        }
    }
}
