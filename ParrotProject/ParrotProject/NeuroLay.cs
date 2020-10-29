using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParrotProject
{
    class NeuroLay<T>
    {
        List<T> Neurons = new List<T>();
        List<Synaps> Synapses = new List<Synaps>(); 

        public void set(T neuron)
        {
            Neurons.Add(neuron);
        }

        public void setSynaps(Synaps syn)
        {
            Synapses.Add(syn);
        }
    }
}
