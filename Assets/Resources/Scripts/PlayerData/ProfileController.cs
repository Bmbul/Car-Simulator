    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

[XmlRoot("playerCollection")]
public class ProfileController  
{

    [XmlArray("players")]
    [XmlArrayItem("player")]
    public List<Player> players = new List<Player>();
    #region Static Fields
    
    public static string resourcesPath = "Scripts/PlayerData/PlayerData";


    static XmlSerializer serializer = new XmlSerializer((typeof(ProfileController)));
    #endregion

    #region Static methods Loader and Saver

    public static ProfileController LoadData(string path)
    {
        var xml = XmlLoader.xml;

        if (xml.DocumentElement.IsEmpty)
            //GameManager.gameState = GameState.unsigned;
            return new ProfileController();
        StringReader stringReader = new StringReader(xml.OuterXml);

        ProfileController players = serializer.Deserialize(stringReader) as ProfileController;

        stringReader.Close();

        return players;

    }

    internal void CreatePlayer(string text, int money)
    {
        GameManager.currentPlayer = new Player(text, money) ;
        players.Add(GameManager.currentPlayer);
        
        using (var stream = new FileStream(XmlLoader.xmlPath, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
    internal void SaveData()
    {
        using (var stream = new FileStream(XmlLoader.xmlPath, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    #endregion



    #region Gets the full relative path
    static string GetPath(string _relativePath)
    {
        return Path.Combine(Application.persistentDataPath, _relativePath);
    }
    
    #endregion
}
