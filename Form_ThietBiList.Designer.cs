namespace QLTB
{
    partial class Form_ThietBiList
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabThietBiList = new System.Windows.Forms.TabPage();
            this.btnDong = new Guna.UI2.WinForms.Guna2GradientButton();
            this.dtNgayNhap = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cboTinhTrang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboLoaiTB = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtViTri = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTenTB = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaTB = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnXemBaoTri = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnReload = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnXoa = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSua = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnThem = new Guna.UI2.WinForms.Guna2GradientButton();
            this.dgvThietBi = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.tabVeSinh = new System.Windows.Forms.TabPage();
            this.guna2TabControl1.SuspendLayout();
            this.tabThietBiList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThietBi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(59, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã thiết bị";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(59, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên thiết bị";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(59, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Loại thiết bị";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(58, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày nhập";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(59, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tình trạng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(59, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Vị trí";
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.guna2TabControl1.Controls.Add(this.tabThietBiList);
            this.guna2TabControl1.Controls.Add(this.tabReport);
            this.guna2TabControl1.Controls.Add(this.tabVeSinh);
            this.guna2TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.Location = new System.Drawing.Point(0, 0);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(1068, 596);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.TabIndex = 7;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.SelectedIndexChanged += new System.EventHandler(this.guna2TabControl1_SelectedIndexChanged);
            // 
            // tabThietBiList
            // 
            this.tabThietBiList.Controls.Add(this.btnDong);
            this.tabThietBiList.Controls.Add(this.dtNgayNhap);
            this.tabThietBiList.Controls.Add(this.cboTinhTrang);
            this.tabThietBiList.Controls.Add(this.cboLoaiTB);
            this.tabThietBiList.Controls.Add(this.txtViTri);
            this.tabThietBiList.Controls.Add(this.txtTenTB);
            this.tabThietBiList.Controls.Add(this.txtMaTB);
            this.tabThietBiList.Controls.Add(this.btnXemBaoTri);
            this.tabThietBiList.Controls.Add(this.btnReload);
            this.tabThietBiList.Controls.Add(this.btnXoa);
            this.tabThietBiList.Controls.Add(this.btnSua);
            this.tabThietBiList.Controls.Add(this.btnThem);
            this.tabThietBiList.Controls.Add(this.dgvThietBi);
            this.tabThietBiList.Controls.Add(this.label1);
            this.tabThietBiList.Controls.Add(this.label2);
            this.tabThietBiList.Controls.Add(this.label3);
            this.tabThietBiList.Controls.Add(this.label4);
            this.tabThietBiList.Controls.Add(this.label5);
            this.tabThietBiList.Controls.Add(this.label6);
            this.tabThietBiList.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabThietBiList.Location = new System.Drawing.Point(184, 4);
            this.tabThietBiList.Name = "tabThietBiList";
            this.tabThietBiList.Padding = new System.Windows.Forms.Padding(3);
            this.tabThietBiList.Size = new System.Drawing.Size(880, 588);
            this.tabThietBiList.TabIndex = 0;
            this.tabThietBiList.Text = "Danh sách thiết bị";
            this.tabThietBiList.UseVisualStyleBackColor = true;
            // 
            // btnDong
            // 
            this.btnDong.BorderRadius = 20;
            this.btnDong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDong.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDong.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(829, 6);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(45, 38);
            this.btnDong.TabIndex = 15;
            this.btnDong.Text = "X";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // dtNgayNhap
            // 
            this.dtNgayNhap.Checked = true;
            this.dtNgayNhap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(147)))), ((int)(((byte)(216)))));
            this.dtNgayNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtNgayNhap.Location = new System.Drawing.Point(179, 185);
            this.dtNgayNhap.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtNgayNhap.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtNgayNhap.Name = "dtNgayNhap";
            this.dtNgayNhap.Size = new System.Drawing.Size(232, 36);
            this.dtNgayNhap.TabIndex = 12;
            this.dtNgayNhap.Value = new System.DateTime(2025, 9, 10, 15, 43, 10, 572);
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
            "Đang sử dụng",
            "Cần bảo trì",
            "Hỏng",
            "Thanh lý"});
            this.cboTinhTrang.Location = new System.Drawing.Point(179, 239);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(232, 36);
            this.cboTinhTrang.TabIndex = 11;
            // 
            // cboLoaiTB
            // 
            this.cboLoaiTB.BackColor = System.Drawing.Color.Transparent;
            this.cboLoaiTB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLoaiTB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiTB.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLoaiTB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLoaiTB.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboLoaiTB.ItemHeight = 30;
            this.cboLoaiTB.Location = new System.Drawing.Point(179, 131);
            this.cboLoaiTB.Name = "cboLoaiTB";
            this.cboLoaiTB.Size = new System.Drawing.Size(232, 36);
            this.cboLoaiTB.TabIndex = 11;
            // 
            // txtViTri
            // 
            this.txtViTri.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtViTri.DefaultText = "";
            this.txtViTri.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtViTri.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtViTri.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtViTri.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtViTri.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtViTri.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtViTri.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtViTri.Location = new System.Drawing.Point(179, 293);
            this.txtViTri.Name = "txtViTri";
            this.txtViTri.PlaceholderText = "";
            this.txtViTri.SelectedText = "";
            this.txtViTri.Size = new System.Drawing.Size(232, 36);
            this.txtViTri.TabIndex = 10;
            // 
            // txtTenTB
            // 
            this.txtTenTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenTB.DefaultText = "";
            this.txtTenTB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenTB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenTB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenTB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenTB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenTB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenTB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenTB.Location = new System.Drawing.Point(179, 77);
            this.txtTenTB.Name = "txtTenTB";
            this.txtTenTB.PlaceholderText = "";
            this.txtTenTB.SelectedText = "";
            this.txtTenTB.Size = new System.Drawing.Size(232, 36);
            this.txtTenTB.TabIndex = 10;
            // 
            // txtMaTB
            // 
            this.txtMaTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaTB.DefaultText = "";
            this.txtMaTB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaTB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaTB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaTB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaTB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaTB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaTB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaTB.Location = new System.Drawing.Point(179, 23);
            this.txtMaTB.Name = "txtMaTB";
            this.txtMaTB.PlaceholderText = "";
            this.txtMaTB.SelectedText = "";
            this.txtMaTB.Size = new System.Drawing.Size(232, 36);
            this.txtMaTB.TabIndex = 10;
            // 
            // btnXemBaoTri
            // 
            this.btnXemBaoTri.BorderRadius = 20;
            this.btnXemBaoTri.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXemBaoTri.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXemBaoTri.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXemBaoTri.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXemBaoTri.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXemBaoTri.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXemBaoTri.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoTri.Location = new System.Drawing.Point(686, 163);
            this.btnXemBaoTri.Name = "btnXemBaoTri";
            this.btnXemBaoTri.Size = new System.Drawing.Size(124, 45);
            this.btnXemBaoTri.TabIndex = 9;
            this.btnXemBaoTri.Text = "Xem bảo trì";
            this.btnXemBaoTri.Click += new System.EventHandler(this.btnXemBaoTri_Click);
            // 
            // btnReload
            // 
            this.btnReload.BorderRadius = 20;
            this.btnReload.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReload.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReload.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReload.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReload.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReload.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.Location = new System.Drawing.Point(609, 234);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(124, 45);
            this.btnReload.TabIndex = 9;
            this.btnReload.Text = "Tải lại";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BorderRadius = 20;
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(534, 163);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(124, 45);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 20;
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(686, 90);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(124, 45);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 20;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(534, 90);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(124, 45);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvThietBi
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvThietBi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThietBi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThietBi.ColumnHeadersHeight = 4;
            this.dgvThietBi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThietBi.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvThietBi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvThietBi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThietBi.Location = new System.Drawing.Point(3, 353);
            this.dgvThietBi.Name = "dgvThietBi";
            this.dgvThietBi.RowHeadersVisible = false;
            this.dgvThietBi.Size = new System.Drawing.Size(874, 232);
            this.dgvThietBi.TabIndex = 7;
            this.dgvThietBi.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThietBi.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvThietBi.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvThietBi.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvThietBi.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvThietBi.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvThietBi.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThietBi.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvThietBi.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvThietBi.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvThietBi.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvThietBi.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThietBi.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvThietBi.ThemeStyle.ReadOnly = false;
            this.dgvThietBi.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThietBi.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThietBi.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvThietBi.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvThietBi.ThemeStyle.RowsStyle.Height = 22;
            this.dgvThietBi.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThietBi.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvThietBi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThietBi_CellClick);
            this.dgvThietBi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThietBi_CellDoubleClick);
            // 
            // tabReport
            // 
            this.tabReport.Location = new System.Drawing.Point(184, 4);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabReport.Size = new System.Drawing.Size(880, 588);
            this.tabReport.TabIndex = 1;
            this.tabReport.Text = "Báo cáo";
            this.tabReport.UseVisualStyleBackColor = true;
            this.tabReport.Click += new System.EventHandler(this.tabReport_Click);
            // 
            // tabVeSinh
            // 
            this.tabVeSinh.Location = new System.Drawing.Point(184, 4);
            this.tabVeSinh.Name = "tabVeSinh";
            this.tabVeSinh.Size = new System.Drawing.Size(880, 588);
            this.tabVeSinh.TabIndex = 2;
            this.tabVeSinh.Text = "Vệ sinh";
            this.tabVeSinh.UseVisualStyleBackColor = true;
            // 
            // Form_ThietBiList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 596);
            this.Controls.Add(this.guna2TabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_ThietBiList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.guna2TabControl1.ResumeLayout(false);
            this.tabThietBiList.ResumeLayout(false);
            this.tabThietBiList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThietBi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage tabThietBiList;
        private System.Windows.Forms.TabPage tabReport;
        private Guna.UI2.WinForms.Guna2DataGridView dgvThietBi;
        private Guna.UI2.WinForms.Guna2GradientButton btnThem;
        private Guna.UI2.WinForms.Guna2GradientButton btnXemBaoTri;
        private Guna.UI2.WinForms.Guna2GradientButton btnReload;
        private Guna.UI2.WinForms.Guna2GradientButton btnXoa;
        private Guna.UI2.WinForms.Guna2GradientButton btnSua;
        private Guna.UI2.WinForms.Guna2TextBox txtMaTB;
        private Guna.UI2.WinForms.Guna2TextBox txtViTri;
        private Guna.UI2.WinForms.Guna2TextBox txtTenTB;
        private Guna.UI2.WinForms.Guna2ComboBox cboTinhTrang;
        private Guna.UI2.WinForms.Guna2ComboBox cboLoaiTB;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtNgayNhap;
        private Guna.UI2.WinForms.Guna2GradientButton btnDong;
        private System.Windows.Forms.TabPage tabVeSinh;
    }
}

