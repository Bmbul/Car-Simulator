using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using UnityEngine.SceneManagement;

public class GameSceneUIController: MonoBehaviour
{
    [SerializeField]
    GameObject pauseCanvas;
    [SerializeField]
    GameObject mainCanvas;
    [SerializeField]
    TextMeshProUGUI speedText;
    StringBuilder sb;

    [SerializeField]
    RectTransform dotTransform;

    [SerializeField]
    Vector3 dotStartingPosition;
    [SerializeField]
    Vector3 dotEndingPosition;
    [SerializeField]
    SceneLoader SceneLoader;

    private void Update()
    {
        SpeedometerUpdate();
    }
    public void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        mainCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
    }

    public void OnResumeClick()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

    public void OnGarageClick()
    {
        Time.timeScale = 1;
        SaveGameData();
        SceneManager.LoadScene(0);
    }

    public void OnRestoreClick()
    {
        SceneData.currentCar.transform.eulerAngles = new Vector3(0, SceneData.currentCar.transform.eulerAngles.y, 0);
    }

    public void OnCameraChangePositionClick()
    {
        CameraController.currentPosition = (CameraController.currentPosition + 1) % CameraController.cameraPositionsArrayLenght;
    }

    void SpeedometerUpdate()
    {
        sb = new StringBuilder("Km/h");
        sb.Insert(0, "  ");
        speedText.text = sb.Insert(0, CarController.carSpeed.ToString()).ToString();
        dotTransform.localPosition = DotCurrentPosition();
    }

    Vector3 DotCurrentPosition()
    {
        Vector3 differenceVector = dotEndingPosition - dotStartingPosition;
        if (CarController.carSpeed >= SceneData.currentCar.GetComponent<Car>().carInfo.maxSpeed)
            return dotEndingPosition;
        return new Vector3(dotStartingPosition.x + differenceVector.x * ((float)CarController.carSpeed / SceneData.currentCar.GetComponent<Car>().carInfo.maxSpeed),dotStartingPosition.y, 0);
    }
    void SaveGameData()
    {
        GameManager.playerCollection.SaveData();
    }
}
