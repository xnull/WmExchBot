using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.Config.Mapping;
using ru.xnull.config;
using ru.xnull.webmoney;

namespace ru.xnull
{
    /// <summary>
    /// Получить из конфига по переданному в конструктор направлению обмена номера кошельков.
    /// Для получения используется рабочий вмид их вонфига
    /// </summary>
    public class PursesFromDirection
    {
        private WmidsMap _wmids;

        public PursesFromDirection(string direction)
        {
            _wmids = ConfigDao.Instance().configMap.wmids;
            _InPurseType = direction.Substring(0, WmCurrencyNames.CURR_NAME_LENGTH);
            _OutPurseType = direction.Substring(WmCurrencyNames.CURR_NAME_LENGTH + 1, WmCurrencyNames.CURR_NAME_LENGTH);
        }

        private string _InPurseType;
        public string InPurseType
        {
            get { return _InPurseType; }
        }

        private string _OutPurseType;
        public string OutPurseType
        {
            get { return _OutPurseType; }
        }

        public string Job_InPurse
        {
            get { return _wmids.getJobWmidMap().getPurseByType(_InPurseType).number; }
        }

        public string Job_OutPurse
        {
            get { return _wmids.getJobWmidMap().getPurseByType(_OutPurseType).number; }
        }
    }
}
