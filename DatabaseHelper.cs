﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTB
{
    internal class DatabaseHelper
    {
        private static readonly string connectionString = "Data Source=.; Database=UserManagement;" +
                                                            "user id=sa;" + "password=1234;" +
                                                            "MultipleActiveResultSets=True;" + "TrustServerCertificate=True;";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        // 🔹 Hàm thực hiện truy vấn SELECT (trả về DataTable)
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        // 🔹 Hàm thực hiện INSERT, UPDATE, DELETE (trả về số dòng bị ảnh hưởng)
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            //using (SqlConnection conn = GetConnection())
            //{
            //    conn.Open();
            //    using (SqlCommand cmd = new SqlCommand(query, conn))
            //    {
            //        if (parameters != null)
            //            cmd.Parameters.AddRange(parameters);
            //        return cmd.ExecuteNonQuery();
            //    }
            //}
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực thi câu lệnh SQL: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // 🔹 Hàm thực hiện truy vấn trả về một giá trị duy nhất (ví dụ: COUNT, SUM, MAX, MIN)
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
