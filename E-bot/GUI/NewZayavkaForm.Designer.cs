namespace ru.xnull
{
    partial class NewZayavkaForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.wmidComboBox = new System.Windows.Forms.ComboBox();
            this.inPurseComboBox = new System.Windows.Forms.ComboBox();
            this.outPurseComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.inAmountTextBox = new System.Windows.Forms.TextBox();
            this.outAmountTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.resultRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.payRateTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "WMID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Кошелек источник";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Кошелек получатель";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Сумма для обмена";
            // 
            // wmidComboBox
            // 
            this.wmidComboBox.FormattingEnabled = true;
            this.wmidComboBox.IntegralHeight = false;
            this.wmidComboBox.ItemHeight = 13;
            this.wmidComboBox.Location = new System.Drawing.Point(130, 11);
            this.wmidComboBox.Name = "wmidComboBox";
            this.wmidComboBox.Size = new System.Drawing.Size(166, 21);
            this.wmidComboBox.TabIndex = 8;
            this.wmidComboBox.Click += new System.EventHandler(this.wmidComboBox_Click);
            // 
            // inPurseComboBox
            // 
            this.inPurseComboBox.FormattingEnabled = true;
            this.inPurseComboBox.Location = new System.Drawing.Point(130, 38);
            this.inPurseComboBox.Name = "inPurseComboBox";
            this.inPurseComboBox.Size = new System.Drawing.Size(166, 21);
            this.inPurseComboBox.TabIndex = 9;
            this.inPurseComboBox.Click += new System.EventHandler(this.inPurseComboBox_Click);
            // 
            // outPurseComboBox
            // 
            this.outPurseComboBox.FormattingEnabled = true;
            this.outPurseComboBox.Location = new System.Drawing.Point(130, 65);
            this.outPurseComboBox.Name = "outPurseComboBox";
            this.outPurseComboBox.Size = new System.Drawing.Size(166, 21);
            this.outPurseComboBox.TabIndex = 10;
            this.outPurseComboBox.Click += new System.EventHandler(this.outPurseComboBox_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Желаемая сумма";
            // 
            // inAmountTextBox
            // 
            this.inAmountTextBox.Location = new System.Drawing.Point(130, 94);
            this.inAmountTextBox.Name = "inAmountTextBox";
            this.inAmountTextBox.Size = new System.Drawing.Size(166, 20);
            this.inAmountTextBox.TabIndex = 12;
            // 
            // outAmountTextBox
            // 
            this.outAmountTextBox.Location = new System.Drawing.Point(130, 120);
            this.outAmountTextBox.Name = "outAmountTextBox";
            this.outAmountTextBox.Size = new System.Drawing.Size(166, 20);
            this.outAmountTextBox.TabIndex = 13;
            this.outAmountTextBox.TextChanged += new System.EventHandler(this.outAmountTextBox_TextChanged);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(173, 172);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(123, 23);
            this.submitButton.TabIndex = 16;
            this.submitButton.Text = "Поставить заявку";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // resultRichTextBox
            // 
            this.resultRichTextBox.Location = new System.Drawing.Point(15, 225);
            this.resultRichTextBox.Name = "resultRichTextBox";
            this.resultRichTextBox.Size = new System.Drawing.Size(281, 113);
            this.resultRichTextBox.TabIndex = 17;
            this.resultRichTextBox.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Результат выполнения операции";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Курс заявки";
            // 
            // payRateTextBox
            // 
            this.payRateTextBox.Enabled = false;
            this.payRateTextBox.Location = new System.Drawing.Point(130, 146);
            this.payRateTextBox.Name = "payRateTextBox";
            this.payRateTextBox.Size = new System.Drawing.Size(166, 20);
            this.payRateTextBox.TabIndex = 15;
            // 
            // NewZayavka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 353);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.resultRichTextBox);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.payRateTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.outAmountTextBox);
            this.Controls.Add(this.inAmountTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.outPurseComboBox);
            this.Controls.Add(this.inPurseComboBox);
            this.Controls.Add(this.wmidComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewZayavka";
            this.Text = "Постановка новой заявки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox wmidComboBox;
        private System.Windows.Forms.ComboBox inPurseComboBox;
        private System.Windows.Forms.ComboBox outPurseComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inAmountTextBox;
        private System.Windows.Forms.TextBox outAmountTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.RichTextBox resultRichTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox payRateTextBox;
    }
}