using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string maMHChon = "";
        private readonly string strConn = @"Server=.\SQLEXPRESS;Database=DuLieu;Integrated Security=True;TrustServerCertificate=true;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnThoat.Enabled = true;

            LoadData();
        }

        private void dataGridView1_CellClick(
    object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            
            maMHChon = row.Cells["Mã Môn Học"].Value.ToString();
            txtMa.Text = maMHChon;
            txtMonHoc.Text = row.Cells["Tên Môn Học"].Value.ToString();
            txtTinChi.Text = row.Cells["Số tín chỉ"].Value.ToString();

            txtMa.ReadOnly = true;

            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            btnThem.Enabled = false;
        }
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    string query = @"SELECT
                                MaMonHoc AS [Mã Môn Học],
                                TenMonHoc AS [Tên Môn Học],
                                SoTinChi AS [Số tín chỉ]
                             FROM MonHoc";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.AutoGenerateColumns = true;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dt;

                        dataGridView1.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.Fill;

                        dataGridView1.ReadOnly = true;
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.SelectionMode =
                            DataGridViewSelectionMode.FullRowSelect;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi tải dữ liệu: " + ex.Message,
                    "Thông báo lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maMH = txtMa.Text.Trim();
            string tenMH = txtMonHoc.Text.Trim();
            string tinchi = txtTinChi.Text.Trim();

            if (string.IsNullOrWhiteSpace(maMH) ||
                string.IsNullOrWhiteSpace(tenMH) ||
                string.IsNullOrWhiteSpace(tinchi))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin môn học!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(tinchi, out int soTinChi) || soTinChi <= 0)
            {
                MessageBox.Show(
                    "Số tín chỉ phải là số nguyên dương!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtTinChi.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();

                    string checkSql =
                        "SELECT COUNT(*) FROM MonHoc WHERE MaMonHoc = @MaMH";

                    using (SqlCommand cmdCheck = new SqlCommand(checkSql, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@MaMH", maMH);

                        int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "Mã môn học đã tồn tại!",
                                "Cảnh báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            txtMa.Focus();
                            return;
                        }
                    }

                    string insertSql = @"
                INSERT INTO MonHoc (MaMonHoc, TenMonHoc, SoTinChi)
                VALUES (@MaMH, @TenMH, @SoTinChi)";

                    using (SqlCommand cmdInsert =
                           new SqlCommand(insertSql, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@MaMH", maMH);
                        cmdInsert.Parameters.AddWithValue("@TenMH", tenMH);
                        cmdInsert.Parameters.AddWithValue("@SoTinChi", soTinChi);

                        cmdInsert.ExecuteNonQuery();
                    }
                }

                LoadData();
                clearInputs();

                btnThem.Enabled = true;

                MessageBox.Show(
                    "Thêm môn học thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi thêm môn học: " + ex.Message,
                    "Thông báo lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void clearInputs()
        {
            txtMa.Clear();
            

            txtMa.Focus();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string tenMH = txtMonHoc.Text.Trim();
            string tinchi = txtTinChi.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenMH) ||
                string.IsNullOrWhiteSpace(tinchi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin môn học!");
                return;
            }

            if (!int.TryParse(tinchi, out int soTinChi) || soTinChi <= 0)
            {
                MessageBox.Show("Số tín chỉ phải là số nguyên dương!");
                txtTinChi.Focus();
                return;
            }

            if (string.IsNullOrEmpty(maMHChon))
            {
                MessageBox.Show("Vui lòng chọn môn học cần sửa!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();

                    string sql = @"
                UPDATE MonHoc
                SET TenMonHoc = @TenMH,
                    SoTinChi = @SoTinChi
                WHERE MaMonHoc = @MaMH";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaMH", maMHChon);
                        cmd.Parameters.AddWithValue("@TenMH", tenMH);
                        cmd.Parameters.AddWithValue("@SoTinChi", soTinChi);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Sửa môn học thành công!");

                            LoadData();
                            clearInputs();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy môn học cần sửa!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa môn học: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maMHChon))
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa!");
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa môn học " + maMHChon + " không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();

                    string sql = "DELETE FROM MonHoc WHERE MaMonHoc = @MaMH";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaMH", maMHChon);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Xóa môn học thành công!");

                            LoadData();
                            clearInputs();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy môn học cần xóa!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi xóa môn học: " + ex.Message +
                    "\nCó thể môn học đang được sử dụng ở bảng dữ liệu khác.");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "bạn có muốn thoát không", "xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar
                != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            if((e.KeyChar =='.' || e.KeyChar==',')&&(txtTinChi.Text.Contains('.')||txtTinChi.Text.Contains(',')))
            {
                e.Handled=true;
            }
        }
    }
}
