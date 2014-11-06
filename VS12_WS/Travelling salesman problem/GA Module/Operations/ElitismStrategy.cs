using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    static public class ElitismStrategy
    {
        public static List<Chromossome> basicElitism(List<Chromossome> _population, int _elitismSize)
        {
            List<Chromossome> population = new List<Chromossome>(_population);
            List<double> populationFitness = new List<double>();

            foreach(Chromossome c in population)
                populationFitness.Add(c.Fitness);

            Array acandidates = population.ToArray();
            Array acandidates_fitness = populationFitness.ToArray();
            Array.Sort(acandidates_fitness, acandidates);

            population = acandidates.OfType<Chromossome>().ToList();
            population.Reverse();
            population.RemoveRange(_elitismSize, population.Count() - _elitismSize);

            return population;
        }
    }
}
