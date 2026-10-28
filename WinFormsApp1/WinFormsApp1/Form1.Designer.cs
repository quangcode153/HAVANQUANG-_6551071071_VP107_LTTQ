namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            txtMonHoc = new TextBox();
            txtTinChi = new TextBox();
            txtMa = new TextBox();
            label = new Label();
            MonHoc = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnThoat = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            btnSua = new Button();
            groupBox3 = new GroupBox();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtMonHoc);
            groupBox1.Controls.Add(txtTinChi);
            groupBox1.Controls.Add(txtMa);
            groupBox1.Controls.Add(label);
            groupBox1.Controls.Add(MonHoc);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 284);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin môn học";
            // 
            // txtMonHoc
            // 
            txtMonHoc.Location = new Point(16, 136);
            txtMonHoc.Name = "txtMonHoc";
            txtMonHoc.Size = new Size(171, 27);
            txtMonHoc.TabIndex = 6;
            // 
            // txtTinChi
            // 
            txtTinChi.Location = new Point(16, 220);
            txtTinChi.Name = "txtTinChi";
            txtTinChi.Size = new Size(171, 27);
            txtTinChi.TabIndex = 5;
            txtTinChi.KeyPress += textBox2_KeyPress;
            // 
            // txtMa
            // 
            txtMa.Location = new Point(16, 56);
            txtMa.Name = "txtMa";
            txtMa.Size = new Size(171, 27);
            txtMa.TabIndex = 4;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(16, 180);
            label.Name = "label";
            label.Size = new Size(76, 20);
            label.TabIndex = 2;
            label.Text = "Số Tín chỉ:";
            // 
            // MonHoc
            // 
            MonHoc.AutoSize = true;
            MonHoc.Location = new Point(16, 100);
            MonHoc.Name = "MonHoc";
            MonHoc.Size = new Size(100, 20);
            MonHoc.TabIndex = 1;
            MonHoc.Text = "Tên Môn Học:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 23);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã Môn Học:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnThoat);
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(btnThem);
            groupBox2.Controls.Add(btnSua);
            groupBox2.Location = new Point(12, 302);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 151);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(134, 85);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 43);
            btnThoat.TabIndex = 10;
            btnThoat.Text = "X Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(6, 85);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 43);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(6, 17);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 46);
            btnThem.TabIndex = 8;
            btnThem.Text = "+Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(134, 17);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 46);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridView1);
            groupBox3.Location = new Point(280, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(522, 441);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "Danh sách môn học ";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 23);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(392, 140);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtMonHoc;
        private TextBox txtTinChi;
        private TextBox txtMa;
        private Label label;
        private Label MonHoc;
        private Label label1;
        private GroupBox groupBox2;
        private Button btnThem;
        private Button btnSua;
        private Button btnThoat;
        private Button btnXoa;
        private GroupBox groupBox3;
        private DataGridView dataGridView1;
    }
}
