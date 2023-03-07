using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CarState {locked , unlocked};
[CreateAssetMenu(fileName = "Car", menuName = "ScriptableObjects/CreateNewCar", order = 1)]
public class CarScriptable : ScriptableObject
{
    public int id;
    public string carName;
    public int price;
    public int maxSpeed;
    public float maxSteerAngle;
    public float turnSensitivity;
    public CarState carState;
    public int benzin;
}
