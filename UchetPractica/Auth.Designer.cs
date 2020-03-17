namespace UchetPractica
{
    partial class Auth
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
            this.label2 = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.bEnter = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tbPas = new System.Windows.Forms.TextBox();
            this.cbRemember = new System.Windows.Forms.CheckBox();
            this.lReg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(104, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(94, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // bCancel
            // 
            this.bCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCancel.Location = new System.Drawing.Point(12, 257);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(110, 46);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bEnter
            // 
            this.bEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bEnter.Location = new System.Drawing.Point(328, 252);
            this.bEnter.Name = "bEnter";
            this.bEnter.Size = new System.Drawing.Size(114, 46);
            this.bEnter.TabIndex = 4;
            this.bEnter.Text = "Вход";
            this.bEnter.UseVisualStyleBackColor = true;
            this.bEnter.Click += new System.EventHandler(this.bEnter_Click);
            // 
            // tbLog
            // 
            this.tbLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLog.Location = new System.Drawing.Point(186, 81);
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(165, 28);
            this.tbLog.TabIndex = 5;
            // 
            // tbPas
            // 
            this.tbPas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPas.Location = new System.Drawing.Point(186, 127);
            this.tbPas.Name = "tbPas";
            this.tbPas.PasswordChar = '*';
            this.tbPas.Size = new System.Drawing.Size(165, 28);
            this.tbPas.TabIndex = 6;
            // 
            // cbRemember
            // 
            this.cbRemember.AutoSize = true;
            this.cbRemember.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbRemember.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbRemember.Location = new System.Drawing.Point(98, 192);
            this.cbRemember.Name = "cbRemember";
            this.cbRemember.Size = new System.Drawing.Size(183, 28);
            this.cbRemember.TabIndex = 7;
            this.cbRemember.Text = "Запомнить меня";
            this.cbRemember.UseVisualStyleBackColor = true;
            // 
            // lReg
            // 
            this.lReg.AutoSize = true;
            this.lReg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lReg.Location = new System.Drawing.Point(316, 9);
            this.lReg.Name = "lReg";
            this.lReg.Size = new System.Drawing.Size(126, 24);
            this.lReg.TabIndex = 8;
            this.lReg.Text = "Регистрация";
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 310);
            this.Controls.Add(this.lReg);
            this.Controls.Add(this.cbRemember);
            this.Controls.Add(this.tbPas);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.bEnter);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximumSize = new System.Drawing.Size(472, 357);
            this.MinimumSize = new System.Drawing.Size(472, 357);
            this.Name = "Auth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация пользователя";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Auth_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bEnter;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.TextBox tbPas;
        private System.Windows.Forms.CheckBox cbRemember;
        private System.Windows.Forms.Label lReg;
    }
}