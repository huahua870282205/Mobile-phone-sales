using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace 手机销售系统
{
    class DBcon
    {
        public static SqlConnection My_con;//连接对象
        public static string constr = "server=(local);database='手机销售系统';uid='sjxs';pwd='123456'";
    

        public static SqlConnection getcon()
        {
            My_con = new SqlConnection(constr);//连接对象实例化
            My_con.Open();
            return My_con;
        }
        public void con_close()
        {
            if (My_con.State == ConnectionState.Open)
            {
                My_con.Close();
                My_con.Dispose();

            }
        }

        public void executeUpdate(string SQLstr)
        {
            getcon();
            SqlCommand SQLcom = new SqlCommand(SQLstr, My_con);
            SQLcom.ExecuteNonQuery();
            SQLcom.Dispose();
            con_close();
        }
        public DataSet getDataSet(string SQLstr, string tableName)
        {
            getcon();
            SqlDataAdapter SQLda = new SqlDataAdapter(SQLstr, My_con);
            DataSet My_Dataset = new DataSet();
            SQLda.Fill(My_Dataset, tableName);
            con_close();
            return My_Dataset;
        }
        //public static SqlConnection My_con;
        //public static string ConStr = "server=(local);database='手机销售系统';uid='sjxs';pwd='123456'";
        //public static SqlConnection getcon()
        //{
        //    My_con = new SqlConnection(ConStr);
        //    My_con.Open();
        //    return My_con;
        //}
        //public void con_close()
        //{
        //    if(My_con.State==ConnectionState.Open)
        //    {
        //        My_con.Close();
        //        My_con.Dispose();

        //    }
        //}
        //public SqlDataReader executeQuery(string SqlStr)
        //{
        //    getcon();
        //    SqlCommand My_com = My_con.CreateCommand();
        //    My_com.CommandText = SqlStr;
        //    SqlDataReader My_read = My_com.ExecuteReader();
        //    return My_read;

        //}
        //public DataSet GetDataSet(string SQLstr,string tableName)
        //{
        //    getcon();
        //    SqlDataAdapter sqlData = new SqlDataAdapter(SQLstr,My_con);
        //    DataSet my_dataSet = new DataSet();
        //    sqlData.Fill(my_dataSet, tableName);
        //    con_close();
        //    return my_dataSet;


    }
    }

