using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ru.xnull
{
    public partial class BL_TLForm : Form
    {
        public BL_TLForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate("https://stats.wmtransfer.com/Levels/pWMIDLevel.aspx?wmid=" + textBox1.Text);
                webBrowser2.Navigate("https://passport.webmoney.ru/aspx/TL.aspx?wmid=" + textBox1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось получить данные.");
            }
        }
    }
}