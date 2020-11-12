using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ParrotProject
{
    [Serializable]
    class Matrix
    {
        List<List<double>> messageData = new List<List<double>>();

        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("messageData.dat", FileMode.OpenOrCreate))
                formatter.Serialize(fs, messageData);
        }

        public void Load()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("messageData.dat", FileMode.OpenOrCreate))
            {
                List<List<double>> mD = (List<List<double>>)formatter.Deserialize(fs);
                messageData = mD;
            }

        }
    }
}
