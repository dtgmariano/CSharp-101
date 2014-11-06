using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public class Model
    {
        Random random;
        public GA myGA;
        public Local myLocal;

        public Model(Random _random, Local _local, GA _ga)
        {
            random = _random;
            myLocal = _local;
            myGA = _ga;
        }
    }
}
