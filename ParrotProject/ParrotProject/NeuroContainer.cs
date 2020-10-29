using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParrotProject
{
    class NeuroContainer
    {
        List<object> list;

        public NeuroContainer()
        {
            list = new List<object>();
        }

        public void setLay<Type>(int size, LinkType linkType)
        {
           // list.Add(new NeuroLay<Type>(size, linkType));
        }

        public string run(List<Vector2> points)
        {
            return "";
        }
    }
}
