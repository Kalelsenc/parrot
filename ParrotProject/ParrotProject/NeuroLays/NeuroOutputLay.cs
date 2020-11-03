using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParrotProject.NeuroLays
{
    class NeuroOutputLay:NeuroLay
    {
        public NeuroOutputLay(Func<List<object>, object> action):base(action)
        {
        }

        public override NeuroMessage calculate(List<NeuroLay>.Enumerator enumerator, NeuroMessage message)
        {
            if (neurons.Count < 1)
                throw new Exception("Neuron count is 0");

            Lookup<int, object> lookupList = null;
            var neuronsOutput = from n in neurons select new { id = neurons.IndexOf(n), value = n.get(message.get(neurons.IndexOf(n))) };

            NeuroMessage nextLayMessage = new NeuroMessage(neurons.Count);

            foreach (var a in neuronsOutput)
                nextLayMessage.add(a.id, a.value);

            return nextLayMessage;
        }
    }
}
