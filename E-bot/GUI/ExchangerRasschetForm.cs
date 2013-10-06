using System;
using System.Windows.Forms;
using ru.xnull.Exchanger;
using ru.xnull.NetTools;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.config;
using ru.xnull.calc;
using ru.xnull.ebot.calc;
using ru.xnull.ebot.webmoney;


namespace ru.xnull
{
    public partial class ExchangerRasschetForm : Form
    {
        public ExchangerRasschetForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Convertation convertation = Convertation.createConvertation();
            ResultTable.Rows.Clear();
            ResultTable.Columns.Clear();

            int j = 0;

            NetMap net = ConfigDao.Instance().configMap.netMap;
            NetSender netSender = new NetSender(net.proxyMap, net.tryConnect);
            ListBidsDao listBidsDao = new ListBidsDao(netSender);
            Exchanger.AllExchanges AllExchanges = new Exchanger.AllExchanges(listBidsDao, new int[] { 1, 2, 3, 4, 5, 6 });

            ResultTable.Columns.Add("", "");
            ResultTable.Columns.Add("", "");                

            foreach (Exchanger.ListBids currListBids in AllExchanges)
            {
                if (currListBids.ExchType %2 != 0)
                {
                    try
                    {
                        ResultTable.Rows.Add();
                        ResultTable.Rows[j].Cells[0].Value = currListBids.Direction;
                        ResultTable.Rows[j].Cells[1].Value = currListBids.OfficalRate;
                        j++;
                    }
                    catch { }
                }                
            }
            ResultTable.Rows.Add();
            ResultTable.Rows.Add();       
            j++;

            for (int posCounter = 0; posCounter < AllExchanges[0].Count; posCounter++)
            {
                try
                {
                    ResultTable.Columns.Add("", "");
                    ResultTable.Rows[j].Cells[posCounter + 1].Value = "Pos" + (posCounter + 1);
                }
                catch { }
            }
            ResultTable.Rows.Add();
            j++;

            foreach (Exchanger.ListBids currListBids in AllExchanges)
            {
                ResultTable.Rows[j].Cells[0].Value = currListBids.Direction;
                int biditerator = 1;
                foreach (Exchanger.Bid currBid in currListBids)
                {
                    try
                    {
                        ResultTable.Rows[j].Cells[biditerator].Value = currBid.rate;
                    }
                    catch { }
                    biditerator++;
                }
                ResultTable.Rows.Add();
                j++;
            }

            ResultTable.Rows.Add();
            j++;

            Exchanger.ListBids WMZ_WMR = AllExchanges.GetListBids(1);
            Exchanger.ListBids WMR_WMZ = AllExchanges.GetListBids(2);
            Exchanger.ListBids WMZ_WME = AllExchanges.GetListBids(3);
            Exchanger.ListBids WME_WMZ = AllExchanges.GetListBids(4);
            Exchanger.ListBids WME_WMR = AllExchanges.GetListBids(5);
            Exchanger.ListBids WMR_WME = AllExchanges.GetListBids(6);

            for (int i = 0; i < WMZ_WMR.Count; i++)
            {
                try
                {
                    ResultTable.Rows[j].Cells[0].Value = "Z_R_Z";

                    ResultTable.Rows[j].Cells[i + 1].Value = getConvertationCalcResult(convertation, WMZ_WMR[i].rate, WmCurrency.Wmz, WMR_WMZ[i].rate, WmCurrency.Wmr);
                }
                catch { }
            }

            ResultTable.Rows.Add();
            j++;

            for (int i = 0; i < WMZ_WME.Count; i++)
            {
                try
                {
                    ResultTable.Rows[j].Cells[0].Value = "Z_E_Z";
                    ResultTable.Rows[j].Cells[i + 1].Value = getConvertationCalcResult(convertation, WMZ_WME[i].rate, WmCurrency.Wmz, WME_WMZ[i].rate, WmCurrency.Wme);
                }
                catch { }
            }

            ResultTable.Rows.Add();
            j++;

            for (int i = 0; i < WME_WMR.Count; i++)
            {
                try
                {
                    ResultTable.Rows[j].Cells[0].Value = "E_R_E";
                    ResultTable.Rows[j].Cells[i + 1].Value =  getConvertationCalcResult(convertation, WME_WMR[i].rate, WmCurrency.Wme, WMR_WME[i].rate, WmCurrency.Wmr);
                }
                catch { }
            }
        }

        private String getConvertationCalcResult(Convertation convertation, Double firstRate, WmCurrency firstCurr, Double secondRate, WmCurrency secondCurr)
        {
            ConvertationInfo firstConvert = new ConvertationInfo();
            firstConvert.rate = firstRate;
            firstConvert.wmCurrency = firstCurr;

            ConvertationInfo secondConvert = new ConvertationInfo();
            secondConvert.rate = secondRate;
            secondConvert.wmCurrency = secondCurr;

            return convertation.X_Y_X(firstConvert, secondConvert).amount.ToString();
        }
    }
}