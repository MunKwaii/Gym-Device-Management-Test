namespace QLTB
{
    partial class Form_Report
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
            this.tabControlReport = new System.Windows.Forms.TabControl();
            this.tabCanBaoTri = new System.Windows.Forms.TabPage();
            this.btnReloadCanBaoTri = new System.Windows.Forms.Button();
            this.btnExportCanBaoTri = new System.Windows.Forms.Button();
            this.dgvCanBaoTri = new System.Windows.Forms.DataGridView();
            this.tabTongChiPhi = new System.Windows.Forms.TabPage();
            this.btnReloadTongChiPhi = new System.Windows.Forms.Button();
            this.btnExportTongChiPhi = new System.Windows.Forms.Button();
            this.dgvTongChiPhi = new System.Windows.Forms.DataGridView();
            this.tabTopChiPhi = new System.Windows.Forms.TabPage();
            this.btnReloadTopChiPhi = new System.Windows.Forms.Button();
            this.btnExportTopChiPhi = new System.Windows.Forms.Button();
            this.dgvTopChiPhi = new System.Windows.Forms.DataGridView();
            this.tabThongKeNhanh = new System.Windows.Forms.TabPage();
            this.lblCountCanBaoTri = new System.Windows.Forms.Label();
            this.lblAvgChiPhi = new System.Windows.Forms.Label();
            this.lblTongChiPhi = new System.Windows.Forms.Label();
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
            this.tabControlReport.Controls.Add(this.tabThongKeNhanh);
            this.tabControlReport.Location = new System.Drawing.Point(-2, 12);
            this.tabControlReport.Name = "tabControlReport";
            this.tabControlReport.SelectedIndex = 0;
            this.tabControlReport.Size = new System.Drawing.Size(798, 357);
            this.tabControlReport.TabIndex = 0;
            // 
            // tabCanBaoTri
            // 
            this.tabCanBaoTri.Controls.Add(this.lblAvgChiPhi);
            this.tabCanBaoTri.Controls.Add(this.lblTongChiPhi);
            this.tabCanBaoTri.Controls.Add(this.lblCountCanBaoTri);
            this.tabCanBaoTri.Controls.Add(this.btnReloadCanBaoTri);
            this.tabCanBaoTri.Controls.Add(this.btnExportCanBaoTri);
            this.tabCanBaoTri.Controls.Add(this.dgvCanBaoTri);
            this.tabCanBaoTri.Location = new System.Drawing.Point(4, 22);
            this.tabCanBaoTri.Name = "tabCanBaoTri";
            this.tabCanBaoTri.Padding = new System.Windows.Forms.Padding(3);
            this.tabCanBaoTri.Size = new System.Drawing.Size(790, 331);
            this.tabCanBaoTri.TabIndex = 0;
            this.tabCanBaoTri.Text = "Can bao tri";
            this.tabCanBaoTri.UseVisualStyleBackColor = true;
            // 
            // btnReloadCanBaoTri
            // 
            this.btnReloadCanBaoTri.Location = new System.Drawing.Point(349, 278);
            this.btnReloadCanBaoTri.Name = "btnReloadCanBaoTri";
            this.btnReloadCanBaoTri.Size = new System.Drawing.Size(75, 23);
            this.btnReloadCanBaoTri.TabIndex = 6;
            this.btnReloadCanBaoTri.Text = "reload";
            this.btnReloadCanBaoTri.UseVisualStyleBackColor = true;
            this.btnReloadCanBaoTri.Click += new System.EventHandler(this.btnReloadCanBaoTri_Click);
            // 
            // btnExportCanBaoTri
            // 
            this.btnExportCanBaoTri.Location = new System.Drawing.Point(122, 278);
            this.btnExportCanBaoTri.Name = "btnExportCanBaoTri";
            this.btnExportCanBaoTri.Size = new System.Drawing.Size(75, 23);
            this.btnExportCanBaoTri.TabIndex = 1;
            this.btnExportCanBaoTri.Text = "Xuat excel";
            this.btnExportCanBaoTri.UseVisualStyleBackColor = true;
            // 
            // dgvCanBaoTri
            // 
            this.dgvCanBaoTri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCanBaoTri.Location = new System.Drawing.Point(3, 33);
            this.dgvCanBaoTri.Name = "dgvCanBaoTri";
            this.dgvCanBaoTri.Size = new System.Drawing.Size(781, 150);
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
            this.tabTongChiPhi.Size = new System.Drawing.Size(790, 331);
            this.tabTongChiPhi.TabIndex = 1;
            this.tabTongChiPhi.Text = "Tong chi phi";
            this.tabTongChiPhi.UseVisualStyleBackColor = true;
            // 
            // btnReloadTongChiPhi
            // 
            this.btnReloadTongChiPhi.Location = new System.Drawing.Point(420, 280);
            this.btnReloadTongChiPhi.Name = "btnReloadTongChiPhi";
            this.btnReloadTongChiPhi.Size = new System.Drawing.Size(75, 23);
            this.btnReloadTongChiPhi.TabIndex = 8;
            this.btnReloadTongChiPhi.Text = "reload";
            this.btnReloadTongChiPhi.UseVisualStyleBackColor = true;
            this.btnReloadTongChiPhi.Click += new System.EventHandler(this.btnReloadTongChiPhi_Click);
            // 
            // btnExportTongChiPhi
            // 
            this.btnExportTongChiPhi.Location = new System.Drawing.Point(193, 280);
            this.btnExportTongChiPhi.Name = "btnExportTongChiPhi";
            this.btnExportTongChiPhi.Size = new System.Drawing.Size(75, 23);
            this.btnExportTongChiPhi.TabIndex = 7;
            this.btnExportTongChiPhi.Text = "Xuat excel";
            this.btnExportTongChiPhi.UseVisualStyleBackColor = true;
            // 
            // dgvTongChiPhi
            // 
            this.dgvTongChiPhi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTongChiPhi.Location = new System.Drawing.Point(5, 90);
            this.dgvTongChiPhi.Name = "dgvTongChiPhi";
            this.dgvTongChiPhi.Size = new System.Drawing.Size(781, 150);
            this.dgvTongChiPhi.TabIndex = 1;
            // 
            // tabTopChiPhi
            // 
            this.tabTopChiPhi.Controls.Add(this.btnReloadTopChiPhi);
            this.tabTopChiPhi.Controls.Add(this.btnExportTopChiPhi);
            this.tabTopChiPhi.Controls.Add(this.dgvTopChiPhi);
            this.tabTopChiPhi.Location = new System.Drawing.Point(4, 22);
            this.tabTopChiPhi.Name = "tabTopChiPhi";
            this.tabTopChiPhi.Size = new System.Drawing.Size(790, 331);
            this.tabTopChiPhi.TabIndex = 2;
            this.tabTopChiPhi.Text = "TopChiPhi";
            this.tabTopChiPhi.UseVisualStyleBackColor = true;
            // 
            // btnReloadTopChiPhi
            // 
            this.btnReloadTopChiPhi.Location = new System.Drawing.Point(423, 275);
            this.btnReloadTopChiPhi.Name = "btnReloadTopChiPhi";
            this.btnReloadTopChiPhi.Size = new System.Drawing.Size(75, 23);
            this.btnReloadTopChiPhi.TabIndex = 8;
            this.btnReloadTopChiPhi.Text = "reload";
            this.btnReloadTopChiPhi.UseVisualStyleBackColor = true;
            this.btnReloadTopChiPhi.Click += new System.EventHandler(this.btnReloadTopChiPhi_Click);
            // 
            // btnExportTopChiPhi
            // 
            this.btnExportTopChiPhi.Location = new System.Drawing.Point(196, 275);
            this.btnExportTopChiPhi.Name = "btnExportTopChiPhi";
            this.btnExportTopChiPhi.Size = new System.Drawing.Size(75, 23);
            this.btnExportTopChiPhi.TabIndex = 7;
            this.btnExportTopChiPhi.Text = "Xuat excel";
            this.btnExportTopChiPhi.UseVisualStyleBackColor = true;
            // 
            // dgvTopChiPhi
            // 
            this.dgvTopChiPhi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopChiPhi.Location = new System.Drawing.Point(5, 90);
            this.dgvTopChiPhi.Name = "dgvTopChiPhi";
            this.dgvTopChiPhi.Size = new System.Drawing.Size(781, 150);
            this.dgvTopChiPhi.TabIndex = 1;
            // 
            // tabThongKeNhanh
            // 
            this.tabThongKeNhanh.Location = new System.Drawing.Point(4, 22);
            this.tabThongKeNhanh.Name = "tabThongKeNhanh";
            this.tabThongKeNhanh.Size = new System.Drawing.Size(790, 331);
            this.tabThongKeNhanh.TabIndex = 3;
            this.tabThongKeNhanh.Text = "ThongKeNhanh";
            this.tabThongKeNhanh.UseVisualStyleBackColor = true;
            // 
            // lblCountCanBaoTri
            // 
            this.lblCountCanBaoTri.AutoSize = true;
            this.lblCountCanBaoTri.Location = new System.Drawing.Point(389, 219);
            this.lblCountCanBaoTri.Name = "lblCountCanBaoTri";
            this.lblCountCanBaoTri.Size = new System.Drawing.Size(35, 13);
            this.lblCountCanBaoTri.TabIndex = 7;
            this.lblCountCanBaoTri.Text = "label1";
            // 
            // lblAvgChiPhi
            // 
            this.lblAvgChiPhi.AutoSize = true;
            this.lblAvgChiPhi.Location = new System.Drawing.Point(530, 278);
            this.lblAvgChiPhi.Name = "lblAvgChiPhi";
            this.lblAvgChiPhi.Size = new System.Drawing.Size(35, 13);
            this.lblAvgChiPhi.TabIndex = 9;
            this.lblAvgChiPhi.Text = "label3";
            // 
            // lblTongChiPhi
            // 
            this.lblTongChiPhi.AutoSize = true;
            this.lblTongChiPhi.Location = new System.Drawing.Point(534, 202);
            this.lblTongChiPhi.Name = "lblTongChiPhi";
            this.lblTongChiPhi.Size = new System.Drawing.Size(35, 13);
            this.lblTongChiPhi.TabIndex = 8;
            this.lblTongChiPhi.Text = "label2";
            // 
            // Form_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlReport);
            this.Name = "Form_Report";
            this.Text = "Form_Report";
            this.Load += new System.EventHandler(this.Form_Report_Load);
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
        private System.Windows.Forms.TabPage tabTongChiPhi;
        private System.Windows.Forms.Button btnExportCanBaoTri;
        private System.Windows.Forms.DataGridView dgvCanBaoTri;
        private System.Windows.Forms.DataGridView dgvTongChiPhi;
        private System.Windows.Forms.TabPage tabTopChiPhi;
        private System.Windows.Forms.DataGridView dgvTopChiPhi;
        private System.Windows.Forms.Button btnReloadCanBaoTri;
        private System.Windows.Forms.Button btnReloadTongChiPhi;
        private System.Windows.Forms.Button btnExportTongChiPhi;
        private System.Windows.Forms.Button btnReloadTopChiPhi;
        private System.Windows.Forms.Button btnExportTopChiPhi;
        private System.Windows.Forms.TabPage tabThongKeNhanh;
        private System.Windows.Forms.Label lblCountCanBaoTri;
        private System.Windows.Forms.Label lblAvgChiPhi;
        private System.Windows.Forms.Label lblTongChiPhi;
    }
}