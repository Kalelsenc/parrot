using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Threading;

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

        public void add(NeuroLay lay, int pos)
        {
            list.Insert(pos, lay);
        }

        public string run(List<Vector2> points)
        {
            return "";
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
