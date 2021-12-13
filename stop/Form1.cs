using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin")
            {
                if (textBox2.Text == "12345")
                {
                    Form2 f2 = new Form2();
                    f2.ShowDialog();
                }
            }
            else
                MessageBox.Show("Пароль не верный");
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "polzovat")
            {
                if (textBox2.Text == "54321")
                {
                    Form3 f3 = new Form3();
                    f3.ShowDialog();
                }
            }
            else
                MessageBox.Show("Пароль не верный");
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}