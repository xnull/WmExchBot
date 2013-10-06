using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using ru.xnull.NetTools;
using ru.xnull.CentroBank;
using log4net;

namespace ru.xnull
{
    /// <summary>
    /// ДЛя обфускации http://eziriz.com/
    /// </summary>
    public class Trial
    {
        private static ILog log = LogManager.GetLogger(typeof(Trial));

        private static Boolean isTrial;
        private DateTime expired;
        private CbrMap cbr;
        private String _trialMessage;

        /// <summary>
        /// Класс для реализации триальности программы
        /// </summary>
        /// <param name="cbr"></param>
        /// <param name="dateExpired"></param>
        /// <param name="trial">является ли программа триальной</param>
        public Trial(CbrMap cbr, DateTime dateExpired, Boolean trial)
        {
            this.cbr = cbr;
            expired = dateExpired;
            isTrial = trial;
        }
        
        /// <summary>
        /// Истекло ли время пользования триал версии
        /// </summary>
        /// <returns></returns>
        public Boolean isExpired()
        {
            log.Debug("Начинаем проверку на истекший срок действия триальной версии");
            try
            {
                if (DateTime.Parse(cbr.date) > expired)
                {
                    log.Debug("Время действия триальной версии истекло!");
                    trialExpiredMessage();
                    return true;
                }
            }
            catch
            {
                Exception err = new Exception("Нет соединения с интернетом, программа не может продолжать работу");
                log.Debug("Ошибка проверки трильности", err);
            } 
            return false;
        }

        /// <summary>
        /// Является ли данная версия программы триальной
        /// </summary>
        /// <returns></returns>
        public static Boolean isTrialVersion()
        {
            return isTrial;
        }

        public String trialMessage
        {
            get { return _trialMessage; }
        }

        /// <summary>
        /// Показать сообщение о истекшем времени действия програмы
        /// </summary>
        private void trialExpiredMessage()
        {            
            _trialMessage = "Время работы триальной версии истекло!!! За полной версией обращайтесь: ICQ: 23-64-810-58, E-mail: x-r-w@ya.ru";
        }
    }
}
