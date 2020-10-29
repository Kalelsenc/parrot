using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ParrotProject
{
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

        object call(int i, List< object> value)
        {
            var groupings = 

            return (Lookup<int, object>)groupings.ToLookup(x=>x.id, x=>x.value);
        }

        public Lookup<int, object> descent(List<NeuroLay> list, int id)
        {
            if(id>0)
            {
                Lookup<int, object> values = list[id - 1].descent(list, id - 1);

                var current =  from n in neurons select new { id = neurons.IndexOf(n), value = n.get(values[neurons.IndexOf(n)].ToList()) };

                var descentReturn = from s in synapses join c in current on s.fromId equals c.id select new { id = s.toId, value = s.weight != Double.NaN ? (double)c.value * s.weight : c.value };
                return (Lookup<int, object>)descentReturn;
            }
            return  (Lookup<int, object>) from n in neurons select new { id = neurons.IndexOf(n), value = n.get() };
        }
    }
}