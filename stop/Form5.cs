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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
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
            da = new SqlDataAdapter("Select * from Tovar", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Tovar");
            dataGridView1.DataSource = ds.Tables["Tovar"];
            con.Close();
        }

        /// <summery>
        /// INSERT
        /// </summery>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = String.Format("insert into Tovar(Price_tovara, Nazvanie_tovara, Kachestvo_tovara) values ('{0}','{1}','{2}')", textBox2.Text, textBox3.Text, textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }

        /// <summery>
        /// UPDATE
        /// </summery>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {


            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                try
                {
                    cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = string.Format("update Tovar set Price_tovara='{1}', Nazvanie_tovara='{2}', Kachestvo_tovara='{3}' where Nazvanie_tovara='{2}'", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GetList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summery>
        /// DELETE
        /// </summery>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = String.Format("delete from Tovar where Id_Tovar='{0}'", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }
    }
}