using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace Project1_Group_39
{
    class Program
    {
        static void Main(string[] args)
        {
            Statistics statistics = new Statistics("Canadacities-JSON.json", "json");

            try
            {
                string cityName = "Deer Lake";
                string province = "New Brunswick";
                string city1 = "Deer Lake"; // refers to Deer Lake, Newfoundland and Labrador OR Deer Lake, Ontario
                string city2 = "Windsor"; // refers to Windsor, Nova Scotia OR Windsor, Ontario 
                string city3 = "Thompson";
                string city4 = "Amos";

                Console.WriteLine($"Display city information for {cityName}:\n");
                Console.WriteLine(statistics.DisplayCityInformation(cityName));

                Console.WriteLine($"\nDisplay largest population city in {province}: {statistics.DisplayLargestPopulationCity(province)}");
                Console.WriteLine($"\nDisplay smallest population city in {province}: {statistics.DisplaySmallestPopulationCity(province)}\n");

                Console.WriteLine($"\nResult of the method CompareCitiesPopulation({city1}, {city2}):\n");
                Console.WriteLine(statistics.CompareCitiesPopulation(city1, city2));

                Console.WriteLine($"\n\nResult of the method CompareCitiesPopulation({city2}, {city3}):\n");
                Console.WriteLine(statistics.CompareCitiesPopulation(city2, city3));

                Console.WriteLine($"\n\nResult of the method CompareCitiesPopulation({city3}, {city4}):\n");
                Console.WriteLine(statistics.CompareCitiesPopulation(city3, city4));

                Console.WriteLine($"\n\nThe population of {province} is {statistics.DisplayProvincePopulation(province)} people");

                List<CityInfo> provinceCities = statistics.DisplayProvinceCities(province);
                Console.WriteLine($"\nThe cities of {province} are:\n");

                foreach(CityInfo city in provinceCities)
                {
                    Console.WriteLine($"{city.CityName}\n");
                }

                Console.WriteLine($"\nProvinces sorted by population in ascending order:\n");
                Console.WriteLine(statistics.RankProvincesByPopulation());

                Console.WriteLine($"\nProvinces sorted by number of cities in ascending order:\n");
                Console.WriteLine(statistics.RankProvincesByCities());

                Console.WriteLine(statistics.GetCapital(province));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nPrint province catalogue:\n");
            statistics.PrintProvinceCatalogue();

            //DataModeler dataModeler = new DataModeler();
            //Dictionary<string, List<CityInfo>> cityInfoDictionary = new Dictionary<string, List<CityInfo>>();
            //cityInfoDictionary = dataModeler.ParseFile("Canadacities-JSON.json", "json");

                //int duplicatedCityNameCount = 0;
                //int capitalCitiesCount = 0;
                //int count;

                //Console.WriteLine("Print Dictionary<string, List<CityInfo>> ordered by city name:\n");
                //foreach (KeyValuePair<string, List<CityInfo>> city in cityInfoDictionary.OrderBy(c => c.Key))
                //{
                //    // if found a city that have a name that is shared by another city
                //    if (city.Value.Count > 1)
                //    {
                //        duplicatedCityNameCount++;
                //        count = 1;
                //        Console.WriteLine("****************************************************** Found a city that have a name that is shared by another city! ******************************************************\n");
                //        foreach (CityInfo c in city.Value)
                //        {
                //            Console.WriteLine($"Entry #{count}:\n");

                //            if(c.Capital == "admin")
                //            {
                //                capitalCitiesCount++;
                //                Console.WriteLine($"{c.CityName} is the capital city of {c.Province} ##################################################################################\n");
                //            }

                //            Console.WriteLine("CityName = " + c.CityName);
                //            Console.WriteLine("CityAscii = " + c.CityAscii);
                //            Console.WriteLine("Population = " + c.Population);
                //            Console.WriteLine("Province = " + c.Province);
                //            Console.WriteLine("Latitude = " + c.Latitude);
                //            Console.WriteLine("Longitude = " + c.Longitude);
                //            Console.WriteLine("Capital = " + c.Capital);
                //            Console.WriteLine("CityId = " + c.CityID);
                //            Console.WriteLine();
                //            count++;
                //        }
                //        Console.WriteLine("***************************************************************************************************************************************************************************\n");
                //        count = 1;
                //    }
                //    // found a city with a unique name
                //    else
                //    {
                //        if (city.Value[0].Capital == "admin")
                //        {
                //            capitalCitiesCount++;
                //            Console.WriteLine($"{city.Value[0].CityName} is the capital city of {city.Value[0].Province} ##################################################################################\n");
                //        }

                //        Console.WriteLine("CityName = " + city.Value[0].CityName);
                //        Console.WriteLine("CityAscii = " + city.Value[0].CityAscii);
                //        Console.WriteLine("Population = " + city.Value[0].Population);
                //        Console.WriteLine("Province = " + city.Value[0].Province);
                //        Console.WriteLine("Latitude = " + city.Value[0].Latitude);
                //        Console.WriteLine("Longitude = " + city.Value[0].Longitude);
                //        Console.WriteLine("Capital = " + city.Value[0].Capital);
                //        Console.WriteLine("CityId = " + city.Value[0].CityID);
                //        Console.WriteLine();
                //    }
                //}

                //Console.WriteLine($"There are {duplicatedCityNameCount} city names that have at least one other city sharing the same name.");
                //Console.WriteLine($"There are {capitalCitiesCount} capital cities in Canada.");
        }
    }
}
