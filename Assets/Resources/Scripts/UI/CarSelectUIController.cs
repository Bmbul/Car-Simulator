using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class CarSelectUIController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI playerName;
    [SerializeField]
    TextMeshProUGUI playerMoney;
    [SerializeField]
    TextMeshProUGUI carName;
    [SerializeField]
    GameObject left;
    [SerializeField]
    GameObject right;
    [SerializeField]
    GameObject carUnlockPanel;
    [SerializeField]
    Button startButton;
    [SerializeField]
    GameObject benzinPanel;
    [SerializeField]
    TextMeshProUGUI benzinText;
    [SerializeField]
    TextMeshProUGUI carPriceText;
    [SerializeField]
    GameObject notEnoughMoneyPanel;
    [SerializeField]
    AudioSource notEnoughMoneySound;
    [SerializeField]
    AudioSource carBuySound;
    [SerializeField]
    SceneLoader sceneLoader;
    private void OnEnable()
    {
        playerName.text = GameManager.currentPlayer.playerName;
        playerMoney.text = GameManager.currentPlayer.money.ToString();
        if(CarSelectionController.currentCar == null)
        {
            CarSelectionController.Instance.fillCarsList();
        }

        carName.text = CarSelectionController.currentCar.carInfo.carName;
        CarSelectionController.currentCar.gameObject.SetActive(true);

            if (CarSelectionController.carList[CarSelectionController.currentCarId].carInfo.carState == CarState.unlocked)
            {
                benzinText.text = GameManager.currentPlayer.UnlockedCars[CarSelectionController.currentCarId].carBenzin.ToString();
                return;
            }
        carUnlockPanelUpdate(true);
        startButton.interactable = false;
        benzinPanel.SetActive(false);
    }

    public void OnCarChange(int direction)
    {
        CarSelectionController.currentCarId += direction;
        if (CarSelectionController.currentCarId == 0 && direction == -1)
            left.SetActive(false);
        else if(CarSelectionController.currentCarId == 1 && direction == 1)
            left.SetActive(true);
        if(CarSelectionController.currentCarId == (CarSelectionController.carList.Count - 1) && direction == 1)
            right.SetActive(false);
        else if (CarSelectionController.currentCarId == (CarSelectionController.carList.Count - 2) && direction == -1)
            right.SetActive(true);
        UpdateScene();
    }


    private void UpdateScene()
    {
        CarSelectionController.currentCar.gameObject.SetActive(false);
        CarSelectionController.Reposition();
        CarSelectionController.UpdateCurrentCar();
        CarSelectionController.currentCar.gameObject.SetActive(true);

        carName.text = CarSelectionController.currentCar.carInfo.carName;
        playerMoney.text = GameManager.currentPlayer.money.ToString();
        if (CarSelectionController.currentCar.carInfo.carState == CarState.unlocked)
        {
            benzinText.text = CarSelectionController.currentCar.carInfo.benzin.ToString();
            carUnlockPanelUpdate(false);
            startButton.interactable = true;
            benzinPanel.SetActive(true);
        }
        else
        {
            carUnlockPanelUpdate(true);
            startButton.interactable = false;
            benzinPanel.SetActive(false);
        }
    }

    void carUnlockPanelUpdate(bool cond)
    {
        carUnlockPanel.SetActive(cond);
        if (cond)
        {
            StringBuilder sb = new StringBuilder("Price \n");
            sb.Append(CarSelectionController.currentCar.carInfo.price.ToString());
            carPriceText.text = sb.ToString();
        }
    }

    public void OnBuyButtonClick()
    {
        if(GameManager.currentPlayer.money < CarSelectionController.currentCar.carInfo.price)
        {
            notEnoughMoneyPanel.SetActive(true);
            notEnoughMoneySound.Play();
            left.GetComponent<Button>().interactable = false;
            right.GetComponent<Button>().interactable = false;
            return;
        }
        carBuySound.Play();
        GameManager.currentPlayer.money = GameManager.currentPlayer.money - CarSelectionController.currentCar.carInfo.price;
        GameManager.currentPlayer.UnlockedCars.Add(new CarData(CarSelectionController.currentCarId, 100));
        CarSelectionController.currentCar.carInfo.carState = CarState.unlocked;
        GameManager.playerCollection.SaveData();
        UpdateScene();
    }

    public void OnBackButtonClick()
    {
        notEnoughMoneyPanel.SetActive(false);
        left.GetComponent<Button>().interactable = true;
        right.GetComponent<Button>().interactable = true;
    }

    public void StartGame()
    {
        SceneData.carID = CarSelectionController.currentCarId;
        sceneLoader.LoadScene(1);
    }
}
