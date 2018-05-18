namespace Cemp.gui
{
    partial class FrmQuotationView
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
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.btnNewCopy = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWaiting = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApprove = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkApprove = new System.Windows.Forms.CheckBox();
            this.cboContact = new System.Windows.Forms.ComboBox();
            this.cboCust = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pB1 = new System.Windows.Forms.ProgressBar();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvView
            // 
            this.dgvView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Location = new System.Drawing.Point(9, 88);
            this.dgvView.Margin = new System.Windows.Forms.Padding(2);
            this.dgvView.Name = "dgvView";
            this.dgvView.RowTemplate.Height = 24;
            this.dgvView.Size = new System.Drawing.Size(812, 425);
            this.dgvView.TabIndex = 2;
            this.dgvView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvView_CellDoubleClick);
            this.dgvView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvView_MouseClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(951, 10);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 39);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "ป้อนใหม่";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Year";
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(64, 20);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(50, 21);
            this.cboYear.TabIndex = 6;
            this.cboYear.SelectedIndexChanged += new System.EventHandler(this.cboYear_SelectedIndexChanged);
            // 
            // btnNewCopy
            // 
            this.btnNewCopy.Location = new System.Drawing.Point(1022, 10);
            this.btnNewCopy.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewCopy.Name = "btnNewCopy";
            this.btnNewCopy.Size = new System.Drawing.Size(64, 39);
            this.btnNewCopy.TabIndex = 7;
            this.btnNewCopy.Text = "New&Copy";
            this.btnNewCopy.UseVisualStyleBackColor = true;
            this.btnNewCopy.Click += new System.EventHandler(this.btnNewCopy_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTotal.ForeColor = System.Drawing.Color.Black;
            this.txtTotal.Location = new System.Drawing.Point(143, 11);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(144, 19);
            this.txtTotal.TabIndex = 8;
            this.txtTotal.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "รวมทั้งหมด";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "รวมสถานะ รออนุมัติ";
            // 
            // txtWaiting
            // 
            this.txtWaiting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtWaiting.ForeColor = System.Drawing.Color.Black;
            this.txtWaiting.Location = new System.Drawing.Point(143, 37);
            this.txtWaiting.Name = "txtWaiting";
            this.txtWaiting.ReadOnly = true;
            this.txtWaiting.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWaiting.Size = new System.Drawing.Size(144, 19);
            this.txtWaiting.TabIndex = 10;
            this.txtWaiting.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "รวมสถานะ อนุมัติแล้ว";
            // 
            // txtApprove
            // 
            this.txtApprove.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtApprove.ForeColor = System.Drawing.Color.Black;
            this.txtApprove.Location = new System.Drawing.Point(143, 63);
            this.txtApprove.Name = "txtApprove";
            this.txtApprove.ReadOnly = true;
            this.txtApprove.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtApprove.Size = new System.Drawing.Size(144, 19);
            this.txtApprove.TabIndex = 12;
            this.txtApprove.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkApprove);
            this.groupBox1.Controls.Add(this.cboContact);
            this.groupBox1.Controls.Add(this.cboCust);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboYear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(360, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 69);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค้นหา";
            // 
            // chkApprove
            // 
            this.chkApprove.AutoSize = true;
            this.chkApprove.Location = new System.Drawing.Point(18, 46);
            this.chkApprove.Name = "chkApprove";
            this.chkApprove.Size = new System.Drawing.Size(89, 17);
            this.chkApprove.TabIndex = 13;
            this.chkApprove.Text = "อนุมัติแล้ว     ";
            this.chkApprove.UseVisualStyleBackColor = true;
            // 
            // cboContact
            // 
            this.cboContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboContact.FormattingEnabled = true;
            this.cboContact.Location = new System.Drawing.Point(200, 39);
            this.cboContact.Margin = new System.Windows.Forms.Padding(2);
            this.cboContact.Name = "cboContact";
            this.cboContact.Size = new System.Drawing.Size(367, 25);
            this.cboContact.TabIndex = 12;
            this.cboContact.SelectedIndexChanged += new System.EventHandler(this.cboContact_SelectedIndexChanged);
            // 
            // cboCust
            // 
            this.cboCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboCust.FormattingEnabled = true;
            this.cboCust.Location = new System.Drawing.Point(200, 11);
            this.cboCust.Margin = new System.Windows.Forms.Padding(2);
            this.cboCust.Name = "cboCust";
            this.cboCust.Size = new System.Drawing.Size(367, 25);
            this.cboCust.TabIndex = 11;
            this.cboCust.SelectedIndexChanged += new System.EventHandler(this.cboCust_SelectedIndexChanged);
            this.cboCust.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboCust_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(135, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "ชื่อผู้ติดต่อ :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(135, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "บริษัท :";
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(1104, 10);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(64, 39);
            this.btnExcel.TabIndex = 15;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pB1
            // 
            this.pB1.Location = new System.Drawing.Point(953, 55);
            this.pB1.Name = "pB1";
            this.pB1.Size = new System.Drawing.Size(215, 23);
            this.pB1.TabIndex = 16;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1175, 10);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 39);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmQuotationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 555);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pB1);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtApprove);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWaiting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnNewCopy);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmQuotationView";
            this.Text = "FrmQuotationView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmQuotationView_Load);
            this.Resize += new System.EventHandler(this.FrmQuotationView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Button btnNewCopy;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWaiting;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApprove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboContact;
        private System.Windows.Forms.ComboBox cboCust;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.ProgressBar pB1;
        private System.Windows.Forms.CheckBox chkApprove;
        private System.Windows.Forms.Button btnSearch;
    }
}