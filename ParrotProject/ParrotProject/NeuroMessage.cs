using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParrotProject
{
    class NeuroMessage
    {
        List<List<object>> messageData = new List<List<object>>();

        public NeuroMessage(int neuroCount)
        {
            for(int i = 0; i < neuroCount; i++)
                messageData.Add(new List<object>());
        }

        public void add(int id, object data)
        {
            if (data is List<object> )
                messageData[id].AddRange((List<object>)data);
            else if (data is object[])
                messageData[id].AddRange((object[])data);
            else messageData[id].Add(data);
        }

        public List<object> get(int id)
        {
            return messageData[id];
        }

        public override string ToString()
        {
            string res = "";
            foreach(List<object> list in messageData)
            {
                foreach (object value in list)
                    res += value.ToString() + " ";
                res += "\n";
            }
            return res;
        }

        public static NeuroMessage parseBitmap(Bitmap p)
        {
            NeuroMessage message = new NeuroMessage(p.Height);
            for (int i = 0; i < p.Height; i++)
                for (int j = 0; j < p.Width; j++)
                    message.add(i, p.GetPixel(j, i));
            return message;
        }
    }
}
