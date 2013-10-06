using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using ru.xnull.config;

namespace ru.xnull.Config.Initialization
{
    /// <summary>
    /// Класс проверяет, существует ли конфиг файл.
    /// </summary>
    class ConfigExsistHandler : Handler
    {
        public override Boolean handle()
        {
            if (!File.Exists(ConfigDao.defaultPathToConfig))
            {
                DialogResult result = MessageBox.Show("Возможно это Ваш первый запуск программы\n" +
                                "хотите ли Вы просмотреть справку о начале работы с программой?", "Справочная информация", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Process.Start(@"help\before.pdf");
                    }
                    catch { }
                }
                return failer.handle();
            }
            return successor.handle();
        }
    }
}
