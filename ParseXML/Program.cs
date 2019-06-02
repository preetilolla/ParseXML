using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParseXML
{
    class XMLParsing
    {
        static void Main(string[] args)
        {
            XmlDocument SrcDoc = new XmlDocument();

            SrcDoc.Load("c:\\users\\plolla\\documents\\visual studio 2015\\Projects\\ParseXML\\ParseXML\\Sample.xml");
            string xmlcontents = SrcDoc.InnerXml;

            var nsmgr = new XmlNamespaceManager(SrcDoc.NameTable);
            nsmgr.AddNamespace("ws", "urn:com.workday/workersync");

            XmlNode RootNode = SrcDoc.DocumentElement;
            //var nodes=SrcDoc.GetElementsByTagName()
            XmlNodeList nodes = RootNode.SelectNodes("//ws:Worker/ws:Personal/ws:Phone_Data", nsmgr);
            var n = nodes;
            List<string> phonetype = new List<string>();
            for (int i = 0; i < nodes.Count; i++)
            {
                if (!phonetype.Contains(nodes[i].ChildNodes[0].InnerText +" | " + nodes[i].ChildNodes[1].InnerText))
                {
                    //Console.WriteLine(nodes[i].InnerText);
                    phonetype.Add(nodes[i].ChildNodes[0].InnerText + " | " + nodes[i].ChildNodes[1].InnerText);
                }
            }
        }
    }
}
