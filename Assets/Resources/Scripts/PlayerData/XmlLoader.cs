using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System.Xml;


public class XmlLoader : MonoBehaviour
{
    public static XmlDocument xml;
    public static string xmlPath;
    private void Awake()
    {
        xmlPath = Application.persistentDataPath + Path.DirectorySeparatorChar + "GameData.xml";
        if (File.Exists(xmlPath))
        {
            xml = new XmlDocument();
            xml.Load(xmlPath);
        }
        else
        {
            XmlTextWriter xmlWriter = new XmlTextWriter(xmlPath, System.Text.Encoding.UTF8);
            xmlWriter.Formatting = Formatting.Indented;
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteComment("Creating xml file");
            xmlWriter.WriteStartElement("PlayersContainer");
            xmlWriter.WriteEndElement();
            xmlWriter.Flush();
            xmlWriter.Close();

            xml = new XmlDocument();
            xml.Load(xmlPath);
        }
    }
}
