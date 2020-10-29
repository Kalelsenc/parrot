
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

        public Lookup<int, object> call()
        {
            //Lookup<int, object> groupings = (Lookup<int, object>)neurons.ToLookup(x=> x.)
            return null;
        }

        public void descent(List<NeuroLay> list, int id)
        {

        }
    }
}