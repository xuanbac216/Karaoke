namespace QuanlyKaraoke
{
    partial class frm_hddv
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_hddv_madv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_hddv_sohd = new System.Windows.Forms.TextBox();
            this.lb_sohoadon = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgv_hddv = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgv_hddvchon = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_dsdv_madv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_dsdv_tendv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_dsdv_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nud_hddv_sl = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hddv)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hddvchon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_hddv_sl)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.SlateBlue;
            this.splitContainer1.Panel1.Controls.Add(this.nud_hddv_sl);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txt_hddv_madv);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txt_hddv_sohd);
            this.splitContainer1.Panel1.Controls.Add(this.lb_sohoadon);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(379, 406);
            this.splitContainer1.SplitterDistance = 130;
            this.splitContainer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(261, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(34, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Số lượng";
            // 
            // txt_hddv_madv
            // 
            this.txt_hddv_madv.Location = new System.Drawing.Point(109, 57);
            this.txt_hddv_madv.Name = "txt_hddv_madv";
            this.txt_hddv_madv.Size = new System.Drawing.Size(133, 20);
            this.txt_hddv_madv.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dịch vụ";
            this.label1.Click += new System.EventHandler(this.lb_sohoadon_Click);
            // 
            // txt_hddv_sohd
            // 
            this.txt_hddv_sohd.Location = new System.Drawing.Point(109, 21);
            this.txt_hddv_sohd.Name = "txt_hddv_sohd";
            this.txt_hddv_sohd.Size = new System.Drawing.Size(133, 20);
            this.txt_hddv_sohd.TabIndex = 3;
            // 
            // lb_sohoadon
            // 
            this.lb_sohoadon.AutoSize = true;
            this.lb_sohoadon.ForeColor = System.Drawing.Color.White;
            this.lb_sohoadon.Location = new System.Drawing.Point(33, 24);
            this.lb_sohoadon.Name = "lb_sohoadon";
            this.lb_sohoadon.Size = new System.Drawing.Size(63, 13);
            this.lb_sohoadon.TabIndex = 2;
            this.lb_sohoadon.Text = "Số hóa đơn";
            this.lb_sohoadon.Click += new System.EventHandler(this.lb_sohoadon_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(379, 272);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv_hddv);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(371, 246);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Danh sách dịch vụ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgv_hddv
            // 
            this.dgv_hddv.BackgroundColor = System.Drawing.Color.SlateBlue;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_hddv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_hddv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hddv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_dsdv_madv,
            this.dgv_dsdv_tendv,
            this.dgv_dsdv_sl});
            this.dgv_hddv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_hddv.Location = new System.Drawing.Point(3, 3);
            this.dgv_hddv.Name = "dgv_hddv";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_hddv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_hddv.Size = new System.Drawing.Size(365, 240);
            this.dgv_hddv.TabIndex = 0;
            this.dgv_hddv.Click += new System.EventHandler(this.dgv_hddv_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgv_hddvchon);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(371, 246);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dịch vụ đã chọn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgv_hddvchon
            // 
            this.dgv_hddvchon.BackgroundColor = System.Drawing.Color.SlateBlue;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_hddvchon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_hddvchon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hddvchon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgv_hddvchon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_hddvchon.Location = new System.Drawing.Point(3, 3);
            this.dgv_hddvchon.Name = "dgv_hddvchon";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_hddvchon.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_hddvchon.Size = new System.Drawing.Size(365, 240);
            this.dgv_hddvchon.TabIndex = 1;
            this.dgv_hddvchon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã dịch vụ";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên dịch vụ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Số lượng";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dgv_dsdv_madv
            // 
            this.dgv_dsdv_madv.HeaderText = "Mã dịch vụ";
            this.dgv_dsdv_madv.Name = "dgv_dsdv_madv";
            // 
            // dgv_dsdv_tendv
            // 
            this.dgv_dsdv_tendv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_dsdv_tendv.HeaderText = "Tên dịch vụ";
            this.dgv_dsdv_tendv.Name = "dgv_dsdv_tendv";
            // 
            // dgv_dsdv_sl
            // 
            this.dgv_dsdv_sl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_dsdv_sl.HeaderText = "Số lượng hiện có";
            this.dgv_dsdv_sl.Name = "dgv_dsdv_sl";
            // 
            // nud_hddv_sl
            // 
            this.nud_hddv_sl.Location = new System.Drawing.Point(109, 92);
            this.nud_hddv_sl.Name = "nud_hddv_sl";
            this.nud_hddv_sl.Size = new System.Drawing.Size(120, 20);
            this.nud_hddv_sl.TabIndex = 8;
            // 
            // frm_hddv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 406);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frm_hddv";
            this.Text = "Hóa đơn - Dịch vụ";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hddv)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hddvchon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_hddv_sl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txt_hddv_sohd;
        private System.Windows.Forms.Label lb_sohoadon;
        private System.Windows.Forms.TextBox txt_hddv_madv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_hddv;
        private System.Windows.Forms.DataGridView dgv_hddvchon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_dsdv_madv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_dsdv_tendv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_dsdv_sl;
        private System.Windows.Forms.NumericUpDown nud_hddv_sl;
    }
}