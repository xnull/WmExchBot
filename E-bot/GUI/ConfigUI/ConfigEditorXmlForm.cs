using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using ru.xnull.config;

namespace ru.xnull
{
    public partial class ConfigEditorXmlForm : Form
    {
        public ConfigEditorXmlForm()
        {
            InitializeComponent();

            PassForm accessorForm = new PassForm("Для доступа к настройкам введите пароль для конфига");
            accessorForm.ShowDialog();
            if (accessorForm.password != ConfigDao.Instance().configCrypter.password)
            {
                MessageBox.Show("Введен неверный пароль");
                Close();
            }
        }

        private void CreateConfButton_Click(object sender, EventArgs e)
        {
            Crypter Crypter = new Crypter();
            ContentConfigTextBox.WordWrap = false;
            ContentConfigTextBox.AcceptsReturn = true;
            ContentConfigTextBox.AcceptsTab = true;

            ContentConfigTextBox.Enabled = true;
            SaveButton.Enabled = true;

            if (ConfActionComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите действие");
                return;
            }
            ConfActionChoise(ConfActionComboBox.SelectedItem.ToString());
        }

        private void ConfActionChoise(string ConfAction)
        {
            switch (ConfAction)
            {
                case "Редактировать конфиг":
                    ViewConfig();
                    break;
                case "Просмотр конфига":
                    ViewConfig();
                    SaveButton.Enabled = false;
                    break;
            }
        }

        private void ViewConfig()
        {
            Crypter Crypter = new Crypter();
            string EncryptConfStr = ConfigDao.Instance().configCrypter.LoadStringFromFile(Application.StartupPath + "\\e-bot.enc");
            if (ConfigDao.Instance().configCrypter.password == null)
            {
                PassForm passform = new PassForm("Введите пароль для расшифроки конфига");
                passform.ShowDialog();
            }
            string DecryptConfStr = Crypter.DecryptString(EncryptConfStr, ConfigDao.Instance().configCrypter.password);
            XmlVisualizer XmlVisualizer = new XmlVisualizer();
            ContentConfigTextBox.Text = XmlVisualizer.FormatXmlString(DecryptConfStr);

        }

        void ClearAllNodes(XmlNode xmlnode)
        {
            for (int i = 0; i < xmlnode.ChildNodes.Count; i++)
            {
                XmlNode currNode = xmlnode.ChildNodes[i];
                if (currNode.HasChildNodes)
                {
                    ClearAllNodes(currNode);
                }
                clearAllAttributes(currNode);
            }
        }

        void clearAllAttributes(XmlNode xmlnode)
        {
            try
            {
                for (int i = 0; i < xmlnode.Attributes.Count; i++)
                {
                    xmlnode.Attributes[i].Value = "";
                }
            }
            catch { }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            XmlDocument confDoc = new XmlDocument();
            confDoc.LoadXml(ContentConfigTextBox.Text);
            
            ConfigDao.Instance().configCrypter.encryptXmlConfigAndSaveToFile(confDoc, ConfigDao.Instance().pathToConfigFile);
            ConfigDao.Instance().reloadConfig();

            ContentConfigTextBox.Clear();
        }

        private void ConfigEditorXmlForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}