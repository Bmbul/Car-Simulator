using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControlButtons : Button
{

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        string name = eventData.selectedObject.name;
        if (name == "Left")
            CarController.GetRightLeftInput(-1);
        else if (name == "Right")
            CarController.GetRightLeftInput(1);
        if (name == "Forth")
            CarController.GetBackForthInput(1);
        else if (name == "Back")
            CarController.GetBackForthInput(-0.5f);
        if (name == "Brake")
            CarController.GetBreakInput(10000);

        //switch (eventData.selectedObject.name)
        //{
        //    case "Left":
        //        CarController.GetRightLeftInput(-1);
        //        Debug.LogError("left");
        //        break;
        //    case "Right":
        //        CarController.GetRightLeftInput(1);
        //        Debug.LogError("right");
        //        break;
        //    case "Back":
        //        CarController.GetBackForthInput(-0.5f);
        //        Debug.LogError("back");
        //        break;
        //    case "Forth":
        //        CarController.GetBackForthInput(1);
        //        Debug.LogError("forth");
        //        break;
        //    case "Break":
        //        CarController.GetBreakInput(10000);
        //        Debug.LogError("Brake");
        //        break;
        //}
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        string name = eventData.selectedObject.name;

        if (name == "Left" || name == "Right")
            CarController.GetRightLeftInput(0);
        if (name == "Forth" || name == "Back")
            CarController.GetBackForthInput(0);
        if (name == "Brake")
            CarController.GetBreakInput(0);
        //switch (eventData.selectedObject.name)
        //{
        //    case "Left":
        //        CarController.GetRightLeftInput(0);
        //        Debug.LogError("Left released");
        //        break;
        //    case "Right":
        //        CarController.GetRightLeftInput(0);
        //        Debug.LogError("Right released");
        //        break;
        //    case "Back":
        //        CarController.GetBackForthInput(0);
        //        Debug.LogError("Back released");
        //        break;
        //    case "Forth":
        //        CarController.GetBackForthInput(0);
        //        Debug.LogError("Forth released");
        //        break;
        //    case "Break":
        //        CarController.GetBreakInput(0);
        //        Debug.LogError("Brake released");
        //        break;
        //}
    }
}