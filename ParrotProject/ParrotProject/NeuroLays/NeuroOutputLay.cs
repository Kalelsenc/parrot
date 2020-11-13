using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParrotProject.NeuroLays
{
    class NeuroOutputLay:NeuroLay
    {
        public NeuroOutputLay(Func<List<object>, object> action, int size):base(action, size)
        {
        }

        public override Matrix calculate(List<NeuroLay>.Enumerator enumerator, Matrix message)
        {
            if (size < 1)
                throw new Exception("Neuron count is 0");

            Matrix neuroMessage = new Matrix(message.count);
            for (int i = 0; i < message.count; i++)
                neuroMessage.add(i, action(message.get(i)));

            return neuroMessage;
        }
    }
}
