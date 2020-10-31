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

        public Lookup<int, object> calculate(List<NeuroLay>.Enumerator enumerator, Lookup<int, object> groupings )
        {
            if (synapses.Count < 1)
                throw new Exception("Synapsis count is 0");
            if (neurons.Count < 1)
                throw new Exception("Neuron count is 0");

            var neuronsOutput = from n in neurons select new { id = neurons.IndexOf(n), value = n.get(groupings[neurons.IndexOf(n)].ToList()) };
            var returnValues = from s in synapses join c in neuronsOutput on s.fromId equals c.id select new { id = s.toId, value = s.weight != Double.NaN ? (double)c.value * s.weight : c.value };
            var lookupList = (Lookup<int, object>)returnValues.ToLookup(p => p.id, p => p.value);

            if (enumerator.MoveNext())
                return enumerator.Current.calculate(enumerator, lookupList);
            else return lookupList;
        }

        public void setLinkType(LinkType type, NeuroLay next)
        {
            Random random = new Random();
            switch (type)
            {
                case LinkType.all_to_all:
                    int n = neurons.Count();
                    int m = next.count();
                    for (int i=0;i<n;i++)
                    {
                        for (int j=0;j<m;j++)
                        {
                            Synaps synaps = new Synaps(i, j, random.NextDouble());
                        }
                    }
                    break;
            }

        }
    }
}