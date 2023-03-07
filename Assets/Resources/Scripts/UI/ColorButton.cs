using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorButton : Button
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        Debug.Log(eventData.selectedObject);

        CarColorChange.newColor = eventData.selectedObject.GetComponent<Image>().color;
        CarColorChange.acceptPanel.SetActive(true);
    }
}
