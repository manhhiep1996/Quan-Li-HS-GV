using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class LichDay : Form
    {
        public static string magv = string.Empty, tengv = string.Empty, bomon = string.Empty;
        string tenmh, tenlop, nienkhoa, namhoc, hocki, phonghoc, lichhoc;

        private void LichDay_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvLichDay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tenmh = Convert.ToString(dgvLichDay.CurrentRow.Cells["TenMH"].Value);
            tenlop = Convert.ToString(dgvLichDay.CurrentRow.Cells["TenLop"].Value);
            nienkhoa = Convert.ToString(dgvLichDay.CurrentRow.Cells["KhoaHoc"].Value);
            namhoc = Convert.ToString(dgvLichDay.CurrentRow.Cells["NamHoc"].Value);
            hocki = Convert.ToString(dgvLichDay.CurrentRow.Cells["HocKi"].Value);
            phonghoc = Convert.ToString(dgvLichDay.CurrentRow.Cells["PhongHoc"].Value);
            lichhoc = Convert.ToString(dgvLichDay.CurrentRow.Cells["ThoiGian"].Value);
        }

        public LichDay()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            string sql = "XemLichDay ";
            SqlCommand com = new SqlCommand(sql, Login.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@magv", magv);

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvLichDay.DataSource = dt;
        }
        private void dgvLichDay_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvLichDay.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void dgvLichDay_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
             if (e.KeyValue == 46)
            {
                if (MessageBox.Show("Bạn muốn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sql = "XoaLichDay ";
                    SqlCommand com = new SqlCommand(sql, Login.con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@magv", magv);
                    com.Parameters.AddWithValue("@lop", tenlop);
                    com.Parameters.AddWithValue("@nienkhoa", nienkhoa);
                    com.Parameters.AddWithValue("@namhoc", namhoc);
                    com.Parameters.AddWithValue("@hocki", hocki);
                    com.Parameters.AddWithValue("@phonghoc", phonghoc);
                    com.Parameters.AddWithValue("@thoigian", lichhoc);
                    int count = com.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo");
                        LoadData();
                    }
                    else
                        MessageBox.Show("Không thể xóa", "Thông báo");
                }
            }
             if (e.KeyValue == 13)
             {
                 string sql = "SuaLichDay ";
                 SqlCommand com = new SqlCommand(sql, Login.con);
                 com.CommandType = CommandType.StoredProcedure;
                 com.Parameters.AddWithValue("@magv", magv);
                 com.Parameters.AddWithValue("@lop", tenlop);
                 com.Parameters.AddWithValue("@nienkhoa", nienkhoa);
                 com.Parameters.AddWithValue("@namhoc", namhoc);
                 com.Parameters.AddWithValue("@hocki", hocki);
                 com.Parameters.AddWithValue("@phonghoc", phonghoc);
                 com.Parameters.AddWithValue("@thoigian", lichhoc);
                 int count = com.ExecuteNonQuery();
                 if (count > 0)
                 {
                     MessageBox.Show("Xóa thành công", "Thông báo");
                 }
                 else
                     MessageBox.Show("Không thể xóa", "Thông báo");
             }
             LoadData();
        }

        private void thêmMiớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemLichDay.magv = magv;
            ThemLichDay.monhoc = bomon;
            ThemLichDay.tengv = tengv;
            ThemLichDay add = new ThemLichDay();
            add.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
