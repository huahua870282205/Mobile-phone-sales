using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 手机销售系统
{
    public partial class 用户 : Form
    {
        public static string name;
        public 用户(string s)
        {
            InitializeComponent();
            label1.Text = s.ToString();
            name = label1.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 用户_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label2.Visible = true;
            label2.Text = "用户信息管理";
            label2.ForeColor = Color.Blue;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            label2.Visible = true;
            label2.Text = "用户信息管理";
            label2.ForeColor = Color.Blue;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string xs = label1.Text;
            xxgl xxgl = new xxgl(xs);
            xxgl.MdiParent = this;
            xxgl.Show();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            string xs = label1.Text;
            xxgl xxgl = new xxgl(xs);
            xxgl.MdiParent = this;
            xxgl.Show();
            //this.Hide();
        }

        private void 订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 切换账户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            登录 denglu = new 登录();
            denglu.Show();
            this.Hide();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 修改个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string xs = label1.Text;
            xxgl xxgl = new xxgl(xs);
            xxgl.MdiParent = this;
            xxgl.Show();

        }

        private void 公司介绍ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gsjs gsjs = new gsjs();
            gsjs.MdiParent = this;
            gsjs.Show();
        }

        private void 浏览商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LLSP lLSPS = new LLSP();
            lLSPS.MdiParent = this;
            lLSPS.Show();
            lLSPS.Dock = DockStyle.Fill;
        }

        private void 购物车ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GWC wC = new GWC();
            wC.MdiParent = this;
            wC.Show();
        }
    }
}
