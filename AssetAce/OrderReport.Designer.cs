namespace AssetAce
{
    partial class OrderReport
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
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.dtp_edate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_sdate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Label();
            this.dgv_report = new System.Windows.Forms.DataGridView();
            this.panel_header = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_report)).BeginInit();
            this.panel_header.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_search.FlatAppearance.BorderSize = 0;
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Location = new System.Drawing.Point(625, 55);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(71, 64);
            this.btn_search.TabIndex = 128;
            this.btn_search.Text = "🔍";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_print.FlatAppearance.BorderSize = 0;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.Location = new System.Drawing.Point(702, 55);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(64, 64);
            this.btn_print.TabIndex = 127;
            this.btn_print.Text = "🖨️";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // dtp_edate
            // 
            this.dtp_edate.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_edate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_edate.Location = new System.Drawing.Point(430, 91);
            this.dtp_edate.Name = "dtp_edate";
            this.dtp_edate.Size = new System.Drawing.Size(178, 28);
            this.dtp_edate.TabIndex = 126;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(481, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 125;
            this.label1.Text = "End Date";
            // 
            // dtp_sdate
            // 
            this.dtp_sdate.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_sdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_sdate.Location = new System.Drawing.Point(230, 91);
            this.dtp_sdate.Name = "dtp_sdate";
            this.dtp_sdate.Size = new System.Drawing.Size(178, 28);
            this.dtp_sdate.TabIndex = 124;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(281, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 21);
            this.label3.TabIndex = 123;
            this.label3.Text = "Start Date";
            // 
            // btn_exit
            // 
            this.btn_exit.AutoSize = true;
            this.btn_exit.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_exit.Location = new System.Drawing.Point(922, 8);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(21, 24);
            this.btn_exit.TabIndex = 122;
            this.btn_exit.Text = "X";
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // dgv_report
            // 
            this.dgv_report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_report.Location = new System.Drawing.Point(12, 135);
            this.dgv_report.Name = "dgv_report";
            this.dgv_report.RowHeadersWidth = 51;
            this.dgv_report.RowTemplate.Height = 24;
            this.dgv_report.Size = new System.Drawing.Size(920, 376);
            this.dgv_report.TabIndex = 121;
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.SystemColors.Control;
            this.panel_header.Controls.Add(this.btn_exit);
            this.panel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_header.Location = new System.Drawing.Point(0, 0);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(946, 32);
            this.panel_header.TabIndex = 129;
            // 
            // OrderReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 530);
            this.Controls.Add(this.panel_header);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.dtp_edate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_sdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_report);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderReport";
            this.Load += new System.EventHandler(this.OrderReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_report)).EndInit();
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.DateTimePicker dtp_edate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_sdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label btn_exit;
        private System.Windows.Forms.DataGridView dgv_report;
        private System.Windows.Forms.Panel panel_header;
    }
}