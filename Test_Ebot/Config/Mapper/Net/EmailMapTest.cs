using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull;
using ru.xnull.XML;
using ru.xnull.Config.Mapping.Net;
using System.Xml;

namespace Test_Ebot.Config.Mapper.Net
{
    [TestFixture]
    class EmailMapTest
    {
        [Test]
        public void testEmail()
        {
            XmlDocument xmlConfig = new XmlDocument();
            xmlConfig.Load(@"Resources\Config.xml");
            
            String emailString = xmlConfig.SelectSingleNode("//Net/Email").OuterXml;

            XmlMapper mapper = new XmlMapper();
            EmailMap emailMap = mapper.xmlStringToClass<EmailMap>(emailString);

            Assert.AreEqual(emailMap.from, "WM@webmoney.ru");
            Assert.AreEqual(emailMap.login, "null");
            Assert.AreEqual(emailMap.pass, "testpass");
            Assert.AreEqual(emailMap.port, 25);
            Assert.AreEqual(emailMap.sendmail, false);
            Assert.AreEqual(emailMap.server, "ya.ru");
            Assert.AreEqual(emailMap.to, "x-r-w@ya.ru");
            Assert.AreEqual(emailMap.usessl, false);

        }
    }
}
