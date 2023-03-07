using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Cars;
    public static GameObject currentCar;
    [SerializeField]
    Vector3 SpawnPosition;

    public static WheelsController WheelsController;
    public static LightsData  lightsData;

    public static int carID; 
    private void Awake()
    {
        foreach( GameObject prefab in Resources.LoadAll<GameObject>("Prefabs"))
        {
            if (prefab.CompareTag("Car"))
                Cars.Add(prefab);
        };
        
        foreach(var car in Cars)
        {
            if(car.GetComponent<Car>().carInfo.id == carID)
            {
                currentCar = car;
                break;
            }
        }

        currentCar = Instantiate(currentCar, SpawnPosition, Quaternion.identity);

        WheelsController = currentCar.GetComponentInChildren<WheelsController>();
        lightsData = currentCar.GetComponentInChildren<LightsData>();
    }
}
