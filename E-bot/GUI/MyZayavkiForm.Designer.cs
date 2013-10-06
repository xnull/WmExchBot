using System.Windows.Forms;
namespace ru.xnull
{
    partial class MyZayavkiForm
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
            this.behaviorsTreeView = new System.Windows.Forms.TreeView();
            this.statusLabel = new System.Windows.Forms.Label();
            this.zrStatusTextBox = new System.Windows.Forms.TextBox();
            this.zrSummTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.zrRateTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.zrPosTextBox = new System.Windows.Forms.TextBox();
            this.dateCreateZRTextBox = new System.Windows.Forms.TextBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.payInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wantZRSummTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.zrIdTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.behaviorDateLabel = new System.Windows.Forms.Label();
            this.profitLabel = new System.Windows.Forms.Label();
            this.guidLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.wantRZSummTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rzIdTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rzStatusTextBox = new System.Windows.Forms.TextBox();
            this.dateCreateRZTextBox = new System.Windows.Forms.TextBox();
            this.rzPosTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.rzSummTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.rzRateTextBox = new System.Windows.Forms.TextBox();
            this.payInfoGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // behaviorsTreeView
            // 
            this.behaviorsTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.behaviorsTreeView.Location = new System.Drawing.Point(12, 12);
            this.behaviorsTreeView.Name = "behaviorsTreeView";
            this.behaviorsTreeView.Size = new System.Drawing.Size(248, 395);
            this.behaviorsTreeView.TabIndex = 0;
            this.behaviorsTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.behaviorsTreeView_NodeMouseClick);
            this.behaviorsTreeView.DoubleClick += new System.EventHandler(this.behaviorsTreeView_DoubleClick);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(16, 52);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(41, 13);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Статус";
            // 
            // zrStatusTextBox
            // 
            this.zrStatusTextBox.Location = new System.Drawing.Point(129, 45);
            this.zrStatusTextBox.Name = "zrStatusTextBox";
            this.zrStatusTextBox.Size = new System.Drawing.Size(153, 20);
            this.zrStatusTextBox.TabIndex = 5;
            // 
            // zrSummTextBox
            // 
            this.zrSummTextBox.Location = new System.Drawing.Point(129, 71);
            this.zrSummTextBox.Name = "zrSummTextBox";
            this.zrSummTextBox.Size = new System.Drawing.Size(153, 20);
            this.zrSummTextBox.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Сумма для обмена";
            // 
            // zrRateTextBox
            // 
            this.zrRateTextBox.Location = new System.Drawing.Point(129, 123);
            this.zrRateTextBox.Name = "zrRateTextBox";
            this.zrRateTextBox.Size = new System.Drawing.Size(153, 20);
            this.zrRateTextBox.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Курс";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Позиция на бирже";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 182);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Дата постановки";
            // 
            // zrPosTextBox
            // 
            this.zrPosTextBox.Location = new System.Drawing.Point(129, 149);
            this.zrPosTextBox.Name = "zrPosTextBox";
            this.zrPosTextBox.Size = new System.Drawing.Size(153, 20);
            this.zrPosTextBox.TabIndex = 22;
            // 
            // dateCreateZRTextBox
            // 
            this.dateCreateZRTextBox.Location = new System.Drawing.Point(129, 175);
            this.dateCreateZRTextBox.Name = "dateCreateZRTextBox";
            this.dateCreateZRTextBox.Size = new System.Drawing.Size(153, 20);
            this.dateCreateZRTextBox.TabIndex = 23;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RefreshButton.Location = new System.Drawing.Point(185, 413);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 31;
            this.RefreshButton.Text = "Обновить";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // payInfoGroupBox
            // 
            this.payInfoGroupBox.Controls.Add(this.label1);
            this.payInfoGroupBox.Controls.Add(this.wantZRSummTextBox);
            this.payInfoGroupBox.Controls.Add(this.label6);
            this.payInfoGroupBox.Controls.Add(this.zrIdTextBox);
            this.payInfoGroupBox.Controls.Add(this.statusLabel);
            this.payInfoGroupBox.Controls.Add(this.zrStatusTextBox);
            this.payInfoGroupBox.Controls.Add(this.dateCreateZRTextBox);
            this.payInfoGroupBox.Controls.Add(this.zrPosTextBox);
            this.payInfoGroupBox.Controls.Add(this.label11);
            this.payInfoGroupBox.Controls.Add(this.label7);
            this.payInfoGroupBox.Controls.Add(this.label10);
            this.payInfoGroupBox.Controls.Add(this.zrSummTextBox);
            this.payInfoGroupBox.Controls.Add(this.label8);
            this.payInfoGroupBox.Controls.Add(this.zrRateTextBox);
            this.payInfoGroupBox.Location = new System.Drawing.Point(266, 162);
            this.payInfoGroupBox.Name = "payInfoGroupBox";
            this.payInfoGroupBox.Size = new System.Drawing.Size(288, 209);
            this.payInfoGroupBox.TabIndex = 32;
            this.payInfoGroupBox.TabStop = false;
            this.payInfoGroupBox.Text = "Информация по заявке (WMZ_WMR)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Желаемая сумма";
            // 
            // wantZRSummTextBox
            // 
            this.wantZRSummTextBox.Location = new System.Drawing.Point(129, 97);
            this.wantZRSummTextBox.Name = "wantZRSummTextBox";
            this.wantZRSummTextBox.Size = new System.Drawing.Size(153, 20);
            this.wantZRSummTextBox.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Идентификатор";
            // 
            // zrIdTextBox
            // 
            this.zrIdTextBox.Location = new System.Drawing.Point(129, 19);
            this.zrIdTextBox.Name = "zrIdTextBox";
            this.zrIdTextBox.Size = new System.Drawing.Size(153, 20);
            this.zrIdTextBox.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.behaviorDateLabel);
            this.groupBox1.Controls.Add(this.profitLabel);
            this.groupBox1.Controls.Add(this.guidLabel);
            this.groupBox1.Location = new System.Drawing.Point(266, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 144);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация по обмену";
            // 
            // behaviorDateLabel
            // 
            this.behaviorDateLabel.AutoSize = true;
            this.behaviorDateLabel.Location = new System.Drawing.Point(16, 49);
            this.behaviorDateLabel.Name = "behaviorDateLabel";
            this.behaviorDateLabel.Size = new System.Drawing.Size(90, 13);
            this.behaviorDateLabel.TabIndex = 2;
            this.behaviorDateLabel.Text = "Дата создания: ";
            // 
            // profitLabel
            // 
            this.profitLabel.AutoSize = true;
            this.profitLabel.Location = new System.Drawing.Point(16, 73);
            this.profitLabel.Name = "profitLabel";
            this.profitLabel.Size = new System.Drawing.Size(51, 13);
            this.profitLabel.TabIndex = 1;
            this.profitLabel.Text = "Выгода: ";
            // 
            // guidLabel
            // 
            this.guidLabel.AutoSize = true;
            this.guidLabel.Location = new System.Drawing.Point(16, 26);
            this.guidLabel.Name = "guidLabel";
            this.guidLabel.Size = new System.Drawing.Size(40, 13);
            this.guidLabel.TabIndex = 0;
            this.guidLabel.Text = "GUID: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.wantRZSummTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.rzIdTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.rzStatusTextBox);
            this.groupBox2.Controls.Add(this.dateCreateRZTextBox);
            this.groupBox2.Controls.Add(this.rzPosTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.rzSummTextBox);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.rzRateTextBox);
            this.groupBox2.Location = new System.Drawing.Point(576, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 209);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информация по заявке (WMR_WMZ)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Желаемая сумма";
            // 
            // wantRZSummTextBox
            // 
            this.wantRZSummTextBox.Location = new System.Drawing.Point(129, 97);
            this.wantRZSummTextBox.Name = "wantRZSummTextBox";
            this.wantRZSummTextBox.Size = new System.Drawing.Size(146, 20);
            this.wantRZSummTextBox.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Идентификатор";
            // 
            // rzIdTextBox
            // 
            this.rzIdTextBox.Location = new System.Drawing.Point(129, 19);
            this.rzIdTextBox.Name = "rzIdTextBox";
            this.rzIdTextBox.Size = new System.Drawing.Size(146, 20);
            this.rzIdTextBox.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Статус";
            // 
            // rzStatusTextBox
            // 
            this.rzStatusTextBox.Location = new System.Drawing.Point(129, 45);
            this.rzStatusTextBox.Name = "rzStatusTextBox";
            this.rzStatusTextBox.Size = new System.Drawing.Size(146, 20);
            this.rzStatusTextBox.TabIndex = 5;
            // 
            // dateCreateRZTextBox
            // 
            this.dateCreateRZTextBox.Location = new System.Drawing.Point(129, 175);
            this.dateCreateRZTextBox.Name = "dateCreateRZTextBox";
            this.dateCreateRZTextBox.Size = new System.Drawing.Size(146, 20);
            this.dateCreateRZTextBox.TabIndex = 23;
            // 
            // rzPosTextBox
            // 
            this.rzPosTextBox.Location = new System.Drawing.Point(129, 149);
            this.rzPosTextBox.Name = "rzPosTextBox";
            this.rzPosTextBox.Size = new System.Drawing.Size(146, 20);
            this.rzPosTextBox.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Дата постановки";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Сумма для обмена";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Позиция на бирже";
            // 
            // rzSummTextBox
            // 
            this.rzSummTextBox.Location = new System.Drawing.Point(129, 71);
            this.rzSummTextBox.Name = "rzSummTextBox";
            this.rzSummTextBox.Size = new System.Drawing.Size(146, 20);
            this.rzSummTextBox.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 130);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Курс";
            // 
            // rzRateTextBox
            // 
            this.rzRateTextBox.Location = new System.Drawing.Point(129, 123);
            this.rzRateTextBox.Name = "rzRateTextBox";
            this.rzRateTextBox.Size = new System.Drawing.Size(146, 20);
            this.rzRateTextBox.TabIndex = 17;
            // 
            // MyZayavkiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 443);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.payInfoGroupBox);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.behaviorsTreeView);
            this.Name = "MyZayavkiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список поставленных на обмен заявок";
            this.Load += new System.EventHandler(this.MyZayavki_Load);
            this.payInfoGroupBox.ResumeLayout(false);
            this.payInfoGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView behaviorsTreeView;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox zrStatusTextBox;
        private System.Windows.Forms.TextBox zrSummTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox zrRateTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox zrPosTextBox;
        private System.Windows.Forms.TextBox dateCreateZRTextBox;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.GroupBox payInfoGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox zrIdTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox rzIdTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox rzStatusTextBox;
        private System.Windows.Forms.TextBox dateCreateRZTextBox;
        private System.Windows.Forms.TextBox rzPosTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox rzSummTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox rzRateTextBox;
        private System.Windows.Forms.Label guidLabel;
        private System.Windows.Forms.Label profitLabel;
        private System.Windows.Forms.Label behaviorDateLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox wantZRSummTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox wantRZSummTextBox;
    }
}