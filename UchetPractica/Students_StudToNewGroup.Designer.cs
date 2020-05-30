namespace UchetPractica
{
    partial class Students_StudToNewGroup
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
            this.lGroupNum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bEnterShow = new System.Windows.Forms.Button();
            this.bCancelShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lGroupNum
            // 
            this.lGroupNum.AutoSize = true;
            this.lGroupNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lGroupNum.Location = new System.Drawing.Point(201, 9);
            this.lGroupNum.Name = "lGroupNum";
            this.lGroupNum.Size = new System.Drawing.Size(86, 24);
            this.lGroupNum.TabIndex = 39;
            this.lGroupNum.Text = "Студент";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 24);
            this.label1.TabIndex = 40;
            this.label1.Text = "Перевод студента";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 24);
            this.label2.TabIndex = 41;
            this.label2.Text = "В группу";
            // 
            // cbGroup
            // 
            this.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(105, 44);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(208, 30);
            this.cbGroup.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(54, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 24);
            this.label3.TabIndex = 55;
            this.label3.Text = "ID студента";
            this.label3.Visible = false;
            // 
            // bEnterShow
            // 
            this.bEnterShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bEnterShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bEnterShow.Location = new System.Drawing.Point(205, 117);
            this.bEnterShow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bEnterShow.Name = "bEnterShow";
            this.bEnterShow.Size = new System.Drawing.Size(147, 55);
            this.bEnterShow.TabIndex = 57;
            this.bEnterShow.Text = "Подтвердить";
            this.bEnterShow.UseVisualStyleBackColor = true;
            this.bEnterShow.Click += new System.EventHandler(this.bEnterShow_Click);
            // 
            // bCancelShow
            // 
            this.bCancelShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCancelShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCancelShow.Location = new System.Drawing.Point(12, 117);
            this.bCancelShow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bCancelShow.Name = "bCancelShow";
            this.bCancelShow.Size = new System.Drawing.Size(137, 55);
            this.bCancelShow.TabIndex = 56;
            this.bCancelShow.Text = "Отмена";
            this.bCancelShow.UseVisualStyleBackColor = true;
            this.bCancelShow.Click += new System.EventHandler(this.bCancelShow_Click);
            // 
            // Students_StudToNewGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 189);
            this.Controls.Add(this.bEnterShow);
            this.Controls.Add(this.bCancelShow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lGroupNum);
            this.MaximumSize = new System.Drawing.Size(388, 236);
            this.MinimumSize = new System.Drawing.Size(388, 236);
            this.Name = "Students_StudToNewGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Перевод студента";
            this.Load += new System.EventHandler(this.Students_StudToNewGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbGroup;
        public System.Windows.Forms.Label lGroupNum;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bEnterShow;
        private System.Windows.Forms.Button bCancelShow;
    }
}