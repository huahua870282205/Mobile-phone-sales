using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace 手机销售系统
{
    class DB
    {
        public static string con = "server=(local);database='手机销售系统';uid='sjxs';pwd='123456'";
        public static SqlConnection sql = new SqlConnection(con);
        
    }
}
