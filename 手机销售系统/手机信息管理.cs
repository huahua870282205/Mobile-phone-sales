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
    public partial class 手机信息管理 : Form
    {
        private static string ConStr = "initial catalog = 手机销售系统;Server=(local);user id=sjxs;password=123456";
        public 手机信息管理()
        {
            InitializeComponent();
        }
        private void 手机信息管理_Load(object sender, EventArgs e)
        {
            DgvSx();
            comboBox1.Items.Add("华为");
            comboBox1.Items.Add("苹果");
            comboBox1.Items.Add("三星");
            comboBox1.Items.Add("小米");
            comboBox1.Items.Add("魅族");
            comboBox2.Items.Add("Android");
            comboBox2.Items.Add("IOS");
            comboBox2.Items.Add("Windows Phone");
            comboBox3.Items.Add("华为");
            comboBox3.Items.Add("苹果");
            comboBox3.Items.Add("三星");
            comboBox3.Items.Add("小米");
            comboBox3.Items.Add("魅族");

        }
        public void DgvSx()
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
            try
            {
                this.textBox1.Text = this.dataGridView1.Rows[e.RowIndex].Cells["手机编号"].Value.ToString();
                this.textBox2.Text = this.dataGridView1.Rows[e.RowIndex].Cells["手机型号"].Value.ToString();
                this.textBox3.Text = this.dataGridView1.Rows[e.RowIndex].Cells["手机价格"].Value.ToString();
                this.textBox4.Text = this.dataGridView1.Rows[e.RowIndex].Cells["手机库存"].Value.ToString();
                this.comboBox1.Text = this.dataGridView1.Rows[e.RowIndex].Cells["手机品牌"].Value.ToString();
                this.comboBox2.Text = this.dataGridView1.Rows[e.RowIndex].Cells["手机系统"].Value.ToString();
            }
            catch
            {
                //MessageBox.Show("点击位置错误！","提示！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text!="")
            {
                DialogResult result = MessageBox.Show("是否删除手机信息", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result==DialogResult.OK)
                {
                    string com = "delete from 手机信息表 where 手机编号='"+ textBox1.Text +"'";
                    SqlConnection sqlConnection = new SqlConnection(ConStr);
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand(com, sqlConnection);
                    command.ExecuteNonQuery();
                    DgvSx();
                    MessageBox.Show("删除成功！","提示！");
                }
                else
                {
                    MessageBox.Show("取消删除!","提示");
                }
            }

         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {
                try
                {
                    string com = "insert into 手机信息表 values ('"+ textBox1.Text + "','"+ comboBox1.Text +"','"+ comboBox2.Text +"','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                    SqlConnection connection = new SqlConnection(ConStr);
                    connection.Open();
                    SqlCommand command = new SqlCommand(com,connection);
                    command.ExecuteNonQuery();
                    DgvSx();
                    MessageBox.Show("添加成功！","提示！");
                    
                }
                catch
                {
                    MessageBox.Show("手机编号已存在！","提示！");
                }
            }
            else
            {
                MessageBox.Show("手机编号不能为空！","提示！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                string com = "update 手机信息表 set 手机品牌='" + comboBox1.Text + "',手机系统='" + comboBox2.Text + "',手机型号='" + textBox2.Text + "',手机价格='" + textBox3.Text + "',手机库存='" + textBox4.Text + "' where 手机编号='" + textBox1.Text + "'";
                SqlConnection connection = new SqlConnection(ConStr);
                connection.Open();
                SqlCommand command = new SqlCommand(com, connection);
                command.ExecuteNonQuery();
                DgvSx();
                MessageBox.Show("修改成功！", "提示！");
            }
            else
            {
                MessageBox.Show("手机编号不能为空！", "提示！");
            }





        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str = "select * from 手机信息表 where 手机品牌='"+ comboBox3.Text +"'";
            SqlConnection connection = new SqlConnection(ConStr);
            connection.Close();
            SqlCommand command = new SqlCommand(str, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(str, connection);
            DataSet data = new DataSet();
            adapter.Fill(data, "手机信息表");
            dataGridView1.DataSource = data;
            dataGridView1.DataMember = "手机信息表";
            connection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DgvSx();
        }
    }
}
