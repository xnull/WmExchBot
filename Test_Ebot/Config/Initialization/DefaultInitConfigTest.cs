using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull.Config.Initialization;
using System.IO;
using System.Windows.Forms;
using Rhino.Mocks;
using ru.xnull;
using ru.xnull.config;

namespace Test_Ebot.Config.Initialization
{
    [TestFixture]
    class DefaultInitConfigTest
    {
        [Test]
        [ExpectedException(typeof(ConfigDaoException))]
        public void testDefault()
        {
            MockRepository mocks = new MockRepository();
            Handler failerMock = mocks.StrictMock<Handler>();

            Expect.Call(failerMock.handle()).IgnoreArguments().Return(true);
            mocks.ReplayAll();

            File.Delete(Application.StartupPath + "\\e-bot.enc");
            
            ConfigDecriptor defaultInit = new ConfigDecriptor();
            defaultInit.setFailer(failerMock);
            defaultInit.setPassword("password");

            Assert.True(!defaultInit.handle());
        }
    }
}
