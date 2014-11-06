using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public static class MutationStrategy
    {
        public static List<Chromossome> Swap(List<Chromossome> _offspring, List<Point> _points, double _probabilityMutation, Random _random)
        {
            List<Chromossome> mutants = new List<Chromossome>(_offspring);
            double dice;

            for(int i=0; i< mutants.Count();i++)
            {
                dice = _random.NextDouble();
                if (dice <= _probabilityMutation)
                    mutants[i] = new Chromossome(swapProcedure(mutants[i].Gene, _random), _points);
            }

            return mutants;
        }

        static List<int> swapProcedure(List<int> _offspring, Random _random)
        {
            List<int> mutant = new List<int>(_offspring);
            int t;

            List<int> dices = new List<int>();
            dices.Add(_random.Next(0, mutant.Count()));
            dices.Add(_random.Next(0, mutant.Count()));
            while (dices[0] == dices[1])
            {
                dices.Clear();
                dices.Add(_random.Next(0, mutant.Count()));
                dices.Add(_random.Next(0, mutant.Count()));
            }
            dices.Sort();

            t = mutant[dices[0]];
            mutant[dices[0]] = mutant[dices[1]];
            mutant[dices[1]] = t;
 
            return mutant;
        }
    }
}
