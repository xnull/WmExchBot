using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ru.xnull.XmlInterfaces;
using ru.xnull.Config.Mapping;
using ru.xnull.NetTools;
using ru.xnull.XmlInterfaces.Request;
using ru.xnull.XmlInterfaces.Response;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.Threading;
using ru.xnull.GUI.MyWM;
using ru.xnull.config;
using ru.xnull.config.mapping;
using ru.xnull.exchangerapi;

namespace ru.xnull
{
    public partial class MyWMForm : Form
    {
        private WmidsMap _wmids;
        private INetSender _netSender;
        private BalanceTaker balanceTaker;

        public MyWMForm()
        {
            InitializeComponent();
            _wmids = ConfigDao.Instance().configMap.wmids;
            NetMap net = ConfigDao.Instance().configMap.netMap;
            _netSender = new NetSender(net.proxyMap, net.tryConnect);
        }

        private void WmidComboBox_Click(object sender, EventArgs e)
        {
            WmidComboBox.Items.Clear();
            foreach (WmidMap currWmid in _wmids.wmidList)
            {
                WmidComboBox.Items.Add(currWmid.number);
            }
        }

        private void PurseComboBox_Click(object sender, EventArgs e)
        {
            PurseComboBox.Items.Clear();
            if (WmidComboBox.SelectedItem != null)
            {
                foreach (PurseMap currPurse in _wmids.getWmid(WmidComboBox.SelectedItem.ToString()).purses)
                {
                    PurseComboBox.Items.Add(currPurse.number);
                }
            }
        }

        private void getHistoryButton_Click(object sender, EventArgs e)
        {
            resultRichTextBox.Clear();
            if (!wmidAndPurseIsChoised())
            {
                return;
            }

            WmXmlInterfaces xmlInterfaces = new WmXmlInterfaces(_netSender);
            X3RequestMap request = new X3RequestMap();
            GetOperationsRequestMap getOperations = new GetOperationsRequestMap();
            getOperations.purse = PurseComboBox.SelectedItem.ToString();
            getOperations.datestart = StartDateTextBox.Text;
            getOperations.datefinish = FinishDateTextBox.Text;

            request.reqn = 1;
            request.wmid = WmidComboBox.SelectedItem.ToString();

            WmidMap wmid = ConfigDao.Instance().configMap.wmids.getWmid(request.wmid);
            request.sign = ExchangerUtils.signString(wmid, getOperations.purse + "1");


            request.getOperations = getOperations;

            try
            {
                HistoryMap history = xmlInterfaces.X3_History(request);
                if (history == null)
                {
                    resultRichTextBox.AppendText("Невозможно получить историю операций с сайта");
                    return;
                }
                if (history.retval != "0")
                {
                    resultRichTextBox.AppendText("Ошибка при получении истории операций:");
                    resultRichTextBox.AppendText("retval: " + history.retval + " retdesc: " + history.retdesc);
                    return;
                }

                if (history.operations.operationsList.Count == 0)
                {
                    resultRichTextBox.AppendText(String.Format("Время запроса {0}:\nc {1} по {2} времени операций не было", DateTime.Now.ToString("hh:mm:ss"), StartDateTextBox.Text, FinishDateTextBox.Text));
                    return;
                }

                foreach (OperationMap currentOperation in history.operations.operationsList)
                {
                    resultRichTextBox.AppendText(currentOperation.ToString());
                    resultRichTextBox.AppendText("\n");
                }
            }
            catch (Exception err)
            {
                resultRichTextBox.Text = "Ошибка: " + err.Message;
            }
        }

        private Boolean wmidAndPurseIsChoised()
        {
            if (WmidComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите wmid");
                return false;
            }
            if (PurseComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите кошелек по которому необходимо получить историю операий");
                return false;
            }
            return true;
        }

        private void trustListButton_Click(object sender, EventArgs e)
        {
            XmlDocument result = new XmlDocument();
            try
            {
                WmXmlInterfaces xmlInterfaces = new WmXmlInterfaces(_netSender);
                WmidMap wmid = ConfigDao.Instance().configMap.wmids.getWmid(trustWmidComboBox.SelectedItem.ToString());
                result.LoadXml(xmlInterfaces.X15_Trust_List(wmid));
                XmlVisualizer XmlVisualizer = new XmlVisualizer();
                trustRichTextBox.Text = XmlVisualizer.FormatXmlString(result.InnerXml);
            }
            catch (Exception err)
            {
                trustRichTextBox.Text = "Ошибка: " + err.Message;
            }
        }

        private void trustWmidComboBox_Click(object sender, EventArgs e)
        {
            trustWmidComboBox.Items.Clear();
            foreach (WmidMap currWmid in _wmids.wmidList)
            {
                trustWmidComboBox.Items.Add(currWmid.number);
            }
        }

        private void balanceButton_Click(object sender, EventArgs e)
        {
            balanceTextBox.Clear();
            if (!wmidAndPurseIsChoised())
            {
                return;
            }

            balanceTaker = new BalanceTaker(_netSender, WmidComboBox.SelectedItem.ToString(), PurseComboBox.SelectedItem.ToString());
            ThreadManager threadManager = new ThreadManager(balanceTaker);
            threadManager.startThread();

            Timer timer = new Timer();
            timer.Tick += new EventHandler(balanceChecking_Tick);
            timer.Start();
        }

        void balanceChecking_Tick(object sender, EventArgs e)
        {
            if (balanceTaker.getBalance() == null)
            {
                return;
            }
            if (balanceTaker.getBalance().StartsWith("Ошибка"))
            {
                resultRichTextBox.Text = balanceTaker.getBalance();
                ((Timer)sender).Stop();
                return;
            }
            balanceTextBox.Text = balanceTaker.getBalance();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StartDateTextBox.Text = DateTime.Now.AddDays(-1).ToString("yyyyMMdd HH:mm");
            FinishDateTextBox.Text = DateTime.Now.ToString("yyyyMMdd HH:mm");
        }

        private void MyWMForm_Load(object sender, EventArgs e)
        {
            StartDateTextBox.Text = DateTime.Now.AddDays(-1).ToString("yyyyMMdd HH:mm");
            FinishDateTextBox.Text = DateTime.Now.ToString("yyyyMMdd HH:mm");            
        }
    }
}