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
    class MyPaysMapTest
    {
        [Test]
        public void checkMyPaysMapping()
        {
            Assert.True(File.Exists("Resources\\MyPay\\ListMyPays.xml"));
            XmlDocument listMyPaysXml = new XmlDocument();
            listMyPaysXml.Load("Resources\\MyPay\\ListMyPays.xml");

            XmlMapper mapper = new XmlMapper();
            MyPaysMap myPays = mapper.xmlStringToClass<MyPaysMap>(listMyPaysXml.DocumentElement["WMExchnagerQuerys"].OuterXml);


            Assert.AreEqual(myPays.listMyPays.Count, 1);
            Assert.AreEqual(myPays.listMyPays[0].id, 5314812); 
        }
    }
}
