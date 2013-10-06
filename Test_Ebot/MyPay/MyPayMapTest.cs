using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Xml;
using System.IO;
using ru.xnull.MyPay;
using ru.xnull.XML;

namespace Test_Ebot.MyPay
{
    [TestFixture]
    class MyPayMapTest
    {
        [Test]
        public void checkMyPay()
        {            
            Assert.True(File.Exists("Resources\\MyPay\\ListMyPays.xml"));
            XmlDocument listMyPaysXml = new XmlDocument();
            listMyPaysXml.Load("Resources\\MyPay\\ListMyPays.xml");
            
            
            XmlNode myPayXmlNode = listMyPaysXml.SelectSingleNode("//query");
            Assert.NotNull(myPayXmlNode);

            XmlMapper mapper = new XmlMapper();
            MyPayMap myPay = mapper.xmlStringToClass<MyPayMap>(myPayXmlNode.OuterXml);
            myPay.wmid = "123";

            Assert.AreEqual(myPay.amountin, "2");
            Assert.AreEqual(myPay.wmid, "123");
            Assert.AreEqual(myPay.exchtype, 1);
            Assert.AreEqual(myPay.direction, "WMZ_WMR");
            Assert.AreEqual(myPay.Rate, 28.9);
            Assert.AreEqual(myPay.CursType, 1); //прямой курс обмена
        }
    }
}
