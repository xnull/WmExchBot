namespace ru.xnull
{
    partial class MyWMForm
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.balanceButton = new System.Windows.Forms.Button();
            this.balanceTextBox = new System.Windows.Forms.TextBox();
            this.WmidComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.getHistoryButton = new System.Windows.Forms.Button();
            this.StartDateTextBox = new System.Windows.Forms.TextBox();
            this.FinishDateTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PurseComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resultRichTextBox = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.trustWmidComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.trustListButton = new System.Windows.Forms.Button();
            this.trustRichTextBox = new System.Windows.Forms.RichTextBox();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(652, 368);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Webmoney keeper classic";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(10, 10);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(636, 350);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.WmidComboBox);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.PurseComboBox);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.resultRichTextBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(628, 324);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "История операций";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.balanceButton);
            this.groupBox2.Controls.Add(this.balanceTextBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 56);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Баланс на кошельке";
            // 
            // balanceButton
            // 
            this.balanceButton.Location = new System.Drawing.Point(6, 21);
            this.balanceButton.Name = "balanceButton";
            this.balanceButton.Size = new System.Drawing.Size(102, 23);
            this.balanceButton.TabIndex = 1;
            this.balanceButton.Text = "Получить баланс";
            this.balanceButton.UseVisualStyleBackColor = true;
            this.balanceButton.Click += new System.EventHandler(this.balanceButton_Click);
            // 
            // balanceTextBox
            // 
            this.balanceTextBox.Location = new System.Drawing.Point(114, 23);
            this.balanceTextBox.Name = "balanceTextBox";
            this.balanceTextBox.Size = new System.Drawing.Size(89, 20);
            this.balanceTextBox.TabIndex = 2;
            // 
            // WmidComboBox
            // 
            this.WmidComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WmidComboBox.FormattingEnabled = true;
            this.WmidComboBox.Location = new System.Drawing.Point(67, 27);
            this.WmidComboBox.Name = "WmidComboBox";
            this.WmidComboBox.Size = new System.Drawing.Size(135, 21);
            this.WmidComboBox.TabIndex = 1;
            this.WmidComboBox.Click += new System.EventHandler(this.WmidComboBox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Кошелек";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.getHistoryButton);
            this.groupBox1.Controls.Add(this.StartDateTextBox);
            this.groupBox1.Controls.Add(this.FinishDateTextBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 157);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "История операций";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(5, 19);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(193, 13);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Формат времени (yyyyMMdd HH:mm)";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Начало";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Конец";
            // 
            // getHistoryButton
            // 
            this.getHistoryButton.Location = new System.Drawing.Point(63, 87);
            this.getHistoryButton.Name = "getHistoryButton";
            this.getHistoryButton.Size = new System.Drawing.Size(135, 23);
            this.getHistoryButton.TabIndex = 9;
            this.getHistoryButton.Text = "Получить историю";
            this.getHistoryButton.UseVisualStyleBackColor = true;
            this.getHistoryButton.Click += new System.EventHandler(this.getHistoryButton_Click);
            // 
            // StartDateTextBox
            // 
            this.StartDateTextBox.Location = new System.Drawing.Point(63, 35);
            this.StartDateTextBox.Name = "StartDateTextBox";
            this.StartDateTextBox.Size = new System.Drawing.Size(135, 20);
            this.StartDateTextBox.TabIndex = 7;
            // 
            // FinishDateTextBox
            // 
            this.FinishDateTextBox.Location = new System.Drawing.Point(63, 61);
            this.FinishDateTextBox.Name = "FinishDateTextBox";
            this.FinishDateTextBox.Size = new System.Drawing.Size(135, 20);
            this.FinishDateTextBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(221, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(331, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Результат выполнения запроса истории операций по кошельку";
            // 
            // PurseComboBox
            // 
            this.PurseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PurseComboBox.FormattingEnabled = true;
            this.PurseComboBox.Location = new System.Drawing.Point(67, 54);
            this.PurseComboBox.Name = "PurseComboBox";
            this.PurseComboBox.Size = new System.Drawing.Size(135, 21);
            this.PurseComboBox.TabIndex = 3;
            this.PurseComboBox.Click += new System.EventHandler(this.PurseComboBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "WMID";
            // 
            // resultRichTextBox
            // 
            this.resultRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultRichTextBox.Location = new System.Drawing.Point(221, 27);
            this.resultRichTextBox.Name = "resultRichTextBox";
            this.resultRichTextBox.Size = new System.Drawing.Size(401, 291);
            this.resultRichTextBox.TabIndex = 10;
            this.resultRichTextBox.Text = "";
            this.resultRichTextBox.WordWrap = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 394);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.trustRichTextBox);
            this.tabPage2.Controls.Add(this.trustWmidComboBox);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.trustListButton);
            this.tabPage2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(628, 324);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Список доверенных кошельков";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // trustWmidComboBox
            // 
            this.trustWmidComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trustWmidComboBox.FormattingEnabled = true;
            this.trustWmidComboBox.Location = new System.Drawing.Point(6, 28);
            this.trustWmidComboBox.Name = "trustWmidComboBox";
            this.trustWmidComboBox.Size = new System.Drawing.Size(112, 21);
            this.trustWmidComboBox.TabIndex = 7;
            this.trustWmidComboBox.UseWaitCursor = true;
            this.trustWmidComboBox.Click += new System.EventHandler(this.trustWmidComboBox_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "WMID";
            this.label7.UseWaitCursor = true;
            // 
            // trustListButton
            // 
            this.trustListButton.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.trustListButton.Location = new System.Drawing.Point(6, 55);
            this.trustListButton.Name = "trustListButton";
            this.trustListButton.Size = new System.Drawing.Size(112, 23);
            this.trustListButton.TabIndex = 6;
            this.trustListButton.Text = "Получить список";
            this.trustListButton.UseVisualStyleBackColor = true;
            this.trustListButton.UseWaitCursor = true;
            this.trustListButton.Click += new System.EventHandler(this.trustListButton_Click);
            // 
            // trustRichTextBox
            // 
            this.trustRichTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.trustRichTextBox.Location = new System.Drawing.Point(124, 6);
            this.trustRichTextBox.Name = "trustRichTextBox";
            this.trustRichTextBox.Size = new System.Drawing.Size(498, 312);
            this.trustRichTextBox.TabIndex = 9;
            this.trustRichTextBox.Text = "";
            // 
            // MyWMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 396);
            this.Controls.Add(this.tabControl1);
            this.Name = "MyWMForm";
            this.Text = "Webmoney инструменты";
            this.Load += new System.EventHandler(this.MyWMForm_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button balanceButton;
        private System.Windows.Forms.TextBox balanceTextBox;
        private System.Windows.Forms.RichTextBox resultRichTextBox;
        private System.Windows.Forms.Button getHistoryButton;
        private System.Windows.Forms.TextBox FinishDateTextBox;
        private System.Windows.Forms.TextBox StartDateTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox WmidComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PurseComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox trustWmidComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button trustListButton;
        private System.Windows.Forms.RichTextBox trustRichTextBox;

    }
}