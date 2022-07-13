using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Project1_Group_39
{
    /// <summary>
    /// class that will hold information about the city
    /// </summary>
    public class CityInfo
    {
        /*--------------------- Properties --------------------*/

        [JsonProperty("id")]
        public string CityID { get; set; }
        [JsonProperty("city")]
        public string CityName { get; set; }
        [JsonProperty("city_ascii")]
        public string CityAscii { get; set; }
        [JsonProperty("population")]
        public int Population { get; set; }
        [JsonProperty("admin_name")]
        public string Province { get; set; }
        [JsonProperty("lat")]
        public decimal Latitude { get; set; }
        [JsonProperty("lng")]
        public decimal Longitude { get; set; }

        // if city is capital then string = "admin" otherwise string = ""
        [JsonProperty("capital")]
        public string Capital { get; set; }

        /*--------------------- Constructors --------------------*/

        public CityInfo()
        {

        }

        /*--------------------- Methods --------------------*/

        public string GetProvince()
        {
            return Province;
        }

        public int GetPopulation()
        {
            return Population;
        }

        public string GetLocation()
        {
            return $"Latitude: {Latitude}\nLongitude: {Longitude}";
        }

        /*--------------------- Extra Methods --------------------*/

        public decimal GetLatitude()
        {
            return Latitude;
        }

        public decimal GetLongitude()
        {
            return Longitude;
        }
    }
}
