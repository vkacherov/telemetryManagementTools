#r "Newtonsoft.Json"
 
using System;
using System.Xml.XPath;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Xml;
using System.Text;
 
public static string Run(string sbdIoTHubXmlMessage, TraceWriter log)
{
    log.Info($"input:{sbdIoTHubXmlMessage}:");
 
    var json = new Dictionary<string, string>();
    string key;
    string value;
 
    byte[] encodedString = Encoding.UTF8.GetBytes(sbdIoTHubXmlMessage);

    MemoryStream ms = new MemoryStream(encodedString);
    ms.Flush();
    ms.Position = 0;

    XmlDocument doc = new XmlDocument();
    doc.Load(ms);
 
    XPathNavigator navigator = doc.CreateNavigator(); 
    XPathNodeIterator nodes = navigator.Select("/MeasurementData/MeasurementParameter"); 
 
    while(nodes.MoveNext()) 
    {
        nodes.Current.MoveToChild("key", "");
 
        key = nodes.Current.InnerXml;
 
        nodes.Current.MoveToNext();
        value = nodes.Current.InnerXml;
 
        json.Add(key, value);
    }
    
    string outputjson = JsonConvert.SerializeObject(json);
   
    log.Info($"output: {outputjson}");
 
    return outputjson;
}
 
 
 