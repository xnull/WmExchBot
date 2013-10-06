using System.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ru.xnull.Config.Mapping;
using ru.xnull.Config.Mapping.Bot;
using ru.xnull.MyPay;
using ru.xnull.NetTools;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.config;

namespace ru.xnull
{
    public partial class ZayavkaToConfigForm : Form
    {
        List<string> OperIdForConfig = new List<string>();
        private WmidsMap _wmidsMap;
        private ListMyPaysDao listMyPaysDao;

        public ZayavkaToConfigForm()
        {
            InitializeComponent();
            _wmidsMap = ConfigDao.Instance().configMap.wmids;
            NetMap net = ConfigDao.Instance().configMap.netMap;
            listMyPaysDao = new ListMyPaysDao(new NetSender(net.proxyMap, net.tryConnect));
        }

        private void wmidComboBox_Click(object sender, EventArgs e)
        {
            wmidComboBox.Items.Clear();

            foreach (WmidMap currWmid in _wmidsMap.wmidList)
            {
                wmidComboBox.Items.Add(currWmid.number);
            }
        }

        private void missingMyPaysComboBox_Click(object sender, EventArgs e)
        {
            missingMyPaysComboBox.Items.Clear();

            String wmid = getSelectedWmidNumber(sender, e);
            MyPaysMap MyPays = getAllMyPays(wmid);

            List<BehaviorMap> Behaviours = ConfigDao.Instance().configMap.botMap.behaviors;

            foreach (MyPayMap currPay in MyPays.listMyPays)
            {
                if (myPayAlreadyExsistInConfig(Behaviours, currPay))
                {
                    continue;
                }

                missingMyPaysComboBox.Items.Add(currPay.id);
                OperIdForConfig.Add(currPay.id.ToString());
            }
        }

        private Boolean myPayAlreadyExsistInConfig(List<BehaviorMap> behaviors, MyPayMap myPay)
        {            
            foreach (BehaviorMap currBehaviour in behaviors)
            {
                foreach (BehaviorPayMap currBehaviourMyPay in currBehaviour.paysMap)
                {
                    if (currBehaviourMyPay.operid == myPay.id)
                    {
                        return true;
                    }
                }                
            }
            return false;
        }

        /// <summary>
        /// Получить список моих заявок с биржи
        /// </summary>
        /// <param name="wmid"></param>
        /// <returns></returns>
        private MyPaysMap getAllMyPays(String wmid)
        {
            MyPaysMap MyPays = null;

            WmidMap wmidMap = ConfigDao.Instance().configMap.wmids.getWmid(wmid);
            MyPays = listMyPaysDao.getListMyPays(wmidMap, new MyPayType(MyPayType.PAID), "");
            return MyPays;
        }


        private string getSelectedWmidNumber(object sender, EventArgs e)
        {
            String wmid = "";
            try
            {
                wmid = wmidComboBox.SelectedItem.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите WMID");
                missingMyPaysComboBox_Click(sender, e);
            }
            return wmid;
        }


        private void missingMyPaysComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MyPayMap MyPay = listMyPaysDao.findMyPay(_wmidsMap.getJobWmidMap(), missingMyPaysComboBox.SelectedItem.ToString());
                idTextBox.Text = MyPay.id.ToString();
                directionTextBox.Text = MyPay.direction.Replace("-", "_");
                amountInTextBox.Text = MyPay.amountin.ToString();
                amountOutTextBox.Text = MyPay.amountout.ToString();
                rateTextBox.Text = MyPay.Rate.ToString();
                inPurseTextBox.Text = MyPay.inpurse;
                outPurseTextBox.Text = MyPay.outpurse;
                queryDateTextBox.Text = Convert.ToDateTime(MyPay.querydatecr).AddHours(5).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось получить данные с сайта");
            }
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException ("Данная часть программы не реализована!!! Обратитесь к разработчику");

            //String selectedWmid =  getSelectedWmidNumber(sender, e);
            //BehaviorPay behaviorPay = new BehaviorPay();

            //                ConfigBehaviour.addBehaviorPay();
            //              ConfigBehaviour.NewBid(wmid, ID.Text, PlanPos.Text, Convert.ToDouble(AmountIn.Text), Convert.ToDouble(AmountOut.Text), QueryDate.Text, Direction.Text, MinKurs.Text);
            //            ConfigBehaviour.saveBehaviourInConfig(); 
            //MessageBox.Show("Данные записаны в конфиг!");                
            //}

            //catch (Exception)
            //{
            //  MessageBox.Show("Не удалось записать заявку в конфиг.");
            //}
        }
    }
}