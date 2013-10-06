namespace ru.xnull
{
    partial class PayReflectZayavkaForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.myRateTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.operIdComboBox = new System.Windows.Forms.ComboBox();
            this.wmidComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.reflectRateTextBox = new System.Windows.Forms.TextBox();
            this.reflectIdTextBox = new System.Windows.Forms.TextBox();
            this.saleButton = new System.Windows.Forms.Button();
            this.resultRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.myRateTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.operIdComboBox);
            this.groupBox1.Controls.Add(this.wmidComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Моя заявка";
            // 
            // myRateTextBox
            // 
            this.myRateTextBox.Location = new System.Drawing.Point(83, 73);
            this.myRateTextBox.Name = "myRateTextBox";
            this.myRateTextBox.Size = new System.Drawing.Size(179, 20);
            this.myRateTextBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Курс заявки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID заявки";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "WMID";
            // 
            // operIdComboBox
            // 
            this.operIdComboBox.FormattingEnabled = true;
            this.operIdComboBox.Location = new System.Drawing.Point(83, 46);
            this.operIdComboBox.Name = "operIdComboBox";
            this.operIdComboBox.Size = new System.Drawing.Size(179, 21);
            this.operIdComboBox.TabIndex = 1;
            this.operIdComboBox.SelectedIndexChanged += new System.EventHandler(this.operIdComboBox_SelectedIndexChanged);
            this.operIdComboBox.Click += new System.EventHandler(this.operIdComboBox_Click);
            // 
            // wmidComboBox
            // 
            this.wmidComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wmidComboBox.FormattingEnabled = true;
            this.wmidComboBox.Location = new System.Drawing.Point(83, 19);
            this.wmidComboBox.Name = "wmidComboBox";
            this.wmidComboBox.Size = new System.Drawing.Size(179, 21);
            this.wmidComboBox.TabIndex = 0;
            this.wmidComboBox.Click += new System.EventHandler(this.wmidComboBox_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.reflectRateTextBox);
            this.groupBox2.Controls.Add(this.reflectIdTextBox);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox2.Location = new System.Drawing.Point(12, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 80);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Противоположная заявка";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Курс заявки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ID заявки";
            // 
            // reflectRateTextBox
            // 
            this.reflectRateTextBox.Location = new System.Drawing.Point(83, 45);
            this.reflectRateTextBox.Name = "reflectRateTextBox";
            this.reflectRateTextBox.Size = new System.Drawing.Size(179, 20);
            this.reflectRateTextBox.TabIndex = 1;
            // 
            // reflectIdTextBox
            // 
            this.reflectIdTextBox.Location = new System.Drawing.Point(83, 19);
            this.reflectIdTextBox.Name = "reflectIdTextBox";
            this.reflectIdTextBox.Size = new System.Drawing.Size(179, 20);
            this.reflectIdTextBox.TabIndex = 0;
            // 
            // saleButton
            // 
            this.saleButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.saleButton.Location = new System.Drawing.Point(95, 213);
            this.saleButton.Name = "saleButton";
            this.saleButton.Size = new System.Drawing.Size(185, 23);
            this.saleButton.TabIndex = 4;
            this.saleButton.Text = "Купить противоположную заявку";
            this.saleButton.UseVisualStyleBackColor = true;
            this.saleButton.Click += new System.EventHandler(this.saleButton_Click);
            // 
            // resultRichTextBox
            // 
            this.resultRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultRichTextBox.Location = new System.Drawing.Point(12, 255);
            this.resultRichTextBox.Name = "resultRichTextBox";
            this.resultRichTextBox.Size = new System.Drawing.Size(268, 75);
            this.resultRichTextBox.TabIndex = 5;
            this.resultRichTextBox.Text = "Result";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Результат операции";
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "По умолчанию отображается лучшая противоположная заявка к заявке пользователя";
            // 
            // PayReflectZayavkaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 342);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.resultRichTextBox);
            this.Controls.Add(this.saleButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PayReflectZayavkaForm";
            this.Text = "Покупка противоположных заявок";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox operIdComboBox;
        private System.Windows.Forms.ComboBox wmidComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox reflectRateTextBox;
        private System.Windows.Forms.TextBox reflectIdTextBox;
        private System.Windows.Forms.TextBox myRateTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saleButton;
        private System.Windows.Forms.RichTextBox resultRichTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}