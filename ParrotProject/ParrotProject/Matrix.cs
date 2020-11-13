using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing;

namespace ParrotProject
{
    [Serializable]
    class Matrix
    {
        List<List<object>> messageData = new List<List<object>>();

        public int count => messageData.Count;

        public Matrix(int neuroCount)
        {
            for (int i = 0; i < neuroCount; i++)
                messageData.Add(new List<object>());
        }

        public void add(int id, object data) {
            if (data is IEnumerable<object>)
                messageData[id].AddRange((IEnumerable<object>)data);
            else
                messageData[id].Add(data);
        }

        public List<object> get(int id) => messageData[id];

        public override string ToString()
        {
            string res = "";
            foreach (List<object> list in messageData)
            {
                foreach (object value in list)
                    res += value.ToString() + " ";
                res += "\n";
            }
            return res;
        }

        public static Matrix parseBitmap(Bitmap p)
        {
            Matrix message = new Matrix(p.Height);
            for (int i = 0; i < p.Height; i++)
                for (int j = 0; j < p.Width; j++)
                    message.add(i, p.GetPixel(j, i).R+ p.GetPixel(j, i).G+ p.GetPixel(j, i).B);
            return message;
        }
    }
}
