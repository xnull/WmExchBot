namespace ru.xnull.GUI
{
    partial class ConfigEditorForm
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
            this.emailBox = new System.Windows.Forms.GroupBox();
            this.sendMailTextBox = new System.Windows.Forms.ComboBox();
            this.sslTextBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.servertextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ConfigTabControl = new System.Windows.Forms.TabControl();
            this.netTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.proxyUseProxytextBox = new System.Windows.Forms.ComboBox();
            this.proxyPasswdTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.proxyLoginTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.proxyIptextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.botTab = new System.Windows.Forms.TabPage();
            this.botTimeOutTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.botJobComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.wmidsTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.wmzMinSummTextBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.wmzSummFoExchTextBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.wmzTextBox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.wmrMinSummTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.wmrSummForExchTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.wmrTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.wmidNumberTextBox = new System.Windows.Forms.TextBox();
            this.wmidWmKeyTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.applyButton = new System.Windows.Forms.Button();
            this.emailBox.SuspendLayout();
            this.ConfigTabControl.SuspendLayout();
            this.netTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.botTab.SuspendLayout();
            this.wmidsTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // emailBox
            // 
            this.emailBox.Controls.Add(this.sendMailTextBox);
            this.emailBox.Controls.Add(this.sslTextBox);
            this.emailBox.Controls.Add(this.label10);
            this.emailBox.Controls.Add(this.label11);
            this.emailBox.Controls.Add(this.passTextBox);
            this.emailBox.Controls.Add(this.label7);
            this.emailBox.Controls.Add(this.loginTextBox);
            this.emailBox.Controls.Add(this.label8);
            this.emailBox.Controls.Add(this.portTextBox);
            this.emailBox.Controls.Add(this.label5);
            this.emailBox.Controls.Add(this.servertextBox);
            this.emailBox.Controls.Add(this.label6);
            this.emailBox.Controls.Add(this.toTextBox);
            this.emailBox.Controls.Add(this.label2);
            this.emailBox.Controls.Add(this.fromTextBox);
            this.emailBox.Controls.Add(this.label1);
            this.emailBox.Location = new System.Drawing.Point(16, 124);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(516, 158);
            this.emailBox.TabIndex = 2;
            this.emailBox.TabStop = false;
            this.emailBox.Text = "Рассылка уведомлений на Email";
            // 
            // sendMailTextBox
            // 
            this.sendMailTextBox.FormattingEnabled = true;
            this.sendMailTextBox.Items.AddRange(new object[] {
            "False",
            "True"});
            this.sendMailTextBox.Location = new System.Drawing.Point(83, 19);
            this.sendMailTextBox.Name = "sendMailTextBox";
            this.sendMailTextBox.Size = new System.Drawing.Size(149, 21);
            this.sendMailTextBox.TabIndex = 18;
            // 
            // sslTextBox
            // 
            this.sslTextBox.FormattingEnabled = true;
            this.sslTextBox.Items.AddRange(new object[] {
            "True",
            "False"});
            this.sslTextBox.Location = new System.Drawing.Point(344, 77);
            this.sslTextBox.Name = "sslTextBox";
            this.sslTextBox.Size = new System.Drawing.Size(157, 21);
            this.sslTextBox.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Уведомлять";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(238, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Использовать SSL";
            // 
            // passTextBox
            // 
            this.passTextBox.Location = new System.Drawing.Point(83, 129);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.Size = new System.Drawing.Size(149, 20);
            this.passTextBox.TabIndex = 12;
            this.passTextBox.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Пароль";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(83, 103);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(149, 20);
            this.loginTextBox.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Логин";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(344, 51);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(157, 20);
            this.portTextBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "порт Smtp сервера";
            // 
            // servertextBox
            // 
            this.servertextBox.Location = new System.Drawing.Point(344, 19);
            this.servertextBox.Name = "servertextBox";
            this.servertextBox.Size = new System.Drawing.Size(157, 20);
            this.servertextBox.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Smtp сервер";
            // 
            // toTextBox
            // 
            this.toTextBox.Location = new System.Drawing.Point(83, 77);
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(149, 20);
            this.toTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Кому";
            // 
            // fromTextBox
            // 
            this.fromTextBox.Location = new System.Drawing.Point(83, 51);
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(149, 20);
            this.fromTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "От";
            // 
            // ConfigTabControl
            // 
            this.ConfigTabControl.Controls.Add(this.netTab);
            this.ConfigTabControl.Controls.Add(this.botTab);
            this.ConfigTabControl.Controls.Add(this.wmidsTab);
            this.ConfigTabControl.Location = new System.Drawing.Point(12, 12);
            this.ConfigTabControl.Name = "ConfigTabControl";
            this.ConfigTabControl.SelectedIndex = 0;
            this.ConfigTabControl.Size = new System.Drawing.Size(556, 333);
            this.ConfigTabControl.TabIndex = 3;
            // 
            // netTab
            // 
            this.netTab.Controls.Add(this.groupBox1);
            this.netTab.Controls.Add(this.emailBox);
            this.netTab.Location = new System.Drawing.Point(4, 22);
            this.netTab.Name = "netTab";
            this.netTab.Padding = new System.Windows.Forms.Padding(3);
            this.netTab.Size = new System.Drawing.Size(548, 307);
            this.netTab.TabIndex = 0;
            this.netTab.Text = "Сеть";
            this.netTab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.proxyUseProxytextBox);
            this.groupBox1.Controls.Add(this.proxyPasswdTextBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.proxyLoginTextBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.proxyIptextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 89);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки прокси сервера";
            // 
            // proxyUseProxytextBox
            // 
            this.proxyUseProxytextBox.FormattingEnabled = true;
            this.proxyUseProxytextBox.Items.AddRange(new object[] {
            "False",
            "True"});
            this.proxyUseProxytextBox.Location = new System.Drawing.Point(132, 46);
            this.proxyUseProxytextBox.Name = "proxyUseProxytextBox";
            this.proxyUseProxytextBox.Size = new System.Drawing.Size(157, 21);
            this.proxyUseProxytextBox.TabIndex = 9;
            // 
            // proxyPasswdTextBox
            // 
            this.proxyPasswdTextBox.Location = new System.Drawing.Point(353, 45);
            this.proxyPasswdTextBox.Name = "proxyPasswdTextBox";
            this.proxyPasswdTextBox.Size = new System.Drawing.Size(157, 20);
            this.proxyPasswdTextBox.TabIndex = 8;
            this.proxyPasswdTextBox.UseSystemPasswordChar = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(299, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Пароль";
            // 
            // proxyLoginTextBox
            // 
            this.proxyLoginTextBox.Location = new System.Drawing.Point(353, 19);
            this.proxyLoginTextBox.Name = "proxyLoginTextBox";
            this.proxyLoginTextBox.Size = new System.Drawing.Size(157, 20);
            this.proxyLoginTextBox.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(309, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Использовать прокси";
            // 
            // proxyIptextBox
            // 
            this.proxyIptextBox.Location = new System.Drawing.Point(132, 20);
            this.proxyIptextBox.Name = "proxyIptextBox";
            this.proxyIptextBox.Size = new System.Drawing.Size(157, 20);
            this.proxyIptextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "IP адрес";
            // 
            // botTab
            // 
            this.botTab.Controls.Add(this.botTimeOutTextBox);
            this.botTab.Controls.Add(this.label15);
            this.botTab.Controls.Add(this.botJobComboBox);
            this.botTab.Controls.Add(this.label14);
            this.botTab.Location = new System.Drawing.Point(4, 22);
            this.botTab.Name = "botTab";
            this.botTab.Padding = new System.Windows.Forms.Padding(3);
            this.botTab.Size = new System.Drawing.Size(548, 307);
            this.botTab.TabIndex = 2;
            this.botTab.Text = "Бот";
            this.botTab.UseVisualStyleBackColor = true;
            // 
            // botTimeOutTextBox
            // 
            this.botTimeOutTextBox.Location = new System.Drawing.Point(196, 44);
            this.botTimeOutTextBox.Name = "botTimeOutTextBox";
            this.botTimeOutTextBox.Size = new System.Drawing.Size(121, 20);
            this.botTimeOutTextBox.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "ТаймАут (минут)";
            // 
            // botJobComboBox
            // 
            this.botJobComboBox.FormattingEnabled = true;
            this.botJobComboBox.Items.AddRange(new object[] {
            "True",
            "False"});
            this.botJobComboBox.Location = new System.Drawing.Point(196, 17);
            this.botJobComboBox.Name = "botJobComboBox";
            this.botJobComboBox.Size = new System.Drawing.Size(121, 21);
            this.botJobComboBox.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "В работе";
            // 
            // wmidsTab
            // 
            this.wmidsTab.Controls.Add(this.groupBox3);
            this.wmidsTab.Controls.Add(this.groupBox2);
            this.wmidsTab.Location = new System.Drawing.Point(4, 22);
            this.wmidsTab.Name = "wmidsTab";
            this.wmidsTab.Padding = new System.Windows.Forms.Padding(3);
            this.wmidsTab.Size = new System.Drawing.Size(548, 307);
            this.wmidsTab.TabIndex = 1;
            this.wmidsTab.Text = "WMID";
            this.wmidsTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(6, 137);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(533, 164);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Кошельки";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.wmzMinSummTextBox);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.wmzSummFoExchTextBox);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.wmzTextBox);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Location = new System.Drawing.Point(7, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(248, 100);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "WMZ";
            // 
            // wmzMinSummTextBox
            // 
            this.wmzMinSummTextBox.Location = new System.Drawing.Point(116, 64);
            this.wmzMinSummTextBox.Name = "wmzMinSummTextBox";
            this.wmzMinSummTextBox.Size = new System.Drawing.Size(125, 20);
            this.wmzMinSummTextBox.TabIndex = 22;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 71);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 13);
            this.label21.TabIndex = 21;
            this.label21.Text = "Мин. сумма";
            // 
            // wmzSummFoExchTextBox
            // 
            this.wmzSummFoExchTextBox.Location = new System.Drawing.Point(116, 38);
            this.wmzSummFoExchTextBox.Name = "wmzSummFoExchTextBox";
            this.wmzSummFoExchTextBox.Size = new System.Drawing.Size(125, 20);
            this.wmzSummFoExchTextBox.TabIndex = 20;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 45);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(103, 13);
            this.label22.TabIndex = 19;
            this.label22.Text = "Сумма для обмена";
            // 
            // wmzTextBox
            // 
            this.wmzTextBox.Location = new System.Drawing.Point(116, 12);
            this.wmzTextBox.Name = "wmzTextBox";
            this.wmzTextBox.Size = new System.Drawing.Size(125, 20);
            this.wmzTextBox.TabIndex = 18;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 19);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "Номер";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.wmrMinSummTextBox);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.wmrSummForExchTextBox);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.wmrTextBox);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(279, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(248, 100);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "WMR";
            // 
            // wmrMinSummTextBox
            // 
            this.wmrMinSummTextBox.Location = new System.Drawing.Point(116, 64);
            this.wmrMinSummTextBox.Name = "wmrMinSummTextBox";
            this.wmrMinSummTextBox.Size = new System.Drawing.Size(125, 20);
            this.wmrMinSummTextBox.TabIndex = 22;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 71);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 21;
            this.label19.Text = "Мин. сумма";
            // 
            // wmrSummForExchTextBox
            // 
            this.wmrSummForExchTextBox.Location = new System.Drawing.Point(116, 38);
            this.wmrSummForExchTextBox.Name = "wmrSummForExchTextBox";
            this.wmrSummForExchTextBox.Size = new System.Drawing.Size(125, 20);
            this.wmrSummForExchTextBox.TabIndex = 20;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(103, 13);
            this.label17.TabIndex = 19;
            this.label17.Text = "Сумма для обмена";
            // 
            // wmrTextBox
            // 
            this.wmrTextBox.Location = new System.Drawing.Point(116, 12);
            this.wmrTextBox.Name = "wmrTextBox";
            this.wmrTextBox.Size = new System.Drawing.Size(125, 20);
            this.wmrTextBox.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Номер";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.wmidNumberTextBox);
            this.groupBox2.Controls.Add(this.wmidWmKeyTextBox);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(533, 125);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wmid";
            // 
            // wmidNumberTextBox
            // 
            this.wmidNumberTextBox.Location = new System.Drawing.Point(94, 19);
            this.wmidNumberTextBox.Name = "wmidNumberTextBox";
            this.wmidNumberTextBox.Size = new System.Drawing.Size(154, 20);
            this.wmidNumberTextBox.TabIndex = 15;
            // 
            // wmidWmKeyTextBox
            // 
            this.wmidWmKeyTextBox.Location = new System.Drawing.Point(94, 45);
            this.wmidWmKeyTextBox.Multiline = true;
            this.wmidWmKeyTextBox.Name = "wmidWmKeyTextBox";
            this.wmidWmKeyTextBox.Size = new System.Drawing.Size(433, 71);
            this.wmidWmKeyTextBox.TabIndex = 17;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 26);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 13);
            this.label18.TabIndex = 14;
            this.label18.Text = "Номер wmid";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 45);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(84, 39);
            this.label20.TabIndex = 16;
            this.label20.Text = "Текстовое\r\nпредставление\r\nключей";
            this.toolTip1.SetToolTip(this.label20, "Текстовое представление ключей\r\n");
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(489, 361);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(408, 361);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 10;
            this.applyButton.Text = "Применить";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // ConfigEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 396);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.ConfigTabControl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(590, 430);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(590, 430);
            this.Name = "ConfigEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование параметров конфигурационного файла";
            this.Load += new System.EventHandler(this.ConfigCreaterForm_Load);
            this.emailBox.ResumeLayout(false);
            this.emailBox.PerformLayout();
            this.ConfigTabControl.ResumeLayout(false);
            this.netTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.botTab.ResumeLayout(false);
            this.botTab.PerformLayout();
            this.wmidsTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox emailBox;
        private System.Windows.Forms.TextBox fromTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox toTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl ConfigTabControl;
        private System.Windows.Forms.TabPage netTab;
        private System.Windows.Forms.TabPage wmidsTab;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox proxyIptextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage botTab;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox servertextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox proxyPasswdTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox proxyLoginTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox sslTextBox;
        private System.Windows.Forms.ComboBox proxyUseProxytextBox;
        private System.Windows.Forms.ComboBox sendMailTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox botJobComboBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox botTimeOutTextBox;
        private System.Windows.Forms.TextBox wmidWmKeyTextBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox wmidNumberTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox wmrTextBox;
        private System.Windows.Forms.TextBox wmrMinSummTextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox wmrSummForExchTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox wmzMinSummTextBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox wmzSummFoExchTextBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox wmzTextBox;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button applyButton;

    }
}