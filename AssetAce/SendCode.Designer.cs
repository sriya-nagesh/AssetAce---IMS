namespace AssetAce
{
    partial class SendCode
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
            this.components = new System.ComponentModel.Container();
            this.panel_header = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Label();
            this.btn_sendEmail = new System.Windows.Forms.Button();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_validate = new System.Windows.Forms.Button();
            this.panel_header.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel_header.Controls.Add(this.label2);
            this.panel_header.Controls.Add(this.btn_exit);
            this.panel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_header.Location = new System.Drawing.Point(0, 0);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(505, 31);
            this.panel_header.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(166, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Reset Password";
            // 
            // btn_exit
            // 
            this.btn_exit.AutoSize = true;
            this.btn_exit.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_exit.Location = new System.Drawing.Point(484, 4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(21, 24);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.Text = "X";
            // 
            // btn_sendEmail
            // 
            this.btn_sendEmail.BackColor = System.Drawing.Color.LightSlateGray;
            this.btn_sendEmail.FlatAppearance.BorderSize = 0;
            this.btn_sendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sendEmail.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sendEmail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_sendEmail.Location = new System.Drawing.Point(365, 67);
            this.btn_sendEmail.Name = "btn_sendEmail";
            this.btn_sendEmail.Size = new System.Drawing.Size(94, 36);
            this.btn_sendEmail.TabIndex = 27;
            this.btn_sendEmail.Text = "Get code";
            this.toolTip2.SetToolTip(this.btn_sendEmail, "Validate the code that has been sent to your email");
            this.btn_sendEmail.UseVisualStyleBackColor = false;
            this.btn_sendEmail.Click += new System.EventHandler(this.btn_sendEmail_Click);
            // 
            // txt_code
            // 
            this.txt_code.Location = new System.Drawing.Point(231, 127);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(119, 22);
            this.txt_code.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(123, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 21);
            this.label3.TabIndex = 25;
            this.label3.Text = "Enter code";
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(231, 76);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(119, 22);
            this.txt_id.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 21);
            this.label1.TabIndex = 23;
            this.label1.Text = "Enter employee ID";
            // 
            // btn_validate
            // 
            this.btn_validate.BackColor = System.Drawing.Color.LightSlateGray;
            this.btn_validate.FlatAppearance.BorderSize = 0;
            this.btn_validate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_validate.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_validate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_validate.Location = new System.Drawing.Point(365, 118);
            this.btn_validate.Name = "btn_validate";
            this.btn_validate.Size = new System.Drawing.Size(94, 36);
            this.btn_validate.TabIndex = 29;
            this.btn_validate.Text = "Validate";
            this.toolTip2.SetToolTip(this.btn_validate, "Validate the code that has been sent to your email");
            this.btn_validate.UseVisualStyleBackColor = false;
            this.btn_validate.Click += new System.EventHandler(this.btn_validate_Click);
            // 
            // SendCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 202);
            this.Controls.Add(this.btn_validate);
            this.Controls.Add(this.panel_header);
            this.Controls.Add(this.btn_sendEmail);
            this.Controls.Add(this.txt_code);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SendCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SendCode";
            this.Load += new System.EventHandler(this.SendCode_Load);
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label btn_exit;
        private System.Windows.Forms.Button btn_sendEmail;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btn_validate;
    }
}