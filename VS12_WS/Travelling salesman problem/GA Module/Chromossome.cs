using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GA
{
    public class Chromossome
    {
        public List<int> Gene { get; set; }
        public double Fitness { get; set; }

        /*First generation chromossomes*/
        public Chromossome(List<Point> _points, Random _random)
        {
            this.Gene = genCode(_points, _random);
            this.Fitness = 100.0 / CalculationStrategy.routeDistance(this.Gene, _points);
        }

        /*Following generations chromossome*/
        public Chromossome(List<int> _route, List<Point> _points)
        {
            this.Gene = _route;
            this.Fitness = 100.0 / CalculationStrategy.routeDistance(this.Gene, _points);
        }

        public List<int> genCode(List<Point> _points, Random _random)
        {
            List<int> route = new List<int>();
            List<Point> points = new List<Point>(_points);
            int dice;

            while (points.Count() > 0)
            {
                dice = _random.Next(0, points.Count());
                //route.Add(Convert.ToChar(points[dice].id));
                route.Add(points[dice].id);
                points.RemoveAt(dice);
            }

            return route;
        }

    }
}
