namespace QLTB
{
    partial class UserControl_Report
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
            this.tabControlReport = new System.Windows.Forms.TabControl();
            this.tabCanBaoTri = new System.Windows.Forms.TabPage();
            this.lblAvgChiPhi = new System.Windows.Forms.Label();
            this.lblTongChiPhi = new System.Windows.Forms.Label();
            this.lblCountCanBaoTri = new System.Windows.Forms.Label();
            this.dgvCanBaoTri = new System.Windows.Forms.DataGridView();
            this.tabTongChiPhi = new System.Windows.Forms.TabPage();
            this.dgvTongChiPhi = new System.Windows.Forms.DataGridView();
            this.tabTopChiPhi = new System.Windows.Forms.TabPage();
            this.dgvTopChiPhi = new System.Windows.Forms.DataGridView();
            this.btnReloadTopChiPhi = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnExportTopChiPhi = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnReloadTongChiPhi = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnExportTongChiPhi = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnReloadCanBaoTri = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnExportCanBaoTri = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tabControlReport.SuspendLayout();
            this.tabCanBaoTri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanBaoTri)).BeginInit();
            this.tabTongChiPhi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongChiPhi)).BeginInit();
            this.tabTopChiPhi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopChiPhi)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlReport
            // 
            this.tabControlReport.Controls.Add(this.tabCanBaoTri);
            this.tabControlReport.Controls.Add(this.tabTongChiPhi);
            this.tabControlReport.Controls.Add(this.tabTopChiPhi);
            this.tabControlReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlReport.Location = new System.Drawing.Point(0, 0);
            this.tabControlReport.Name = "tabControlReport";
            this.tabControlReport.SelectedIndex = 0;
            this.tabControlReport.Size = new System.Drawing.Size(880, 588);
            this.tabControlReport.TabIndex = 1;
            // 
            // tabCanBaoTri
            // 
            this.tabCanBaoTri.Controls.Add(this.btnReloadCanBaoTri);
            this.tabCanBaoTri.Controls.Add(this.btnExportCanBaoTri);
            this.tabCanBaoTri.Controls.Add(this.lblAvgChiPhi);
            this.tabCanBaoTri.Controls.Add(this.lblTongChiPhi);
            this.tabCanBaoTri.Controls.Add(this.lblCountCanBaoTri);
            this.tabCanBaoTri.Controls.Add(this.dgvCanBaoTri);
            this.tabCanBaoTri.Location = new System.Drawing.Point(4, 22);
            this.tabCanBaoTri.Name = "tabCanBaoTri";
            this.tabCanBaoTri.Padding = new System.Windows.Forms.Padding(3);
            this.tabCanBaoTri.Size = new System.Drawing.Size(872, 562);
            this.tabCanBaoTri.TabIndex = 0;
            this.tabCanBaoTri.Text = "Cần bảo trì";
            this.tabCanBaoTri.UseVisualStyleBackColor = true;
            // 
            // lblAvgChiPhi
            // 
            this.lblAvgChiPhi.AutoSize = true;
            this.lblAvgChiPhi.Location = new System.Drawing.Point(676, 260);
            this.lblAvgChiPhi.Name = "lblAvgChiPhi";
            this.lblAvgChiPhi.Size = new System.Drawing.Size(35, 13);
            this.lblAvgChiPhi.TabIndex = 9;
            this.lblAvgChiPhi.Text = "label3";
            // 
            // lblTongChiPhi
            // 
            this.lblTongChiPhi.AutoSize = true;
            this.lblTongChiPhi.Location = new System.Drawing.Point(676, 186);
            this.lblTongChiPhi.Name = "lblTongChiPhi";
            this.lblTongChiPhi.Size = new System.Drawing.Size(35, 13);
            this.lblTongChiPhi.TabIndex = 8;
            this.lblTongChiPhi.Text = "label2";
            // 
            // lblCountCanBaoTri
            // 
            this.lblCountCanBaoTri.AutoSize = true;
            this.lblCountCanBaoTri.Location = new System.Drawing.Point(676, 219);
            this.lblCountCanBaoTri.Name = "lblCountCanBaoTri";
            this.lblCountCanBaoTri.Size = new System.Drawing.Size(35, 13);
            this.lblCountCanBaoTri.TabIndex = 7;
            this.lblCountCanBaoTri.Text = "label1";
            // 
            // dgvCanBaoTri
            // 
            this.dgvCanBaoTri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCanBaoTri.Location = new System.Drawing.Point(0, 0);
            this.dgvCanBaoTri.Name = "dgvCanBaoTri";
            this.dgvCanBaoTri.Size = new System.Drawing.Size(872, 150);
            this.dgvCanBaoTri.TabIndex = 0;
            this.dgvCanBaoTri.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCanBaoTri_CellClick);
            // 
            // tabTongChiPhi
            // 
            this.tabTongChiPhi.Controls.Add(this.btnReloadTongChiPhi);
            this.tabTongChiPhi.Controls.Add(this.btnExportTongChiPhi);
            this.tabTongChiPhi.Controls.Add(this.dgvTongChiPhi);
            this.tabTongChiPhi.Location = new System.Drawing.Point(4, 22);
            this.tabTongChiPhi.Name = "tabTongChiPhi";
            this.tabTongChiPhi.Padding = new System.Windows.Forms.Padding(3);
            this.tabTongChiPhi.Size = new System.Drawing.Size(872, 562);
            this.tabTongChiPhi.TabIndex = 1;
            this.tabTongChiPhi.Text = "Tổng chi phí";
            this.tabTongChiPhi.UseVisualStyleBackColor = true;
            // 
            // dgvTongChiPhi
            // 
            this.dgvTongChiPhi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTongChiPhi.Location = new System.Drawing.Point(3, 0);
            this.dgvTongChiPhi.Name = "dgvTongChiPhi";
            this.dgvTongChiPhi.Size = new System.Drawing.Size(872, 150);
            this.dgvTongChiPhi.TabIndex = 1;
            // 
            // tabTopChiPhi
            // 
            this.tabTopChiPhi.Controls.Add(this.btnReloadTopChiPhi);
            this.tabTopChiPhi.Controls.Add(this.btnExportTopChiPhi);
            this.tabTopChiPhi.Controls.Add(this.dgvTopChiPhi);
            this.tabTopChiPhi.Location = new System.Drawing.Point(4, 22);
            this.tabTopChiPhi.Name = "tabTopChiPhi";
            this.tabTopChiPhi.Size = new System.Drawing.Size(872, 562);
            this.tabTopChiPhi.TabIndex = 2;
            this.tabTopChiPhi.Text = "Top chi phí";
            this.tabTopChiPhi.UseVisualStyleBackColor = true;
            this.tabTopChiPhi.Click += new System.EventHandler(this.tabTopChiPhi_Click);
            // 
            // dgvTopChiPhi
            // 
            this.dgvTopChiPhi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopChiPhi.Location = new System.Drawing.Point(3, 0);
            this.dgvTopChiPhi.Name = "dgvTopChiPhi";
            this.dgvTopChiPhi.Size = new System.Drawing.Size(866, 150);
            this.dgvTopChiPhi.TabIndex = 1;
            // 
            // btnReloadTopChiPhi
            // 
            this.btnReloadTopChiPhi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReloadTopChiPhi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReloadTopChiPhi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReloadTopChiPhi.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReloadTopChiPhi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReloadTopChiPhi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReloadTopChiPhi.ForeColor = System.Drawing.Color.White;
            this.btnReloadTopChiPhi.Location = new System.Drawing.Point(416, 339);
            this.btnReloadTopChiPhi.Name = "btnReloadTopChiPhi";
            this.btnReloadTopChiPhi.Size = new System.Drawing.Size(124, 45);
            this.btnReloadTopChiPhi.TabIndex = 11;
            this.btnReloadTopChiPhi.Text = "Tải lại";
            this.btnReloadTopChiPhi.Click += new System.EventHandler(this.btnReloadTopChiPhi_Click);
            // 
            // btnExportTopChiPhi
            // 
            this.btnExportTopChiPhi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportTopChiPhi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportTopChiPhi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportTopChiPhi.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportTopChiPhi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportTopChiPhi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportTopChiPhi.ForeColor = System.Drawing.Color.White;
            this.btnExportTopChiPhi.Location = new System.Drawing.Point(264, 339);
            this.btnExportTopChiPhi.Name = "btnExportTopChiPhi";
            this.btnExportTopChiPhi.Size = new System.Drawing.Size(124, 45);
            this.btnExportTopChiPhi.TabIndex = 12;
            this.btnExportTopChiPhi.Text = "Xuất Excel";
            // 
            // btnReloadTongChiPhi
            // 
            this.btnReloadTongChiPhi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReloadTongChiPhi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReloadTongChiPhi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReloadTongChiPhi.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReloadTongChiPhi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReloadTongChiPhi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReloadTongChiPhi.ForeColor = System.Drawing.Color.White;
            this.btnReloadTongChiPhi.Location = new System.Drawing.Point(448, 363);
            this.btnReloadTongChiPhi.Name = "btnReloadTongChiPhi";
            this.btnReloadTongChiPhi.Size = new System.Drawing.Size(124, 45);
            this.btnReloadTongChiPhi.TabIndex = 13;
            this.btnReloadTongChiPhi.Text = "Tải lại";
            this.btnReloadTongChiPhi.Click += new System.EventHandler(this.btnReloadTongChiPhi_Click);
            // 
            // btnExportTongChiPhi
            // 
            this.btnExportTongChiPhi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportTongChiPhi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportTongChiPhi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportTongChiPhi.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportTongChiPhi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportTongChiPhi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportTongChiPhi.ForeColor = System.Drawing.Color.White;
            this.btnExportTongChiPhi.Location = new System.Drawing.Point(296, 363);
            this.btnExportTongChiPhi.Name = "btnExportTongChiPhi";
            this.btnExportTongChiPhi.Size = new System.Drawing.Size(124, 45);
            this.btnExportTongChiPhi.TabIndex = 14;
            this.btnExportTongChiPhi.Text = "Xuất Excel";
            // 
            // btnReloadCanBaoTri
            // 
            this.btnReloadCanBaoTri.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReloadCanBaoTri.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReloadCanBaoTri.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReloadCanBaoTri.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReloadCanBaoTri.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReloadCanBaoTri.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReloadCanBaoTri.ForeColor = System.Drawing.Color.White;
            this.btnReloadCanBaoTri.Location = new System.Drawing.Point(335, 350);
            this.btnReloadCanBaoTri.Name = "btnReloadCanBaoTri";
            this.btnReloadCanBaoTri.Size = new System.Drawing.Size(124, 45);
            this.btnReloadCanBaoTri.TabIndex = 13;
            this.btnReloadCanBaoTri.Text = "Tải lại";
            this.btnReloadCanBaoTri.Click += new System.EventHandler(this.btnReloadCanBaoTri_Click);
            // 
            // btnExportCanBaoTri
            // 
            this.btnExportCanBaoTri.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportCanBaoTri.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportCanBaoTri.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportCanBaoTri.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportCanBaoTri.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportCanBaoTri.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportCanBaoTri.ForeColor = System.Drawing.Color.White;
            this.btnExportCanBaoTri.Location = new System.Drawing.Point(183, 350);
            this.btnExportCanBaoTri.Name = "btnExportCanBaoTri";
            this.btnExportCanBaoTri.Size = new System.Drawing.Size(124, 45);
            this.btnExportCanBaoTri.TabIndex = 14;
            this.btnExportCanBaoTri.Text = "Xuất Excel";
            // 
            // UserControl_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlReport);
            this.Name = "UserControl_Report";
            this.Size = new System.Drawing.Size(880, 588);
            this.Load += new System.EventHandler(this.UserControl_Report_Load);
            this.tabControlReport.ResumeLayout(false);
            this.tabCanBaoTri.ResumeLayout(false);
            this.tabCanBaoTri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanBaoTri)).EndInit();
            this.tabTongChiPhi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongChiPhi)).EndInit();
            this.tabTopChiPhi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopChiPhi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlReport;
        private System.Windows.Forms.TabPage tabCanBaoTri;
        private System.Windows.Forms.Label lblAvgChiPhi;
        private System.Windows.Forms.Label lblTongChiPhi;
        private System.Windows.Forms.Label lblCountCanBaoTri;
        private System.Windows.Forms.DataGridView dgvCanBaoTri;
        private System.Windows.Forms.TabPage tabTongChiPhi;
        private System.Windows.Forms.DataGridView dgvTongChiPhi;
        private System.Windows.Forms.TabPage tabTopChiPhi;
        private System.Windows.Forms.DataGridView dgvTopChiPhi;
        private Guna.UI2.WinForms.Guna2GradientButton btnReloadTopChiPhi;
        private Guna.UI2.WinForms.Guna2GradientButton btnExportTopChiPhi;
        private Guna.UI2.WinForms.Guna2GradientButton btnReloadTongChiPhi;
        private Guna.UI2.WinForms.Guna2GradientButton btnExportTongChiPhi;
        private Guna.UI2.WinForms.Guna2GradientButton btnReloadCanBaoTri;
        private Guna.UI2.WinForms.Guna2GradientButton btnExportCanBaoTri;
    }
}
