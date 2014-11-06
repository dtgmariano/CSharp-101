using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public static class CalculationStrategy
    {
        public static double routeDistance(List<Point> route)
        {
            double distance = 0.0;

            for (int i = 1; i < route.Count(); i++)
                distance += distanceBetweenPoints(route[i - 1], route[i]);

            distance += distanceBetweenPoints(route[route.Count() - 1], route[0]);

            return distance;
        }

        public static double routeDistance(List<int> _routeindex, List<Point> _points)
        {
            double distance = 0.0;
            List<Point> points = new List<Point>(_points);
            int idx1, idx2;

            for (int i = 1; i < _routeindex.Count(); i++)
            {
                idx1 = _routeindex[i - 1];
                idx2 = _routeindex[i];
                distance += distanceBetweenPoints(points[idx1], points[idx2]);
            }
            distance += distanceBetweenPoints(points[_routeindex[_routeindex.Count() - 1]], points[_routeindex[0]]);

            return distance;
        }

        public static double distanceBetweenPoints(Point A, Point B)
        {
            double distance = 0.0;
            distance = Math.Sqrt(Math.Pow(Math.Abs(A.coord_x - B.coord_x), 2) + Math.Pow(Math.Abs(A.coord_y - B.coord_y), 2));
            return distance;
        }

        public static Point getPoint(int _index, List<Point> _points)
        {
            Point point = _points[0];

            for(int i=0; i< _points.Count(); i++)
            {
                if (Convert.ToChar(_points[i].id) == _index)
                {
                    point = _points[i];
                    break;
                }
            }

            return point;
        }
    }
}
