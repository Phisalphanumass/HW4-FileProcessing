namespace FileProcessing
{
	partial class frmTextView
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btBrowse = new System.Windows.Forms.Button();
            this.tabcMain = new System.Windows.Forms.TabControl();
            this.tabpText = new System.Windows.Forms.TabPage();
            this.rtbShow = new System.Windows.Forms.RichTextBox();
            this.btRead = new System.Windows.Forms.Button();
            this.tabpCSV = new System.Windows.Forms.TabPage();
            this.labal2 = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.txtM = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.RegisterDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHA256_Hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MD5_Hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHA1_Hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btReadCSV = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabcMain.SuspendLayout();
            this.tabpText.SuspendLayout();
            this.tabpCSV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "File";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(93, 11);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(809, 22);
            this.tbFileName.TabIndex = 1;
            this.tbFileName.Text = "D:\\YutData\\DistributedHome\\cdti.Code\\FileProcessing\\data\\malware_500.csv";
            // 
            // btBrowse
            // 
            this.btBrowse.Location = new System.Drawing.Point(936, 6);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(100, 27);
            this.btBrowse.TabIndex = 2;
            this.btBrowse.Text = "Browse";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // tabcMain
            // 
            this.tabcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabcMain.Controls.Add(this.tabpText);
            this.tabcMain.Controls.Add(this.tabpCSV);
            this.tabcMain.Location = new System.Drawing.Point(11, 38);
            this.tabcMain.Name = "tabcMain";
            this.tabcMain.SelectedIndex = 0;
            this.tabcMain.Size = new System.Drawing.Size(1056, 889);
            this.tabcMain.TabIndex = 3;
            // 
            // tabpText
            // 
            this.tabpText.Controls.Add(this.rtbShow);
            this.tabpText.Controls.Add(this.btRead);
            this.tabpText.Location = new System.Drawing.Point(4, 25);
            this.tabpText.Name = "tabpText";
            this.tabpText.Padding = new System.Windows.Forms.Padding(3);
            this.tabpText.Size = new System.Drawing.Size(1048, 860);
            this.tabpText.TabIndex = 0;
            this.tabpText.Text = "Text";
            this.tabpText.UseVisualStyleBackColor = true;
            // 
            // rtbShow
            // 
            this.rtbShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbShow.Location = new System.Drawing.Point(15, 49);
            this.rtbShow.Name = "rtbShow";
            this.rtbShow.Size = new System.Drawing.Size(1030, 804);
            this.rtbShow.TabIndex = 1;
            this.rtbShow.Text = "";
            this.rtbShow.WordWrap = false;
            // 
            // btRead
            // 
            this.btRead.Location = new System.Drawing.Point(15, 13);
            this.btRead.Name = "btRead";
            this.btRead.Size = new System.Drawing.Size(103, 31);
            this.btRead.TabIndex = 0;
            this.btRead.Text = "read as text file";
            this.btRead.UseVisualStyleBackColor = true;
            this.btRead.Click += new System.EventHandler(this.btRead_Click);
            // 
            // tabpCSV
            // 
            this.tabpCSV.Controls.Add(this.label2);
            this.tabpCSV.Controls.Add(this.txtFilter);
            this.tabpCSV.Controls.Add(this.label3);
            this.tabpCSV.Controls.Add(this.labal2);
            this.tabpCSV.Controls.Add(this.txtN);
            this.tabpCSV.Controls.Add(this.txtM);
            this.tabpCSV.Controls.Add(this.dgvData);
            this.tabpCSV.Controls.Add(this.btReadCSV);
            this.tabpCSV.Location = new System.Drawing.Point(4, 25);
            this.tabpCSV.Name = "tabpCSV";
            this.tabpCSV.Padding = new System.Windows.Forms.Padding(3);
            this.tabpCSV.Size = new System.Drawing.Size(1048, 860);
            this.tabpCSV.TabIndex = 1;
            this.tabpCSV.Text = "CSV";
            this.tabpCSV.UseVisualStyleBackColor = true;
            // 
            // labal2
            // 
            this.labal2.AutoSize = true;
            this.labal2.Location = new System.Drawing.Point(154, 11);
            this.labal2.Name = "labal2";
            this.labal2.Size = new System.Drawing.Size(18, 16);
            this.labal2.TabIndex = 4;
            this.labal2.Text = "M";
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(326, 8);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(100, 22);
            this.txtN.TabIndex = 3;
            // 
            // txtM
            // 
            this.txtM.Location = new System.Drawing.Point(178, 8);
            this.txtM.Name = "txtM";
            this.txtM.Size = new System.Drawing.Size(100, 22);
            this.txtM.TabIndex = 2;
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RegisterDate,
            this.SHA256_Hash,
            this.MD5_Hash,
            this.SHA1_Hash});
            this.dgvData.Location = new System.Drawing.Point(22, 45);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 62;
            this.dgvData.RowTemplate.Height = 28;
            this.dgvData.Size = new System.Drawing.Size(1007, 803);
            this.dgvData.TabIndex = 1;
            // 
            // RegisterDate
            // 
            this.RegisterDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RegisterDate.HeaderText = "Date";
            this.RegisterDate.MinimumWidth = 8;
            this.RegisterDate.Name = "RegisterDate";
            this.RegisterDate.Width = 65;
            // 
            // SHA256_Hash
            // 
            this.SHA256_Hash.HeaderText = "SHA256 Hash";
            this.SHA256_Hash.MinimumWidth = 8;
            this.SHA256_Hash.Name = "SHA256_Hash";
            this.SHA256_Hash.Width = 150;
            // 
            // MD5_Hash
            // 
            this.MD5_Hash.HeaderText = "MD5Hash";
            this.MD5_Hash.MinimumWidth = 8;
            this.MD5_Hash.Name = "MD5_Hash";
            this.MD5_Hash.Width = 150;
            // 
            // SHA1_Hash
            // 
            this.SHA1_Hash.HeaderText = "SHA1 Hash";
            this.SHA1_Hash.MinimumWidth = 8;
            this.SHA1_Hash.Name = "SHA1_Hash";
            this.SHA1_Hash.Width = 150;
            // 
            // btReadCSV
            // 
            this.btReadCSV.Location = new System.Drawing.Point(20, 5);
            this.btReadCSV.Name = "btReadCSV";
            this.btReadCSV.Size = new System.Drawing.Size(95, 29);
            this.btReadCSV.TabIndex = 0;
            this.btReadCSV.Text = "read as csv";
            this.btReadCSV.UseVisualStyleBackColor = true;
            this.btReadCSV.Click += new System.EventHandler(this.btReadCSV_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "N";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(520, 8);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(100, 22);
            this.txtFilter.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(456, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "File type";
            // 
            // frmTextView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 703);
            this.Controls.Add(this.tabcMain);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label1);
            this.Name = "frmTextView";
            this.Text = "Text/CSV viewer";
            this.tabcMain.ResumeLayout(false);
            this.tabpText.ResumeLayout(false);
            this.tabpCSV.ResumeLayout(false);
            this.tabpCSV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbFileName;
		private System.Windows.Forms.Button btBrowse;
		private System.Windows.Forms.TabControl tabcMain;
		private System.Windows.Forms.TabPage tabpText;
		private System.Windows.Forms.TabPage tabpCSV;
		private System.Windows.Forms.Button btRead;
		private System.Windows.Forms.RichTextBox rtbShow;
		private System.Windows.Forms.DataGridView dgvData;
		private System.Windows.Forms.Button btReadCSV;
		private System.Windows.Forms.DataGridViewTextBoxColumn RegisterDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn SHA256_Hash;
		private System.Windows.Forms.DataGridViewTextBoxColumn MD5_Hash;
		private System.Windows.Forms.DataGridViewTextBoxColumn SHA1_Hash;
        private System.Windows.Forms.Label labal2;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.TextBox txtM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilter;
    }
}

