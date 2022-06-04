using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace VangBacDaQuy.Class
{
    internal class Functions
    {
        public static SqlConnection con;
        public static string User; 
        //Kết nối cơ sở dữ liệu
        public static void Connect()
        {
            con = new SqlConnection();

            string str = Application.StartupPath;
            str = str.Substring(0, str.IndexOf("VangBacDaQuy")) + @"VangBacDaQuy\VBDQ.mdf";
            
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+str+";Integrated Security=True;Connect Timeout=30";
            //con.ConnectionString = Properties.Settings.Default.VBDQConnection;

            if (con.State != ConnectionState.Open) { 
                con.Open();
                //MessageBox.Show("Kết nối thành công");
            }
            else
            {
                MessageBox.Show("Kết nối không thành công");
            }
        }
        //Ngắt kết nối cơ sở dữ liệu
        public static void Disconnect()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
                con = null;
            }
        }
        //Select dữ liệu 
        public static DataTable GetDataToDataTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            adapter.Fill(dt);
            return dt;
        }
        public static Chart GetDataToChart(string sql, Chart ct, string xValue, string yValue, bool isRound)
        {
            
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            ct.DataSource = ds;
            ct.Series[yValue].XValueMember = xValue;
            ct.Series[yValue].YValueMembers = yValue;
            if(isRound) ct.Series[0].ChartType = SeriesChartType.Pie;
            return ct;
            
        }

        //Insert, Update, Delete
        public static void RunSQL(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            } catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL: \n" + ex.ToString().Substring(0, ex.ToString().IndexOf('\n')));
            }
            cmd.Dispose();
            cmd = null;
        }
        //Kiểm tra quyền hạn
        public static bool CheckPermission(String maChucNang)
        {
            String sql = "select PHANQUYEN.MACHUCNANG as MACHUCNANG from PHANQUYEN, NHOMNGUOIDUNG, NGUOIDUNG where NGUOIDUNG.MANHOM = NHOMNGUOIDUNG.MANHOM and NHOMNGUOIDUNG.MANHOM = PHANQUYEN.MANHOM and NGUOIDUNG.TENDANGNHAP =  '" + User + "' and MACHUCNANG = '" + maChucNang +"'" ;
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0) return true;
            else return false;
        }
        //Kiểm tra khóa chính
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0) return true;
            else return false;
        }
        //Fill Combobox
        public static void FillCombo(string sql, ComboBox cb, string ma, string ten)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cb.DataSource = table;
            cb.ValueMember = ma;
            cb.DisplayMember = ten;
        }
        //Lấy dữ liệu từ lệnh sql
        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }
        
    }
}
