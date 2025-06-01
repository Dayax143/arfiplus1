namespace ARFI_POS
{
    partial class uLoan
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
            this.cbbPayNow = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvLoan = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.bopanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.viewbtn = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.topanel = new System.Windows.Forms.Panel();
            this.btnPayLoan = new System.Windows.Forms.Button();
            this.lblNewBalance = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDaysLeft = new System.Windows.Forms.Label();
            this.lblPreviousBalance = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNumLoans = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDateTaken = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoan)).BeginInit();
            this.bopanel.SuspendLayout();
            this.topanel.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbPayNow
            // 
            this.cbbPayNow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbPayNow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cbbPayNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPayNow.Location = new System.Drawing.Point(262, 115);
            this.cbbPayNow.Margin = new System.Windows.Forms.Padding(2);
            this.cbbPayNow.Multiline = true;
            this.cbbPayNow.Name = "cbbPayNow";
            this.cbbPayNow.Size = new System.Drawing.Size(218, 41);
            this.cbbPayNow.TabIndex = 65;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label6.Location = new System.Drawing.Point(170, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 25);
            this.label6.TabIndex = 49;
            this.label6.Text = "Pay now";
            // 
            // dgvLoan
            // 
            this.dgvLoan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoan.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvLoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoan.Location = new System.Drawing.Point(0, 57);
            this.dgvLoan.Name = "dgvLoan";
            this.dgvLoan.RowHeadersWidth = 62;
            this.dgvLoan.Size = new System.Drawing.Size(1311, 465);
            this.dgvLoan.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(814, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 25);
            this.label10.TabIndex = 63;
            this.label10.Text = "Previos balance : $";
            // 
            // bopanel
            // 
            this.bopanel.BackColor = System.Drawing.SystemColors.Control;
            this.bopanel.Controls.Add(this.label1);
            this.bopanel.Controls.Add(this.dgvLoan);
            this.bopanel.Controls.Add(this.viewbtn);
            this.bopanel.Controls.Add(this.txtFind);
            this.bopanel.Controls.Add(this.btnRefresh);
            this.bopanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bopanel.Location = new System.Drawing.Point(0, 260);
            this.bopanel.Name = "bopanel";
            this.bopanel.Size = new System.Drawing.Size(1311, 522);
            this.bopanel.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15F);
            this.label1.Location = new System.Drawing.Point(974, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "Search";
            // 
            // viewbtn
            // 
            this.viewbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.viewbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.viewbtn.FlatAppearance.BorderSize = 0;
            this.viewbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewbtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.viewbtn.ForeColor = System.Drawing.Color.White;
            this.viewbtn.Location = new System.Drawing.Point(589, 6);
            this.viewbtn.Name = "viewbtn";
            this.viewbtn.Size = new System.Drawing.Size(143, 41);
            this.viewbtn.TabIndex = 13;
            this.viewbtn.Text = "View mode";
            this.viewbtn.UseVisualStyleBackColor = false;
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.Location = new System.Drawing.Point(1054, 13);
            this.txtFind.Multiline = true;
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(210, 29);
            this.txtFind.TabIndex = 14;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleGreen;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(1269, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(39, 37);
            this.btnRefresh.TabIndex = 51;
            this.btnRefresh.Text = "*";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // topanel
            // 
            this.topanel.BackColor = System.Drawing.SystemColors.Control;
            this.topanel.Controls.Add(this.cbbPayNow);
            this.topanel.Controls.Add(this.label6);
            this.topanel.Controls.Add(this.btnPayLoan);
            this.topanel.Controls.Add(this.lblNewBalance);
            this.topanel.Controls.Add(this.label10);
            this.topanel.Controls.Add(this.label8);
            this.topanel.Controls.Add(this.label7);
            this.topanel.Controls.Add(this.lblNumLoans);
            this.topanel.Controls.Add(this.label3);
            this.topanel.Controls.Add(this.lblDateTaken);
            this.topanel.Controls.Add(this.lblDaysLeft);
            this.topanel.Controls.Add(this.lblPreviousBalance);
            this.topanel.Controls.Add(this.pnlTop);
            this.topanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topanel.Location = new System.Drawing.Point(0, 0);
            this.topanel.Name = "topanel";
            this.topanel.Size = new System.Drawing.Size(1311, 260);
            this.topanel.TabIndex = 20;
            // 
            // btnPayLoan
            // 
            this.btnPayLoan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPayLoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.btnPayLoan.FlatAppearance.BorderSize = 0;
            this.btnPayLoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayLoan.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.btnPayLoan.ForeColor = System.Drawing.Color.White;
            this.btnPayLoan.Location = new System.Drawing.Point(514, 113);
            this.btnPayLoan.Name = "btnPayLoan";
            this.btnPayLoan.Size = new System.Drawing.Size(218, 66);
            this.btnPayLoan.TabIndex = 13;
            this.btnPayLoan.Text = "PAY";
            this.btnPayLoan.UseVisualStyleBackColor = false;
            this.btnPayLoan.Click += new System.EventHandler(this.btnPayLoan_Click);
            // 
            // lblNewBalance
            // 
            this.lblNewBalance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNewBalance.AutoSize = true;
            this.lblNewBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewBalance.Location = new System.Drawing.Point(285, 191);
            this.lblNewBalance.Name = "lblNewBalance";
            this.lblNewBalance.Size = new System.Drawing.Size(130, 25);
            this.lblNewBalance.TabIndex = 63;
            this.lblNewBalance.Text = "New balance ";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(846, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 25);
            this.label7.TabIndex = 47;
            this.label7.Text = "Date taken : ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(797, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 25);
            this.label3.TabIndex = 47;
            this.label3.Text = "Number of days left : ";
            // 
            // lblDaysLeft
            // 
            this.lblDaysLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDaysLeft.AutoSize = true;
            this.lblDaysLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaysLeft.Location = new System.Drawing.Point(1011, 132);
            this.lblDaysLeft.Name = "lblDaysLeft";
            this.lblDaysLeft.Size = new System.Drawing.Size(17, 25);
            this.lblDaysLeft.TabIndex = 64;
            this.lblDaysLeft.Text = ".";
            // 
            // lblPreviousBalance
            // 
            this.lblPreviousBalance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPreviousBalance.AutoSize = true;
            this.lblPreviousBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviousBalance.Location = new System.Drawing.Point(1011, 91);
            this.lblPreviousBalance.Name = "lblPreviousBalance";
            this.lblPreviousBalance.Size = new System.Drawing.Size(17, 25);
            this.lblPreviousBalance.TabIndex = 64;
            this.lblPreviousBalance.Text = ".";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.pnlTop.Controls.Add(this.txtPhone);
            this.pnlTop.Controls.Add(this.btnFind);
            this.pnlTop.Controls.Add(this.btnclear);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label5);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1311, 56);
            this.pnlTop.TabIndex = 60;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(735, 10);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(218, 36);
            this.txtPhone.TabIndex = 65;
            // 
            // btnFind
            // 
            this.btnFind.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Location = new System.Drawing.Point(958, 10);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(92, 36);
            this.btnFind.TabIndex = 9;
            this.btnFind.Text = "FIND";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnclear
            // 
            this.btnclear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnclear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.btnclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclear.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.btnclear.ForeColor = System.Drawing.Color.White;
            this.btnclear.Location = new System.Drawing.Point(1207, 10);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(92, 36);
            this.btnclear.TabIndex = 11;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Consolas", 15F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(533, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 23);
            this.label2.TabIndex = 47;
            this.label2.Text = "Customer phone : ";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Consolas", 15F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(33, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(351, 23);
            this.label5.TabIndex = 47;
            this.label5.Text = "Here you will manage your loans";
            // 
            // lblNumLoans
            // 
            this.lblNumLoans.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNumLoans.AutoSize = true;
            this.lblNumLoans.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumLoans.Location = new System.Drawing.Point(1027, 216);
            this.lblNumLoans.Name = "lblNumLoans";
            this.lblNumLoans.Size = new System.Drawing.Size(17, 25);
            this.lblNumLoans.TabIndex = 64;
            this.lblNumLoans.Text = ".";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(846, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(177, 25);
            this.label8.TabIndex = 47;
            this.label8.Text = "Number of Loans : ";
            // 
            // lblDateTaken
            // 
            this.lblDateTaken.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDateTaken.AutoSize = true;
            this.lblDateTaken.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTaken.Location = new System.Drawing.Point(1010, 172);
            this.lblDateTaken.Name = "lblDateTaken";
            this.lblDateTaken.Size = new System.Drawing.Size(17, 25);
            this.lblDateTaken.TabIndex = 64;
            this.lblDateTaken.Text = ".";
            // 
            // uLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bopanel);
            this.Controls.Add(this.topanel);
            this.Name = "uLoan";
            this.Size = new System.Drawing.Size(1311, 782);
            this.Load += new System.EventHandler(this.uLoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoan)).EndInit();
            this.bopanel.ResumeLayout(false);
            this.bopanel.PerformLayout();
            this.topanel.ResumeLayout(false);
            this.topanel.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox cbbPayNow;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvLoan;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Panel bopanel;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button viewbtn;
        internal System.Windows.Forms.TextBox txtFind;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Panel topanel;
        internal System.Windows.Forms.Label lblPreviousBalance;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlTop;
        internal System.Windows.Forms.Button btnFind;
        internal System.Windows.Forms.Button btnclear;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label lblDaysLeft;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Button btnPayLoan;
        private System.Windows.Forms.TextBox txtPhone;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label lblNewBalance;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label lblNumLoans;
        internal System.Windows.Forms.Label lblDateTaken;
    }
}
