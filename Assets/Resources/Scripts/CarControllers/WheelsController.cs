using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Axel { Front,Rear};

[Serializable]
public struct Wheel
{
    public GameObject model;
    public WheelCollider collider;
    public Axel wheelAxel;
}


public class WheelsController : MonoBehaviour
{
   

    [SerializeField]
    private List<Wheel> wheels;


    private void OnEnable()
    {
        foreach (var wheel in wheels)
        {
            wheel.collider.ConfigureVehicleSubsteps(5,15,17);
        }
    }


    void Update()
    {
        AnimateWheels();
    }


    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        foreach (var wheel in wheels)
        {
            if(CarController.carSpeed < CarController.maxSpeed)
            {
                wheel.collider.motorTorque = CarController.inputY * CarController.maxSpeed * 200 * Time.deltaTime;
            }
            wheel.collider.brakeTorque = CarController.breakInput;
        }
    }

    private void Turn()
    {
        foreach (var wheel in wheels)
        {
            if(wheel.wheelAxel == Axel.Front)
            {
                var _steerAngle = CarController.inputX * CarController.turnSensitivity * CarController.maxSteerAngle* CarController.direction;
                wheel.collider.steerAngle = Mathf.Lerp(_steerAngle,wheel.collider.steerAngle, 0.5f);
            }
        }
    }

    private void AnimateWheels()
    {
        foreach(var wheel in wheels)
        {
            Quaternion rotation;
            Vector3 position;

            wheel.collider.GetWorldPose(out position, out rotation);
            wheel.model.transform.position = position;
            wheel.model.transform.rotation = rotation;
        }
    }
}
