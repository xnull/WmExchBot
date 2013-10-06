using System;
using System.Collections.Generic;
using System.Text;
using ru.xnull.exchanger;

namespace ru.xnull.Exchanger
{
    /// <summary>
    /// Класс показывает спред в направлениях обменов.
    /// В конструкторе задается направление обмена и спред который мы получаем по этому направлению.
    /// Рассчеты идут в классе SpreadCalc
    /// </summary>
    public class Spread
    {
        private string _FullDirection;
        public string FullDirection
        {
            get { return _FullDirection; }
        }

        public string ForwardDirection
        {
            get { return _FullDirection.Substring(0, 7); }
        }

        /// <summary>
        /// Обратное направление для первого направления обмена из fullDirection
        /// </summary>
        public string ReverseForwardDirection
        {
            get { return _FullDirection.Substring(9); }
        }

        private double _spread;
        public double spread
        {
            get { return _spread; }
        }

        /// <summary>
        /// Класс результат рассчета спреда по данному направлению
        /// </summary>
        /// <param name="fulldirection">полное направление обмена, то есть для бехавиора (WMZ_WMR__WMR_WMZ)</param>
        /// <param name="spread">Спред, наверное в копейках? проконтролировать!!!</param>
        public Spread(string fulldirection, double spread)
        {
            _FullDirection = fulldirection;
            _spread = spread;
        }

        public string[] GetDirections()
        {
            string[] result = new string[2];
            result[0] = _FullDirection.Substring(0, 7);
            result[1] = _FullDirection.Substring(9);
            return result;
        }

        public int[] GetExchTypes()
        {
            string[] Direcions = GetDirections();
            int[] result = new int[2];
            int i = 0;
            foreach (string currDirections in Direcions)
            {
                result[i] = new ExchType().GetExchTypeFromDirection(currDirections);
                i++;
            }
            return result;
        }
    }
}
