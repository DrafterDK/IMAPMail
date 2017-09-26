namespace IMAP_Mail
{
    partial class Form1
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
            this.textBoxTheme = new System.Windows.Forms.TextBox();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.buttonGetMail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxTheme
            // 
            this.textBoxTheme.Location = new System.Drawing.Point(66, 21);
            this.textBoxTheme.Name = "textBoxTheme";
            this.textBoxTheme.Size = new System.Drawing.Size(462, 20);
            this.textBoxTheme.TabIndex = 0;
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Location = new System.Drawing.Point(66, 62);
            this.textBoxSubject.Multiline = true;
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSubject.Size = new System.Drawing.Size(872, 148);
            this.textBoxSubject.TabIndex = 0;
            // 
            // buttonGetMail
            // 
            this.buttonGetMail.Location = new System.Drawing.Point(257, 216);
            this.buttonGetMail.Name = "buttonGetMail";
            this.buttonGetMail.Size = new System.Drawing.Size(75, 23);
            this.buttonGetMail.TabIndex = 1;
            this.buttonGetMail.Text = "Get mail";
            this.buttonGetMail.UseVisualStyleBackColor = true;
            this.buttonGetMail.Click += new System.EventHandler(this.buttonGetMail_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 248);
            this.Controls.Add(this.buttonGetMail);
            this.Controls.Add(this.textBoxSubject);
            this.Controls.Add(this.textBoxTheme);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTheme;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.Button buttonGetMail;
    }
}

