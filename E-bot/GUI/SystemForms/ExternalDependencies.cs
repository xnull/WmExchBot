using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using ru.xnull.NetTools;
using System.Diagnostics;
using ru.xnull.config;

namespace ru.xnull.GUI.SystemForms
{
    public partial class ExternalDependencies : Form
    {
        public ExternalDependencies()
        {
            InitializeComponent();
        }

        private void trustButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://security.webmoney.ru/asp/settrust.asp");
        }

        private void rootCertButton_Click(object sender, EventArgs e)
        {            
            NetSender netSender = new NetSender(ConfigDao.Instance().configMap.netMap.proxyMap, 1);
            WebClient webClient = netSender.getWebClient();
            
            String tmpDir = Environment.GetEnvironmentVariable("TEMP");            
            String rootCrt = tmpDir + "\\rootCert.crt";
            statusLabel.Text = "Скачать сертификат во временную папку";
            this.Refresh();

            try
            {
                webClient.DownloadFile("https://cert.wmtransfer.com/CertEnroll/cert.wmtransfer.com_WebMoney%20Transfer%20Root%20CA.crt", rootCrt);
            }
            catch
            {
                MessageBox.Show("Не удалось скачать корневой сертификат с сайта webmoney. Проверьте соединение с интернетом!");
                return;
            }

            statusLabel.Text = "Импортируем сертификат";

            try
            {
                Process process = System.Diagnostics.Process.Start(rootCrt);
                process.WaitForExit(1000 * 10);
            }
            catch (Exception err)
            {
                MessageBox.Show("Не удалось импортировать корневой сертификат. Ошибка " + err.Message);
            }
            statusLabel.Text = "";
        }
    }
}
