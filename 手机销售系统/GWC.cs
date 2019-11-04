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
    public partial class GWC : Form
    {
        public GWC()
        {
            InitializeComponent();
        }
        private static string ConStr = "initial catalog = 手机销售系统;Server=(local);user id=sjxs;password=123456";
        private void GWC_Load(object sender, EventArgs e)
        {
            Dbsx();
           
           
        }
        public void Dbsx()
        {
            string sql = "select * from 购物表 where 用户名='"+ 用户.name+ "'";
            SqlConnection connection = new SqlConnection(ConStr);
            connection.Open();

            SqlCommand command = new SqlCommand(sql, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "购物表");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "购物表";




        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Left -= 2;
            if(label1.Right<0)
            {
                label1.Left = panel1.Width;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.textBox1.Text = this.dataGridView1.Rows[e.RowIndex].Cells["手机品牌"].Value.ToString();
            this.textBox2.Text = this.dataGridView1.Rows[e.RowIndex].Cells["手机型号"].Value.ToString();
            this.textBox3.Text = this.dataGridView1.Rows[e.RowIndex].Cells["手机价格"].Value.ToString();
            this.textBox4.Text = this.dataGridView1.Rows[e.RowIndex].Cells["购买数量"].Value.ToString();
            this.textBox5.Text = this.dataGridView1.Rows[e.RowIndex].Cells["合计金额"].Value.ToString();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConStr);
            connection.Open();
            string com = "delete from 购物表 where 用户名='"+ 用户.name +"'";
            SqlCommand command = new SqlCommand(com,connection);
            command.ExecuteNonQuery();
            connection.Close();
            Dbsx();
            MessageBox.Show("购物车已清空！","提示!");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否支付订单？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
           if(result==DialogResult.OK)
            {
                string com = "insert into 订单表(用户名,订单总额,订单状态) values('"+ 用户.name+ "','" + textBox5.Text + "','"+ 1 +"') ";
                SqlConnection connection = new SqlConnection(ConStr);
                connection.Open();
                SqlCommand command = new SqlCommand(com, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                string com = "insert into 订单表(用户名,订单总额,订单状态) values('" + 用户.name + "','" + textBox5.Text + "','" + 0 + "') ";
                SqlConnection connection = new SqlConnection(ConStr);
                connection.Open();
                SqlCommand command = new SqlCommand(com, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            MessageBox.Show("提交订单成功！");
            string com1 = "delete from 购物表 where 手机型号='"+ textBox2.Text +"' ";
            SqlConnection connection1 = new SqlConnection(ConStr);
            connection1.Open();
            SqlCommand command1 = new SqlCommand(com1, connection1);
            command1.ExecuteNonQuery();
            connection1.Close();
            Dbsx();

        }
    }
}
