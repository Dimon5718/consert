using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace stop
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            GetList();
        }
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        void GetList()
        {

            con = new SqlConnection(@"Data Source=LAPTOP-IUFK5CBJ\DIMON;Initial Catalog=stop;User ID=sa;Password=123");
            da = new SqlDataAdapter("Select *From Ychet_Spiski", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Ychet_Spiski");
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = String.Format("insert into Ychet_Spiski(Nomer_Tovara, Adres_raspolojenia_tovara, Kolichestvo_Tovara, Tovar) values ('{0}','{1}','{2}','{3}')", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(Text, "Товар успешно добавлен");
            GetList();
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {
            GetList();
        }
    }
}