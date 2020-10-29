using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParrotProject
{
    class Synaps
    {
        
        readonly int fromId;
        readonly int toId;
        double weight;

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
