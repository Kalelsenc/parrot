﻿using System;
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

            var neuronsOutput = from n in neurons select new { id = neurons.IndexOf(n), value = n.get(message.get(neurons.IndexOf(n)))};
            var returnValues = from s in synapses join c in neuronsOutput on s.fromId 
                               equals c.id select new { id = s.toId, value = s.weight != Double.NaN ? c.value : Convert.ToDouble(c.value) * s.weight };

            NeuroMessage nextLayMessage = new NeuroMessage(neurons.Count);

            foreach (var a in returnValues)
                nextLayMessage.add(a.id, a.value);

            if (enumerator.MoveNext())
                return enumerator.Current.calculate(enumerator, nextLayMessage);
            else return nextLayMessage;
        }

        public void setLinkType(LinkType type, NeuroLay next, bool randomWeight)
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