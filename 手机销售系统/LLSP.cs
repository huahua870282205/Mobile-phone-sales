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
    public partial class LLSP : Form
    {
        static string sjbh;
        private static string ConStr = "initial catalog = 手机销售系统;Server=(local);user id=sjxs;password=123456";
        public LLSP()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void LLSP_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("苹果");
            comboBox1.Items.Add("华为");
            comboBox1.Items.Add("魅族");
            comboBox1.Items.Add("小米");
            comboBox1.Items.Add("三星");
            comboBox1.SelectedIndex = 0;
            Dbsx();
        }
        public void Dbsx()
        {
            string sql = "select * from 手机信息表";
            SqlConnection connection = new SqlConnection(ConStr);
            connection.Open();

            SqlCommand command = new SqlCommand(sql, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "手机信息表");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "手机信息表";




        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.textBox1.Text = this.dataGridView1.Rows[e.RowIndex].Cells["手机品牌"].Value.ToString();
            this.textBox2.Text = this.dataGridView1.Rows[e.RowIndex].Cells["手机型号"].Value.ToString();
            this.textBox3.Text = this.dataGridView1.Rows[e.RowIndex].Cells["手机系统"].Value.ToString();
            this.textBox4.Text = this.dataGridView1.Rows[e.RowIndex].Cells["手机库存"].Value.ToString();
            this.textBox5.Text = this.dataGridView1.Rows[e.RowIndex].Cells["手机价格"].Value.ToString();
            sjbh = this.dataGridView1.Rows[e.RowIndex].Cells["手机编号"].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dbsx();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "select * from 手机信息表 where 手机品牌='" + comboBox1.Text +"'";
            SqlConnection connection = new SqlConnection(ConStr);
            connection.Open();

            SqlCommand command = new SqlCommand(str, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(str, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "手机信息表");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "手机信息表";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            numericUpDown1.Value = 0;
          
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(textBox4.Text) - Convert.ToInt16(numericUpDown1.Value) >= 0)
            {
                if (this.numericUpDown1.Value > 0)
                {
                    float sum;
                    sum = Convert.ToInt16(textBox5.Text) * Convert.ToInt16(numericUpDown1.Value);
                    string yonghu = 用户.name;
                    SqlConnection connection = new SqlConnection(ConStr);
                    connection.Open();

                    string com = "insert into 购物表 values('" + yonghu + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + numericUpDown1.Value + "','" + sum + "')";
                    SqlCommand command = new SqlCommand(com, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("加入购物车成功！");
                    int kc = Convert.ToInt16(textBox4.Text) - Convert.ToInt16(numericUpDown1.Value);
                    string kcl = kc.ToString();
                    

                    string comm = "update 手机信息表 set 手机库存='"+ kcl +"' where 手机编号='"+ sjbh +"'";
                    SqlConnection sqlConnection = new SqlConnection(ConStr);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(comm,sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    Dbsx();
                }


                else
                {
                    MessageBox.Show("购买数量不能为0！");
                }
            }
            else
            {
                MessageBox.Show("库存量不足，不能加入购物车！","提示！");
            }
        }
    }
}
