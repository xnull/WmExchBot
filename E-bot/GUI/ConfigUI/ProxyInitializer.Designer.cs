namespace ru.xnull.GUI.ConfigUI
{
    partial class ProxyInitializer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.proxyUseProxytextBox = new System.Windows.Forms.ComboBox();
            this.proxyPasswdTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.proxyLoginTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.proxyIptextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.proxyUseProxytextBox);
            this.groupBox1.Controls.Add(this.proxyPasswdTextBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.proxyLoginTextBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.proxyIptextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 155);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки прокси сервера";
            // 
            // proxyUseProxytextBox
            // 
            this.proxyUseProxytextBox.FormattingEnabled = true;
            this.proxyUseProxytextBox.Items.AddRange(new object[] {
            "False",
            "True"});
            this.proxyUseProxytextBox.Location = new System.Drawing.Point(91, 30);
            this.proxyUseProxytextBox.Name = "proxyUseProxytextBox";
            this.proxyUseProxytextBox.Size = new System.Drawing.Size(157, 21);
            this.proxyUseProxytextBox.TabIndex = 9;
            // 
            // proxyPasswdTextBox
            // 
            this.proxyPasswdTextBox.Location = new System.Drawing.Point(91, 109);
            this.proxyPasswdTextBox.Name = "proxyPasswdTextBox";
            this.proxyPasswdTextBox.Size = new System.Drawing.Size(157, 20);
            this.proxyPasswdTextBox.TabIndex = 8;
            this.proxyPasswdTextBox.UseSystemPasswordChar = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Использовать";
            // 
            // proxyLoginTextBox
            // 
            this.proxyLoginTextBox.Location = new System.Drawing.Point(91, 83);
            this.proxyLoginTextBox.Name = "proxyLoginTextBox";
            this.proxyLoginTextBox.Size = new System.Drawing.Size(157, 20);
            this.proxyLoginTextBox.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Логин";
            // 
            // proxyIptextBox
            // 
            this.proxyIptextBox.Location = new System.Drawing.Point(91, 57);
            this.proxyIptextBox.Name = "proxyIptextBox";
            this.proxyIptextBox.Size = new System.Drawing.Size(157, 20);
            this.proxyIptextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "IP адрес";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(254, 51);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "Если для работы с интернетом \nВы используете прокси сервер, то здесь необходимо з" +
                "адать его настройки";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(191, 231);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // ProxyInitializer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 266);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(286, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(286, 300);
            this.Name = "ProxyInitializer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки прокси сервера";
            this.Load += new System.EventHandler(this.ProxyInitializer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox proxyUseProxytextBox;
        private System.Windows.Forms.TextBox proxyPasswdTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox proxyLoginTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox proxyIptextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button saveButton;
    }
}