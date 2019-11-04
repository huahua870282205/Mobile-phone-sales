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
    public partial class xxgl : Form
    {
        public xxgl(string xs)
        {
            InitializeComponent();
            this.textBox1.Text = xs;
        }
       
        private void xxgl_Load(object sender, EventArgs e)
        {
            DBS.sql.Open();
            string com = "select * from 用户表 where 用户名='"+this.textBox1.Text+"'";
            SqlCommand comd = new SqlCommand(com,DBS.sql);
            SqlDataReader reader = comd.ExecuteReader();
            
            while (reader.Read())
            {
                this.textBox1.Text = reader["用户名"].ToString();
                this.textBox2.Text = reader["用户密码"].ToString();
                this.textBox3.Text = reader["用户地址"].ToString();
                this.textBox4.Text = reader["用户手机号"].ToString();
                string sex = reader["用户性别"].ToString();
                if (sex == "男")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
            }
            //DBS.sql.Close();
            //DBS.sql.Open();
            //string comm = "delete from 用户表 where 用户名='" + textBox1.Text + "'";
            //SqlCommand sqlcom = new SqlCommand(comm, DBS.sql);
            //sqlcom.ExecuteNonQuery();
            DBS.sql.Close();
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("用户名不能为空！");
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("密码不能为空！");
                textBox2.Focus();

            }
            else
            {
                DBS.sql.Open();
                string sex;
                if (radioButton1.Checked)
                {
                    sex = radioButton1.Text;
                }
                else
                {
                    sex = radioButton2.Text;
                }

                string com = "update 用户表 set 用户密码='" + this.textBox2.Text + "',用户地址='" + this.textBox3.Text + "',用户手机号='" + this.textBox4.Text + "',用户性别= '" + sex + "' where 用户名='" + this.textBox1.Text + "' ";
                SqlCommand command = new SqlCommand(com, DBS.sql);
                command.ExecuteNonQuery();
                DBS.sql.Close();
                MessageBox.Show("修改成功！");
                string s = textBox1.Text;
                用户 yonghu = new 用户(s);
                yonghu.Show();
                this.Hide();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
        }

        private void xxgl_FormClosing(object sender, FormClosingEventArgs e)
        {
            string s = textBox1.Text;
            用户 yonghu = new 用户(s);
            yonghu.Show();
            this.Hide();
        }
    }
}
