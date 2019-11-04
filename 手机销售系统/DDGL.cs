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

namespace 手机销售系统
{
    public partial class DDGL : Form
    {
        public DDGL()
        {
            InitializeComponent();
        }
        private static string ConStr = "initial catalog = 手机销售系统;Server=(local);user id=sjxs;password=123456";

        private void DDGL_Load(object sender, EventArgs e)
        {
            Dbsx();
        }
        public void Dbsx()
        {
            string sql = "select * from 订单表";
            SqlConnection connection = new SqlConnection(ConStr);
            connection.Open();

            SqlCommand command = new SqlCommand(sql, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "订单表");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "订单表";


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.textBox2.Text = this.dataGridView1.Rows[e.RowIndex].Cells["订单编号"].Value.ToString();
            this.textBox3.Text = this.dataGridView1.Rows[e.RowIndex].Cells["用户名"].Value.ToString();
            this.textBox4.Text = this.dataGridView1.Rows[e.RowIndex].Cells["订单总额"].Value.ToString();
            this.textBox5.Text = this.dataGridView1.Rows[e.RowIndex].Cells["订单状态"].Value.ToString();
            string zt = this.textBox5.Text.Trim();
            if (zt == "0")
            {
                zt = "未支付";
            }
            else
            {
                zt = "已支付";
            }
            this.textBox5.Text = zt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string com = "select * from 订单表 where 用户名='"+ textBox1.Text +"'";
            SqlConnection connection = new SqlConnection(ConStr);
            connection.Open();
            SqlCommand command = new SqlCommand(com, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(com,connection);
            DataSet set = new DataSet();
            adapter.Fill(set, "订单表");
            dataGridView1.DataSource = set;
            dataGridView1.DataMember = "订单表";
    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox5.Text.Trim() == "已支付")
            {
                MessageBox.Show("发货成功！","提示！");
                string com = "delete from 订单表 where 订单编号='"+ textBox2.Text +"' ";
                SqlConnection connection = new SqlConnection(ConStr);
                connection.Open();
                SqlCommand command = new SqlCommand(com,connection);
                command.ExecuteNonQuery();
                connection.Close();
                Dbsx();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

            }
            else
            {
                MessageBox.Show("订单未支付，不能发货！","提示！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string com = "delete from 订单表 where 订单编号='" + textBox2.Text + "' ";
            SqlConnection connection = new SqlConnection(ConStr);
            connection.Open();
            SqlCommand command = new SqlCommand(com, connection);
            command.ExecuteNonQuery();
            connection.Close();
            Dbsx();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
    }
