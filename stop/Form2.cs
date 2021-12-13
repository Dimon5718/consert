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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
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
            da = new SqlDataAdapter("Select * from Sotrudnic", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Sotrudnic");
            dataGridView1.DataSource = ds.Tables["Sotrudnic"];
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
            cmd.CommandText = String.Format("insert into Sotrudnic(Familia, Imay, Otchestvo, Data_rogdenia, Nomer_telefona, Doljnost) values ('{0}','{1}','{2}','{3}','{4}','{5}')", textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);
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

            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
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
                    cmd.CommandText = string.Format("update Sotrudnic set  Familia='{1}', Imay='{2}', Otchestvo='{3}', Data_rogdenia='{4}', Nomer_telefona='{5}', Doljnost='{6}' where Imay='{2}'",
                        textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);
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
            cmd.CommandText = String.Format("delete from Sotrudnic where Id_Sotrudnic='{0}'", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            GetList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.ShowDialog();
        }
    }
}