using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ru.xnull.Config.Mapping;
using ru.xnull.Config.Mapping.Net;
using ru.xnull.Config.Mapping.Bot;
using ru.xnull.clone;
using ru.xnull.config;

namespace ru.xnull.GUI
{
    public partial class ConfigEditorForm : Form
    {
        private CloneManager _cloneManager;
        private EmailMap _email;
        private ProxyMap _proxy;
        private BotMap _bot;
        private WmidMap _wmid;

        public ConfigEditorForm()
        {
            PassForm accessorForm = new PassForm("Для доступа к настройкам введите пароль для конфига");
            accessorForm.ShowDialog();
            if (accessorForm.password != ConfigDao.Instance().configCrypter.password)
            {
                MessageBox.Show("Введен неверный пароль");
                Close();
            }
            
            //_accessGranted = true;

            InitializeComponent();
             _cloneManager = new CloneManager();
        }

        private void ConfigCreaterForm_Load(object sender, EventArgs e)
        {
            emailBindInit();
            proxyBindInit();
            botBindInit();
            wmidBindInit();
        }       
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            applyChanges();
            Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            applyChanges();
            MessageBox.Show("Изменения сохранены");
        }

        private void applyChanges()
        {
            ConfigDao.Instance().configMap.netMap.emailMap = _email;
            ConfigDao.Instance().configMap.netMap.proxyMap = _proxy;
            ConfigDao.Instance().configMap.botMap = _bot;
            ConfigDao.Instance().configMap.wmids.jobWmidMap = _wmid;

            ConfigDao.Instance().saveAndReloadConfig();
        }        

        private void emailBindInit()
        {
            
            _email = _cloneManager.memberwiseClone<EmailMap>(ConfigDao.Instance().configMap.netMap.emailMap);

            fromTextBox.DataBindings.Add("Text", _email, "from");
            toTextBox.DataBindings.Add("Text", _email, "to");
            servertextBox.DataBindings.Add("Text", _email, "server");
            portTextBox.DataBindings.Add("Text", _email, "port");
            sslTextBox.DataBindings.Add("Text", _email, "usessl");
            sendMailTextBox.DataBindings.Add("Text", _email, "sendmail");
            loginTextBox.DataBindings.Add("Text", _email, "login");
            passTextBox.DataBindings.Add("Text", _email, "pass");
        }

        private void proxyBindInit()
        {
            _proxy = _cloneManager.memberwiseClone<ProxyMap>(ConfigDao.Instance().configMap.netMap.proxyMap);

            proxyIptextBox.DataBindings.Add("Text", _proxy, "ip");
            proxyUseProxytextBox.DataBindings.Add("Text", _proxy, "useProxy");
            proxyLoginTextBox.DataBindings.Add("Text", _proxy, "login");
            proxyPasswdTextBox.DataBindings.Add("Text", _proxy, "pass");
        }

        private void botBindInit()
        {
            _bot = _cloneManager.memberwiseClone<BotMap>(ConfigDao.Instance().configMap.botMap);

            botJobComboBox.DataBindings.Add("Text", _bot, "job");
            botTimeOutTextBox.DataBindings.Add("Text", _bot, "minutesTimeout");            
        }

        private void wmidBindInit()
        {            
            _wmid = _cloneManager.deepClone<WmidMap>(ConfigDao.Instance().configMap.wmids.getJobWmidMap());

            wmidNumberTextBox.DataBindings.Clear();
            wmidNumberTextBox.DataBindings.Add("Text", _wmid, "number");

            wmidWmKeyTextBox.DataBindings.Clear();
            wmidWmKeyTextBox.DataBindings.Add("Text", _wmid, "wmKeys");

            wmzTextBox.DataBindings.Clear();
            wmzTextBox.DataBindings.Add("Text", _wmid.getPurseByType("WMZ"), "number");
            
            wmzSummFoExchTextBox.DataBindings.Clear();
            wmzSummFoExchTextBox.DataBindings.Add("Text", _wmid.getPurseByType("WMZ"), "summForExch");

            wmzMinSummTextBox.DataBindings.Clear();
            wmzMinSummTextBox.DataBindings.Add("Text", _wmid.getPurseByType("WMZ"), "minSumm");


            wmrTextBox.DataBindings.Clear();
            wmrTextBox.DataBindings.Add("Text", _wmid.getPurseByType("WMR"), "number");

            wmrSummForExchTextBox.DataBindings.Clear();
            wmrSummForExchTextBox.DataBindings.Add("Text", _wmid.getPurseByType("WMR"), "summForExch");

            wmrMinSummTextBox.DataBindings.Clear();
            wmrMinSummTextBox.DataBindings.Add("Text", _wmid.getPurseByType("WMR"), "minSumm");
        }
    }
}
