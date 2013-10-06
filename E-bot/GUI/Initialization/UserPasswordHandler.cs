using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ru.xnull.Config.Initialization
{
    /// <summary>
    /// Класс отображает юзеру форму для ввода пароля и обрабатывает ввод пароля пользователем в форму
    /// </summary>
    class UserPasswordHandler : Handler
    {
        private String passFormText;

        /// <summary>
        /// Проверяем что ввел в форму 
        /// и в зависимости от этого перенаправляем юзера дальше по этапу
        /// </summary>
        /// <returns></returns>
        public override Boolean handle()
        {
            if (passFormText == null)
            {
                passFormText = "Введите пароль для расшифровки конфига";
            }
            PassForm passform = new PassForm(passFormText);

            if (passform.ShowDialog() == DialogResult.Cancel)
            {
                return false;
            }
            if (passform.password == null)
            {
                //TODO Не решил как быть в этой ситуации - когда юзер не ввел пароль.
                throw new Exception("Не был введен пароль для расшифровки конфига");
            }
            successor.setPassword(passform.password);
            return successor.handle();
        }

        public void setTextForPassForm(String text)
        {
            passFormText = text;
        }
    }
}
