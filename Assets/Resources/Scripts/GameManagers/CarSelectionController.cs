using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelectionController : MonoBehaviour
{
    [SerializeField]
    GameObject Cars;
    public static int currentCarId;
    public static List<Car> carList = new List<Car>();
    public static Car currentCar;
    [SerializeField]
    static Vector3 carSpawnPosition = new Vector3(0,1,0);

    #region Simple Singleton
    private static CarSelectionController instance;

    public static CarSelectionController Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null && instance != this)
            Destroy(gameObject);

        #endregion



        if(currentCar == null)
        {
            fillCarsList();
        }
    }

    public static void SyncData()
    {
        foreach (var unlockedCar in GameManager.currentPlayer.UnlockedCars)
        {
            carList[unlockedCar.id].carInfo.carState = CarState.unlocked;
            carList[unlockedCar.id].carInfo.benzin = unlockedCar.carBenzin;
        }
    }

    public static void UpdateCurrentCar()
    {
        currentCar = carList[currentCarId];
    }

    public static void Reposition()
    {
        currentCar.gameObject.transform.position = carSpawnPosition;
    }

    public void fillCarsList()
    {
        carList = new List<Car>();
        currentCarId = 0;
        foreach (Transform child in Cars.transform)
        {
            child.GetComponent<Car>().carInfo.carState = CarState.locked;
            carList.Add(child.GetComponent<Car>());
        }
        currentCar = carList[currentCarId];
    }
}
