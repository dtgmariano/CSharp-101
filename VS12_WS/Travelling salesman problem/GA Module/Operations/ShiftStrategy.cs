using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public static class ShiftStrategy
    {
        public static List<Chromossome> shiftGeneration(List<Chromossome> _elite, List<Chromossome> _children)
        {
            List<Chromossome> population = new List<Chromossome>(_elite);
            population.AddRange(_children);
            return population;
        }
    }
}
