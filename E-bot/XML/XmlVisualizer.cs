using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ru.xnull
{
    class XmlVisualizer
    {
        public string FormatXmlString(string XmlText)
        {
            XmlDocument xmldoc = new XmlDocument();
            string result = "";
            xmldoc.LoadXml(XmlText);
            result = "<?xml " + xmldoc.FirstChild.InnerText + "?>\r\n";
            result += "<" + xmldoc.DocumentElement.Name;
            result += readAttrs(xmldoc.DocumentElement);
            result += ">\r\n";
            result += readNode(xmldoc.DocumentElement, 0);
            result += "\r\n</" + xmldoc.DocumentElement.Name + ">";
            return result;
        }

        string readNode(XmlNode xmlnode, int depth)
        {
            string result = "";
            for (int i = 0; i < xmlnode.ChildNodes.Count; i++)
            {
                if (i != 0)
                {
                    result += "\r\n";
                }
                XmlNode currNode = xmlnode.ChildNodes[i];
                depth++;
                //result += tabInserter(depth);
                switch (currNode.NodeType)
                {
                    case XmlNodeType.Comment:
                        result += "<!--";
                        result += currNode.Value + "--";
                        result += ">";
                        break;
                    case XmlNodeType.CDATA:
                        result += "<![CDATA[";
                        result += currNode.Value;
                        result += "]]>";
                        break;
                    case XmlNodeType.Text:
                        result += currNode.InnerText;
                        result += "</" + xmlnode.Name + ">";
                        break;
                    case XmlNodeType.Element:
                        result += tabInserter(depth) + "<" + currNode.Name;
                        result += readAttrs(currNode);
                        result += ">";
                        if (currNode.HasChildNodes)
                        {
                            if (currNode.ChildNodes[0].NodeType == XmlNodeType.Element)
                            {
                                result += "\r\n";// +tabInserter(depth);
                                result += readNode(currNode, depth);
                                result += "\r\n" + tabInserter(depth) + "</" + currNode.Name + ">";
                            }
                            else if (currNode.ChildNodes[0].NodeType == XmlNodeType.Text)
                            {
                                result += readNode(currNode, depth);
                            }
                        }
                        else
                        {
                            result += "</" + currNode.Name + ">";
                            result += readNode(currNode, depth); 
                        }
                        //result += readNode(currNode, depth);                        
                        depth--;                        
                        break;
                    default:
                        System.Windows.Forms.MessageBox.Show("Непредвиденный тег при разборе XML документа. Документ будет отображаться неправильно. Проверьте класс XmlVisualizer.");
                        break;
                }
            }
            return result;
        }

        string readAttrs(XmlNode xmlnode)
        {
            string result = "";
            for (int i = 0; i < xmlnode.Attributes.Count; i++)
            {
                result += " " + xmlnode.Attributes[i].Name + "=\"" + xmlnode.Attributes[i].Value + "\" ";
            }
            return result;
        }

        string tabInserter(int depth)
        {
            string result = "";
            for (int i = 0; i < depth; i++)
            {
                result += "   ";
            }
            return result;
        }
    }
}
