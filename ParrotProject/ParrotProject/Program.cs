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

            NeuroLay lay = new NeuroLay(x =>
            {
                return (int)x[0] - 2.0;
            });

            container.add(lay, 0);
            lay.add();

            MainWindow main = new MainWindow();
            main.ShowDialog();
            Console.ReadLine();

        }
    }
}
