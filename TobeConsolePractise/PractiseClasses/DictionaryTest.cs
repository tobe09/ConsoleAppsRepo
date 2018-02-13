using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class DictionaryTest
    {
        dynamic dic = new Dictionary<string, dynamic>();

        public dynamic dicMethod()
        {
            dic["name"] = "Weather";
            dynamic mains = new Dictionary<string, string>();
            mains.Add("main", "hot");
            dynamic secondary = new Dictionary<string, string>();
            secondary.Add("secondary", "not very hot though");
            dic["weather"] = new dynamic[2];
            dic["weather"][0] = mains;
            dic["weather"][1] = secondary;
            Console.WriteLine(dic);
            return dic;
        }

        public static async Task<dynamic> objMethod()
        {
            dynamic obj = new
            {
                name = "Weather1",
                main = new { temp = "30 degrees", humidity = "10 %" },
                wind = new { speed = 40 },
                weather = new dynamic[] { new { main = "hot" }, new { secondary = "not very hot though" } },
                sys = new { sunrise = "7am", sunset = "7pm" }
            };
            return await obj;
        }

        public static int run()
        {
            Console.WriteLine("Dictionary test\n");
            Dictionary<string, dynamic> dic = new DictionaryTest().dicMethod();
            Console.WriteLine("Name: " + dic["name"]);
            Console.WriteLine("Main weather: " + dic["weather"][0]["main"]);
            Console.WriteLine("secondary weather: " + dic["weather"][1]["secondary"]);
            Console.WriteLine("\n\nC# Objects test\n");
            dynamic obj = objMethod().Result;
            Console.WriteLine("Name: " + obj.name);
            Console.WriteLine("Humidity: " + obj.main.humidity);
            Console.WriteLine("Name: " + obj.wind.speed);
            Console.WriteLine("Name: " + obj.weather[1].secondary);
            Console.ReadKey();
            return 1;
        }
    }
}
