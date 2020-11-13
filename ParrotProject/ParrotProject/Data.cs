using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ParrotProject
{
    class Data
    {
        public static void save(object data, string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                formatter.Serialize(fs, data);
        }

        public static T load<T>(string path)
        {
            T result;

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                result = (T)formatter.Deserialize(fs);

            return result;
        }
    }
}
