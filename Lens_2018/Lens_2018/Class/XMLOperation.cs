using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Data;



namespace Lens_2018
{
    class XMLOperation
    {
        #region 当前产品名称
        private static string productname;
        public static string ProductName
        {
            get
            {
                Dictionary<string, string> d = ReadAllXmlDefault("CurrentProduct.xml", "部件检测");
                productname = d["当前文件"];
                return productname;
            }
            set
            {
                Dictionary<string, string> d = ReadAllXmlDefault("CurrentProduct.xml", "部件检测");
                d["当前文件"] = value;

                XMLOperation.SaveParameterDefault("CurrentProduct.xml", "部件检测", d);
            }
        }
        #endregion

        #region 对参数的读取操作
        #region 读取参数
        public static Dictionary<string, string> ReadAllXml(string XmlName, string NodeName)
            {
                try
                {
                    Dictionary<string, string> msg = new Dictionary<string, string>();
                    XmlDocument doc = new XmlDocument();
                    string filepath = Environment.CurrentDirectory + "\\ProductXML\\" + ProductName + "\\" + XmlName;
                    if (!File.Exists(filepath))
                        return null;
                    doc.Load(filepath);
                    XmlElement xmlDoc = doc.DocumentElement;
                    XmlNode xn = xmlDoc.SelectSingleNode(NodeName);
                    if (xn == null)
                        return null;

                    XmlNodeList xnl = xn.ChildNodes;

                    foreach (XmlNode xnf in xnl)
                    {
                        if (xnf.HasChildNodes)
                        {
                            msg.Add(xnf.Name, xnf.InnerText);
                        }
                    }
                    return msg;
                }
                catch
                {
                    //throw (new XMLException("XML文件读取产生错误，请检查！"));
                    return null;
                }
            }
        #endregion

        #region 读取当前产品名称
        public static Dictionary<string, string> ReadAllXmlDefault(string XmlName, string NodeName)
        {
            try
            {
                Dictionary<string, string> msg = new Dictionary<string, string>();
                XmlDocument doc = new XmlDocument();
                string filePath = Environment.CurrentDirectory + "\\" + XmlName;
                if (!File.Exists(filePath))
                    return null;
                doc.Load(filePath);
                XmlElement xmlDoc = doc.DocumentElement;
                XmlNode xn = xmlDoc.SelectSingleNode(NodeName);
                if (xn == null)
                    return null;

                XmlNodeList xnl = xn.ChildNodes;
                foreach(XmlNode xnf in xnl)
                {
                    if(xnf.HasChildNodes)
                    {
                        msg.Add(xnf.Name, xnf.InnerText);
                    }
                }
                return msg;

            }
            catch
            {
                throw (new XMLException("XML文件读取产生错误，请检查"));
            }
        }
        #endregion

        #region 保存参数
        public static void SaveParameter(string xmlName, string typeName, Dictionary<string, string> msg)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                string filepath = Environment.CurrentDirectory + "\\ProductXML\\" + ProductName + "\\" + xmlName;

                if (File.Exists(filepath))
                {
                    doc.Load(filepath);
                    XmlElement xmlDoc = doc.DocumentElement;
                    XmlNode xml_node = xmlDoc.SelectSingleNode(typeName);
                    if(xml_node==null)
                    {
                        XmlElement xml = doc.CreateElement(typeName);
                        xmlDoc.AppendChild(xml);
                        foreach(KeyValuePair<string,string> kvp in msg)
                        {
                            XmlElement xml_Element = doc.CreateElement(kvp.Key);
                            xml_Element.InnerText = kvp.Value;
                            xml.AppendChild(xml_Element);
                        } 
                    }
                    else
                    {
                        foreach (KeyValuePair<string, string> kvp in msg)
                        {
                            XmlNode Node = xml_node.SelectSingleNode(kvp.Key);
                            if (Node == null)
                            {
                                XmlElement xml = doc.CreateElement(kvp.Key);
                                xml.InnerText = kvp.Value;
                                xml_node.AppendChild(xml);
                            }
                            else
                            {
                                Node.InnerText = kvp.Value;
                            }
                        }
                    }

                }
                else
                {
                    //将当前数据写入XML文件
                    //加入XML的声明段落,<?xml version="1.0" encoding="UTF-8"?>
                    XmlDeclaration xmlDeclar;
                    xmlDeclar = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    doc.AppendChild(xmlDeclar);
                    XmlElement xmlFirst = doc.CreateElement("", "PARAM", "");
                    doc.AppendChild(xmlFirst);
                    XmlElement xml = doc.CreateElement(typeName);
                    xmlFirst.AppendChild(xml);
                    foreach (KeyValuePair<string, string> kvp in msg)
                    {
                        XmlElement xml_Element = doc.CreateElement(kvp.Key);
                        xml_Element.InnerText = kvp.Value;
                        xml.AppendChild(xml_Element);
                    }
                }

            }
                       
            catch
            {
                //throw(new XMLException("XML文件保存产生错误，请检查！"));
                return;
            }
        }
        #endregion
        #region 保存当前产品名称
        public static void SaveParameterDefault(string xmlName, string typeName, Dictionary<string, string> msg)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                string filepath = Environment.CurrentDirectory + "\\" + xmlName;

                if (File.Exists(filepath))
                {
                    doc.Load(filepath);
                    XmlElement xmlDoc = doc.DocumentElement;
                    XmlNode xml_node = xmlDoc.SelectSingleNode(typeName);
                    if (xml_node == null)                  //当前节点不存在
                    {
                        XmlElement xml = doc.CreateElement(typeName);
                        xmlDoc.AppendChild(xml);
                        foreach (KeyValuePair<string, string> kvp in msg)
                        {
                            XmlElement xml_Element = doc.CreateElement(kvp.Key);
                            xml_Element.InnerText = kvp.Value;
                            xml.AppendChild(xml_Element);
                        }
                    }
                    else
                    {
                        foreach (KeyValuePair<string, string> kvp in msg)
                        {
                            XmlNode Node = xml_node.SelectSingleNode(kvp.Key);
                            if (Node == null)
                            {
                                XmlElement xml = doc.CreateElement(kvp.Key);
                                xml.InnerText = kvp.Value;
                                xml_node.AppendChild(xml);
                            }
                            else
                            {
                                Node.InnerText = kvp.Value;
                            }
                        }
                    }

                }
                else
                {
                    //将当前数据写入XML文件
                    //加入XML的声明段落,<?xml version="1.0" encoding="UTF-8"?>
                    XmlDeclaration xmlDeclar;
                    xmlDeclar = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    doc.AppendChild(xmlDeclar);
                    XmlElement xmlFirst = doc.CreateElement("", "PARAM", "");
                    doc.AppendChild(xmlFirst);
                    XmlElement xml = doc.CreateElement(typeName);
                    xmlFirst.AppendChild(xml);
                    foreach (KeyValuePair<string, string> kvp in msg)
                    {
                        XmlElement xml_Element = doc.CreateElement(kvp.Key);
                        xml_Element.InnerText = kvp.Value;
                        xml.AppendChild(xml_Element);
                    }
                }
                doc.Save(filepath);
            }
            catch
            {
                throw (new XMLException("XML文件保存产生错误，请检查！"));
            }
        }
        #endregion
        #endregion
    }
}
