using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ru.xnull.config;

namespace ru.xnull.GUI
{
    public partial class ConfigHandleEditor : Form
    {
        public ConfigHandleEditor()
        {
            InitializeComponent();
        }

        private void ConfigHandleEditor_Load(object sender, EventArgs e)
        {
            XmlVisualizer formatter = new XmlVisualizer();
            String resultXml = formatter.FormatXmlString(ConfigDao.Instance().configToString());
            resultRichTextBox.Text = resultXml;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ConfigDao configDao = ConfigDao.Instance();
            XmlDocument editedConfig = new XmlDocument();
            try
            {
                editedConfig.LoadXml(resultRichTextBox.Text);
                configDao.configCrypter.encryptXmlConfigAndSaveToFile(editedConfig, configDao.pathToConfigFile);
                MessageBox.Show("Изменения сохранены");
                Close();
            }
            catch (XmlException err)
            {
                MessageBox.Show("Неправильная разметка xml документа: " + err.Message);
            }
        }
    }
}
