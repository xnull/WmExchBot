using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ru.xnull.XML;
using System.Xml;
using ru.xnull.Config.Mapping;
using System.IO;
using ru.xnull.Config.Initialization;

namespace ru.xnull.Config
{
    /// <summary>
    /// Инициализация конфига, со всеми возможными вариантами.
    /// Построен на шаблоне проектирования chain of Responsibility 
    /// </summary>
    class ConfigInitWizard
    {
        /// <summary>
        /// Начальная инициализация конфига
        /// </summary>
        /// <returns></returns>
        public Boolean run()
        {
            Handler configExsist = new ConfigExsistHandler();
            UserPasswordHandler userPasswordHandler = new UserPasswordHandler();
            UserPasswordHandler userPassHandlerForTemplater = new UserPasswordHandler();
            Handler configDecriptor = new ConfigDecriptor();
            Handler templater = new ConfigTemplater();
            Handler templaterAsker = new TemplaterAsker();
            Handler notImplementedHandler = new NotImplementedHandler();

            //если файл конфига существует
            configExsist.setSuccessor(userPasswordHandler);            
            //после ввода пароля передаем управление расшифровщику конфига
            userPasswordHandler.setSuccessor(configDecriptor);
            //если конфиг не смогли расшифровать. передаем управление для ввода пароля, заново.
            configDecriptor.setFailer(userPasswordHandler);

            //если файл конфига не существует, 
            //то спрашиваем юзера - создать ли для него конфиг на основе шаблона
            configExsist.setFailer(templaterAsker);
            //если юзер соглашается, просим его ввести пароль для нового конфига
            userPassHandlerForTemplater.setTextForPassForm("Введите пароль который будет использоваться для нового конфига");
            templaterAsker.setSuccessor(userPassHandlerForTemplater);
            //если юзер ввел пароль, то передаем управление создателю конфига на основе шаблона. иначе выходим
            userPassHandlerForTemplater.setSuccessor(templater);
            templater.setSuccessor(configDecriptor);


            return configExsist.handle();
        }
    }
}

/**
 * Алгоритм работы:
 * 1.	существует ли файл (ConfigExsist) +
1.1.	да  (successor) +
1.1.1.	спрашиваем пароль (UserPassword) +
1.1.1.1.	 если юзер нажал отмену или ввел пустой пароль, выходим из программы. (return false) +-
1.1.1.2.	если юзер ввел данные: (successor) +
1.1.1.2.1.	пытаемся расшифровать (ConfigDecriptor) + 
1.1.1.2.1.1.	 если получилось (return true) +
1.1.1.2.1.1.1.	отлично, работаем дальше +
1.1.1.2.2.	если не получилось расшифровать +
1.1.1.2.2.1.	 выдаем юзеру что пароль не подходит +
1.1.1.2.2.2.	 выдаем юзеру запрос на ввод пароля failer.handle() - UserPassword
1.2.	не существует (failer - ConfigTemplater) +
1.2.1.1.1.	спрашиваем, создать ли конфиг на основе шаблона?  (successor - Templater)+
1.2.1.1.1.1.	 если юзер соглашается  +
1.2.1.1.1.1.1.	спросить пароль +
1.2.1.1.1.1.1.1.	 если юзер ввел пароль то продолжаем + 
1.2.1.1.1.1.1.2.	 если юзер нажал отмену, то выходим из программы + 
1.2.1.1.1.1.2.	выдать форму для редактирования нового конфига?(надо ли)
1.2.1.1.1.1.3.	продолжить работать +
1.2.1.1.1.2.	если юзер не соглашается закрываем программу + 
*/
