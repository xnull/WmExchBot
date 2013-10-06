using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using ru.xnull.Exchanger;
using ru.xnull.NetTools;
using System.Xml.Serialization;
using ru.xnull.Config.Mapping.Net;
using log4net;
using ru.xnull.config;
using ru.xnull.exchanger;


namespace ru.xnull.MyPay
{
    public static class MyPayMapMetaData
    {
        public static String wmid
        {
            get { return "wmid"; }
        }

        public static String id
        {
            get { return "идентификатор"; }
        }

        public static String exchtype
        {
            get { return "Тип направления обмена"; }
        }

        public static String state
        {
            get { return "Состояние заявки"; }

        }

        public static String amountin
        {
            get { return "Сумма выставленной заявки"; }
        }

        public static String amountout
        {
            get { return "Желаемая сумма"; }
        }

        public static String inoutrate
        {
            get { return "Прямой курс обмена"; }
        }

        public static String outinrate
        {
            get { return "Обратный курс обмена"; }
        }

        public static String inpurse
        {
            get { return "Кошелек иточник"; }
        }

        public static String outpurse
        {
            get { return "Кошелек назначения"; }
        }


        public static String querydatecr
        {
            get { return "Дата постановки заявки"; }
        }

        public static String querydate
        {
            get { return "Дата последнего изменения в заявке"; }
        }


        public static String direction
        {
            get { return "Направление обмена"; }
        }

        public static String rate
        {
            get { return "Курс обмена"; }
        }
    }
}