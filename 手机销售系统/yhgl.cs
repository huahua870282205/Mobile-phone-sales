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
    public partial class yhgl : Form
    {
        private static string ConStr = "initial catalog = 手机销售系统;Server=(local);user id=sjxs;password=123456";
        public yhgl()
        {
            InitializeComponent();
        }

        private void yhgl_Load(object sender, EventArgs e)
        {
            Dbsx();
            


        }
        public void Dbsx()
        {
            string sql = "select * from 用户表";
            SqlConnection connection = new SqlConnection(ConStr);
            connection.Open();

            SqlCommand command = new SqlCommand(sql, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds,"用户表");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "用户表";

            
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.textBox1.Text = this.dataGridView1.Rows[e.RowIndex].Cells["用户名"].Value.ToString();
                this.textBox2.Text = this.dataGridView1.Rows[e.RowIndex].Cells["用户密码"].Value.ToString();
                this.textBox3.Text = this.dataGridView1.Rows[e.RowIndex].Cells["用户地址"].Value.ToString();
                this.textBox4.Text = this.dataGridView1.Rows[e.RowIndex].Cells["用户手机号"].Value.ToString();
                string sex = this.dataGridView1.Rows[e.RowIndex].Cells["用户性别"].Value.ToString();

                if (sex == "男")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
            }
            catch
            {
                //MessageBox.Show("点击位置错误！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.textBox1.Text != "" && this.textBox2.Text!="" )
                {
                    SqlConnection connect = new SqlConnection(ConStr);
                    connect.Open();
                    string sex = "";
                    if (radioButton1.Checked)
                    {
                        sex = radioButton1.Text;
                    }
                    else
                    {
                        sex = radioButton2.Text;
                    }
                    string com = "insert into 用户表 values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + sex + "')";
                    SqlCommand cmd = new SqlCommand(com, connect);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("添加成功");
                    Dbsx();
                }
                else
                {
                    MessageBox.Show("用户名或密码不能为空！");
                }
            }
            catch
            {
                MessageBox.Show("用户名已存在！");
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (this.textBox1.Text != "")
            {
                DialogResult result = MessageBox.Show("是否删除？", "提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    string sql = "delete from 用户表 where 用户名 = '" + this.textBox1.Text + "'";
                    SqlConnection conn = new SqlConnection(ConStr);
                    conn.Open();
                    SqlCommand com = new SqlCommand(sql, conn);
                    com.ExecuteNonQuery();
                    Dbsx();
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("取消删除！");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "" && this.textBox2.Text != "")
            {


                string sex;
                if (radioButton1.Checked)
                {
                    sex = radioButton1.Text;

                }
                else
                {
                    sex = radioButton2.Text;
                }

                string sql = "update 用户表 set 用户密码='" + this.textBox2.Text + "',用户地址='" + this.textBox3.Text + "',用户手机号='" + this.textBox4.Text + "',用户性别= '" + sex + "' where 用户名='" + this.textBox1.Text + "' ";

                SqlConnection conn = new SqlConnection(ConStr);
                conn.Open();
                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();
                Dbsx();
            }
            else
            {
                MessageBox.Show("用户名或密码不能为空！");
            }
        }
    }
}
