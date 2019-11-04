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
    public partial class 管理员 : Form
    {
        public 管理员()
        {
            InitializeComponent();
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            yhgl yhgls = new yhgl();
            yhgls.MdiParent = this;
            yhgls.Show();
            yhgls.Dock = DockStyle.Fill;
        }

        private void 切换账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            登录 denglu = new 登录();
            denglu.Show();
            this.Hide();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 手机管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            手机信息管理 shouji = new 手机信息管理();
            shouji.MdiParent = this;
            shouji.Show();
            shouji.Dock = DockStyle.Fill;

        }

        private void 订单管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DDGL dGL = new DDGL();
            dGL.MdiParent = this;
            dGL.Show();
           
        }
    }
}
