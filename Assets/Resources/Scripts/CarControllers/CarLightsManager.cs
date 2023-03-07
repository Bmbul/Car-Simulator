using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CarLightsManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI lights;

    public void OnLightsButtonClick()
    {
        if (lights.text == "OFF")
        {
            lights.text = "ON";
            SceneData.lightsData.LightsOn();
        }
        else
        {
            lights.text = "OFF";
            SceneData.lightsData.LightsOff();
        }
    }
}
