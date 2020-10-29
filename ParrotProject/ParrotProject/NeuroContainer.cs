using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParrotProject
{
    class NeuroContainer
    {
        List<NeuroLay> list;

        public NeuroContainer()
        {
            list = new List<NeuroLay>();
        }

        public void add(NeuroLay lay, int pos)
        {
            list.Insert(pos, lay);
        }

        public string run(List<Vector2> points)
        {
            return "";
        }
    }
}
