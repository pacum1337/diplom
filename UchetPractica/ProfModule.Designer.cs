namespace UchetPractica
{
    partial class ProfModule
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
            this.bAddShow = new System.Windows.Forms.Button();
            this.bEditShow = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.pStud = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbStatusStud = new System.Windows.Forms.ComboBox();
            this.cbCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bEnterShow = new System.Windows.Forms.Button();
            this.bCancelShow = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pStud.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(600, 332);
            this.dataGridView1.TabIndex = 0;
            // 
            // bAddShow
            // 
            this.bAddShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bAddShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bAddShow.Location = new System.Drawing.Point(374, 349);
            this.bAddShow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bAddShow.Name = "bAddShow";
            this.bAddShow.Size = new System.Drawing.Size(116, 55);
            this.bAddShow.TabIndex = 31;
            this.bAddShow.Text = "Добавить";
            this.bAddShow.UseVisualStyleBackColor = true;
            this.bAddShow.Click += new System.EventHandler(this.bAddShow_Click);
            // 
            // bEditShow
            // 
            this.bEditShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bEditShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bEditShow.Location = new System.Drawing.Point(496, 349);
            this.bEditShow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bEditShow.Name = "bEditShow";
            this.bEditShow.Size = new System.Drawing.Size(116, 55);
            this.bEditShow.TabIndex = 30;
            this.bEditShow.Text = "Изменить";
            this.bEditShow.UseVisualStyleBackColor = true;
            this.bEditShow.Click += new System.EventHandler(this.bEditShow_Click);
            // 
            // bCancel
            // 
            this.bCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCancel.Location = new System.Drawing.Point(128, 351);
            this.bCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(116, 55);
            this.bCancel.TabIndex = 28;
            this.bCancel.Text = "Назад";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // pStud
            // 
            this.pStud.Controls.Add(this.label2);
            this.pStud.Controls.Add(this.comboBox1);
            this.pStud.Controls.Add(this.label10);
            this.pStud.Controls.Add(this.cbStatusStud);
            this.pStud.Controls.Add(this.cbCode);
            this.pStud.Controls.Add(this.label4);
            this.pStud.Controls.Add(this.label1);
            this.pStud.Controls.Add(this.bEnterShow);
            this.pStud.Controls.Add(this.bCancelShow);
            this.pStud.Controls.Add(this.tbName);
            this.pStud.Controls.Add(this.label5);
            this.pStud.Location = new System.Drawing.Point(618, 11);
            this.pStud.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pStud.Name = "pStud";
            this.pStud.Size = new System.Drawing.Size(444, 332);
            this.pStud.TabIndex = 32;
            this.pStud.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(19, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 24);
            this.label2.TabIndex = 60;
            this.label2.Text = "Тип практики";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Пу",
            "Пу(р)",
            "Пп",
            "Пд"});
            this.comboBox1.Location = new System.Drawing.Point(213, 143);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(208, 30);
            this.comboBox1.TabIndex = 59;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(19, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 24);
            this.label10.TabIndex = 58;
            this.label10.Text = "Статус";
            // 
            // cbStatusStud
            // 
            this.cbStatusStud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusStud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbStatusStud.FormattingEnabled = true;
            this.cbStatusStud.Items.AddRange(new object[] {
            "Отображается",
            "Скрытое"});
            this.cbStatusStud.Location = new System.Drawing.Point(213, 179);
            this.cbStatusStud.Name = "cbStatusStud";
            this.cbStatusStud.Size = new System.Drawing.Size(208, 30);
            this.cbStatusStud.TabIndex = 57;
            // 
            // cbCode
            // 
            this.cbCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbCode.FormattingEnabled = true;
            this.cbCode.Location = new System.Drawing.Point(213, 75);
            this.cbCode.Name = "cbCode";
            this.cbCode.Size = new System.Drawing.Size(208, 30);
            this.cbCode.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(19, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 24);
            this.label4.TabIndex = 36;
            this.label4.Text = "Настройки студента";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(19, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 24);
            this.label1.TabIndex = 33;
            this.label1.Text = "Название ПМ";
            // 
            // bEnterShow
            // 
            this.bEnterShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bEnterShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bEnterShow.Location = new System.Drawing.Point(287, 275);
            this.bEnterShow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bEnterShow.Name = "bEnterShow";
            this.bEnterShow.Size = new System.Drawing.Size(147, 55);
            this.bEnterShow.TabIndex = 31;
            this.bEnterShow.Text = "Подтвердить";
            this.bEnterShow.UseVisualStyleBackColor = true;
            this.bEnterShow.Click += new System.EventHandler(this.bEnterShow_Click);
            // 
            // bCancelShow
            // 
            this.bCancelShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCancelShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCancelShow.Location = new System.Drawing.Point(3, 275);
            this.bCancelShow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bCancelShow.Name = "bCancelShow";
            this.bCancelShow.Size = new System.Drawing.Size(137, 55);
            this.bCancelShow.TabIndex = 30;
            this.bCancelShow.Text = "Отмена";
            this.bCancelShow.UseVisualStyleBackColor = true;
            this.bCancelShow.Click += new System.EventHandler(this.bCancelShow_Click);
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbName.Location = new System.Drawing.Point(213, 110);
            this.tbName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(208, 28);
            this.tbName.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(19, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 24);
            this.label5.TabIndex = 23;
            this.label5.Text = "Код специальности";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 56);
            this.button1.TabIndex = 41;
            this.button1.Text = "Выйти";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProfModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 417);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pStud);
            this.Controls.Add(this.bAddShow);
            this.Controls.Add(this.bEditShow);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.dataGridView1);
            this.MaximumSize = new System.Drawing.Size(1095, 464);
            this.MinimumSize = new System.Drawing.Size(1095, 464);
            this.Name = "ProfModule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Проф. модули";
            this.Load += new System.EventHandler(this.ProfModule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pStud.ResumeLayout(false);
            this.pStud.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bAddShow;
        private System.Windows.Forms.Button bEditShow;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Panel pStud;
        private System.Windows.Forms.ComboBox cbCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bEnterShow;
        private System.Windows.Forms.Button bCancelShow;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbStatusStud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}