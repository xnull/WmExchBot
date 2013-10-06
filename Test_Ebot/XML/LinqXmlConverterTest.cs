using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ru.xnull.XML;
using System.Xml.Linq;
using System.Xml;

namespace Test_Ebot.XML
{
    [TestFixture]
    class LinqXmlConverterTest
    {
        [Test]
        public void linqToXmlTest()
        {
            LinqXmlConverter lxConverter = new LinqXmlConverter();
            XElement xel = new XElement("test");
            //xel.Add(new XElement("subtest"));
            xel.Add(new XAttribute("you", "you"));
            XmlNode xmlNodeConverted = lxConverter.linqToXml(xel);
            Assert.AreEqual(xmlNodeConverted.OuterXml.Trim(), xel.ToString().Trim());
        }

        [Test]
        public void xmlToLinqTest()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<test>you</test>");
            LinqXmlConverter lxConverter = new LinqXmlConverter();
            XElement xElementConverted = lxConverter.XmlToLinq(xmlDoc.DocumentElement);
            Assert.AreEqual(xElementConverted.ToString(), xmlDoc.DocumentElement.OuterXml);            
        }
    }
}
