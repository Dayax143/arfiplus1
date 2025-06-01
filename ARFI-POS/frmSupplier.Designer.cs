namespace ARFI_POS
{
    partial class frmSupplier
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSupplier = new System.Windows.Forms.DataGridView();
            this.viewbtn = new System.Windows.Forms.Button();
            this.bopanel = new System.Windows.Forms.Panel();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.topanel = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.cbbAddress = new System.Windows.Forms.TextBox();
            this.txtSupplierDetail = new System.Windows.Forms.TextBox();
            this.cbbPhone = new System.Windows.Forms.TextBox();
            this.cbbSupplierId = new System.Windows.Forms.TextBox();
            this.cbbName = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).BeginInit();
            this.bopanel.SuspendLayout();
            this.topanel.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
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
            this.btnRefresh.Location = new System.Drawing.Point(1240, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(39, 37);
            this.btnRefresh.TabIndex = 53;
            this.btnRefresh.Text = "*";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 15F);
            this.label1.Location = new System.Drawing.Point(843, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "Search";
            // 
            // dgvSupplier
            // 
            this.dgvSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSupplier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSupplier.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupplier.Location = new System.Drawing.Point(0, 47);
            this.dgvSupplier.Name = "dgvSupplier";
            this.dgvSupplier.RowHeadersWidth = 62;
            this.dgvSupplier.Size = new System.Drawing.Size(1282, 476);
            this.dgvSupplier.TabIndex = 16;
            this.dgvSupplier.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupplier_CellDoubleClick);
            // 
            // viewbtn
            // 
            this.viewbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.viewbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.viewbtn.FlatAppearance.BorderSize = 0;
            this.viewbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewbtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.viewbtn.ForeColor = System.Drawing.Color.White;
            this.viewbtn.Location = new System.Drawing.Point(550, 3);
            this.viewbtn.Name = "viewbtn";
            this.viewbtn.Size = new System.Drawing.Size(137, 41);
            this.viewbtn.TabIndex = 13;
            this.viewbtn.Text = "View mode";
            this.viewbtn.UseVisualStyleBackColor = false;
            // 
            // bopanel
            // 
            this.bopanel.BackColor = System.Drawing.SystemColors.Control;
            this.bopanel.Controls.Add(this.btnRefresh);
            this.bopanel.Controls.Add(this.label1);
            this.bopanel.Controls.Add(this.dgvSupplier);
            this.bopanel.Controls.Add(this.viewbtn);
            this.bopanel.Controls.Add(this.txtFind);
            this.bopanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bopanel.Location = new System.Drawing.Point(0, 163);
            this.bopanel.Name = "bopanel";
            this.bopanel.Size = new System.Drawing.Size(1282, 523);
            this.bopanel.TabIndex = 23;
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.Location = new System.Drawing.Point(923, 13);
            this.txtFind.Multiline = true;
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(313, 29);
            this.txtFind.TabIndex = 14;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // btnclear
            // 
            this.btnclear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.btnclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclear.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.btnclear.ForeColor = System.Drawing.Color.White;
            this.btnclear.Location = new System.Drawing.Point(1178, 7);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(92, 37);
            this.btnclear.TabIndex = 11;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdate.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.btnupdate.ForeColor = System.Drawing.Color.White;
            this.btnupdate.Location = new System.Drawing.Point(982, 7);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(92, 37);
            this.btnupdate.TabIndex = 9;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndel
            // 
            this.btndel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.btndel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.btndel.ForeColor = System.Drawing.Color.White;
            this.btndel.Location = new System.Drawing.Point(1080, 7);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(92, 37);
            this.btndel.TabIndex = 10;
            this.btndel.Text = "Delete -";
            this.btndel.UseVisualStyleBackColor = false;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(884, 7);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(92, 37);
            this.btnsave.TabIndex = 8;
            this.btnsave.Text = "Add +";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // topanel
            // 
            this.topanel.BackColor = System.Drawing.Color.Transparent;
            this.topanel.Controls.Add(this.Label2);
            this.topanel.Controls.Add(this.cbbAddress);
            this.topanel.Controls.Add(this.txtSupplierDetail);
            this.topanel.Controls.Add(this.cbbPhone);
            this.topanel.Controls.Add(this.cbbSupplierId);
            this.topanel.Controls.Add(this.cbbName);
            this.topanel.Controls.Add(this.Label6);
            this.topanel.Controls.Add(this.label5);
            this.topanel.Controls.Add(this.label4);
            this.topanel.Controls.Add(this.Label3);
            this.topanel.Controls.Add(this.pnlTop);
            this.topanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topanel.Location = new System.Drawing.Point(0, 0);
            this.topanel.Name = "topanel";
            this.topanel.Size = new System.Drawing.Size(1282, 163);
            this.topanel.TabIndex = 22;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Consolas", 15F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(28, 111);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(54, 23);
            this.Label2.TabIndex = 41;
            this.Label2.Text = "ID :";
            // 
            // cbbAddress
            // 
            this.cbbAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cbbAddress.Font = new System.Drawing.Font("Consolas", 15F);
            this.cbbAddress.Location = new System.Drawing.Point(681, 109);
            this.cbbAddress.Margin = new System.Windows.Forms.Padding(2);
            this.cbbAddress.Multiline = true;
            this.cbbAddress.Name = "cbbAddress";
            this.cbbAddress.Size = new System.Drawing.Size(238, 35);
            this.cbbAddress.TabIndex = 72;
            // 
            // txtSupplierDetail
            // 
            this.txtSupplierDetail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSupplierDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSupplierDetail.Font = new System.Drawing.Font("Consolas", 15F);
            this.txtSupplierDetail.Location = new System.Drawing.Point(923, 109);
            this.txtSupplierDetail.Margin = new System.Windows.Forms.Padding(2);
            this.txtSupplierDetail.Multiline = true;
            this.txtSupplierDetail.Name = "txtSupplierDetail";
            this.txtSupplierDetail.Size = new System.Drawing.Size(347, 35);
            this.txtSupplierDetail.TabIndex = 73;
            // 
            // cbbPhone
            // 
            this.cbbPhone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cbbPhone.Font = new System.Drawing.Font("Consolas", 15F);
            this.cbbPhone.Location = new System.Drawing.Point(454, 109);
            this.cbbPhone.Margin = new System.Windows.Forms.Padding(2);
            this.cbbPhone.Multiline = true;
            this.cbbPhone.Name = "cbbPhone";
            this.cbbPhone.Size = new System.Drawing.Size(223, 35);
            this.cbbPhone.TabIndex = 74;
            // 
            // cbbSupplierId
            // 
            this.cbbSupplierId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbSupplierId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cbbSupplierId.Font = new System.Drawing.Font("Consolas", 15F);
            this.cbbSupplierId.Location = new System.Drawing.Point(87, 109);
            this.cbbSupplierId.Margin = new System.Windows.Forms.Padding(2);
            this.cbbSupplierId.Multiline = true;
            this.cbbSupplierId.Name = "cbbSupplierId";
            this.cbbSupplierId.Size = new System.Drawing.Size(90, 35);
            this.cbbSupplierId.TabIndex = 75;
            // 
            // cbbName
            // 
            this.cbbName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cbbName.Font = new System.Drawing.Font("Consolas", 15F);
            this.cbbName.Location = new System.Drawing.Point(194, 109);
            this.cbbName.Margin = new System.Windows.Forms.Padding(2);
            this.cbbName.Multiline = true;
            this.cbbName.Name = "cbbName";
            this.cbbName.Size = new System.Drawing.Size(254, 35);
            this.cbbName.TabIndex = 75;
            // 
            // Label6
            // 
            this.Label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Consolas", 15F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(190, 84);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(153, 23);
            this.Label6.TabIndex = 70;
            this.Label6.Text = "Supplier name";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Consolas", 15F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(919, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 23);
            this.label5.TabIndex = 68;
            this.label5.Text = "Detail";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Consolas", 15F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(450, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 23);
            this.label4.TabIndex = 69;
            this.label4.Text = "Phone";
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Consolas", 15F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(677, 84);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(87, 23);
            this.Label3.TabIndex = 71;
            this.Label3.Text = "Address";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(168)))));
            this.pnlTop.Controls.Add(this.btnclear);
            this.pnlTop.Controls.Add(this.btnupdate);
            this.pnlTop.Controls.Add(this.btndel);
            this.pnlTop.Controls.Add(this.btnsave);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1282, 61);
            this.pnlTop.TabIndex = 57;
            // 
            // frmSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 686);
            this.Controls.Add(this.bopanel);
            this.Controls.Add(this.topanel);
            this.Name = "frmSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSupplier";
            this.Load += new System.EventHandler(this.frmSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).EndInit();
            this.bopanel.ResumeLayout(false);
            this.bopanel.PerformLayout();
            this.topanel.ResumeLayout(false);
            this.topanel.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSupplier;
        internal System.Windows.Forms.Button viewbtn;
        internal System.Windows.Forms.Panel bopanel;
        internal System.Windows.Forms.TextBox txtFind;
        internal System.Windows.Forms.Button btnclear;
        internal System.Windows.Forms.Button btnupdate;
        internal System.Windows.Forms.Button btndel;
        internal System.Windows.Forms.Button btnsave;
        internal System.Windows.Forms.Panel topanel;
        private System.Windows.Forms.Panel pnlTop;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox cbbAddress;
        private System.Windows.Forms.TextBox txtSupplierDetail;
        private System.Windows.Forms.TextBox cbbPhone;
        private System.Windows.Forms.TextBox cbbName;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TextBox cbbSupplierId;
    }
}