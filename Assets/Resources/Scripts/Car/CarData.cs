using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class CarData
{
    [XmlAttribute("CarID")]
    public int id;

    [XmlAttribute("CarBenzin")]
    public int carBenzin;


    public CarData(int _id, int _carBenzin)
    {
        this.id = _id;
        this.carBenzin = _carBenzin;
    }
    public CarData()
    {

    }
}
