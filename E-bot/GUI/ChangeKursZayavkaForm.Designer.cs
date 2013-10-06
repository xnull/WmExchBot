namespace ru.xnull
{
    partial class ChangeKursZayavkaForm
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
            this.wmidComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.myPayIdcomboBox = new System.Windows.Forms.ComboBox();
            this.changeRateButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.newRateTextBox = new System.Windows.Forms.TextBox();
            this.listMyPaysButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wmidComboBox
            // 
            this.wmidComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wmidComboBox.FormattingEnabled = true;
            this.wmidComboBox.Location = new System.Drawing.Point(84, 19);
            this.wmidComboBox.Name = "wmidComboBox";
            this.wmidComboBox.Size = new System.Drawing.Size(240, 21);
            this.wmidComboBox.TabIndex = 0;
            this.wmidComboBox.Click += new System.EventHandler(this.wmidComboBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "WMID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID_Завки";
            // 
            // myPayIdcomboBox
            // 
            this.myPayIdcomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPayIdcomboBox.FormattingEnabled = true;
            this.myPayIdcomboBox.Location = new System.Drawing.Point(84, 46);
            this.myPayIdcomboBox.Name = "myPayIdcomboBox";
            this.myPayIdcomboBox.Size = new System.Drawing.Size(240, 21);
            this.myPayIdcomboBox.TabIndex = 3;
            this.myPayIdcomboBox.SelectedIndexChanged += new System.EventHandler(this.myPayIdcomboBox_SelectedIndexChanged);
            this.myPayIdcomboBox.Click += new System.EventHandler(this.myPayIdcomboBox_Click);
            // 
            // changeRateButton
            // 
            this.changeRateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.changeRateButton.Location = new System.Drawing.Point(176, 131);
            this.changeRateButton.Name = "changeRateButton";
            this.changeRateButton.Size = new System.Drawing.Size(166, 23);
            this.changeRateButton.TabIndex = 4;
            this.changeRateButton.Text = "Изменить курс заявки";
            this.changeRateButton.UseVisualStyleBackColor = true;
            this.changeRateButton.Click += new System.EventHandler(this.changeRateButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultTextBox.Location = new System.Drawing.Point(12, 160);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(330, 192);
            this.resultTextBox.TabIndex = 5;
            this.resultTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Новый курс";
            // 
            // newRateTextBox
            // 
            this.newRateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.newRateTextBox.Location = new System.Drawing.Point(84, 79);
            this.newRateTextBox.Name = "newRateTextBox";
            this.newRateTextBox.Size = new System.Drawing.Size(240, 20);
            this.newRateTextBox.TabIndex = 9;
            // 
            // listMyPaysButton
            // 
            this.listMyPaysButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listMyPaysButton.Location = new System.Drawing.Point(176, 358);
            this.listMyPaysButton.Name = "listMyPaysButton";
            this.listMyPaysButton.Size = new System.Drawing.Size(166, 23);
            this.listMyPaysButton.TabIndex = 10;
            this.listMyPaysButton.Text = "Показать список заявок";
            this.listMyPaysButton.UseVisualStyleBackColor = true;
            this.listMyPaysButton.Click += new System.EventHandler(this.listMyPaysButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.wmidComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.newRateTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.myPayIdcomboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 113);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // ChangeKursZayavka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 392);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listMyPaysButton);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.changeRateButton);
            this.Name = "ChangeKursZayavka";
            this.Text = "Изменение курса заявки";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox wmidComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox myPayIdcomboBox;
        private System.Windows.Forms.Button changeRateButton;
        private System.Windows.Forms.RichTextBox resultTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox newRateTextBox;
        private System.Windows.Forms.Button listMyPaysButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}