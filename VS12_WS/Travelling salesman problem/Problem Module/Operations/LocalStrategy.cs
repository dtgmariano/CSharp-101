using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public static class LocalStrategy
    {
        public static List<Point> genListPoints(int _numpoints, int _minRange, int _maxRange, Random _random)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < _numpoints; i++)
                points.Add(new Point(i, _minRange, _maxRange, _random));

            return points;
        }

        public static bool newPointIsValid(List<Point> points, Point newPoint)
        {
            bool isValid = false;
            /*method to be implemented*/
            return isValid;
        }
    }
}
