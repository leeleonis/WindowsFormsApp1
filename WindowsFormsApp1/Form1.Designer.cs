namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewMoney = new System.Windows.Forms.DataGridView();
            this.MoneyColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoneyColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoneyColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoneyColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoneyColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoneyColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoneyColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewInfo = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExchange = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewMemo = new System.Windows.Forms.DataGridView();
            this.MemoColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listView1 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMemo)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewMoney);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewInfo);
            this.splitContainer1.Panel1.Controls.Add(this.btnExchange);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewMemo);
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(986, 707);
            this.splitContainer1.SplitterDistance = 502;
            this.splitContainer1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoEllipsis = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(6, 582);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(479, 93);
            this.label6.TabIndex = 7;
            this.label6.Text = "比價資訊";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(12, 515);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 21);
            this.label5.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(6, 546);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "比價資訊";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "價格資訊";
            // 
            // dataGridViewMoney
            // 
            this.dataGridViewMoney.AllowUserToAddRows = false;
            this.dataGridViewMoney.AllowUserToDeleteRows = false;
            this.dataGridViewMoney.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMoney.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMoney.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MoneyColumn1,
            this.MoneyColumn2,
            this.MoneyColumn3,
            this.MoneyColumn4,
            this.MoneyColumn5,
            this.MoneyColumn6,
            this.MoneyColumn7});
            this.dataGridViewMoney.Location = new System.Drawing.Point(10, 288);
            this.dataGridViewMoney.Name = "dataGridViewMoney";
            this.dataGridViewMoney.ReadOnly = true;
            this.dataGridViewMoney.RowTemplate.Height = 24;
            this.dataGridViewMoney.Size = new System.Drawing.Size(489, 248);
            this.dataGridViewMoney.TabIndex = 3;
            // 
            // MoneyColumn1
            // 
            this.MoneyColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MoneyColumn1.DataPropertyName = "Name";
            this.MoneyColumn1.HeaderText = "交易所";
            this.MoneyColumn1.Name = "MoneyColumn1";
            this.MoneyColumn1.ReadOnly = true;
            this.MoneyColumn1.Width = 66;
            // 
            // MoneyColumn2
            // 
            this.MoneyColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MoneyColumn2.DataPropertyName = "Currency";
            this.MoneyColumn2.HeaderText = "幣別";
            this.MoneyColumn2.Name = "MoneyColumn2";
            this.MoneyColumn2.ReadOnly = true;
            this.MoneyColumn2.Width = 54;
            // 
            // MoneyColumn3
            // 
            this.MoneyColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MoneyColumn3.DataPropertyName = "StatusBid";
            this.MoneyColumn3.FillWeight = 80F;
            this.MoneyColumn3.HeaderText = "買入狀態";
            this.MoneyColumn3.Name = "MoneyColumn3";
            this.MoneyColumn3.ReadOnly = true;
            this.MoneyColumn3.Width = 78;
            // 
            // MoneyColumn4
            // 
            this.MoneyColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MoneyColumn4.DataPropertyName = "Bid";
            this.MoneyColumn4.FillWeight = 80F;
            this.MoneyColumn4.HeaderText = "買入價";
            this.MoneyColumn4.Name = "MoneyColumn4";
            this.MoneyColumn4.ReadOnly = true;
            this.MoneyColumn4.Width = 66;
            // 
            // MoneyColumn5
            // 
            this.MoneyColumn5.DataPropertyName = "StatusAsk";
            this.MoneyColumn5.HeaderText = "賣出狀態";
            this.MoneyColumn5.Name = "MoneyColumn5";
            this.MoneyColumn5.ReadOnly = true;
            // 
            // MoneyColumn6
            // 
            this.MoneyColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MoneyColumn6.DataPropertyName = "Ask";
            this.MoneyColumn6.FillWeight = 80F;
            this.MoneyColumn6.HeaderText = "賣出價";
            this.MoneyColumn6.Name = "MoneyColumn6";
            this.MoneyColumn6.ReadOnly = true;
            this.MoneyColumn6.Width = 66;
            // 
            // MoneyColumn7
            // 
            this.MoneyColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MoneyColumn7.DataPropertyName = "Fee";
            this.MoneyColumn7.FillWeight = 80F;
            this.MoneyColumn7.HeaderText = "手續費";
            this.MoneyColumn7.Name = "MoneyColumn7";
            this.MoneyColumn7.ReadOnly = true;
            this.MoneyColumn7.Width = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "帳戶資訊";
            // 
            // dataGridViewInfo
            // 
            this.dataGridViewInfo.AllowUserToAddRows = false;
            this.dataGridViewInfo.AllowUserToDeleteRows = false;
            this.dataGridViewInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridViewInfo.Location = new System.Drawing.Point(10, 76);
            this.dataGridViewInfo.Name = "dataGridViewInfo";
            this.dataGridViewInfo.ReadOnly = true;
            this.dataGridViewInfo.RowTemplate.Height = 24;
            this.dataGridViewInfo.Size = new System.Drawing.Size(489, 164);
            this.dataGridViewInfo.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "交易所";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Status";
            this.Column2.HeaderText = "狀態";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "BTC";
            this.Column3.HeaderText = "BTC";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "USDT";
            this.Column4.HeaderText = "USDT";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // btnExchange
            // 
            this.btnExchange.Location = new System.Drawing.Point(12, 12);
            this.btnExchange.Name = "btnExchange";
            this.btnExchange.Size = new System.Drawing.Size(75, 23);
            this.btnExchange.TabIndex = 0;
            this.btnExchange.Text = "開始";
            this.btnExchange.UseVisualStyleBackColor = true;
            this.btnExchange.Click += new System.EventHandler(this.btnExchange_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(13, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "交易資訊";
            // 
            // dataGridViewMemo
            // 
            this.dataGridViewMemo.AllowUserToAddRows = false;
            this.dataGridViewMemo.AllowUserToDeleteRows = false;
            this.dataGridViewMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMemo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMemo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MemoColumn5});
            this.dataGridViewMemo.Location = new System.Drawing.Point(11, 41);
            this.dataGridViewMemo.Name = "dataGridViewMemo";
            this.dataGridViewMemo.ReadOnly = true;
            this.dataGridViewMemo.RowTemplate.Height = 24;
            this.dataGridViewMemo.Size = new System.Drawing.Size(457, 663);
            this.dataGridViewMemo.TabIndex = 5;
            // 
            // MemoColumn5
            // 
            this.MemoColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MemoColumn5.DataPropertyName = "Msg";
            this.MemoColumn5.HeaderText = "交易資訊";
            this.MemoColumn5.Name = "MemoColumn5";
            this.MemoColumn5.ReadOnly = true;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(480, 707);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 707);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMemo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnExchange;
        private System.Windows.Forms.DataGridView dataGridViewInfo;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewMoney;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyColumn7;
    }
}

