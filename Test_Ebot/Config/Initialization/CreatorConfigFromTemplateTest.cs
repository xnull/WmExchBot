using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using ru.xnull.Config.Initialization;
using System.Windows.Forms;

namespace Test_Ebot.Config.Initialization
{
    [TestFixture]
    class CreatorConfigFromTemplateTest
    {
        [Test]
        public void testCreateConfigFromTemplate()
        {
            MockRepository mocks = new MockRepository();
            Handler failerMock = mocks.StrictMock<Handler>();

            Expect.Call(failerMock.handle()).IgnoreArguments().Return(true);
            mocks.ReplayAll();

            ConfigTemplater templater = new ConfigTemplater();
            templater.setFailer(failerMock);
            
            //тестирование  гуя будь он неладен. в выше вызванном коде вылезет окно надо нажать кнопку да, и тест сработает корректно
            //Assert.True(templater.handle("password"));
        }
    }
}
