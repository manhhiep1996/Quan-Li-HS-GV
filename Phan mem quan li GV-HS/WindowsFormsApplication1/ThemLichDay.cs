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
    public partial class ThemLichDay : Form
    {
        public static string magv = string.Empty, tengv = string.Empty, monhoc = string.Empty;

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThemLichDay_Load(object sender, EventArgs e)
        {
            txbTen.Text = tengv;
            txbMH.Text = monhoc;
        }

        public ThemLichDay()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            string sql = "ThemLichDay ";
            SqlCommand com = new SqlCommand(sql, Login.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@magv", magv);
            com.Parameters.AddWithValue("@tenmh", monhoc);
            com.Parameters.AddWithValue("@lop", cboLop.Text);
            com.Parameters.AddWithValue("@nienkhoa", cboNienKhoa.Text);
            com.Parameters.AddWithValue("@namhoc", cboNH.Text);
            com.Parameters.AddWithValue("@hocki", cboHK.Text);
            com.Parameters.AddWithValue("@thoigian", txbLịchHoc.Text);
            com.Parameters.AddWithValue("@phonghoc", txbPhongHoc.Text);
            int count = com.ExecuteNonQuery();
            if (count > 0)
            {
                MessageBox.Show("Thêm thành công", "Thông báo");
            }
            else
                MessageBox.Show("Không thể thêm", "Thông báo");
        }
    }
}
