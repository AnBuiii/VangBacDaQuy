﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VangBacDaQuy.Class
{
    internal class Functions
    {
        public static SqlConnection con;

        //Kết nối cơ sở dữ liệu
        public static void Connect()
        {
            con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.VBDQConnection;
            if (con.State != ConnectionState.Open) { 
                con.Open();
                MessageBox.Show("Kết nối thành công");
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
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0) return true;
            else return false;
        }
    }
}