using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarController : MonoBehaviour
{
    public static float maxAccelation = 20f;

    public static float maxSpeed;

    public static float turnSensitivity = 1f;

    public static float maxSteerAngle;

    public static int carSpeed;

    public static float inputX, inputY, breakInput;

    public static int direction = 1;

    Car currentCar;
    [SerializeField]
    Vector3 centerOfMass;

    [SerializeField]
    static Rigidbody _rb;
    static Vector3 velocityLocal = new Vector3(0, 0, 1);

    private void Awake()
    {
        currentCar = SceneData.currentCar.GetComponent<Car>();
        maxSpeed = currentCar.carInfo.maxSpeed;
        maxSteerAngle = currentCar.carInfo.maxSteerAngle;
        turnSensitivity = currentCar.carInfo.turnSensitivity;
        _rb = SceneData.currentCar.GetComponent<Rigidbody>();
    }

    void Start()
    {
        _rb.centerOfMass = centerOfMass;
    }

    private void Update()
    {
        carSpeed = (int)ConvertKmperHour(_rb.velocity.magnitude);
        float velocityDir = _rb.transform.InverseTransformDirection(_rb.velocity).z;
        //direction = Math.Sign(_rb.velocity.normalized.z*_rb.gameObject.transform.forward.z);
        if (Math.Abs(velocityDir) < 0.0001)
            direction = 0;
        else
            direction = Math.Sign(velocityDir); 
    }


    public static void GetRightLeftInput(int dir)
    {
        if (direction != 0)
            inputX = dir * direction;
        else
            inputX = dir;
    }


    public static void GetBackForthInput(float dir)
    {
       
        if (inputY != dir)
        {
            if (dir < 0)
            {
                SceneData.lightsData.OnReverseDrive();
            }
            else
                SceneData.lightsData.OnReverseDriveRelease();
        }
        inputY = dir;

    }


    public static void GetBreakInput(int input)
    {
        if (input != breakInput)
        {
            if (input > 0)
                SceneData.lightsData.OnBrake();
            else
                SceneData.lightsData.OnBrakeRelease();
        }
        breakInput = input;
    }


    float ConvertKmperHour(float meterPerSeconds)
    {
        return (float)3.6 * meterPerSeconds;
    }
}
