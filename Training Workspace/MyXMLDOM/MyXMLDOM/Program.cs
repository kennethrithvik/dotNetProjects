using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyXMLDOM
{
    class Program
    {
        static void Main(string[] args)
        {
            string path=@"..\..\EMPLOYEEstyle.xml";
            XmlDocument dom=new XmlDocument();//w3c standards
            if (System.IO.File.Exists(path))
            {
                dom.Load(path);
            }
            else
            {
                dom.LoadXml("<EMPLOYEE></EMPLOYEE>");
            }
            XmlElement root = dom.DocumentElement;

            //Console.WriteLine(root.InnerText);
            XmlNode title = root.FirstChild;
            //Console.WriteLine(title.InnerText);

            XmlNodeList allemp = dom.GetElementsByTagName("EMPLOYEE");//descendant
            foreach (XmlNode item in allemp)
            {
                //Console.WriteLine(item.InnerXml);
            }

            XmlNode empe1 = root.SelectSingleNode("./EMPLOYEE[@EMPID='E1']");
            //Console.WriteLine(empe1.InnerXml);

            XmlNodeList allfirsts = root.SelectNodes("//FIRST");
            foreach (XmlNode item in allfirsts)
            {
                Console.WriteLine(item.InnerText);
            }

            XmlElement emp3 = dom.CreateElement("EMPLOYEE");
            emp3.SetAttribute("EMPID", "E3");
            XmlElement name = dom.CreateElement("NAME");
            XmlElement first3 = dom.CreateElement("FIRST");
            first3.InnerText = "First3";
            name.AppendChild(first3);
            emp3.AppendChild(name);
            root.AppendChild(emp3);
            Console.WriteLine(root.InnerXml);

            dom.Save(@"..\..\empnew.xml");



            Console.ReadLine();

        }
    }
}
