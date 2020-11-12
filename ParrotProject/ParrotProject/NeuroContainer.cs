using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Threading;
using ParrotProject.NeuroLays;

namespace ParrotProject
{
    
    [Serializable]
    class NeuroContainer
    {
        List<NeuroLay> list;

        public NeuroContainer()
        {
            list = new List<NeuroLay>();
        }

        public void add(params NeuroLay[] lays)
        {
            list.AddRange(lays);
        }

        public void add(NeuroLay lay, int pos)
        {
            list.Insert(pos, lay);
        }

        public NeuroMessage run(NeuroMessage message)
        {
            if (list.Count > 0)
                return list[0].calculate(list.GetEnumerator(), message);
            else throw new Exception("Lay count = 0");
        }

        public void Save()
        {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream("list.dat", FileMode.OpenOrCreate))
                    formatter.Serialize(fs, list);
        }

        
        public void Load()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("list.dat", FileMode.OpenOrCreate))
            {
                    List<NeuroLay> neuroLays = (List<NeuroLay>)formatter.Deserialize(fs);
                    list = neuroLays;
            }

        }
    }
}
