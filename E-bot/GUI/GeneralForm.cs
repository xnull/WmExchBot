using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.Runtime.InteropServices;
using System.Threading;
using ru.xnull.CentroBank;
using ru.xnull.NetTools;
using ru.xnull.Exchanger;

using ru.xnull.Config.Mapping;
using ru.xnull.GUI;
using ru.xnull.Config.Mapping.Net;
using log4net;
using System.Diagnostics;
using ru.xnull.GUI.SystemForms;
using ru.xnull.GUI.Help;
using ru.xnull.config;
using ru.xnull.globalrepo;
using ru.xnull.exchanger;
using ru.xnull.config.mapping;

namespace ru.xnull
{
    public partial class GeneralForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(GeneralForm));
        /// <summary>
        /// Флаг закрытия формы
        /// </summary>
        public static int closing = 0;

        ToolStripMenuItem dateToolStrip = new ToolStripMenuItem("");
        ToolStripMenuItem usd = new ToolStripMenuItem("");
        ToolStripMenuItem eur = new ToolStripMenuItem("");
        ToolStripMenuItem dateToDay = new ToolStripMenuItem("");
        ToolStripMenuItem usdToDay = new ToolStripMenuItem("");
        ToolStripMenuItem eurToDay = new ToolStripMenuItem("");
        ToolStripMenuItem update = new ToolStripMenuItem("Обновить!");

        public static System.Windows.Forms.Timer SpySpread = new System.Windows.Forms.Timer();

        string botStatus = "Bot остановлен";

        public static BackgroundWorker bw = new BackgroundWorker();

        private WmidsMap _wmidsMap;
        private INetSender _netSender;

        public GeneralForm()
        {
            InitializeComponent();
            //скрываем видимость приложения на панели задач при запуске:
            this.ShowInTaskbar = false;
            botToolStripMenuItem.Checked = false;
            botToolStripMenuItem.Text = botStatus;

            CopyToClipBoardToolStripMenuItem.DropDownItemClicked += new ToolStripItemClickedEventHandler(CopyToClipBoardToolStripMenuItem_DropDownItemClicked);

            _wmidsMap = ConfigDao.Instance().configMap.wmids;

            NetMap net = ConfigDao.Instance().configMap.netMap;
            _netSender = new NetSender(net.proxyMap, net.tryConnect);

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            generalFormShower_Click(this, new EventArgs());
        }

        private void generalFormShower_Click(object sender, EventArgs e)
        {
            //Включаем отображения приложения на панели задач при запуске
            this.ShowInTaskbar = true;
            //Показываем форму
            //this.Show();            
            Show();
            //Отключаем доступность пункта меню mnuShow
            generalFormShower.Enabled = false;
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            closing = 1;
            notifyIcon1.Dispose();
            Application.Exit();
        }

        private void General_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closing == 0)
            {
                e.Cancel = true;
                this.ShowInTaskbar = false;
                this.Hide();
                generalFormShower.Enabled = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void newMyPayCreaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewZayavkaForm NewZayavka = new NewZayavkaForm();
            NewZayavka.Show(this);
        }

        private void listMyPaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListZayavForm ListZayav = new ListZayavForm();
            ListZayav.Show(this);
        }

        private void wmidInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WmidInfoForm WmidInfo = new WmidInfoForm();
            WmidInfo.Show(this);
        }

        private void blTLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BL_TLForm BL_TL = new BL_TLForm();
            BL_TL.Show(this);
        }

        private void officalRatesToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            if (!officalRatesToolStripMenuItem.HasDropDownItems)
            {
                loadCBRRates(DateTime.Now.AddDays(1));

                officalRatesToolStripMenuItem.DropDownItems.Add(update);
                update.Click += new EventHandler(update_Click);
            }

        }

        /// <summary>
        /// Загрузка курсов ЦБ, в ToolSripMenu
        /// </summary>
        /// <param name="date"></param>
        private void loadCBRRates(DateTime date)
        {
            CbrMap cbr =  getCbrRates(date, false);
            if (cbr == null)
            {
                return;
            }

            ToolStripSeparator mySeparator = new ToolStripSeparator();

            dateToolStrip.Text = "Дата: " + cbr.date;
            usd.Text = "Курс доллара ЦБ: " + cbr.getCurrency("USD").rate;
            eur.Text = "Курс евро ЦБ: " + cbr.getCurrency("EUR").rate;

            officalRatesToolStripMenuItem.DropDownItems.Add(dateToolStrip);
            officalRatesToolStripMenuItem.DropDownItems.Add(usd);
            officalRatesToolStripMenuItem.DropDownItems.Add(eur);
            officalRatesToolStripMenuItem.DropDownItems.Add(mySeparator);
        }

        private void update_Click(object sender, EventArgs e)
        {
            updateCBRRates(DateTime.Now.AddDays(1));
        }

        private void updateCBRRates(DateTime date)
        {
            CbrMap cbr = getCbrRates(date, true);
            if (cbr == null)
            {
                return;
            }

            dateToolStrip.Text = "На дату: " + cbr.date + String.Format(" (Обновлено в {0})", DateTime.Now.ToString("hh:mm:ss"));
            usdToDay.Text = "Курс доллара ЦБ: " + cbr.getCurrency("USD").rate;
            eurToDay.Text = "Курс евро ЦБ: " + cbr.getCurrency("EUR").rate;
            contextMenuStrip1.Show();
            officalRatesToolStripMenuItem.ShowDropDown();
        }

        private CbrMap getCbrRates(DateTime date, bool updateRates)
        {
            CbrDao cbrDao = new CbrDao(_netSender);
            cbrDao.updateRates = updateRates;
            CbrMap cbr = null;
            try
            {
                cbr = cbrDao.getCbr(date);
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка получения курсов с цбр: " + err.Message);
            }
            return cbr;

        }

        private void редактироватьКонфигToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigEditorXmlForm ConfEd = new ConfigEditorXmlForm();
            try
            {
                ConfEd.Show();
            }
            catch { }
        }

        private void rateChangerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeKursZayavkaForm ChangeKursZayavka = new ChangeKursZayavkaForm();
            ChangeKursZayavka.Show(this);
        }

        private void RateInPlaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearcherForTorgiForm SearcherForTorgi = new SearcherForTorgiForm();
            SearcherForTorgi.Show(this);
        }

        private void exchangeStatisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExchangerRasschetForm ExchangerRasschet = new ExchangerRasschetForm();
            ExchangerRasschet.Show(this);
        }

        private void myWmidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyWMForm MyWM = new MyWMForm();
            MyWM.Show(this);
        }

        private void claculateProfitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatistForm Statist = new StatistForm();
            Statist.Show(this);
        }

        private void botToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (botToolStripMenuItem.Checked)
            {
                botToolStripMenuItem.Text = "Bot остановлен";
                botStatus = "Bot остановлен";
                botToolStripMenuItem.Checked = false;
                GlobalRepository.getBotManager().StopBot();
            }
            else if (!botToolStripMenuItem.Checked)
            {
                botToolStripMenuItem.Text = "Bot запущен";
                botStatus = "Bot запущен";
                botToolStripMenuItem.Checked = true;
                GlobalRepository.getBotManager().StartBot();
            }
            notifyIcon1.Text = botStatus;
            contextMenuStrip1.Show();
            ботToolStripMenuItem.ShowDropDown();
        }

        private void directionsExchangeTreeView_DoubleClick(object sender, EventArgs e)
        {
            listBidsGridView.Rows.Clear();
            listBidsGridView.Columns.Clear();
            try
            {
                ListBidsDao listBidsDao = new ListBidsDao(_netSender);
                ListBids ListBids = listBidsDao.getListBids(Convert.ToInt32(directionsExchangeTreeView.SelectedNode.Tag));
                kurs.Text = ListBids.OfficalRate.ToString();

                listBidsGridView.Columns.Add("id", "Номер заявки");
                listBidsGridView.Columns.Add("amountin", "Есть сумма " + ListBids.InPurse_Type);
                listBidsGridView.Columns.Add("amountout", "Нужна сумма " + ListBids.OutPurse_Type);
                listBidsGridView.Columns.Add("inoutrate", "Прямой курс " + ListBids.Direction);

                ExchType exchType = new ExchType();
                listBidsGridView.Columns.Add("outinrate", "Обратный курс " + exchType.GetDirectionFromExchType(ListBids.ReverseExchType));
                listBidsGridView.Columns.Add("allamountin", "Всего сумма");
                listBidsGridView.Columns.Add("querydate", "Дата подачи");


                int i = 0;
                foreach (Exchanger.Bid currBid in ListBids)
                {
                    listBidsGridView.Rows.Add();
                    listBidsGridView.Rows[i].Cells["id"].Value = currBid.BidXmlNode.Attributes["id"].Value;
                    listBidsGridView.Rows[i].Cells["amountin"].Value = currBid.BidXmlNode.Attributes["amountin"].Value;
                    listBidsGridView.Rows[i].Cells["amountout"].Value = currBid.BidXmlNode.Attributes["amountout"].Value;
                    listBidsGridView.Rows[i].Cells["inoutrate"].Value = currBid.BidXmlNode.Attributes["inoutrate"].Value;
                    listBidsGridView.Rows[i].Cells["outinrate"].Value = currBid.BidXmlNode.Attributes["outinrate"].Value;
                    listBidsGridView.Rows[i].Cells["allamountin"].Value = currBid.BidXmlNode.Attributes["allamountin"].Value;
                    listBidsGridView.Rows[i].Cells["querydate"].Value = currBid.BidXmlNode.Attributes["querydate"].Value;

                    i++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось получить данные.");
            }
        }

        private void listBidsGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, brush, e.RowBounds.Location.X + 22, e.RowBounds.Location.Y + 4);
            }
        }

        private void payToconfigSaverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZayavkaToConfigForm ZayavkaToConfig = new ZayavkaToConfigForm();
            ZayavkaToConfig.Show(this);
        }

        private void allExchangesStatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyZayavkiForm MyZayavki = new MyZayavkiForm();
            MyZayavki.Show(this);
        }

        private void CopyToClipBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ToolStripMenuItem MyToolstripWmids;
            //MyToolstripWmids.DropDownItemClicked += new ToolStripItemClickedEventHandler(MyToolstripWmids_DropDownItemClicked);
            if (!CopyToClipBoardToolStripMenuItem.HasDropDownItems)
            {
                foreach (WmidMap currWmid in _wmidsMap.wmidList)
                {
                    ToolStripMenuItem MyToolstripWmids = new ToolStripMenuItem(currWmid.number);
                    MyToolstripWmids.DropDownItemClicked += new ToolStripItemClickedEventHandler(MyToolstripWmids_DropDownItemClicked);
                    CopyToClipBoardToolStripMenuItem.DropDownItems.Add(MyToolstripWmids);
                    foreach (PurseMap currPurse in currWmid.purses)
                    {
                        ToolStripMenuItem MyToolstripPurses = new ToolStripMenuItem(currPurse.number);
                        MyToolstripWmids.DropDownItems.Add(MyToolstripPurses);
                    }
                }
            }
            contextMenuStrip1.Show();
            wMToolStripMenuItem.ShowDropDown();
            CopyToClipBoardToolStripMenuItem.ShowDropDown();
        }

        void MyToolstripWmids_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Clipboard.SetText(e.ClickedItem.Text);
            //wMIDSToolStripMenuItem.HideDropDown();
            contextMenuStrip1.Hide();
        }

        void CopyToClipBoardToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Clipboard.SetText(e.ClickedItem.Text);
            //wMIDSToolStripMenuItem.HideDropDown();
            contextMenuStrip1.Hide();
        }

        private void ReflectPayBuyerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PayReflectZayavkaForm PayReflectZayavka = new PayReflectZayavkaForm();
            PayReflectZayavka.Show(this);
        }

        private void blTLToolStripMenuItem_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void newConfigEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigEditorForm creater = new ConfigEditorForm();
            try
            {
                creater.Show();
            }
            catch { }
        }

        private void показатьЛогToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogForm logForm = new LogForm();
            logForm.Show();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExternalDependencies extDep = new ExternalDependencies();
            extDep.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.Show();
        }

        private void справкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"help\Руководство пользователя.pdf");
            }
            catch
            {
                MessageBox.Show("Руководство пользователя отсутствует");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://wm.exchanger.ru/asp/wmlist.asp");
        }

        private void передНачаломРаботыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"help\Перед началом работы.pdf");
            }
            catch
            {
                MessageBox.Show("Руководство отсутствует");
            }
        }
    }
}