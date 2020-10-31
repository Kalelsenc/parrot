using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using System.Text;
using System.Threading.Tasks;

namespace ParrotProject
{
    [Serializable]
    class NeuroLay
    {
        List<Neuron<List<object>, object>> neurons = new List<Neuron<List<object>, object>>();
        List<Synaps> synapses = new List<Synaps>();

        LinkType linkType = LinkType.custom;

        readonly Func<List<object>, object> action;

        public NeuroLay(Func<List<object>, object> action)
        {
            this.action = action;
        }

        public void add()
        {
            neurons.Add(new Neuron<List<object>, object>(action));
        }

        public void setSynapsis(NeuroLay nextLay, LinkType type)
        {
            linkType = type;
        }

        public void setSynaps(Synaps syn)
        {
            synapses.Add(syn);
        }

        public Lookup<int, object> calculate(List<NeuroLay>.Enumerator enumerator, Lookup<int, object> groupings )
        {
            var neuronsOutput = from n in neurons select new { id = neurons.IndexOf(n), value = n.get(groupings[neurons.IndexOf(n)].ToList()) };
            var returnValues = from s in synapses join c in neuronsOutput on s.fromId equals c.id select new { id = s.toId, value = s.weight != Double.NaN ? (double)c.value * s.weight : c.value };
            var lookupList = (Lookup<int, object>)returnValues.ToLookup(p => p.id, p => p.value);

            if (enumerator.MoveNext())
                return enumerator.Current.calculate(enumerator, lookupList);
            else return lookupList;
        }
    }
}