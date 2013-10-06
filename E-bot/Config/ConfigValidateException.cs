using System;
using System.Collections.Generic;
using System.Text;

namespace ru.xnull.Config
{
    class ConfigValidateException : Exception
    {
        public ConfigValidateException(string tagName) : base("Ошибка при парсинге конфига. В конфиге нет тэга " + tagName) { }
    }
}
