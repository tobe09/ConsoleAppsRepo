using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class Conversions
    {
        /// <summary>
        /// AsEnumerable, AsQueryable, Cast(Applicable), OfType, ToArray, ToDictionary, ToList, ToLookup (others are not applicable)
        /// Concatenation: Concat (not applicable)
        /// Aggregation: Aggregate, Average, Count, LonCount, Max, Min, Sum (All are not applicable)
        /// Quantifier: All, Any, Contains (All are not applicable)
        /// Partition: Skip, SkipWhile, Take, TakeWhile (All are not applicable)
        /// Generation: DefaultIfEmpty, Empty, Range, Repeat (All are not applicable)
        /// Set: Distinct, Except, Intersect, Union (All are not applicable)
        /// Equality: SequenceEqual (not applicable)
        /// Element: ElementAt, ElementAtOrDefault, First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault, DefaultIfEmpty (All are not applicable)
        /// </summary>
        public static void Run()
        {
            Plant[] plants = { new CarnivorousPlant { Name = "Plant1", TrapType = "Trap1" },
                            new CarnivorousPlant { Name = "Plant2", TrapType = "T2" },
                            new CarnivorousPlant { Name = "Plant3", TrapType = "Trap3" }};

            IEnumerable<CarnivorousPlant> query = from CarnivorousPlant cPlant in plants
                                                  where cPlant.TrapType.Length > 2
                                                  select cPlant;

            foreach (var p in query)
                Console.WriteLine("Name: {0}, TrapType: {1}", p.Name, p.TrapType);
            
            Plant[] plants2 = { new CarnivorousPlant { Name = "2Plant1", TrapType = "2Trap1" },
                            new CarnivorousPlant { Name = "2Plant2", TrapType = "2T2" },
                            new CarnivorousPlant { Name = "2Plant3", TrapType = "2Trap3" }};

            IEnumerable<string> query2 = plants.Select(p => "TrapType1: " + ((CarnivorousPlant)p).TrapType).Concat(plants2.Select(p => " Name2: " + ((CarnivorousPlant)p).Name));

            foreach (string str in query2)
                Console.WriteLine(str);

            List<Plant> plants3 = new List<Plant>();
            //plants3.Add(new Plant { Name = "plant31" });
            IEnumerable<Plant> test = plants3.DefaultIfEmpty();

            Console.ReadKey();
        }

        class Plant
        {
            public string Name { get; set; }
        }
        class CarnivorousPlant : Plant
        {
            public string TrapType { get; set; }
        }
    }
}
