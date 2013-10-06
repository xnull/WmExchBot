using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ru.xnull.NetTools;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.config;

namespace ru.xnull
{
    public partial class WmidInfoForm : Form
    {
        private NetSender netSender;
        public WmidInfoForm()
        {
            InitializeComponent();
            NetMap net = ConfigDao.Instance().configMap.netMap;
            netSender = new NetSender(net.proxyMap, net.tryConnect);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            string content = "<request>" +
                                "<wmid></wmid>" +
                                "<sign></sign>" +
                                "<passportwmid>" + textBox1.Text + "</passportwmid>" +
                                "<params>" +
                                    "<dict></dict>" +
                                    "<info>1</info>" +
                                    "<mode></mode>" +
                                "</params>" +
                             "</request>";
            try
            {
                string result = netSender.sendPostData("https://passport.webmoney.ru/asp/XMLGetWMPassport.asp", content);
                richTextBox1.Text = result;                
            }
            catch
            {
                richTextBox1.Text = "Ошибка не удалось получить данные.";
            }            
        }        
    }
}