namespace ru.xnull
{
    partial class StatistForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatistForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.secondCurrencyTypeUi = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.firstCurrencyTypeUi = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.TextBox();
            this.Y = new System.Windows.Forms.TextBox();
            this.X = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.firstSummUi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.secondSummUi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.result);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выгода от обмена";
            // 
            // secondCurrencyTypeUi
            // 
            this.secondCurrencyTypeUi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondCurrencyTypeUi.FormattingEnabled = true;
            this.secondCurrencyTypeUi.Location = new System.Drawing.Point(53, 47);
            this.secondCurrencyTypeUi.Name = "secondCurrencyTypeUi";
            this.secondCurrencyTypeUi.Size = new System.Drawing.Size(80, 21);
            this.secondCurrencyTypeUi.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Тип";
            // 
            // firstCurrencyTypeUi
            // 
            this.firstCurrencyTypeUi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.firstCurrencyTypeUi.FormattingEnabled = true;
            this.firstCurrencyTypeUi.Location = new System.Drawing.Point(57, 47);
            this.firstCurrencyTypeUi.Name = "firstCurrencyTypeUi";
            this.firstCurrencyTypeUi.Size = new System.Drawing.Size(80, 21);
            this.firstCurrencyTypeUi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Тип";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Результат";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Курс";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Курс";
            // 
            // result
            // 
            this.result.Enabled = false;
            this.result.Location = new System.Drawing.Point(250, 135);
            this.result.MaxLength = 10;
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(92, 20);
            this.result.TabIndex = 3;
            // 
            // Y
            // 
            this.Y.Location = new System.Drawing.Point(53, 22);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(80, 20);
            this.Y.TabIndex = 1;
            // 
            // X
            // 
            this.X.Location = new System.Drawing.Point(57, 22);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(80, 20);
            this.X.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Рассчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(12, 189);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(354, 141);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.firstSummUi);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.X);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.firstCurrencyTypeUi);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 100);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Первая валюта";
            // 
            // firstSummUi
            // 
            this.firstSummUi.Location = new System.Drawing.Point(57, 74);
            this.firstSummUi.Name = "firstSummUi";
            this.firstSummUi.Size = new System.Drawing.Size(80, 20);
            this.firstSummUi.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Сумма";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.secondSummUi);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.secondCurrencyTypeUi);
            this.groupBox3.Controls.Add(this.Y);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(198, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(144, 100);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Вторая валюта";
            // 
            // secondSummUi
            // 
            this.secondSummUi.Location = new System.Drawing.Point(53, 74);
            this.secondSummUi.Name = "secondSummUi";
            this.secondSummUi.Size = new System.Drawing.Size(80, 20);
            this.secondSummUi.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Сумма";
            // 
            // StatistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 342);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "StatistForm";
            this.Text = "Расчет выгоды обмена с учетом комиссии";
            this.Load += new System.EventHandler(this.StatistForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.TextBox Y;
        private System.Windows.Forms.TextBox X;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox firstCurrencyTypeUi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox secondCurrencyTypeUi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox secondSummUi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox firstSummUi;
        private System.Windows.Forms.Label label6;
    }
}