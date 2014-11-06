using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public class Local
    {
        public List<Point> myPoints;

        public Local(int _numpoints, int _minRange, int _maxRange, Random _random)
        {
            this.myPoints = LocalStrategy.genListPoints(_numpoints, _minRange, _maxRange, _random);
        }

        public Local(List<Point> _points)
        {
            this.myPoints = _points;
        }

        public Local()
        {
            this.myPoints = new List<Point>();
        }

    }
}
