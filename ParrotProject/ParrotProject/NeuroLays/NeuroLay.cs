using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

using System.Text;
using System.Threading.Tasks;

namespace ParrotProject.NeuroLays
{
    [Serializable]
    class NeuroLay
    {
        protected List<Synaps> synapses = new List<Synaps>();

        protected LinkType linkType = LinkType.custom;

        protected readonly Func<List<object>, object> action;

        protected readonly int size;

        public NeuroLay(Func<List<object>, object> action, int size)
        {
            this.action = action;
            this.size = size;
        }

        public int count()
        {
            return size;
        }

        public void setSynapsis(NeuroLay nextLay, LinkType type)
        {
            linkType = type;
        }

        public void setSynaps(Synaps syn)
        {
            synapses.Add(syn);
        }


        public virtual Matrix calculate(List<NeuroLay>.Enumerator enumerator, Matrix message )
        {
            if (synapses.Count < 1)
                throw new Exception("Synapsis count is 0");
            if(message.count != size)
                throw new Exception("message size and NeuroLay size not equal");

            List<object> neuronsOutput = new List<object>();

            for (int i = 0; i < message.count; i++)
                neuronsOutput.Add(action(message.get(i)));

            Matrix nextLayMessage = new Matrix(neuronsOutput.Count);

            foreach(Synaps s in synapses)
                nextLayMessage.add(s.toId, s.weight != Double.NaN ? neuronsOutput[s.fromId] : Convert.ToDouble(neuronsOutput[s.fromId]) * s.weight);

            if (enumerator.MoveNext())
                return enumerator.Current.calculate(enumerator, nextLayMessage);
            else return nextLayMessage;
        }

        public void setLinkTypeAndRandomWeight(LinkType type, NeuroLay next, bool randomWeight)
        {
            Random random = new Random();
            switch (type)
            {
                case LinkType.all_to_all:
                    for (int i = 0; i < size; i++)
                        for (int j = 0; j < next.count(); j++)
                            setSynaps(new Synaps(i, j, randomWeight ?  random.NextDouble() : Double.NaN));
                    break;
            }

        }

    }
}