using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Player
{
    [XmlAttribute("player")]
    public string playerName;

    [XmlAttribute("money")]
    public int money;

    public List<CarData> UnlockedCars;

    public Player(string _name, int _money)
    {
        playerName = _name;
        money = _money;
        UnlockedCars = new List<CarData>();
    }

    public Player()
    {
    }
}
