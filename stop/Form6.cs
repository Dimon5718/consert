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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
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
            da = new SqlDataAdapter("Select * from Ychet_Spiski", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Ychet_Spiski");
            dataGridView1.DataSource = ds.Tables["Ychet_Spiski"];
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
            cmd.CommandText = String.Format("insert into Ychet_Spiski(Nomer_Tovara, Adres_raspolojenia_tovara, Kolichestvo_Tovara, Tovar) values ('{0}','{1}','{2}','{3}')", textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
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


            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
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
                    cmd.CommandText = string.Format("update Ychet_Spiski set Nomer_Tovara='{1}', Adres_raspolojenia_tovara='{2}', Kolichestvo_Tovara='{3}', Tovar='{4}' where Kolichestvo_Tovara='{3}'", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
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
            cmd.CommandText = String.Format("delete from Ychet_Spiski where Id_Ychet_Spiski='{0}'", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }
    }
}