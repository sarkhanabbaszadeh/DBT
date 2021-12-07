using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection elaqe = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBTDB.mdf;Integrated Security=True");
            if (elaqe.State == ConnectionState.Closed)
                elaqe.Open();
            SqlCommand emr = new SqlCommand("insert into dbttable(Ad,Soyad) values(@ad,@soyad)", elaqe);
            emr.Parameters.AddWithValue("@ad", textBox1.Text);
            emr.Parameters.AddWithValue("@soyad", textBox2.Text);
            emr.ExecuteNonQuery();

            elaqe.Close();
            MessageBox.Show("Melumat Daxil edildi !", "Melumatlandirma !");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            yenileme();
        }

        public void yenileme ()
        {
            SqlConnection elaqe = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBTDB.mdf;Integrated Security=True");
            if (elaqe.State == ConnectionState.Closed)
                elaqe.Open();
            SqlCommand emr = new SqlCommand("select * from dbttable", elaqe);
            SqlDataAdapter datadap = new SqlDataAdapter(emr);
            DataTable dt = new DataTable();
            datadap.Fill(dt);
            dataGridView1.DataSource = dt;
            elaqe.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBTDBDataSet.dbttable' table. You can move, or remove it, as needed.
            this.dbttableTableAdapter.Fill(this.dBTDBDataSet.dbttable);

        }
    }
}
