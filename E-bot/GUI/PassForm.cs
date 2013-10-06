using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ru.xnull
{
    public partial class PassForm : Form
    {
        private String _password;
        
        /// <summary>
        /// Для закрытия формы, если переменная true значит была нажата кнопка cancel
        /// </summary>
        private Boolean _cancelBtnClick = false;

        public String password
        {
            get { return _password; }
        }

        public PassForm()
        {
            InitializeComponent();
        }

        public PassForm(string description): this()
        {
            DescriptionLabel.Text = description;            
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {            
            _password = passTextBox.Text;            
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            _cancelBtnClick = true;
            this.Close();
        }

        private void passTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AcceptBtn_Click(sender, e);
            }
        }

        private void Pass_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (passTextBox.Text == "" && !_cancelBtnClick)
            {
                MessageBox.Show("Вы не ввели пароль! Попробуйте ещё раз");
                e.Cancel = true;                
            }
        }
    }
}