using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ru.xnull.XML;
using ru.xnull.Config.Mapping;

namespace ru.xnull.Config.Initialization
{
    /// <summary>
    /// класс спрашивающий, создать ли конфиг на основе шаблона
    /// </summary>
    public class TemplaterAsker : Handler
    {
        public override Boolean handle()
        {
            DialogResult createNewConfig = MessageBox.Show("Конфиг файла не существует. Cоздать новый файл конфига?", "Ошибка открытия конфиг файла", MessageBoxButtons.YesNo);
            if (createNewConfig == DialogResult.Yes)
            {
                return successor.handle();                
            }
            return false;
        }
    }
}
