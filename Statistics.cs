using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Group_39
{
    public class Statistics
    {
        /*--------------------- Fields --------------------*/

        // string = province 
        private Dictionary<string, List<CityInfo>> provinceCatalogue = new Dictionary<string, List<CityInfo>>();
        private List<Province> provinces = new List<Province>();

        /*--------------------- Properties --------------------*/

        // string = city name
        public Dictionary<string, List<CityInfo>> CityCatalogue { get; set; }

        /*--------------------- Constructors --------------------*/

        public Statistics(string fileName, string fileType)
        {
            DataModeler dataModeler = new DataModeler();
            CityCatalogue = dataModeler.ParseFile(fileName, fileType);
            provinceCatalogue = CreateProvinceCatalogueFromCityCatalogue();
            provinces = PopulateProvinceObjectsList();
        }

        /*--------------------- City's methods --------------------*/

        public string DisplayCityInformation(string cityName)
        {
            string cityInformation = "";
            if (CityCatalogue.ContainsKey(cityName))
            {
                // if city have a name that is shared by another city
                if (CityCatalogue[cityName].Count > 1)
                {
                    foreach (CityInfo city in CityCatalogue[cityName])
                    {

                        cityInformation += ($"CityName = {city.CityName}\n"
                        + $"CityAscii = {city.CityAscii}\n"
                        + $"Population = {city.Population}\n"
                        + $"Province = {city.Province}\n"
                        + $"Latitude = {city.Latitude}\n"
                        + $"Longitude = {city.Longitude}\n");

                        // if city is a capital
                        if (city.Capital == "admin")
                        {
                            cityInformation += "Capital = Yes\n";
                        }
                        // city is not a capital
                        else if (city.Capital == "")
                        {
                            cityInformation += "Capital = No\n";
                        }

                        cityInformation += $"CityId = {city.CityID}\n\n";
                    }
                }
                // city have a unique name
                else
                {
                    cityInformation += ($"CityName = {CityCatalogue[cityName][0].CityName}\n"
                    + $"CityAscii = {CityCatalogue[cityName][0].CityAscii}\n"
                    + $"Population = {CityCatalogue[cityName][0].Population}\n"
                    + $"Province = {CityCatalogue[cityName][0].Province}\n"
                    + $"Latitude = {CityCatalogue[cityName][0].Latitude}\n"
                    + $"Longitude = {CityCatalogue[cityName][0].Longitude}\n");

                    // if city is a capital
                    if (CityCatalogue[cityName][0].Capital == "admin")
                    {
                        cityInformation += "Capital = Yes\n";
                    }
                    // city is not a capital
                    else if (CityCatalogue[cityName][0].Capital == "")
                    {
                        cityInformation += "Capital = No\n";
                    }

                    cityInformation += $"CityId = {CityCatalogue[cityName][0].CityID}";
                }
                cityInformation = cityInformation.TrimEnd('\n');
                return cityInformation;
            }
            else
            {
                throw new ArgumentException($"Error: {cityName} could not be found in the city catalogue");
            }
        } // end DisplayCityInformation method

        public string DisplayLargestPopulationCity(string province)
        {
            if (provinceCatalogue.ContainsKey(province))
            {
                string largestPopulationCity = provinceCatalogue[province][0].CityName;
                int largestPopulation = provinceCatalogue[province][0].Population;

                for (int i = 1; i < provinceCatalogue[province].Count; i++)
                {
                    if (provinceCatalogue[province][i].Population > largestPopulation)
                    {
                        largestPopulationCity = provinceCatalogue[province][i].CityName;
                        largestPopulation = provinceCatalogue[province][i].Population;
                    }
                }
                return largestPopulationCity;
            }
            else
            {
                throw new ArgumentException($"Error: {province} could not be found in the city catalogue");
            }
        } // end DisplayLargestPopulationCity method

        public string DisplaySmallestPopulationCity(string province)
        {
            if (provinceCatalogue.ContainsKey(province))
            {
                string smallestPopulationCity = provinceCatalogue[province][0].CityName;
                int smallestPopulation = provinceCatalogue[province][0].Population;

                for (int i = 1; i < provinceCatalogue[province].Count; i++)
                {
                    if (provinceCatalogue[province][i].Population < smallestPopulation)
                    {
                        smallestPopulationCity = provinceCatalogue[province][i].CityName;
                        smallestPopulation = provinceCatalogue[province][i].Population;
                    }
                }
                return smallestPopulationCity;
            }
            else
            {
                throw new ArgumentException($"Error: {province} could not be found in the city catalogue");
            }
        } // end DisplaySmallestPopulationCity method

        public string CompareCitiesPopulation(string city1, string city2)
        {
            if(CityCatalogue.ContainsKey(city1) && CityCatalogue.ContainsKey(city2))
            {
                string result = "";

                for(int i = 0; i < CityCatalogue[city1].Count; i++)
                {
                    for(int j = 0; j < CityCatalogue[city2].Count; j++)
                    {
                        if(CityCatalogue[city1][i].Population > CityCatalogue[city2][j].Population)
                        {
                            result += $"\n{city1}, {CityCatalogue[city1][i].Province} has a larger population than {city2}, {CityCatalogue[city2][j].Province}" +
                                $" with a population of {CityCatalogue[city1][i].Population}\n";
                        }
                        else if(CityCatalogue[city1][i].Population < CityCatalogue[city2][j].Population)
                        {
                            result += $"\n{city2}, {CityCatalogue[city2][j].Province} has a larger population than {city1}, {CityCatalogue[city1][i].Province}" +
                                $" with a population of {CityCatalogue[city2][j].Population}\n";
                        }
                    }
                }
                result = result.TrimStart('\n');
                result = result.TrimEnd('\n');
                return result;
            }
            else
            {
                throw new ArgumentException($"Error: Could not compare {city1} and {city2} because either one or both of them could not be found in the city catalogue");
            }
        } // end CompareCitiesPopulation method

        // Implement ShowCityOnMap(string cityName, string province) method here

        // Implement CalculateDistanceBetweenCities(string city1, string city2) method here

        /*--------------------- Province's methods --------------------*/

        public int DisplayProvincePopulation(string province)
        {
            if (provinceCatalogue.ContainsKey(province))
            {
                Province prov = provinces.Find(p => p.ProvinceName == province);
                return prov.TotalPopulation;
            }
            else
            {
                throw new ArgumentException($"Error: {province} could not be found in the city catalogue");
            }
        } // end DisplayProvincePopulation method

        public List<CityInfo> DisplayProvinceCities(string province)
        {
            if (provinceCatalogue.ContainsKey(province))
            {
                Province prov = provinces.Find(p => p.ProvinceName == province);
                return prov.Cities;
            }
            else
            {
                throw new ArgumentException($"Error: {province} could not be found in the city catalogue");
            }
        } // end DisplayProvinceCities method

        public string RankProvincesByPopulation()
        {
            string ranking = "";
            int count = 1;

            foreach(Province province in provinces.OrderBy(p => p.TotalPopulation))
            {
                ranking += $"{count}) {province.ProvinceName} with a population of {province.TotalPopulation} people.\n";
                count++;
            }

            return ranking;
        } // end RankProvincesByPopulation method

        public string RankProvincesByCities()
        {
            string ranking = "";
            int count = 1;

            foreach (Province province in provinces.OrderBy(p => p.TotalCities))
            {
                ranking += $"{count}) {province.ProvinceName} with a total of {province.TotalCities} cities.\n";
                count++;
            }

            return ranking;
        } // end RankProvincesByCities method

        public string GetCapital(string province)
        {
            if (provinceCatalogue.ContainsKey(province))
            {
                string capitalCityInfo = "";
                Province prov = provinces.Find(p => p.ProvinceName == province);
                capitalCityInfo += $"The capital of {province} is {prov.CapitalCity.CityName} " +
                    $"with a latitude of {prov.CapitalCity.Latitude} and the longitude of {prov.CapitalCity.Longitude}.";
                return capitalCityInfo;
            }
            else
            {
                throw new ArgumentException($"Error: {province} could not be found in the city catalogue");
            }
        } // end GetCapital method

        /*--------------------- Extra methods --------------------*/

        private Dictionary<string, List<CityInfo>> CreateProvinceCatalogueFromCityCatalogue()
        {
            Dictionary<string, List<CityInfo>> provinceCityCatalogue = new Dictionary<string, List<CityInfo>>();

            foreach (KeyValuePair<string, List<CityInfo>> city in CityCatalogue)
            {
                // if found a city that have a name that is shared by another city
                if (city.Value.Count > 1)
                {
                    foreach (CityInfo c in city.Value)
                    {
                        // if province already found in ProvinceCatalogue
                        if (provinceCityCatalogue.ContainsKey(c.Province))
                        {
                            // add to the pre-existing list
                            provinceCityCatalogue[c.Province].Add(c);
                        }
                        // create a new key value pair for new province entry
                        else
                        {
                            List<CityInfo> list = new List<CityInfo>();
                            list.Add(c);
                            provinceCityCatalogue.Add(c.Province, list);
                        }
                    }
                }
                // found a city with a unique name
                else
                {
                    // if province already found in ProvinceCatalogue
                    if (provinceCityCatalogue.ContainsKey(city.Value[0].Province))
                    {
                        // add to the pre-existing list
                        provinceCityCatalogue[city.Value[0].Province].Add(city.Value[0]);
                    }
                    // create a new key value pair for new province entry
                    else
                    {
                        List<CityInfo> list = new List<CityInfo>();
                        list.Add(city.Value[0]);
                        provinceCityCatalogue.Add(city.Value[0].Province, list);
                    }
                }
            }
            return provinceCityCatalogue;
        } // end CreateProvinceCatalogueFromCityCatalogue method

        private List<Province> PopulateProvinceObjectsList()
        {
            List<Province> provincesList = new List<Province>();
            foreach (KeyValuePair<string, List<CityInfo>> p in provinceCatalogue)
            {
                Province province = new Province(p.Key, p.Value);
                provincesList.Add(province);
            }
            return provincesList;
        } // end PopulateProvinceObjectsList method

        // temporary method to check what's stored in private field provinceCatalogue
        // delete this method once project is completed!
        public void PrintProvinceCatalogue()
        {
            foreach (KeyValuePair<string, List<CityInfo>> province in provinceCatalogue.OrderBy(keyValuePair => keyValuePair.Key))
            {
                Console.WriteLine($"{province.Key} contains the following {province.Value.Count} cities:\n");

                foreach (CityInfo city in province.Value.OrderBy(c => c.CityName))
                {
                    Console.WriteLine($"CityName = {city.CityName}\n"
                    + $"CityAscii = {city.CityAscii}\n"
                    + $"Population = {city.Population}\n"
                    + $"Province = {city.Province}\n"
                    + $"Latitude = {city.Latitude}\n"
                    + $"Longitude = {city.Longitude}");

                    // if city is a capital
                    if (city.Capital == "admin")
                    {
                        Console.WriteLine("Capital = Yes");
                    }
                    // city is not a capital
                    else if (city.Capital == "")
                    {
                        Console.WriteLine("Capital = No");
                    }

                    Console.WriteLine($"CityId = {city.CityID}\n");
                }
            }
        } // end PrintProvinceCatalogue method
    }
}
