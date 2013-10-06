using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using ru.xnull.NetTools;
using ru.xnull.Exchanger;

using log4net;
using ru.xnull.exchanger;

namespace ru.xnull
{
    public class Torgi
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Torgi));

        private IListBidsDao _listBidsDao;

        public Torgi(IListBidsDao listBidsDao)
        {
            _listBidsDao = listBidsDao;
        }
        /// <summary>
        /// Найти позицию моей заявки на бирже.
        /// результат: -1: не нашел заявку; -2: не смог загрузить данные; -3: неопределенная ошибка 
        /// </summary>
        /// <param name="DirectExchange"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int FindMyPosition(int exchtype, string id)
        {
            log.Debug("Поиск позиции моей заявки на бирже");
            ListBids ListBids = _listBidsDao.getListBids(exchtype);
            for (int i = 0; i < ListBids.Count; i++)
            {
                if (id == ListBids[i].id)
                {
                    return (i + 1);
                }
            }
            log.WarnFormat("Заявка {0} не найдена на бирже (возращаемый результат -1). Возможно у неё курс выходящий за 50 выставленных заявок на бирже.", id);
            return -1;
        }

        /// <summary>
        /// результат: -1: не нашел заявку; -2: не смог загрузить данные; -3: неопределенная ошибка 
        /// </summary>
        /// <param name="directExchange"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public double getRateForPosition(int exchtype, int position)
        {
            ListBids ListBids = _listBidsDao.getListBids(exchtype);
            log.DebugFormat("Получить курс заявки соответствующий позиции {0} на бирже. Курс заявки: {1}", position,  ListBids[position - 1].rate);            
            return ListBids[position - 1].rate;
        }

        public double ratePlusDelta(int exchType, double rate, double delta)
        {
            log.Debug("По данному направлению прибавить к курсу число");
            double result;
            if (exchType % 2 == 0)
            {
                result = rate - delta;
            }
            else
            {
                result = rate + delta;
            }
            return result;
        }

        public int getPositionForRate(int exchtype, double kurs)
        {
            log.Debug("Получить для курса позицию на бирже");
            ListBids ListBids = _listBidsDao.getListBids(exchtype);
            int iterator = 0;
            foreach (Exchanger.Bid currBid in ListBids)
            {
                iterator++;
                if (exchtype % 2 == 0)
                {
                    if (kurs > currBid.rate)
                    {
                        return iterator;
                    }
                }
                else
                {
                    if (kurs < currBid.rate)
                    {
                        return iterator;
                    }

                }
            }
            log.Warn("По направлению " + new ExchType().GetDirectionFromExchType(exchtype) + " курс " + kurs + " выходит за пределы списка заявок на бирже. Возращаем 48");
            return (48); // не нашел
        }

        public double outamountForInamount(int exchType, double inamount, double inamountKurs)
        {
            double outamount;
            if (exchType % 2 == 0)
            {
                outamount = rate(inamount / inamountKurs);
            }
            else
            {
                outamount = rate(inamount * inamountKurs);
            }
            return (outamount);
        }
                
        public double rate(double rate)
        {
            if (rate < 1)
            {
                return (1 / rate);
            }
            else
            {
                return (rate);
            }
        }

        /// <summary>
        /// Задать для моей заявки либо курс по минимальному (параметр minKurs), либо если плановая позиция удовлетворяет
        /// требованиям то задаем курс взятый по позицци заявки
        /// </summary>
        /// <param name="ExchType"></param>
        /// <param name="currentPlanPosition"></param>
        /// <param name="minKurs"></param>
        /// <returns></returns>
        public int setMyPayPosition(int ExchType, int currentPlanPosition, double minKurs)
        {
            log.Debug("Задать для моей заявки либо курс по минимальному, либо если плановая позиция удовлетворяет требованиям то задаем курс взятый по позицци заявки");
            try
            {                
                double rateForPosition = getRateForPosition(ExchType, currentPlanPosition);
                //проверяем если на этой позиции курс меньше минимального, то ставим по минимальному курсу а не по позиции!!!!!!
                if ((Convert.ToInt32(ExchType)) % 2 == 0) //если четное - прямое направление, покупать как можно дешевле
                {
                    if (rateForPosition < minKurs) //четное - я покупаю
                    {
                        return (currentPlanPosition);
                    }
                    else
                    {
                        int position = getPositionForRate(ExchType, minKurs);
                        if (position < 0)
                        {
                            position = 1;
                        }
                        return (position);
                    }
                }
                else // продавать как можно дороже
                {
                    if (rateForPosition > minKurs)
                    {
                        return (currentPlanPosition);
                    }
                    else
                    {
                        int position = getPositionForRate(ExchType, minKurs);
                        if (position < 0)
                        {
                            position = 1;
                        }
                        return (position);
                    }
                }
            }
            catch (Exception err)
            {
                log.Error("Не могу получить данные.", err);
                throw new Exception("Нет возможности получить данные с сайта");
            }
        }
    }
}
