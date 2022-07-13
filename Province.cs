using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Group_39
{
    internal class Province
    {
        public string ProvinceName { get; set; }
        public List<CityInfo> Cities { get; set; }
        public int TotalPopulation { get; set; }
        public int TotalCities { get; set; }
        public CityInfo CapitalCity { get; set; }

        public Province(string provinceName, List<CityInfo> cities)
        {
            ProvinceName = provinceName;
            Cities = cities;
            TotalCities = cities.Count;
            TotalPopulation = CalculateTotalPopulation();
            CapitalCity = FindCapitalCity();
        }

        private int CalculateTotalPopulation()
        {
            int totalPopulation = 0;

            foreach(CityInfo city in Cities)
            {
                totalPopulation += city.Population;
            }

            return totalPopulation;
        }

        private CityInfo FindCapitalCity()
        {
            CityInfo capitalCity = new CityInfo();
            foreach(CityInfo city in Cities)
            {
                if(city.Capital == "admin")
                {
                    capitalCity = city;
                    break;
                }
            }
            return capitalCity;
        }


    }
}
