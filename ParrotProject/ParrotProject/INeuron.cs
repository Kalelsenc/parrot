using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParrotProject
{
    interface INeuron<T, E>
    {
        void push(T value);
        E get();

        void clear();
    }
}
