using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ru.xnull.Config.Mapping.Bot;
using ru.xnull.MyPay;
using ru.xnull.NetTools;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.Behavior;
using ru.xnull.config;
using ru.xnull.calc;
using ru.xnull.ebot.calc;
using ru.xnull.ebot.webmoney;
using ru.xnull.ebot.currency;

using System.Linq;
using System.Linq.Expressions;
using System.Drawing;

namespace ru.xnull
{
    public partial class MyZayavkiForm : Form
    {
        private List<BehaviorMap> behaviorsList;
        private Convertation convertation;
        private ListMyPaysDao listMyPaysDao;
        private INetSender netSender;

        private MyPayMap wmzWmrMyPay;
        private MyPayMap wmrWmzMyPay;

        private BehaviorPayMap wmzWmr;
        private BehaviorPayMap wmrWmz;

       // private ContextMenuStrip righClickMenu = new ContextMenuStrip();
      //  private ToolStripMenuItem rcShowItem = new ToolStripMenuItem("просмотр");

        public MyZayavkiForm()
        {
            InitializeComponent();
            //righClickMenu.Items.Add(rcShowItem);
           // righClickMenu.Click += righClickMenu_Click;

            convertation = Convertation.createConvertation();

            behaviorsList = ConfigDao.Instance().configMap.botMap.behaviors;

            NetMap net = ConfigDao.Instance().configMap.netMap;
            netSender = new NetSender(net.proxyMap, net.tryConnect);
            listMyPaysDao = new ListMyPaysDao(netSender);
        }

        /// <summary>
        /// При загрузке формы обновляем дерево в котором отображается список бехавиоров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyZayavki_Load(object sender, EventArgs e)
        {
            this.ContextMenuStrip = righClickMenu;
            fillTreeView();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            fillTreeView();
        }

        private void fillTreeView()
        {
            behaviorsTreeView.Nodes.Clear();

            fillTreeViewFromBehaviorList(ConfigDao.Instance().configMap.botMap.behaviors, "Обмены");
            fillTreeViewFromBehaviorList(ConfigDao.Instance().configMap.archiveMap, "Архив");
        }

        private void fillTreeViewFromBehaviorList(List<BehaviorMap> Behaviours, String treeViewNodeName)
        {
            behaviorsTreeView.Nodes.Add(treeViewNodeName, treeViewNodeName);
            if (Behaviours.Count == 0)
            {
                behaviorsTreeView.Nodes[treeViewNodeName].Nodes.Add(Guid.NewGuid().ToString(), "Пусто");
                return;
            }

            //sort behaviors by date
            Behaviours.Sort((beh1, beh2) => beh2.getDateCreate().CompareTo(beh1.getDateCreate()));

            foreach (BehaviorMap currBehavior in Behaviours)
            {
                behaviorsTreeView.Nodes[treeViewNodeName].Nodes.Add(currBehavior.guid, currBehavior.getDateCreate());
                //addPays(currBehavior, treeViewNodeName);
            }
        }

        /// <summary>
        /// Двойной клик в дереве.
        /// Вычисляем ид заявки и предоставляем инфу по ней
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void behaviorsTreeView_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = behaviorsTreeView.SelectedNode;
            if (node.Text.Length != 16)
            {
                return;
            }

            BehaviorManager behManager = new BehaviorManager();
            BehaviorMap selectedBehavior = behManager.find(node.Name);

            fillMyPays(selectedBehavior);

            guidLabel.Text = String.Format("GUID: {0}", selectedBehavior.guid);
            behaviorDateLabel.Text = String.Format("Дата создания: {0}", selectedBehavior.getDateCreate());

            try
            {
                ConvertationInfo firstConvert = new ConvertationInfo();
                firstConvert.wmCurrency = WmCurrency.Wmz;
                firstConvert.rate = wmzWmrMyPay.Rate;
                firstConvert.summ = Convert.ToDouble(wmzWmr.inamount);

                ConvertationInfo secondConvert = new ConvertationInfo();
                secondConvert.wmCurrency = WmCurrency.Wmr;
                secondConvert.rate = wmrWmzMyPay.Rate;
                secondConvert.summ = Convert.ToDouble(wmrWmz.inamount);

                Money profit = convertation.X_Y_X(firstConvert, secondConvert);
                Double profitSumm = profit.multiply(Convert.ToDouble(wmzWmr.inamount)).amount;
                profitLabel.Text = String.Format("Выгода: {0} рублей", profitSumm.ToString());
            }
            catch
            {
                profitLabel.Text = "Выгода: Невозможно рассчитать";
            }
        }

        private void fillMyPays(BehaviorMap behavior)
        {
            MyPayState myPayState = new MyPayState();

            try
            {
                wmzWmr = behavior.getPayByDirection("WMZ_WMR");
                wmzWmrMyPay = listMyPaysDao.findMyPay(ConfigDao.Instance().configMap.wmids.getJobWmidMap(), wmzWmr.operid.ToString());
                zrIdTextBox.Text = wmzWmrMyPay.id.ToString();
                zrRateTextBox.Text = wmzWmrMyPay.Rate.ToString();
                zrPosTextBox.Text = wmzWmrMyPay.getMyPositionDescription();
                zrSummTextBox.Text = wmzWmr.inamount;
                wantZRSummTextBox.Text = Trimmer.trimm(wmzWmr.outamount);
                dateCreateZRTextBox.Text = wmzWmrMyPay.querydatecr;
                zrStatusTextBox.Text = myPayState.getState(wmzWmrMyPay.state);
            }
            catch
            {
                zrIdTextBox.Clear();
                zrRateTextBox.Clear();
                zrPosTextBox.Clear();
                zrSummTextBox.Clear();
                wantZRSummTextBox.Clear();
                dateCreateZRTextBox.Clear();
                zrStatusTextBox.Text = "Такой заявки нет на бирже";
            }

            try
            {
                wmrWmz = behavior.getPayByDirection("WMR_WMZ");
                wmrWmzMyPay = listMyPaysDao.findMyPay(ConfigDao.Instance().configMap.wmids.getJobWmidMap(), wmrWmz.operid.ToString());
                rzIdTextBox.Text = wmrWmzMyPay.id.ToString();
                rzRateTextBox.Text = wmrWmzMyPay.Rate.ToString();
                rzPosTextBox.Text = wmrWmzMyPay.getMyPositionDescription(); ;
                rzSummTextBox.Text = wmrWmz.inamount;
                wantRZSummTextBox.Text = Trimmer.trimm(wmrWmz.outamount);
                dateCreateRZTextBox.Text = wmrWmzMyPay.querydatecr;
                rzStatusTextBox.Text = myPayState.getState(wmrWmzMyPay.state);
            }
            catch
            {
                rzIdTextBox.Clear();
                rzRateTextBox.Clear();
                rzPosTextBox.Clear();
                rzSummTextBox.Clear();
                wantRZSummTextBox.Clear();
                dateCreateRZTextBox.Clear();

                rzStatusTextBox.Text = "Такой заявки нет на бирже";
            }
        }

        /*
        private void behaviorsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {

            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                List<String> ignoreElements = new List<string>();
                ignoreElements.Add("Обмены");
                ignoreElements.Add("Архив");
                ignoreElements.Add("Пусто");

                if (ignoreElements.Contains(e.Node.Text))
                {
                    righClickMenu.Hide();
                    rcShowItem.HideDropDown();
                    return;
                }

                righClickMenu.Show(new Point(e.X, e.Y));
            }
        }

        void righClickMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("qq");
        }
        */
    }
}