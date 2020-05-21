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
            this.графикУПToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportExcelGraphikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShablonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показУведомленийОППToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеОтделенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оИПТСToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.группы2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.группы3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.группы4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьУведомленияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьДоСледующейНеделиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bEnter = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lStudyProcess = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProfileToolStripMenuItem,
            this.графикУПToolStripMenuItem,
            this.показУведомленийОППToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(609, 28);
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
            // графикУПToolStripMenuItem
            // 
            this.графикУПToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportExcelGraphikToolStripMenuItem,
            this.ShablonToolStripMenuItem});
            this.графикУПToolStripMenuItem.Name = "графикУПToolStripMenuItem";
            this.графикУПToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.графикУПToolStripMenuItem.Text = "График УП";
            // 
            // ImportExcelGraphikToolStripMenuItem
            // 
            this.ImportExcelGraphikToolStripMenuItem.Name = "ImportExcelGraphikToolStripMenuItem";
            this.ImportExcelGraphikToolStripMenuItem.Size = new System.Drawing.Size(329, 26);
            this.ImportExcelGraphikToolStripMenuItem.Text = "Импортировать график УП";
            this.ImportExcelGraphikToolStripMenuItem.Click += new System.EventHandler(this.ImportExcelGraphikToolStripMenuItem_Click);
            // 
            // ShablonToolStripMenuItem
            // 
            this.ShablonToolStripMenuItem.Name = "ShablonToolStripMenuItem";
            this.ShablonToolStripMenuItem.Size = new System.Drawing.Size(329, 26);
            this.ShablonToolStripMenuItem.Text = "Скачать шаблон Exel для импорта";
            this.ShablonToolStripMenuItem.Click += new System.EventHandler(this.ShablonToolStripMenuItem_Click);
            // 
            // показУведомленийОППToolStripMenuItem
            // 
            this.показУведомленийОППToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.всеОтделенияToolStripMenuItem,
            this.оИПТСToolStripMenuItem,
            this.группы2ToolStripMenuItem,
            this.группы3ToolStripMenuItem,
            this.группы4ToolStripMenuItem,
            this.отключитьУведомленияToolStripMenuItem,
            this.отключитьДоСледующейНеделиToolStripMenuItem});
            this.показУведомленийОППToolStripMenuItem.Name = "показУведомленийОППToolStripMenuItem";
            this.показУведомленийОППToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
            this.показУведомленийОППToolStripMenuItem.Text = "Показ уведомлений о ПП";
            // 
            // всеОтделенияToolStripMenuItem
            // 
            this.всеОтделенияToolStripMenuItem.Name = "всеОтделенияToolStripMenuItem";
            this.всеОтделенияToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.всеОтделенияToolStripMenuItem.Text = "Все отделения";
            this.всеОтделенияToolStripMenuItem.Click += new System.EventHandler(this.всеОтделенияToolStripMenuItem_Click);
            // 
            // оИПТСToolStripMenuItem
            // 
            this.оИПТСToolStripMenuItem.Name = "оИПТСToolStripMenuItem";
            this.оИПТСToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.оИПТСToolStripMenuItem.Text = "Группы \"1***\"";
            this.оИПТСToolStripMenuItem.Click += new System.EventHandler(this.оИПТСToolStripMenuItem_Click);
            // 
            // группы2ToolStripMenuItem
            // 
            this.группы2ToolStripMenuItem.Name = "группы2ToolStripMenuItem";
            this.группы2ToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.группы2ToolStripMenuItem.Text = "Группы \"2***\"";
            this.группы2ToolStripMenuItem.Click += new System.EventHandler(this.группы2ToolStripMenuItem_Click);
            // 
            // группы3ToolStripMenuItem
            // 
            this.группы3ToolStripMenuItem.Name = "группы3ToolStripMenuItem";
            this.группы3ToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.группы3ToolStripMenuItem.Text = "Группы \"3***\"";
            this.группы3ToolStripMenuItem.Click += new System.EventHandler(this.группы3ToolStripMenuItem_Click);
            // 
            // группы4ToolStripMenuItem
            // 
            this.группы4ToolStripMenuItem.Name = "группы4ToolStripMenuItem";
            this.группы4ToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.группы4ToolStripMenuItem.Text = "Группы \"4***\"";
            this.группы4ToolStripMenuItem.Click += new System.EventHandler(this.группы4ToolStripMenuItem_Click);
            // 
            // отключитьУведомленияToolStripMenuItem
            // 
            this.отключитьУведомленияToolStripMenuItem.Name = "отключитьУведомленияToolStripMenuItem";
            this.отключитьУведомленияToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.отключитьУведомленияToolStripMenuItem.Text = "Отключить уведомления";
            this.отключитьУведомленияToolStripMenuItem.Click += new System.EventHandler(this.отключитьУведомленияToolStripMenuItem_Click);
            // 
            // отключитьДоСледующейНеделиToolStripMenuItem
            // 
            this.отключитьДоСледующейНеделиToolStripMenuItem.Name = "отключитьДоСледующейНеделиToolStripMenuItem";
            this.отключитьДоСледующейНеделиToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.отключитьДоСледующейНеделиToolStripMenuItem.Text = "Отключить до следующей недели";
            this.отключитьДоСледующейНеделиToolStripMenuItem.Click += new System.EventHandler(this.отключитьДоСледующейНеделиToolStripMenuItem_Click);
            // 
            // bEnter
            // 
            this.bEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bEnter.Location = new System.Drawing.Point(147, 159);
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
            this.button1.Location = new System.Drawing.Point(48, 75);
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
            this.button3.Location = new System.Drawing.Point(318, 161);
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
            this.button4.Location = new System.Drawing.Point(220, 75);
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
            this.dataGridView1.Location = new System.Drawing.Point(108, 254);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(56, 22);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.Visible = false;
            // 
            // lStudyProcess
            // 
            this.lStudyProcess.AutoSize = true;
            this.lStudyProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lStudyProcess.Location = new System.Drawing.Point(12, 39);
            this.lStudyProcess.Name = "lStudyProcess";
            this.lStudyProcess.Size = new System.Drawing.Size(285, 24);
            this.lStudyProcess.TabIndex = 39;
            this.lStudyProcess.Text = "График учебного процесса на ";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(391, 75);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 82);
            this.button2.TabIndex = 40;
            this.button2.Text = "ПМ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 277);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lStudyProcess);
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
        private System.Windows.Forms.ToolStripMenuItem показУведомленийОППToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеОтделенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShablonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оИПТСToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem группы2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem группы3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem группы4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отключитьУведомленияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отключитьДоСледующейНеделиToolStripMenuItem;
        private System.Windows.Forms.Label lStudyProcess;
        private System.Windows.Forms.Button button2;
    }
}

