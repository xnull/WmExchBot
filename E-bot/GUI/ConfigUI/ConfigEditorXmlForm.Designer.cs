namespace ru.xnull
{
    partial class ConfigEditorXmlForm
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.ActionLabel = new System.Windows.Forms.Label();
            this.ContentConfigTextBox = new System.Windows.Forms.TextBox();
            this.ConfActionComboBox = new System.Windows.Forms.ComboBox();
            this.CommitButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SaveButton);
            this.tabPage1.Controls.Add(this.ActionLabel);
            this.tabPage1.Controls.Add(this.ContentConfigTextBox);
            this.tabPage1.Controls.Add(this.ConfActionComboBox);
            this.tabPage1.Controls.Add(this.CommitButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(682, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Config";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SaveButton.Location = new System.Drawing.Point(519, 475);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(157, 23);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Сохранить изменения";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ActionLabel
            // 
            this.ActionLabel.AutoSize = true;
            this.ActionLabel.Location = new System.Drawing.Point(6, 18);
            this.ActionLabel.Name = "ActionLabel";
            this.ActionLabel.Size = new System.Drawing.Size(107, 13);
            this.ActionLabel.TabIndex = 8;
            this.ActionLabel.Text = "Выберите действие";
            // 
            // ContentConfigTextBox
            // 
            this.ContentConfigTextBox.AcceptsTab = true;
            this.ContentConfigTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContentConfigTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ContentConfigTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ContentConfigTextBox.Location = new System.Drawing.Point(9, 37);
            this.ContentConfigTextBox.Multiline = true;
            this.ContentConfigTextBox.Name = "ContentConfigTextBox";
            this.ContentConfigTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ContentConfigTextBox.Size = new System.Drawing.Size(670, 432);
            this.ContentConfigTextBox.TabIndex = 7;
            // 
            // ConfActionComboBox
            // 
            this.ConfActionComboBox.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.ConfActionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfActionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConfActionComboBox.FormattingEnabled = true;
            this.ConfActionComboBox.Items.AddRange(new object[] {
            "Просмотр конфига",
            "Редактировать конфиг"});
            this.ConfActionComboBox.Location = new System.Drawing.Point(119, 10);
            this.ConfActionComboBox.Name = "ConfActionComboBox";
            this.ConfActionComboBox.Size = new System.Drawing.Size(509, 21);
            this.ConfActionComboBox.TabIndex = 6;
            // 
            // CommitButton
            // 
            this.CommitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommitButton.Location = new System.Drawing.Point(634, 10);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(42, 21);
            this.CommitButton.TabIndex = 2;
            this.CommitButton.Text = "ОК";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.CreateConfButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(690, 530);
            this.tabControl1.TabIndex = 2;
            // 
            // ConfigEditorXmlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 554);
            this.Controls.Add(this.tabControl1);
            this.Name = "ConfigEditorXmlForm";
            this.Text = "Редактирование конфигураионных данных";
            this.Load += new System.EventHandler(this.ConfigEditorXmlForm_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label ActionLabel;
        private System.Windows.Forms.TextBox ContentConfigTextBox;
        private System.Windows.Forms.ComboBox ConfActionComboBox;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.TabControl tabControl1;



    }
}