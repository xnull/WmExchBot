namespace ru.xnull
{
    partial class SearcherForTorgiForm
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
            this.operIdComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.wmidComboBox = new System.Windows.Forms.ComboBox();
            this.findPositionButton = new System.Windows.Forms.Button();
            this.resultRichTextBox = new System.Windows.Forms.RichTextBox();
            this.rateButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.positionMyPayTextBox = new System.Windows.Forms.TextBox();
            this.directionExchangeTextBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.directExch2ComboBox = new System.Windows.Forms.ComboBox();
            this.findMyPayButton = new System.Windows.Forms.Button();
            this.operIdTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // operIdComboBox
            // 
            this.operIdComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.operIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operIdComboBox.FormattingEnabled = true;
            this.operIdComboBox.Location = new System.Drawing.Point(64, 32);
            this.operIdComboBox.Name = "operIdComboBox";
            this.operIdComboBox.Size = new System.Drawing.Size(276, 21);
            this.operIdComboBox.TabIndex = 7;
            this.operIdComboBox.SelectedIndexChanged += new System.EventHandler(this.operIdComboBox_SelectedIndexChanged);
            this.operIdComboBox.Click += new System.EventHandler(this.operIdComboBox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Operid";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "WMID";
            // 
            // wmidComboBox
            // 
            this.wmidComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wmidComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wmidComboBox.FormattingEnabled = true;
            this.wmidComboBox.Location = new System.Drawing.Point(64, 5);
            this.wmidComboBox.Name = "wmidComboBox";
            this.wmidComboBox.Size = new System.Drawing.Size(276, 21);
            this.wmidComboBox.TabIndex = 4;
            this.wmidComboBox.Click += new System.EventHandler(this.wmidComboBox_Click);
            // 
            // findPositionButton
            // 
            this.findPositionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.findPositionButton.Location = new System.Drawing.Point(64, 59);
            this.findPositionButton.Name = "findPositionButton";
            this.findPositionButton.Size = new System.Drawing.Size(276, 23);
            this.findPositionButton.TabIndex = 8;
            this.findPositionButton.Text = "Найти место на котором находится моя заявка";
            this.findPositionButton.UseVisualStyleBackColor = true;
            this.findPositionButton.Click += new System.EventHandler(this.findPositionButton_Click);
            // 
            // resultRichTextBox
            // 
            this.resultRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultRichTextBox.Location = new System.Drawing.Point(5, 132);
            this.resultRichTextBox.Name = "resultRichTextBox";
            this.resultRichTextBox.Size = new System.Drawing.Size(359, 199);
            this.resultRichTextBox.TabIndex = 9;
            this.resultRichTextBox.Text = "";
            // 
            // rateButton
            // 
            this.rateButton.Location = new System.Drawing.Point(227, 61);
            this.rateButton.Name = "rateButton";
            this.rateButton.Size = new System.Drawing.Size(113, 23);
            this.rateButton.TabIndex = 10;
            this.rateButton.Text = "Получить курс";
            this.rateButton.UseVisualStyleBackColor = true;
            this.rateButton.Click += new System.EventHandler(this.rateButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.wmidComboBox);
            this.panel1.Controls.Add(this.findPositionButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.operIdComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 87);
            this.panel1.TabIndex = 11;
            // 
            // positionMyPayTextBox
            // 
            this.positionMyPayTextBox.Location = new System.Drawing.Point(137, 34);
            this.positionMyPayTextBox.Name = "positionMyPayTextBox";
            this.positionMyPayTextBox.Size = new System.Drawing.Size(203, 20);
            this.positionMyPayTextBox.TabIndex = 9;
            // 
            // directionExchangeTextBox
            // 
            this.directionExchangeTextBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.directionExchangeTextBox.FormattingEnabled = true;
            this.directionExchangeTextBox.Location = new System.Drawing.Point(137, 7);
            this.directionExchangeTextBox.Name = "directionExchangeTextBox";
            this.directionExchangeTextBox.Size = new System.Drawing.Size(203, 21);
            this.directionExchangeTextBox.TabIndex = 12;
            this.directionExchangeTextBox.Click += new System.EventHandler(this.directionExchangeTextBox_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.directionExchangeTextBox);
            this.panel2.Controls.Add(this.rateButton);
            this.panel2.Controls.Add(this.positionMyPayTextBox);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 87);
            this.panel2.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Направление обмена";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Место заявки";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(5, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(363, 122);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(355, 96);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Позиция моей заявки";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(355, 96);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Курс для позиции";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(355, 96);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Поиск заявки по ID";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.directExch2ComboBox);
            this.panel3.Controls.Add(this.findMyPayButton);
            this.panel3.Controls.Add(this.operIdTextBox);
            this.panel3.Location = new System.Drawing.Point(6, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(345, 86);
            this.panel3.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Направление обмена";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "ID заявки";
            // 
            // directExch2ComboBox
            // 
            this.directExch2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.directExch2ComboBox.FormattingEnabled = true;
            this.directExch2ComboBox.Location = new System.Drawing.Point(144, 7);
            this.directExch2ComboBox.Name = "directExch2ComboBox";
            this.directExch2ComboBox.Size = new System.Drawing.Size(198, 21);
            this.directExch2ComboBox.TabIndex = 12;
            this.directExch2ComboBox.Click += new System.EventHandler(this.directExch2ComboBox_Click);
            // 
            // findMyPayButton
            // 
            this.findMyPayButton.Location = new System.Drawing.Point(229, 60);
            this.findMyPayButton.Name = "findMyPayButton";
            this.findMyPayButton.Size = new System.Drawing.Size(113, 23);
            this.findMyPayButton.TabIndex = 10;
            this.findMyPayButton.Text = "Найти заявку";
            this.findMyPayButton.UseVisualStyleBackColor = true;
            this.findMyPayButton.Click += new System.EventHandler(this.findMyPayButton_Click);
            // 
            // operIdTextBox
            // 
            this.operIdTextBox.Location = new System.Drawing.Point(144, 34);
            this.operIdTextBox.Name = "operIdTextBox";
            this.operIdTextBox.Size = new System.Drawing.Size(198, 20);
            this.operIdTextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Direction";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Position";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.comboBox1.Location = new System.Drawing.Point(64, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(213, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(64, 66);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(213, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "KursForPos";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(64, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(213, 20);
            this.textBox2.TabIndex = 9;
            // 
            // SearcherForTorgiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 344);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.resultRichTextBox);
            this.Name = "SearcherForTorgiForm";
            this.Text = "Поиск курсов и мест заявок";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox operIdComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox wmidComboBox;
        private System.Windows.Forms.Button findPositionButton;
        private System.Windows.Forms.RichTextBox resultRichTextBox;
        private System.Windows.Forms.Button rateButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox positionMyPayTextBox;
        private System.Windows.Forms.ComboBox directionExchangeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button findMyPayButton;
        private System.Windows.Forms.TextBox operIdTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        protected System.Windows.Forms.ComboBox directExch2ComboBox;
    }
}