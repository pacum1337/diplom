namespace UchetPractica
{
    partial class Profile
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
            this.bCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lInp1 = new System.Windows.Forms.Label();
            this.lInp2 = new System.Windows.Forms.Label();
            this.lInp3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tbOldPas = new System.Windows.Forms.TextBox();
            this.lPanelHeader = new System.Windows.Forms.Label();
            this.lPas = new System.Windows.Forms.Label();
            this.lSur = new System.Windows.Forms.Label();
            this.lLog = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCancel.Location = new System.Drawing.Point(12, 299);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(110, 46);
            this.bCancel.TabIndex = 37;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lInp1);
            this.panel1.Controls.Add(this.lInp2);
            this.panel1.Controls.Add(this.lInp3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.tbOldPas);
            this.panel1.Controls.Add(this.lPanelHeader);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 284);
            this.panel1.TabIndex = 43;
            this.panel1.Visible = false;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(3, 233);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 46);
            this.button2.TabIndex = 53;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(301, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 51);
            this.button1.TabIndex = 52;
            this.button1.Text = "Подтвердить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lInp1
            // 
            this.lInp1.AutoSize = true;
            this.lInp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lInp1.Location = new System.Drawing.Point(3, 95);
            this.lInp1.Name = "lInp1";
            this.lInp1.Size = new System.Drawing.Size(138, 24);
            this.lInp1.TabIndex = 51;
            this.lInp1.Text = "Новый пароль";
            // 
            // lInp2
            // 
            this.lInp2.AutoSize = true;
            this.lInp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lInp2.Location = new System.Drawing.Point(3, 129);
            this.lInp2.Name = "lInp2";
            this.lInp2.Size = new System.Drawing.Size(214, 24);
            this.lInp2.TabIndex = 50;
            this.lInp2.Text = "Повтор нового пароля";
            this.lInp2.Visible = false;
            // 
            // lInp3
            // 
            this.lInp3.AutoSize = true;
            this.lInp3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lInp3.Location = new System.Drawing.Point(3, 163);
            this.lInp3.Name = "lInp3";
            this.lInp3.Size = new System.Drawing.Size(147, 24);
            this.lInp3.TabIndex = 49;
            this.lInp3.Text = "Старый пароль";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(301, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 28);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(301, 125);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(165, 28);
            this.textBox2.TabIndex = 2;
            this.textBox2.Visible = false;
            // 
            // tbOldPas
            // 
            this.tbOldPas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbOldPas.Location = new System.Drawing.Point(301, 159);
            this.tbOldPas.Name = "tbOldPas";
            this.tbOldPas.Size = new System.Drawing.Size(165, 28);
            this.tbOldPas.TabIndex = 3;
            // 
            // lPanelHeader
            // 
            this.lPanelHeader.AutoSize = true;
            this.lPanelHeader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lPanelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPanelHeader.Location = new System.Drawing.Point(137, 18);
            this.lPanelHeader.Name = "lPanelHeader";
            this.lPanelHeader.Size = new System.Drawing.Size(180, 24);
            this.lPanelHeader.TabIndex = 45;
            this.lPanelHeader.Text = "Изменение пароля";
            // 
            // lPas
            // 
            this.lPas.AutoSize = true;
            this.lPas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lPas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lPas.Location = new System.Drawing.Point(36, 222);
            this.lPas.Name = "lPas";
            this.lPas.Size = new System.Drawing.Size(169, 24);
            this.lPas.TabIndex = 44;
            this.lPas.Text = "Изменить пароль";
            this.lPas.Click += new System.EventHandler(this.lPas_Click);
            // 
            // lSur
            // 
            this.lSur.AutoSize = true;
            this.lSur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lSur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lSur.Location = new System.Drawing.Point(36, 117);
            this.lSur.Name = "lSur";
            this.lSur.Size = new System.Drawing.Size(188, 24);
            this.lSur.TabIndex = 45;
            this.lSur.Text = "Изменить фамилию";
            this.lSur.Click += new System.EventHandler(this.lSur_Click);
            // 
            // lLog
            // 
            this.lLog.AutoSize = true;
            this.lLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lLog.Location = new System.Drawing.Point(36, 173);
            this.lLog.Name = "lLog";
            this.lLog.Size = new System.Drawing.Size(157, 24);
            this.lLog.TabIndex = 46;
            this.lLog.Text = "Изменить логин";
            this.lLog.Click += new System.EventHandler(this.lLog_Click);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lName.Location = new System.Drawing.Point(36, 65);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(139, 24);
            this.lName.TabIndex = 47;
            this.lName.Text = "Изменить имя";
            this.lName.Click += new System.EventHandler(this.lName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(263, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(486, 291);
            this.panel2.TabIndex = 49;
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 369);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.lLog);
            this.Controls.Add(this.lSur);
            this.Controls.Add(this.lPas);
            this.Controls.Add(this.bCancel);
            this.MaximumSize = new System.Drawing.Size(798, 416);
            this.MinimumSize = new System.Drawing.Size(798, 416);
            this.Name = "Profile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Профиль пользователя";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lPas;
        private System.Windows.Forms.Label lSur;
        private System.Windows.Forms.Label lLog;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lPanelHeader;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox tbOldPas;
        private System.Windows.Forms.Label lInp1;
        private System.Windows.Forms.Label lInp2;
        private System.Windows.Forms.Label lInp3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
    }
}