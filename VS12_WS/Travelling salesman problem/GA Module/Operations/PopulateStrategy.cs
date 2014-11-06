using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    static public class PopulateStrategy
    {
        public static List<Chromossome> populate(int _populationSize, List<Point> _points, Random _random)
        {
            List<Chromossome>  population = new List<Chromossome>();
            for (int i = 0; i < _populationSize; i++)
                population.Add(new Chromossome(_points, _random));
            return population;
        }
    }
}
