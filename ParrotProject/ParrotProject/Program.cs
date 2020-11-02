using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParrotProject
{
    class Program
    {
      
        static void Main(string[] args)
        {
            NeuroContainer container = new NeuroContainer();


            NeuroLay lay = new NeuroLay( x => {
                return (int)x[0] - 2.0;
            } );

            lay.add();

            NeuroLay firstLay = new NeuroLay(x =>
            {
                return x[0];
            });

            NeuroLay secondLay = new NeuroLay(x =>
            {
                double s2 = 0;
                //...for(int )
                // s2 += i*i;

                return Math.Sqrt(s2);
            });

            NeuroLay thirdLay = new NeuroLay(x =>
            {
                double sum = 0;
                for (int i= 0; i < x.Count; i++)
                    sum += (double)x[i];

                return sum;
            });

            container.add(firstLay, 0);
            container.add(secondLay, 1);
            container.add(thirdLay, 2);

            firstLay.setLinkType(LinkType.all_to_all, secondLay);
            secondLay.setLinkType(LinkType.all_to_all, thirdLay);

           // double[] list = { 1, 3, 4 };

            //Console.WriteLine("" + container.run(list.Any(p => p).ToLookup(p => p.Key, p=>));


            container.add(lay, 1);
        }
    }
}
