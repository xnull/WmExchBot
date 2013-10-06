using System;
using System.Windows.Forms;
using ru.xnull.calc;
using ru.xnull.ebot.calc;
using ru.xnull.webmoney;
using ru.xnull.ebot.webmoney;

namespace ru.xnull
{
    public partial class StatistForm : Form
    {
        public StatistForm()
        {
            InitializeComponent();
        }

        private void StatistForm_Load(object sender, EventArgs e)
        {
            foreach (var val in Enum.GetValues(typeof(WmCurrency)))
            {
                firstCurrencyTypeUi.Items.Add(val.ToString());
                secondCurrencyTypeUi.Items.Add(val.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Convertation convertation = Convertation.createConvertation();

                WmCurrency firstCurrency = WmCurrencyUtil.fromStr(firstCurrencyTypeUi.SelectedItem.ToString());
                WmCurrency secondCurrency = WmCurrencyUtil.fromStr(secondCurrencyTypeUi.SelectedItem.ToString());

                ConvertationInfo firstConvert = new ConvertationInfo();
                firstConvert.wmCurrency = firstCurrency;
                firstConvert.rate = Convert.ToDouble(checkDigit(X.Text));
                firstConvert.summ = Convert.ToDouble(checkDigit(firstSummUi.Text));

                ConvertationInfo secondConvert = new ConvertationInfo();
                secondConvert.wmCurrency = secondCurrency;
                secondConvert.rate = Convert.ToDouble(checkDigit(Y.Text));
                secondConvert.summ = Convert.ToDouble(checkDigit(secondSummUi.Text));

                string itog = convertation.X_Y_X(firstConvert, secondConvert).amount.ToString();
                result.Text = trimmer(itog);
            }
            catch (Exception)
            {
                result.Text = "Неправильные данные.";
            }
        }

        private String checkDigit(String digitStr)
        {
            if (digitStr.Contains("."))
            {
                digitStr = digitStr.Replace(".", ",");
            }

            return digitStr;
        }

        public static string trimmer(string sourse)
        {
            return Trimmer.trimm(sourse);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}