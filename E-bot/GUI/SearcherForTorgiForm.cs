using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using ru.xnull.Exchanger;
using ru.xnull.NetTools;
using ru.xnull.Config.Mapping;
using ru.xnull.MyPay;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.config;
using ru.xnull.exchanger;

namespace ru.xnull
{
    public partial class SearcherForTorgiForm : Form
    {        
        private XmlDocument list = new XmlDocument();        
        private WmidsMap _wmidsMap;
        private ListMyPaysDao listMyPaysDao;
        MyPaysMap MyPays;

        public SearcherForTorgiForm()
        {
            InitializeComponent();
            _wmidsMap = ConfigDao.Instance().configMap.wmids;

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

        private void operIdComboBox_Click(object sender, EventArgs e)
        {            
            try
            {
                WmidMap wmid = ConfigDao.Instance().configMap.wmids.getWmid(wmidComboBox.SelectedItem.ToString());
                MyPays = listMyPaysDao.getListMyPays(wmid, new MyPayType(MyPayType.PAID), "");

                operIdComboBox.Items.Clear();
                foreach (MyPayMap currPay in MyPays.listMyPays)
                {
                    operIdComboBox.Items.Add(currPay.id);                    
                }
                if (MyPays.listMyPays.Count == 0)
                {
                    operIdComboBox.Items.Add("Нет заявок выставленных на обмен");
                }
            }
            catch (Exception)
            {
                operIdComboBox.Items.Clear();
                operIdComboBox.Items.Add("Нет заявок выставленных на обмен");
            }
        }

        private void findPositionButton_Click(object sender, EventArgs e)
        {
            try
            {
                resultRichTextBox.Clear();
                                                                
                WmidMap wmid = ConfigDao.Instance().configMap.wmids.getWmid(wmidComboBox.SelectedItem.ToString());
                MyPayMap MyPay = listMyPaysDao.findMyPay(wmid, operIdComboBox.SelectedItem.ToString());
                int myPosition = MyPay.GetMyPosition();
                resultRichTextBox.Text += "Направление обмена: " + MyPay.direction;
                resultRichTextBox.Text += "\nКурс моей заявки: " + MyPay.Rate;

                String myPositionResult = getMyPositionDescription(myPosition);                
                resultRichTextBox.Text += "\nМоя текущая позиция на торгах: " + myPositionResult;
            }
            catch (Exception)
            {
                resultRichTextBox.Text = "Нет заявок выставленных на обмен!!!";
            }
        }

        private String getMyPositionDescription(int myPosition)
        {
            String myPositionResult = myPosition.ToString();
            if (myPosition == -1)
            {
                myPositionResult = "Нет в списке заявок (выходит за пределы диапазона отображаемых заявок)";
            }
            return myPositionResult;
        }

        private void operIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyPayMap MyPay;
            try
            {
                MyPay = MyPays.getMyPayById(int.Parse(operIdComboBox.SelectedItem.ToString()));
            }
            catch
            {
                return;
            }

            try
            {
                resultRichTextBox.Clear();
                resultRichTextBox.AppendText(MyPay.getFullInfo());
            }
            catch (Exception err)
            {
                resultRichTextBox.Text = "Ошибка: " + err.Message;
            }
        }

        private void rateButton_Click(object sender, EventArgs e)
        {
            if (directionExchangeTextBox.SelectedItem != null)
            {
                try
                {
                    int.Parse(positionMyPayTextBox.Text);
                    ExchType exchType = new ExchType();
                    NetMap net = ConfigDao.Instance().configMap.netMap;
                    NetSender netSender = new NetSender(net.proxyMap, net.tryConnect);
                    ListBidsDao listBidsDao = new ListBidsDao(netSender);
                    Torgi torgi = new Torgi(listBidsDao);
                    resultRichTextBox.Text = "Направление обмена: " + directionExchangeTextBox.SelectedItem.ToString() + "\n" +
                                        "Позиция заявки: " + positionMyPayTextBox.Text + "\n" +
                                        "Курс заявки для этой позиции на торгах: " + Convert.ToString(torgi.getRateForPosition(exchType.GetExchTypeFromDirection(directionExchangeTextBox.SelectedItem.ToString()), Convert.ToInt16(positionMyPayTextBox.Text)));
                }
                catch (Exception)
                {
                    MessageBox.Show("Невозможно получить курс заявки");
                }                
            }
            else
            {
                MessageBox.Show("Выберите направление обмена.");
            }
        }

        private void findMyPayButton_Click(object sender, EventArgs e)
        {
            if (directExch2ComboBox.SelectedItem != null)
            {
                try
                {
                    ExchType exchType = new ExchType();
                    NetMap net = ConfigDao.Instance().configMap.netMap;
                    NetSender netSender = new NetSender(net.proxyMap, net.tryConnect);
                    ListBidsDao listBidsDao = new ListBidsDao(netSender);
                    Torgi torgi = new Torgi(listBidsDao);
                    resultRichTextBox.Clear();
                    resultRichTextBox.AppendText("Направление обмена: " + directExch2ComboBox.SelectedItem.ToString());
                    resultRichTextBox.AppendText("\nID заявки: " + operIdTextBox.Text);
                    
                    int position = torgi.FindMyPosition(exchType.GetExchTypeFromDirection(directExch2ComboBox.SelectedItem.ToString()), operIdTextBox.Text);
                    resultRichTextBox.AppendText("Позиция заявки: " + getMyPositionDescription(position));
                }
                catch (Exception)
                {
                    MessageBox.Show("Невозможно найти заявку");
                }
            }
        }

        //вторая закладка на таб панели
        private void directionExchangeTextBox_Click(object sender, EventArgs e)
        {
            ExchType exchType = new ExchType();
            directionExchangeTextBox.Items.Clear();
            foreach (string currentEx in exchType.getAllDirections())
            {
                directionExchangeTextBox.Items.Add(currentEx);
            }
        }

        /// <summary>
        /// третья закладка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void directExch2ComboBox_Click(object sender, EventArgs e)
        {
            ExchType exchType = new ExchType();
            directExch2ComboBox.Items.Clear();
            foreach (string currentEx in exchType.getAllDirections())
            {
                directExch2ComboBox.Items.Add(currentEx);
            }
        }
    }
}