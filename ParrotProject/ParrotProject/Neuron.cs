
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParrotProject
{
    class Neuron<T, E>
    {
        readonly Func<T, E> action;
        public Neuron(Func<T,E> action)
        {
            this.action = action;
        }

        public E get(T value)
        {
            return action(value);
        }
    }
}