using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParrotProject
{
    class Synaps
    {
        
        public readonly int fromId;
        public readonly int toId;
        public Double weight = Double.NaN;

        Synaps(int from, int to, double w)
        {
            fromId = from;
            toId = to;
            weight = w;
        }

        void setWeight(double w)
        {
            weight = w;
        }
    }
}
