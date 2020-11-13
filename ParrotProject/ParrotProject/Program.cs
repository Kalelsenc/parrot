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

            NeuroLay firstLay = new NeuroLay(x =>
            {
                return x;
            }, 1);

            NeuroOutputLay secondLay = new NeuroOutputLay(x =>
            {
                Vector2 p1 = (Vector2)x[0];
                Vector2 p2 = (Vector2)x[1];
                double k = (p2.y - p1.y) / (p2.x - p1.x);
                double c = p1.x * (p2.y - p1.y) / (p2.x - p1.x) + p1.y;
                return "x * " + k + " + " + c;
            }, 1 );


            container.add(firstLay, secondLay);

            //container.add(firstLay, 0);
            //container.add(secondLay, 1);

            firstLay.setLinkTypeAndRandomWeight(LinkType.all_to_all, secondLay, false);


            object[] list = { new Vector2(0,2),new Vector2(-0.667,0) };

            Matrix message = new Matrix(1);
            message.add(0, list);
            

            Console.WriteLine("" + container.run(message).ToString());

            MenuForm menuForm = new MenuForm();
            menuForm.ShowDialog();

            //MainWindow main = new MainWindow();
            //MainWindow.setPoints(list.ToList());
            
            Console.ReadLine();
        }
    }
}
