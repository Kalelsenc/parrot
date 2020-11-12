using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParrotProject
{
    public partial class MenuForm : Form
    {
        List<object> list=new List<object>();

        public MenuForm()
        {
            InitializeComponent();
            label2.Text = "";
        }

        private void Load_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {

        }

        private void Random_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int i = 1;
            int a, b;
            while (i<16)
            {
                a = random.Next(-50, 50);
                b = random.Next(-50, 50);
                list.Add(new Vector2(a, b));
                if (i%5==0)
                    label2.Text += "(" + a + "," + b + ")\r\n";
                else
                    label2.Text += "(" + a + "," + b + "); ";
                i++;
            }
        }

        private void addPoint_Click(object sender, EventArgs e)
        {
            if (textBoxX.Text != "" && textBoxY.Text != "")
            {
                list.Add(new Vector2(Convert.ToDouble(textBoxX.Text), Convert.ToDouble(textBoxY.Text)));
                label2.Text+="("+textBoxX.Text+","+textBoxY.Text+"); ";
            }
            Submit.Enabled = true;
        }

        private void textBoxX_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            MainWindow.setPoints(list.ToList());
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            list.Clear();
            label2.Text = "";
        }
    }
}
