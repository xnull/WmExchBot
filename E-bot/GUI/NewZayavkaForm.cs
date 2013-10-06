using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ru.xnull.ExchangerAPI;
using ru.xnull.NetTools;

using ru.xnull.Config.Mapping;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.config;
using ru.xnull.config.mapping;
using ru.xnull.exchangerapi;


namespace ru.xnull
{
    public partial class NewZayavkaForm : Form
    {
        private WmidsMap _wmidsMap;

        public NewZayavkaForm()
        {
            InitializeComponent();
            _wmidsMap = ConfigDao.Instance().configMap.wmids;
        }

        private void wmidComboBox_Click(object sender, EventArgs e)
        {
            wmidComboBox.Items.Clear();           
            foreach (WmidMap currWmid in _wmidsMap.wmidList)
            {
                wmidComboBox.Items.Add(currWmid.number);
            }    
        }

        private void inPurseComboBox_Click(object sender, EventArgs e)
        {
            inPurseComboBox.Items.Clear();
            if (wmidComboBox.SelectedItem != null)
            {                
                foreach (PurseMap currPurse in _wmidsMap.getWmid(wmidComboBox.SelectedItem.ToString()).purses)
                {
                    inPurseComboBox.Items.Add(currPurse.number);
                }                
            }
        }

        private void outPurseComboBox_Click(object sender, EventArgs e)
        {
            outPurseComboBox.Items.Clear();
            if (wmidComboBox.SelectedItem != null)
            {                
                foreach (PurseMap currPurse in _wmidsMap.getWmid(wmidComboBox.SelectedItem.ToString()).purses)
                {
                    outPurseComboBox.Items.Add(currPurse.number);
                }    
            }
        }



        private void submitButton_Click(object sender, EventArgs e)
        {
            NetMap net = ConfigDao.Instance().configMap.netMap;
            NetSender netSender = new NetSender(net.proxyMap, net.tryConnect);
            ExchangerUtils exchange = new ExchangerUtils(netSender);
            ResponseMap PayResult;            
            try
            {
                String wmidNumber = wmidComboBox.SelectedItem.ToString();
                String inpurse = inPurseComboBox.SelectedItem.ToString();
                String outpurse = outPurseComboBox.SelectedItem.ToString();
                String inamount = inAmountTextBox.Text;
                String outamount = outAmountTextBox.Text;
                NewMyPayParameters newMyPayParams = new NewMyPayParameters(wmidNumber, inpurse, outpurse, inamount, outamount);
                PayResult = exchange.newPay(newMyPayParams);
                resultRichTextBox.Text = "OperId: " + PayResult.retval.operid + "\nResult:" + PayResult.retval.status + "\nDescription:" + PayResult.retdesc;
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка при постановке новой заявки: " + err.Message);                 
            }
        }

        private void outAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(inAmountTextBox.Text) / Convert.ToDouble(outAmountTextBox.Text);
                double y = Convert.ToDouble(outAmountTextBox.Text) / Convert.ToDouble(inAmountTextBox.Text);
                payRateTextBox.Text = string.Format("{0:f4}", x) + " / " + string.Format("{0:f4}", y);
            }
            catch (Exception)
            {
                outAmountTextBox.Text = "";
            }
        }
                
    }
}