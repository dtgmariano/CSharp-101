using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public static class CrossoverStrategy
    {
        public static List<Chromossome> PMX(List<Chromossome> _parents, List<Point> _points, double _crossoverProbability, Random _random)
        {
            List<Chromossome> offsprings = new List<Chromossome>();

            List<int> parent1, parent2;
            List<int> offspring1, offspring2;
            List<int> cutoffPoints = new List<int>();
            double dice;

            /*In case the number of parents is an odd number, one parent will be left alone. 
             * In this case an exception handling is performed.*/
            if (_parents.Count % 2 != 0)
            {
                offsprings.Add(_parents[_parents.Count()]);
                _parents.RemoveAt(_parents.Count());
            }

            for(int i=0; i<(_parents.Count/2); i++)
            {
                dice = _random.NextDouble();

                if (dice <= _crossoverProbability)
                {
                    cutoffPoints.Clear();
                    cutoffPoints.Add(_random.Next(0, _parents[2 * i].Gene.Count()));
                    cutoffPoints.Add(_random.Next(0, _parents[2 * i].Gene.Count()));
                    while (cutoffPoints[0] == cutoffPoints[1])
                    {
                        cutoffPoints.Clear();
                        cutoffPoints.Add(_random.Next(0, _parents[2 * i].Gene.Count()));
                        cutoffPoints.Add(_random.Next(0, _parents[2 * i].Gene.Count()));
                    }
                    cutoffPoints.Sort();

                    parent1 = _parents[2 * i].Gene;
                    parent2 = _parents[2 * i + 1].Gene;

                    offspring1 = pmxProcedure(parent1, parent2, cutoffPoints[0], cutoffPoints[1]);
                    offspring2 = pmxProcedure(parent2, parent1, cutoffPoints[0], cutoffPoints[1]);

                    offsprings.Add(new Chromossome(offspring1, _points));
                    offsprings.Add(new Chromossome(offspring2, _points));
                }
                else
                {
                    offsprings.Add(_parents[2 * i]);
                    offsprings.Add(_parents[2 * i + 1]);
                }
            }
            return offsprings;
        }
        
        static List<int> pmxProcedure(List<int> _parent1, List<int> _parent2, int _cutoff1, int _cutoff2)
        {
            List<int> child = new List<int>();
            List<int> swath_p1;

            /*Step 1: Randomly select a swath of alleles from parent 1 
             * and copy them directly to the child. Note the indexes of the segment.*/
            swath_p1 = _parent1.GetRange(_cutoff1, _cutoff2 - _cutoff1 + 1);

            /*Organizes child alleles. The ones that are out of the cutoff zone, receives '*' */
            for (int i = 0; i < _cutoff1; i++)
                child.Add('*');
            child.AddRange(swath_p1);
            for (int i = _cutoff2 + 1; i < _parent1.Count(); i++)
                child.Add('*');

            /*Step 2: Looking in the same segment positions in parent 2, 
             * select each value that hasn't already been copied to the child.*/
            for (int i = _cutoff1; i < _cutoff2 + 1; i++)
            {
                int v, valuetoinsert;
                int idx_at_p2;

                /*For each of these values*/
                if (isItemRepeated(_parent2[i], child) == false)
                {
                    /*Note the index of this value (parent2[i]) in Parent 2. Locate the value, V, 
                     * from parent 1 in this same position. Locate this same value in parent 2.*/
                    valuetoinsert = _parent2[i];
                    v = _parent1[i];
                    idx_at_p2 = getIndex(v, _parent2);

                    while (is_part_of_the_original_swath(idx_at_p2, _cutoff1, _cutoff2) == true)
                    {
                        v = _parent1[idx_at_p2];
                        idx_at_p2 = getIndex(v, _parent2);
                    }

                    child[idx_at_p2] = valuetoinsert;
                    /*If the index of this value in Parent 2 is part of the original swath, 
                     * go to step i. using this value.*/

                    /*If the position isn't part of the original swath, 
                     * insert Step A's value into the child in this position.*/
                }
            }

            /*6. Now the easy part, we've taken care of all swath values, 
             * so everything else from Parent 2 drops down to the child.*/
            for (int i = 0; i < child.Count(); i++)
            {
                if (child[i] == '*')
                    child[i] = _parent2[i];
            }

            return child;
        }

        public static int getIndex(int item, List<int> list)
        {
            int index = 0;
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i] == item)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public static bool isItemRepeated(int item, List<int> list)
        {
            bool answer = false;
            foreach (int i in list)
            {
                if (i == item)
                {
                    answer = true;
                    break;
                }
            }
            return answer;
        }

        public static bool is_part_of_the_original_swath(int index, int cutoff1, int cutoff2)
        {
            bool answer;

            if (index >= cutoff1 && index <= cutoff2)
                answer = true;
            else
                answer = false;

            return answer;
        }
    }
}
