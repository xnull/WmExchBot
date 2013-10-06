using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository.Hierarchy;
using log4net.Repository;
using log4net.Core;
using System.Xml;

namespace ru.xnull.GUI
{
    public partial class LogForm : Form
    {
        private String logFile;
        private String advancedLogFile;
        private long logFileSize = 0;

        public LogForm()
        {

            InitializeComponent();
            Timer timer = new Timer();
            timer.Tick += new EventHandler(logAutoUpdate);
            timer.Interval = 1000 * 10;
            timer.Start();
        }

        void logAutoUpdate(object sender, EventArgs e)
        {
            if (autoUpdateCheckBox.Checked)
            {
                readLogFile(logFile);                
            }            
        }

        private void logCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            logFile = String.Format("logs\\{0}.txt", logCalendar.SelectionStart.ToString("yyyy-MM-dd"));
            advancedLogFile = String.Format("logs\\{0}(advanced).txt", logCalendar.SelectionStart.ToString("yyyy-MM-dd"));
            
            readLogFile(logFile);            
        }

        private void readLogFile(String logFile)
        {
            if (!logIsChanged())
            {
                return;
            } 

            try
            {
                logRichTextBox.Clear();
                logRichTextBox.Text = File.ReadAllText(logFile, Encoding.Default);
            }
            catch
            {
                logRichTextBox.Clear();
                logRichTextBox.Text = "За " + logCalendar.SelectionStart.ToString("yyyy-MM-dd") + " нет логов";
            }
            scrollToEndLogRichTextBox();
        }

        private Boolean logIsChanged()
        {
            FileInfo log;
            try
            {
                log = new FileInfo(logFile);

                if (log.Length == logFileSize)
                {                    
                    return false;
                }
                logFileSize = log.Length;
            }
            catch 
            {
                logFileSize = 0;
            }
            return true;            
        }

        private void scrollToEndLogRichTextBox()
        {            
            try
            {
                logRichTextBox.SelectionStart = logRichTextBox.Text.Length;
                logRichTextBox.ScrollToCaret();
                logRichTextBox.Refresh();
            }
            catch
            {}
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            logFile = String.Format("logs\\{0}.txt", DateTime.Now.ToString("yyyy-MM-dd"));
            advancedLogFile = String.Format("logs\\{0}(advanced).txt", DateTime.Now.ToString("yyyy-MM-dd"));
            
            readLogFile(logFile);
            
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            readLogFile(logFile);
            
        }

        private void clearLogButton_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(logFile, "");
                File.WriteAllText(advancedLogFile, "");
            }
            catch { }
            readLogFile(logFile);
        }        
    }
}
