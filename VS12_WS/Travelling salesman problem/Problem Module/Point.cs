using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public class Point
    {
        public int id;
        public double coord_x, coord_y;

        public Point(int _id, int _minRange, int _maxRange, Random _random)
        {
            this.id = _id;
            this.coord_x = _random.Next(_minRange, _maxRange);
            this.coord_y = _random.Next(_minRange, _maxRange);
        }
    }
}
