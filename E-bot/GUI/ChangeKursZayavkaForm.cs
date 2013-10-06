using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ru.xnull.ExchangerAPI;
using ru.xnull.NetTools;
using ru.xnull.Config.Mapping;
using ru.xnull.MyPay;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.config;
using ru.xnull.exchangerapi;


namespace ru.xnull
{
    public partial class ChangeKursZayavkaForm : Form
    {
        private MyPayMap MyPay;       
        private WmidsMap _wmidsMap;
        private ListMyPaysDao listMyPaysDao;

        public ChangeKursZayavkaForm()
        {
            InitializeComponent();
            ConfigMap config = ConfigDao.Instance().configMap;
            _wmidsMap = config.wmids;
            NetMap net = ConfigDao.Instance().configMap.netMap;
            NetSender netSender = new NetSender(net.proxyMap, net.tryConnect);
            listMyPaysDao = new ListMyPaysDao(netSender);
        }

        private void wmidComboBox_Click(object sender, EventArgs e)
        {
            wmidComboBox.Items.Clear();
            foreach (WmidMap currWmid in _wmidsMap.wmidList)
            {
                wmidComboBox.Items.Add(currWmid.number);
            }
        }

        private void myPayIdcomboBox_Click(object sender, EventArgs e)
        {            
            MyPaysMap MyPays = null;
            try
            {
                WmidMap wmid = ConfigDao.Instance().configMap.wmids.getWmid(wmidComboBox.SelectedItem.ToString());
                MyPays = listMyPaysDao.getListMyPays(wmid, new MyPayType(MyPayType.PAID), "");
                myPayIdcomboBox.Items.Clear();
                foreach (MyPayMap currPay in MyPays.listMyPays)
                {
                    myPayIdcomboBox.Items.Add(currPay.id);
                }
            }
            catch (Exception)
            {
                myPayIdcomboBox.Items.Clear();
                myPayIdcomboBox.Items.Add("Нет заявок выставленных на обмен");
            }
        }

        private void changeRateButton_Click(object sender, EventArgs e)
        {
            NetMap net = ConfigDao.Instance().configMap.netMap;
            NetSender netSender = new NetSender(net.proxyMap, net.tryConnect);

            ExchangerUtils exchange = new ExchangerUtils(netSender);
            ResponseMap changeKurs = null;
            try
            {
                WmidMap wmid = ConfigDao.Instance().configMap.wmids.getWmid(MyPay.wmid);
                changeKurs = exchange.changeRate(wmid, MyPay.id.ToString(), MyPay.CursType, newRateTextBox.Text);
                resultTextBox.Text = "Результат изменения курса: " + changeKurs.retval.status + "\n Описание: " + changeKurs.retdesc;
            }
            catch (Exception)
            {
                resultTextBox.Text = "Ошибка:\n" + changeKurs.retdesc;

            }
        }

        private void listMyPaysButton_Click(object sender, EventArgs e)
        {
            ListZayavForm ListZayav = new ListZayavForm();
            ListZayav.Show(this);
        }

        private void myPayIdcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultTextBox.Clear();
            try
            {
                if (myPayIdcomboBox.SelectedItem == null)
                {
                    return;
                }

                MyPay = listMyPaysDao.findMyPay(_wmidsMap.getJobWmidMap(), myPayIdcomboBox.SelectedItem.ToString());
                newRateTextBox.Text = MyPay.Rate.ToString();

                resultTextBox.AppendText("id: " + MyPay.id);
                resultTextBox.AppendText("state: " + MyPay.state);
                resultTextBox.AppendText("direction: " + MyPay.direction);
                resultTextBox.AppendText("exchtype: " + MyPay.exchtype);
                resultTextBox.AppendText("amountin: " + MyPay.amountin);
                resultTextBox.AppendText("amountout: " + MyPay.amountout);
                resultTextBox.AppendText("CursType: " + MyPay.CursType);                
                resultTextBox.AppendText("inoutrate: " + MyPay.inoutrate);
                resultTextBox.AppendText("inpurse: " + MyPay.inpurse);
                resultTextBox.AppendText("outinrate: " + MyPay.outinrate);
                resultTextBox.AppendText("outpurse: " + MyPay.outpurse);
                resultTextBox.AppendText("querydate: " + MyPay.querydate);
                resultTextBox.AppendText("querydatecr: " + MyPay.querydatecr);                
                resultTextBox.AppendText("\n");
            }
            catch
            {
                resultTextBox.Text = "Ошибка при получении информации о заявке: " + myPayIdcomboBox.SelectedItem.ToString();
            }
        }

    }
}