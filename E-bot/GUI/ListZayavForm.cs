using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;

using ru.xnull.Config.Mapping;
using ru.xnull.MyPay;
using ru.xnull.NetTools;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.config;

namespace ru.xnull
{
    public partial class ListZayavForm : Form
    {
        public ListZayavForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NetMap net = ConfigDao.Instance().configMap.netMap;
            ListMyPaysDao ListMyPays = new ListMyPaysDao(new NetSender(net.proxyMap, net.tryConnect));
            
            MyPaysMap MyPays = null;
            XmlVisualizer XmlVisualizer = new XmlVisualizer();
            try
            {                          
                WmidMap wmid = ConfigDao.Instance().configMap.wmids.getWmid(comboBox1.SelectedItem.ToString());
                MyPayType myPayType = new MyPayType(type.SelectedIndex.ToString());
                MyPays = ListMyPays.getListMyPays(wmid, myPayType, "");

            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка при получении списка заявок: " + err.Message + "\n Код ошибки: " + err.StackTrace);
            }
            resultRichTextBox.Clear();

            if (MyPays == null)
            {
                resultRichTextBox.Text = "Ошибка при получении заявок";
                return;
            }
            
            foreach (MyPayMap currPay in MyPays.listMyPays)
            {
                resultRichTextBox.AppendText("----------\n");
                resultRichTextBox.AppendText(currPay.getFullInfo());               
                resultRichTextBox.AppendText("----------\n\n");
            }
            if (MyPays.listMyPays.Count == 0)
            {
                resultRichTextBox.AppendText("В списке нет заявок");
            }
             
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            WmidsMap wmidsMap = ConfigDao.Instance().configMap.wmids;
            foreach (WmidMap currWmid in wmidsMap.wmidList)
            {
                comboBox1.Items.Add(currWmid.number);
            }                     

        }
    }
}