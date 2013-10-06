using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.clone;
using ru.xnull.config;

namespace ru.xnull.GUI.ConfigUI
{
    public partial class ProxyInitializer : Form
    {
        private CloneManager _cloneManager;
        private ProxyMap _proxy;

        public ProxyInitializer()
        {
            InitializeComponent();
            _cloneManager = new CloneManager();
        }

        private void proxyBindInit()
        {
            _proxy = _cloneManager.memberwiseClone<ProxyMap>(ConfigDao.Instance().configMap.netMap.proxyMap);

            proxyIptextBox.DataBindings.Add("Text", _proxy, "ip");
            proxyUseProxytextBox.DataBindings.Add("Text", _proxy, "useProxy");
            proxyLoginTextBox.DataBindings.Add("Text", _proxy, "login");
            proxyPasswdTextBox.DataBindings.Add("Text", _proxy, "pass");
        }

        private void ProxyInitializer_Load(object sender, EventArgs e)
        {
            proxyBindInit();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ConfigDao.Instance().configMap.netMap.proxyMap = _proxy;            

            ConfigDao.Instance().saveAndReloadConfig();
            MessageBox.Show("Изменения сохранены");
            Close();
        }
    }
}
