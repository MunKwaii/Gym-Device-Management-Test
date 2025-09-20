namespace QLTB
{
    partial class UserControl_VeSinh
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabTinhTrangVeSinh = new System.Windows.Forms.TabPage();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2GradientButton();
            this.dtNgayVeSinh = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCapNhap = new Guna.UI2.WinForms.Guna2GradientButton();
            this.cboTinhTrang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvTinhTrangVeSinh = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTinhTrangVeSinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTinhTrangVeSinh)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTinhTrangVeSinh
            // 
            this.tabTinhTrangVeSinh.Controls.Add(this.txtSearch);
            this.tabTinhTrangVeSinh.Controls.Add(this.btnSearch);
            this.tabTinhTrangVeSinh.Controls.Add(this.dtNgayVeSinh);
            this.tabTinhTrangVeSinh.Controls.Add(this.label2);
            this.tabTinhTrangVeSinh.Controls.Add(this.btnCapNhap);
            this.tabTinhTrangVeSinh.Controls.Add(this.cboTinhTrang);
            this.tabTinhTrangVeSinh.Controls.Add(this.dgvTinhTrangVeSinh);
            this.tabTinhTrangVeSinh.Controls.Add(this.label1);
            this.tabTinhTrangVeSinh.Location = new System.Drawing.Point(4, 26);
            this.tabTinhTrangVeSinh.Name = "tabTinhTrangVeSinh";
            this.tabTinhTrangVeSinh.Padding = new System.Windows.Forms.Padding(3);
            this.tabTinhTrangVeSinh.Size = new System.Drawing.Size(864, 528);
            this.tabTinhTrangVeSinh.TabIndex = 1;
            this.tabTinhTrangVeSinh.Text = "Tình trạng vệ sinh";
            this.tabTinhTrangVeSinh.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(209, 261);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(360, 36);
            this.txtSearch.TabIndex = 30;
            // 
            // btnSearch
            // 
            this.btnSearch.BorderRadius = 20;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(630, 257);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 47);
            this.btnSearch.TabIndex = 29;
            this.btnSearch.Text = "🔍";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtNgayVeSinh
            // 
            this.dtNgayVeSinh.Checked = true;
            this.dtNgayVeSinh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(147)))), ((int)(((byte)(216)))));
            this.dtNgayVeSinh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtNgayVeSinh.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtNgayVeSinh.Location = new System.Drawing.Point(275, 393);
            this.dtNgayVeSinh.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtNgayVeSinh.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtNgayVeSinh.Name = "dtNgayVeSinh";
            this.dtNgayVeSinh.Size = new System.Drawing.Size(232, 36);
            this.dtNgayVeSinh.TabIndex = 28;
            this.dtNgayVeSinh.Value = new System.DateTime(2025, 9, 10, 15, 43, 10, 572);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(123, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 21);
            this.label2.TabIndex = 27;
            this.label2.Text = "Ngày vệ sinh";
            // 
            // btnCapNhap
            // 
            this.btnCapNhap.BorderRadius = 20;
            this.btnCapNhap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCapNhap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCapNhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCapNhap.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCapNhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCapNhap.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.btnCapNhap.ForeColor = System.Drawing.Color.White;
            this.btnCapNhap.Location = new System.Drawing.Point(592, 358);
            this.btnCapNhap.Name = "btnCapNhap";
            this.btnCapNhap.Size = new System.Drawing.Size(124, 45);
            this.btnCapNhap.TabIndex = 26;
            this.btnCapNhap.Text = "Cập nhập";
            this.btnCapNhap.Click += new System.EventHandler(this.btnCapNhap_Click);
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.BackColor = System.Drawing.Color.Transparent;
            this.cboTinhTrang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinhTrang.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTinhTrang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTinhTrang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTinhTrang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTinhTrang.ItemHeight = 30;
            this.cboTinhTrang.Items.AddRange(new object[] {
            "Sạch",
            "Bẩn",
            "Đang vệ sinh"});
            this.cboTinhTrang.Location = new System.Drawing.Point(275, 329);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(232, 36);
            this.cboTinhTrang.TabIndex = 25;
            // 
            // dgvTinhTrangVeSinh
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dgvTinhTrangVeSinh.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTinhTrangVeSinh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvTinhTrangVeSinh.ColumnHeadersHeight = 4;
            this.dgvTinhTrangVeSinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTinhTrangVeSinh.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvTinhTrangVeSinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTinhTrangVeSinh.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTinhTrangVeSinh.Location = new System.Drawing.Point(3, 3);
            this.dgvTinhTrangVeSinh.Name = "dgvTinhTrangVeSinh";
            this.dgvTinhTrangVeSinh.RowHeadersVisible = false;
            this.dgvTinhTrangVeSinh.Size = new System.Drawing.Size(858, 232);
            this.dgvTinhTrangVeSinh.TabIndex = 21;
            this.dgvTinhTrangVeSinh.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTinhTrangVeSinh.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTinhTrangVeSinh.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTinhTrangVeSinh.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTinhTrangVeSinh.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTinhTrangVeSinh.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTinhTrangVeSinh.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTinhTrangVeSinh.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTinhTrangVeSinh.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTinhTrangVeSinh.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvTinhTrangVeSinh.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTinhTrangVeSinh.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTinhTrangVeSinh.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvTinhTrangVeSinh.ThemeStyle.ReadOnly = false;
            this.dgvTinhTrangVeSinh.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTinhTrangVeSinh.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTinhTrangVeSinh.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvTinhTrangVeSinh.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTinhTrangVeSinh.ThemeStyle.RowsStyle.Height = 22;
            this.dgvTinhTrangVeSinh.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTinhTrangVeSinh.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTinhTrangVeSinh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTinhTrangVeSinh_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(123, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 21);
            this.label1.TabIndex = 22;
            this.label1.Text = "Tình trạng mới";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTinhTrangVeSinh);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(872, 558);
            this.tabControl1.TabIndex = 0;
            // 
            // UserControl_VeSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UserControl_VeSinh";
            this.Size = new System.Drawing.Size(872, 558);
            this.Load += new System.EventHandler(this.UserControl_VeSinh_Load);
            this.tabTinhTrangVeSinh.ResumeLayout(false);
            this.tabTinhTrangVeSinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTinhTrangVeSinh)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabTinhTrangVeSinh;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtNgayVeSinh;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2GradientButton btnCapNhap;
        private Guna.UI2.WinForms.Guna2ComboBox cboTinhTrang;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTinhTrangVeSinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2GradientButton btnSearch;
    }
}
