using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EmptyProject
{
    public class T
    {
XmlDocument xdoc = new XmlDocument();
// xdoc.LoadXml("XML字符串");
xdoc.Load("XML文件路径");
var listNodes = xdoc.SelectSingleNode("Lists").ChildNodes[0]; // 表示Lists下的List的所有数据
var keyNodes = xdoc.SelectSingleNode("Lists").ChildNodes[1]; // 表示Lists下的key的所有数据

#region 获取属性的值

// 获取属性的值
string CN1 = listNodes.SelectSingleNode("Item").Attributes["CN"].Value; // SelectSingleNode 表示第一个
CN1 = ((XmlElement) listNodes.SelectSingleNode("Item")).GetAttribute("CN");
CN1 = listNodes.SelectNodes("Item")[0].Attributes["CN"].Value; // SelectNodes 表示查询所有
CN1 = xdoc.SelectSingleNode("Lists/List/Item").Attributes["CN"].Value;
CN1 = xdoc.SelectNodes("Lists/List/Item")[0].Attributes["CN"].Value;
string EN2 = listNodes.SelectNodes("Item")[1].Attributes["EN"].Value; // SelectNodes 表示查询所有
EN2 = xdoc.SelectNodes("Lists/List/Item")[1].Attributes["EN"].Value;
string one = keyNodes.SelectSingleNode("ID").Attributes["id"].Value;
string two = keyNodes.SelectSingleNode("Name").Attributes["name"].Value;

#endregion

#region 获取节点的值

// 获取节点的值
string Item1 = xdoc.SelectSingleNode("Lists/List/Item").InnerText;
Item1 = listNodes.SelectSingleNode("Item").InnerText;
string Item2 = xdoc.SelectNodes("Lists/List/Item")[1].InnerText;
string id = xdoc.SelectSingleNode("Lists/key/ID").InnerText;
string name = xdoc.SelectSingleNode("Lists/key/Name").InnerText;
id = keyNodes.SelectSingleNode("ID").InnerText;
name = keyNodes.SelectSingleNode("Name").InnerText;

#endregion

#region 循环遍历读取，添加至 Dictionary

Dictionary<string, string> dic = new Dictionary<string, string>();
var nodes = xdoc.SelectSingleNode("Lists/key").ChildNodes;
foreach (XmlNode item in nodes)
{
    XmlElement xe = (XmlElement)item;
    string id2 = xe.GetAttribute("id"); // 属性
    dic.Add(xe.Name, xe.InnerText);
}
string id3 = dic.FirstOrDefault(q => q.Key == "ID").Value;

#endregion
    }
}
