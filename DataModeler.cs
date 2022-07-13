using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Group_39
{
    /// <summary>
    /// class that will parse the data files
    /// </summary>
    public class DataModeler
    {
        /*--------------------- Fields --------------------*/

        private Dictionary<string, List<CityInfo>> ParsedData = new Dictionary<string, List<CityInfo>>();

        /*--------------------- Customized delegate --------------------*/

        public delegate void ParseMethodHandler(string fileName);

        /*--------------------- Methods --------------------*/

        public void ParseXML(string fileName)
        {

        }

        public void ParseJSON(string fileName)
        {
            string jsonString = File.ReadAllText($"Data\\{fileName}");
            List<CityInfo> cityInfoList = new List<CityInfo>(JsonConvert.DeserializeObject<List<CityInfo>>(jsonString));
            foreach (CityInfo city in cityInfoList)
            {
                // if found an empty data entry
                if (city.CityName == "")
                {
                    // skip this entry and go to the next iteration of the loop
                    continue;
                }
                // if found a city with the same name
                else if (ParsedData.ContainsKey(city.CityName))
                {
                    ParsedData[city.CityName].Add(city);
                }
                // found a city with a unique name
                else
                {
                    List<CityInfo> list = new List<CityInfo>();
                    list.Add(city);
                    ParsedData.Add(city.CityName, list);
                }
            }
        }

        public void ParseCSV(string fileName)
        {

        }

        public Dictionary<string, List<CityInfo>> ParseFile(string fileName, string fileType)
        {
            ParseMethodHandler parseMethodHandler;

            switch (fileType)
            {
                case "xml":
                    parseMethodHandler = ParseXML;
                    parseMethodHandler(fileName);
                    return ParsedData;
                case "json":
                    parseMethodHandler = ParseJSON;
                    parseMethodHandler(fileName);
                    return ParsedData;
                case "csv":
                    parseMethodHandler = ParseCSV;
                    parseMethodHandler(fileName);
                    return ParsedData;
                default:
                    throw new ArgumentException("Error: Invalid file type");
            }
        }
    }
}
