namespace UchetPractica
{
    partial class Documents
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbPeriodEnd = new System.Windows.Forms.ComboBox();
            this.cbPeriodStart = new System.Windows.Forms.ComboBox();
            this.cbLiderCollege = new System.Windows.Forms.ComboBox();
            this.cbLiderOrg = new System.Windows.Forms.ComboBox();
            this.cbPracticPlace = new System.Windows.Forms.ComboBox();
            this.cbGroupNum = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 14);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1504, 469);
            this.dataGridView1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(80, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 24);
            this.label4.TabIndex = 39;
            this.label4.Text = "Номер группы";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(69, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 24);
            this.label7.TabIndex = 43;
            this.label7.Text = "Место практики";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(476, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(252, 24);
            this.label8.TabIndex = 45;
            this.label8.Text = "Наставник от организации";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(493, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(223, 24);
            this.label9.TabIndex = 47;
            this.label9.Text = "Наставник от колледжа";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(1007, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(245, 24);
            this.label10.TabIndex = 49;
            this.label10.Text = "Период практики (начало)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(971, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(282, 24);
            this.label11.TabIndex = 51;
            this.label11.Text = "Период практики (Окончание)";
            // 
            // bCancel
            // 
            this.bCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCancel.Location = new System.Drawing.Point(12, 487);
            this.bCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(116, 55);
            this.bCancel.TabIndex = 52;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbPeriodEnd);
            this.panel1.Controls.Add(this.cbPeriodStart);
            this.panel1.Controls.Add(this.cbLiderCollege);
            this.panel1.Controls.Add(this.cbLiderOrg);
            this.panel1.Controls.Add(this.cbPracticPlace);
            this.panel1.Controls.Add(this.cbGroupNum);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 549);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1505, 162);
            this.panel1.TabIndex = 54;
            // 
            // cbPeriodEnd
            // 
            this.cbPeriodEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeriodEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPeriodEnd.FormattingEnabled = true;
            this.cbPeriodEnd.Items.AddRange(new object[] {
            "Не учитывать"});
            this.cbPeriodEnd.Location = new System.Drawing.Point(1267, 49);
            this.cbPeriodEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPeriodEnd.Name = "cbPeriodEnd";
            this.cbPeriodEnd.Size = new System.Drawing.Size(235, 30);
            this.cbPeriodEnd.TabIndex = 63;
            // 
            // cbPeriodStart
            // 
            this.cbPeriodStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeriodStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPeriodStart.FormattingEnabled = true;
            this.cbPeriodStart.Items.AddRange(new object[] {
            "Не учитывать"});
            this.cbPeriodStart.Location = new System.Drawing.Point(1267, 14);
            this.cbPeriodStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPeriodStart.Name = "cbPeriodStart";
            this.cbPeriodStart.Size = new System.Drawing.Size(235, 30);
            this.cbPeriodStart.TabIndex = 62;
            // 
            // cbLiderCollege
            // 
            this.cbLiderCollege.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLiderCollege.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbLiderCollege.FormattingEnabled = true;
            this.cbLiderCollege.Items.AddRange(new object[] {
            "Не учитывать"});
            this.cbLiderCollege.Location = new System.Drawing.Point(735, 52);
            this.cbLiderCollege.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLiderCollege.Name = "cbLiderCollege";
            this.cbLiderCollege.Size = new System.Drawing.Size(235, 30);
            this.cbLiderCollege.TabIndex = 61;
            // 
            // cbLiderOrg
            // 
            this.cbLiderOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLiderOrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbLiderOrg.FormattingEnabled = true;
            this.cbLiderOrg.Items.AddRange(new object[] {
            "Не учитывать"});
            this.cbLiderOrg.Location = new System.Drawing.Point(735, 16);
            this.cbLiderOrg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLiderOrg.Name = "cbLiderOrg";
            this.cbLiderOrg.Size = new System.Drawing.Size(235, 30);
            this.cbLiderOrg.TabIndex = 60;
            // 
            // cbPracticPlace
            // 
            this.cbPracticPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPracticPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPracticPlace.FormattingEnabled = true;
            this.cbPracticPlace.Items.AddRange(new object[] {
            "Не учитывать"});
            this.cbPracticPlace.Location = new System.Drawing.Point(229, 49);
            this.cbPracticPlace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPracticPlace.Name = "cbPracticPlace";
            this.cbPracticPlace.Size = new System.Drawing.Size(235, 30);
            this.cbPracticPlace.TabIndex = 59;
            // 
            // cbGroupNum
            // 
            this.cbGroupNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroupNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbGroupNum.FormattingEnabled = true;
            this.cbGroupNum.Items.AddRange(new object[] {
            "Не учитывать"});
            this.cbGroupNum.Location = new System.Drawing.Point(229, 14);
            this.cbGroupNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbGroupNum.Name = "cbGroupNum";
            this.cbGroupNum.Size = new System.Drawing.Size(235, 30);
            this.cbGroupNum.TabIndex = 57;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(1360, 98);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 55);
            this.button2.TabIndex = 54;
            this.button2.Text = "Фильтрация";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(1244, 487);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(275, 57);
            this.button6.TabIndex = 58;
            this.button6.Text = "Работа с выбранным документом";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(976, 487);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(263, 56);
            this.button5.TabIndex = 61;
            this.button5.Text = "Составить новый документ";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Documents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 768);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Documents";
            this.Text = "Архив документов";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox cbLiderCollege;
        private System.Windows.Forms.ComboBox cbLiderOrg;
        private System.Windows.Forms.ComboBox cbPracticPlace;
        private System.Windows.Forms.ComboBox cbGroupNum;
        private System.Windows.Forms.ComboBox cbPeriodEnd;
        private System.Windows.Forms.ComboBox cbPeriodStart;
    }
}