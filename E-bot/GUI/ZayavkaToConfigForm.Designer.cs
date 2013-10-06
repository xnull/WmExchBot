namespace ru.xnull
{
    partial class ZayavkaToConfigForm
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
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.wmidComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.missingMyPaysComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.minRateTextBox = new System.Windows.Forms.TextBox();
            this.planPosTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.queryDateTextBox = new System.Windows.Forms.TextBox();
            this.outPurseTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.inPurseTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rateTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.amountOutTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.amountInTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.directionTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(287, 231);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(177, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Сохранить заявку в конфиге";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "WMID";
            // 
            // wmidComboBox
            // 
            this.wmidComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wmidComboBox.FormattingEnabled = true;
            this.wmidComboBox.Location = new System.Drawing.Point(221, 10);
            this.wmidComboBox.Name = "wmidComboBox";
            this.wmidComboBox.Size = new System.Drawing.Size(249, 21);
            this.wmidComboBox.TabIndex = 2;
            this.wmidComboBox.Click += new System.EventHandler(this.wmidComboBox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Список заявок которых нет в конфиге";
            // 
            // missingMyPaysComboBox
            // 
            this.missingMyPaysComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.missingMyPaysComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.missingMyPaysComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.missingMyPaysComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.missingMyPaysComboBox.FormattingEnabled = true;
            this.missingMyPaysComboBox.Location = new System.Drawing.Point(221, 38);
            this.missingMyPaysComboBox.Name = "missingMyPaysComboBox";
            this.missingMyPaysComboBox.Size = new System.Drawing.Size(249, 21);
            this.missingMyPaysComboBox.TabIndex = 4;
            this.missingMyPaysComboBox.SelectedIndexChanged += new System.EventHandler(this.missingMyPaysComboBox_SelectedIndexChanged);
            this.missingMyPaysComboBox.Click += new System.EventHandler(this.missingMyPaysComboBox_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.minRateTextBox);
            this.groupBox1.Controls.Add(this.planPosTextBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.queryDateTextBox);
            this.groupBox1.Controls.Add(this.outPurseTextBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.inPurseTextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.rateTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.amountOutTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.amountInTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.directionTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.idTextBox);
            this.groupBox1.Location = new System.Drawing.Point(15, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 160);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация о выбранной заявке";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(201, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "MinKurs";
            // 
            // minRateTextBox
            // 
            this.minRateTextBox.Location = new System.Drawing.Point(272, 123);
            this.minRateTextBox.Name = "minRateTextBox";
            this.minRateTextBox.Size = new System.Drawing.Size(177, 20);
            this.minRateTextBox.TabIndex = 7;
            // 
            // planPosTextBox
            // 
            this.planPosTextBox.Location = new System.Drawing.Point(272, 97);
            this.planPosTextBox.Name = "planPosTextBox";
            this.planPosTextBox.Size = new System.Drawing.Size(177, 20);
            this.planPosTextBox.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(201, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "PlanPos";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(201, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "QueryDate";
            // 
            // queryDateTextBox
            // 
            this.queryDateTextBox.Location = new System.Drawing.Point(272, 71);
            this.queryDateTextBox.Name = "queryDateTextBox";
            this.queryDateTextBox.Size = new System.Drawing.Size(177, 20);
            this.queryDateTextBox.TabIndex = 7;
            // 
            // outPurseTextBox
            // 
            this.outPurseTextBox.Enabled = false;
            this.outPurseTextBox.Location = new System.Drawing.Point(272, 45);
            this.outPurseTextBox.Name = "outPurseTextBox";
            this.outPurseTextBox.Size = new System.Drawing.Size(177, 20);
            this.outPurseTextBox.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(201, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "OutPurse";
            // 
            // inPurseTextBox
            // 
            this.inPurseTextBox.Enabled = false;
            this.inPurseTextBox.Location = new System.Drawing.Point(272, 19);
            this.inPurseTextBox.Name = "inPurseTextBox";
            this.inPurseTextBox.Size = new System.Drawing.Size(177, 20);
            this.inPurseTextBox.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "InPurse";
            // 
            // rateTextBox
            // 
            this.rateTextBox.Enabled = false;
            this.rateTextBox.Location = new System.Drawing.Point(93, 125);
            this.rateTextBox.Name = "rateTextBox";
            this.rateTextBox.Size = new System.Drawing.Size(86, 20);
            this.rateTextBox.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Kurs";
            // 
            // amountOutTextBox
            // 
            this.amountOutTextBox.Enabled = false;
            this.amountOutTextBox.Location = new System.Drawing.Point(93, 99);
            this.amountOutTextBox.Name = "amountOutTextBox";
            this.amountOutTextBox.Size = new System.Drawing.Size(86, 20);
            this.amountOutTextBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "AmountOut";
            // 
            // amountInTextBox
            // 
            this.amountInTextBox.Enabled = false;
            this.amountInTextBox.Location = new System.Drawing.Point(93, 73);
            this.amountInTextBox.Name = "amountInTextBox";
            this.amountInTextBox.Size = new System.Drawing.Size(86, 20);
            this.amountInTextBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "AmountIn";
            // 
            // directionTextBox
            // 
            this.directionTextBox.Enabled = false;
            this.directionTextBox.Location = new System.Drawing.Point(93, 45);
            this.directionTextBox.Name = "directionTextBox";
            this.directionTextBox.Size = new System.Drawing.Size(86, 20);
            this.directionTextBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Direction";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "ID";
            // 
            // idTextBox
            // 
            this.idTextBox.BackColor = System.Drawing.Color.LightYellow;
            this.idTextBox.Enabled = false;
            this.idTextBox.Location = new System.Drawing.Point(93, 19);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(86, 20);
            this.idTextBox.TabIndex = 0;
            // 
            // ZayavkaToConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 269);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.missingMyPaysComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.wmidComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Name = "ZayavkaToConfig";
            this.Text = "Добавить заявку с сайта в конфиг";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox wmidComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox missingMyPaysComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox outPurseTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox inPurseTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox rateTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox amountOutTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox amountInTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox directionTextBox;
        private System.Windows.Forms.TextBox planPosTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox queryDateTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox minRateTextBox;
    }
}