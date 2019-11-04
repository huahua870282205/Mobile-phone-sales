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
    public partial class 注册 : Form
    {
        public 注册()
        {
            InitializeComponent();
        }
        public static string con = "server=(local);database='手机销售系统';uid='sjxs';pwd='123456'";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("用户名不为空");
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("密码不为空");
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("确定密码不为空");
                textBox3.Focus();
            }
            else if (textBox3.Text != textBox2.Text)
            {
                MessageBox.Show("两次密码不一致");
                textBox2.Clear();
                textBox3.Clear();
                textBox2.Focus();
            }
            else {
               
                try {
                    SqlConnection connect = new SqlConnection(con);
                    connect.Open();
                    string sex = "";
                    if (radioButton1.Checked)
                    {
                        sex = radioButton1.Text;
                    }
                    else {
                        sex = radioButton2.Text;
                    }
                    string com="insert into 用户表 values ('"+textBox1.Text+ "','" + textBox2.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + sex + "')";
                    SqlCommand cmd = new SqlCommand(com,connect);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("注册成功");
                    登录 denglu = new 登录();
                    denglu.Show();
                    this.Hide();
                }
                catch (Exception )
                {
                    MessageBox.Show("用户名已存在！");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox1.Focus();
                    
                }
               
            }
            
        }
        
        private void 注册_Load(object sender, EventArgs e)
        {
            this.textBox1.Focus();
            this.radioButton1.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
           
        }

        private void 注册_FormClosing(object sender, FormClosingEventArgs e)
        {
            登录 denglu = new 登录();
            denglu.Show();
            this.Hide();
        }
    }
}
