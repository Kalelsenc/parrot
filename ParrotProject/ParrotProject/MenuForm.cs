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
        object[] list;

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

        }

        private void addPoint_Click(object sender, EventArgs e)
        {
            if (textBoxX.Text != "" && textBoxY.Text != "")
            {
                list[list.Length] = new Vector2(Convert.ToDouble(textBoxX), Convert.ToDouble(textBoxY));
                label2.Text+="("+textBoxX+","+textBoxY+")\r\n";
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
    }
}
