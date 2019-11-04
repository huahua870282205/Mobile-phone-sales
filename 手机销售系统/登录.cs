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
    public partial class 登录 : Form
    {
        public 登录()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.Focus();
            this.radioButton2.Checked = true;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked)
            {
                string constr = "server=(local); database='手机销售系统'; uid='sjxs';pwd='123456'";
                SqlConnection sqlConnection = new SqlConnection(constr);
                sqlConnection.Open();
                string comm = "select 管理员工号,管理员密码 from 管理员表 where 管理员工号='"+ textBox1.Text +"' and 管理员密码='"+ textBox2.Text+"' ";
                SqlCommand sqlCommand = new SqlCommand(comm, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if(!sqlDataReader.Read())
                {
                    if(this.textBox1.Text==""||this.textBox2.Text=="")
                    {
                        MessageBox.Show("用户名或密码不能为空!");
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误！");
                        this.textBox1.Clear();
                        this.textBox1.Clear();
                        textBox1.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("登录成功！");
                    管理员 guanliyuan = new 管理员();
                    guanliyuan.Show();
                    this.Hide();
                }
                sqlConnection.Close();
                //if (this.textBox1.Text == "" || this.textBox2.Text == "")
                //{
                //    MessageBox.Show("账户或密码不为空");
                //}
                //if (this.textBox1.Text == "admin" && this.textBox2.Text == "admin")
                //{
                //    MessageBox.Show("管理员登录成功");
                //    管理员 guanliyuan = new 管理员();
                //    guanliyuan.Show();
                //    this.Hide();
                    
                //}
            }
            else
            {
                string con = "server=(local);database='手机销售系统';uid='sjxs';pwd='123456'";
                string com = "select 用户名,用户密码 from 用户表 where 用户名='" + textBox1.Text + "'and 用户密码='"+textBox2.Text+"'";
                SqlConnection connect = new SqlConnection(con);
                connect.Open();
                SqlCommand cmd= new SqlCommand(com,connect);
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    if (this.textBox1.Text == "" || this.textBox2.Text == "")
                    {
                        MessageBox.Show("账户或密码不为空");
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误");
                        this.textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    }
                }
                else {
                    MessageBox.Show("用户登录成功！");
                    string yonghu = this.textBox1.Text;
                    用户 yonghus= new 用户(yonghu);
                    yonghus.Show();
                    
                    this.Hide();
                }
                connect.Close();
    }
        }

        public static string yonghu;
        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox2.Clear();
            this.textBox1.Clear();
            this.textBox1.Focus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            注册 zhuce = new 注册();
            zhuce.Show();
            this.Hide();
        }


        private void 登录_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
