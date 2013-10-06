using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using ru.xnull.Exchanger;
using ru.xnull.NetTools;
using ru.xnull.Config.Mapping;
using ru.xnull.MyPay;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.config;
using ru.xnull.exchangerapi;

namespace ru.xnull
{
    public partial class PayReflectZayavkaForm : Form
    {
        private MyPayMap MyPay;
        private WmidsMap _WmidsMap;
        private ListMyPaysDao listMyPaysDao;

        public PayReflectZayavkaForm()
        {
            InitializeComponent();
            _WmidsMap = ConfigDao.Instance().configMap.wmids;
            NetMap net = ConfigDao.Instance().configMap.netMap;
            listMyPaysDao = new ListMyPaysDao(new NetSender(net.proxyMap, net.tryConnect));
        }

        private void operIdComboBox_Click(object sender, EventArgs e)
        {
            ListMyPaysDao ListMyPays = null;
            MyPaysMap MyPays = null;
            try
            {                
                WmidMap wmid = ConfigDao.Instance().configMap.wmids.getWmid(wmidComboBox.SelectedItem.ToString());
                MyPays = listMyPaysDao.getListMyPays(wmid, new MyPayType(MyPayType.PAID), "");
                operIdComboBox.Items.Clear();
                foreach (MyPayMap currPay in MyPays.listMyPays)
                {
                    operIdComboBox.Items.Add("id: " + currPay.id);
                }                
            }
            catch (Exception)
            {
                operIdComboBox.Items.Clear();
                operIdComboBox.Items.Add("Нет заявок выставленных на обмен");
            }
        }

        private void operIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {            
            try
            {
                MyPay = listMyPaysDao.findMyPay(_WmidsMap.getJobWmidMap(), operIdComboBox.SelectedItem.ToString());
                myRateTextBox.Text = MyPay.Rate.ToString();

                NetMap net = ConfigDao.Instance().configMap.netMap;
                NetSender netSender = new NetSender(net.proxyMap, net.tryConnect);
                ListBidsDao listBidsDao = new ListBidsDao(netSender);

                ListBids ReverseListBids = listBidsDao.getListBids(MyPay.GetReverseExchType());

                reflectIdTextBox.Text = ReverseListBids[0].id;
                reflectRateTextBox.Text = ReverseListBids[0].rate.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибко! " + err.Message);
            }
        }

        private void saleButton_Click(object sender, EventArgs e)
        {
            NetMap net = ConfigDao.Instance().configMap.netMap;
            NetSender netSender = new NetSender(net.proxyMap, net.tryConnect);
            
            ExchangerUtils exchange = new ExchangerUtils(netSender);
            try
            {
                WmidMap wmid = ConfigDao.Instance().configMap.wmids.getWmid(wmidComboBox.SelectedItem.ToString());
                XmlNode exchResult = exchange.payReflectBestZayavka(wmid, MyPay.id.ToString(), reflectIdTextBox.Text);
                resultRichTextBox.Text = exchResult.OuterXml;
            }
            catch (Exception err)
            {
                MessageBox.Show("Не могу обменять заявку: " + err.Message);
            }
        }

        private void wmidComboBox_Click(object sender, EventArgs e)
        {
            wmidComboBox.Items.Clear();
            foreach (WmidMap currWmid in _WmidsMap.wmidList)
            {
                wmidComboBox.Items.Add(currWmid.number);
            }            
        }     
    }
}