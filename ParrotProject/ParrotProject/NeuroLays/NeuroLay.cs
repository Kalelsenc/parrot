using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using System.Text;
using System.Threading.Tasks;

namespace ParrotProject.NeuroLays
{
    [Serializable]
    class NeuroLay
    {
        protected List<Neuron<List<object>, object>> neurons = new List<Neuron<List<object>, object>>();
        protected List<Synaps> synapses = new List<Synaps>();

        protected LinkType linkType = LinkType.custom;

        protected readonly Func<List<object>, object> action;

        public NeuroLay(Func<List<object>, object> action)
        {
            this.action = action;
        }

        public void add()
        {
            neurons.Add(new Neuron<List<object>, object>(action));
        }

        public int count()
        {
            return neurons.Count();
        }

        public void setSynapsis(NeuroLay nextLay, LinkType type)
        {
            linkType = type;
        }

        public void setSynaps(Synaps syn)
        {
            synapses.Add(syn);
        }

        public virtual NeuroMessage calculate(List<NeuroLay>.Enumerator enumerator, NeuroMessage message )
        {
            if (synapses.Count < 1)
                throw new Exception("Synapsis count is 0");
            if (neurons.Count < 1)
                throw new Exception("Neuron count is 0");

            List<object> neuronsOutput = new List<object>();

            for (int i = 0; i < neurons.Count; i++)
                neuronsOutput.Add(neurons[i].get(message.get(i)));
       
            NeuroMessage nextLayMessage = new NeuroMessage(neurons.Count);

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
                    for (int i = 0; i < neurons.Count(); i++)
                        for (int j = 0; j < next.count(); j++)
                            setSynaps(new Synaps(i, j, randomWeight ?  random.NextDouble() : Double.NaN));
                    break;
            }

        }

    }
}