namespace UchetPractica
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redactProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bEnter = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.графикУПToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportExcelGraphikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProfileToolStripMenuItem,
            this.графикУПToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1165, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ProfileToolStripMenuItem
            // 
            this.ProfileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redactProfileToolStripMenuItem,
            this.UserExitToolStripMenuItem});
            this.ProfileToolStripMenuItem.Name = "ProfileToolStripMenuItem";
            this.ProfileToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.ProfileToolStripMenuItem.Text = "Профиль";
            // 
            // redactProfileToolStripMenuItem
            // 
            this.redactProfileToolStripMenuItem.Name = "redactProfileToolStripMenuItem";
            this.redactProfileToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.redactProfileToolStripMenuItem.Text = "Изменить профиль";
            this.redactProfileToolStripMenuItem.Click += new System.EventHandler(this.redactProfileToolStripMenuItem_Click);
            // 
            // UserExitToolStripMenuItem
            // 
            this.UserExitToolStripMenuItem.Name = "UserExitToolStripMenuItem";
            this.UserExitToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.UserExitToolStripMenuItem.Text = "Выйти из профиля";
            this.UserExitToolStripMenuItem.Click += new System.EventHandler(this.UserExitToolStripMenuItem_Click);
            // 
            // bEnter
            // 
            this.bEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bEnter.Location = new System.Drawing.Point(78, 154);
            this.bEnter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bEnter.Name = "bEnter";
            this.bEnter.Size = new System.Drawing.Size(165, 82);
            this.bEnter.TabIndex = 1;
            this.bEnter.Text = "Студенты и Группы";
            this.bEnter.UseVisualStyleBackColor = true;
            this.bEnter.Click += new System.EventHandler(this.bEnter_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(78, 68);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 82);
            this.button1.TabIndex = 2;
            this.button1.Text = "Организации";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(249, 156);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 82);
            this.button3.TabIndex = 4;
            this.button3.Text = "Документы";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(250, 68);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(165, 82);
            this.button4.TabIndex = 3;
            this.button4.Text = "Руководители практики";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(532, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(539, 376);
            this.dataGridView1.TabIndex = 5;
            // 
            // графикУПToolStripMenuItem
            // 
            this.графикУПToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportExcelGraphikToolStripMenuItem});
            this.графикУПToolStripMenuItem.Name = "графикУПToolStripMenuItem";
            this.графикУПToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.графикУПToolStripMenuItem.Text = "График УП";
            // 
            // ImportExcelGraphikToolStripMenuItem
            // 
            this.ImportExcelGraphikToolStripMenuItem.Name = "ImportExcelGraphikToolStripMenuItem";
            this.ImportExcelGraphikToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.ImportExcelGraphikToolStripMenuItem.Text = "Импортировать график УП";
            this.ImportExcelGraphikToolStripMenuItem.Click += new System.EventHandler(this.ImportExcelGraphikToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 478);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bEnter);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню быстрого доступа";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserExitToolStripMenuItem;
        private System.Windows.Forms.Button bEnter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem redactProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графикУПToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportExcelGraphikToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

