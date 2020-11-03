using ParrotProject.NeuroLays;
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


            //NeuroLay lay = new NeuroLay(x =>
            //{
            //    return (int)x[0] - 2.0;
            //});

            //container.add(lay, 0);
            //lay.add();


            NeuroLay firstLay = new NeuroLay(x =>
            {
                return x;
            });
            firstLay.add();

            NeuroOutputLay secondLay = new NeuroOutputLay(x =>
            {
                double average = 0;
                for (int i = 0; i < x.Count; i++)
                    average += Convert.ToDouble(x[i]);
                average /= x.Count;

                int biggerThenAverage = 0;

                for (int i = 0; i < x.Count; i++)
                    if (Convert.ToDouble(x[i]) > average)
                        biggerThenAverage++;

                return biggerThenAverage > x.Count/2;
            });
            secondLay.add();

            container.add(firstLay, 0);
            container.add(secondLay, 1);

            firstLay.setLinkType(LinkType.all_to_all, secondLay, false);

            object[] list = { 1.0, 3.0, 4.0 };
            NeuroMessage message = new NeuroMessage(1);
            message.add(0, list);

            Console.WriteLine("" + container.run(message).ToString());


            //container.add(lay, 1);

            MainWindow main = new MainWindow();
            main.ShowDialog();
            Console.ReadLine();


        }
    }
}
