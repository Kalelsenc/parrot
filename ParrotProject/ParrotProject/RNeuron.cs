using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonProject
{
    class RNeuron : INeuron<List<ANeuron>, Tuple<int, double>>
    {
        List<List<ANeuron>> values = new List<List<ANeuron>>();
        public void clear()
        {
            values.Clear();
        }

        public void push(List<ANeuron> value)
        {
            values.Add(value);
        }

        public Tuple<int, double> get()
        {
            Tuple < int, double> max = new Tuple<int, double>(int.MinValue, double.MinValue);


          
            for(int i = 0; i < values.Count; i++)
            {
                double sum = 0;
                foreach (ANeuron neuron in values[i])
                    sum += neuron.get();
                if (sum > max.Item2)
                    max = new Tuple<int, double>(i, sum);
            }

            return max;
        }
    }
}
