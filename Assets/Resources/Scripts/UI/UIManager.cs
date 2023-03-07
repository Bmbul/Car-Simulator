using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;

public class UIManager : MonoBehaviour
{
    #region SerializeFields
    [SerializeField]
    GameObject createPlayerMenu;
    [SerializeField]
    TMP_InputField nameInputField;
    [SerializeField]
    GameObject createButton;
    [SerializeField]
    GameObject selectCarMenu;
    [SerializeField]
    GameObject selectPlayerMenu;

    [SerializeField]
    GameObject createNewPlayerButton;

    [SerializeField]
    GameObject playerButtonsGO;

    [SerializeField]
    Button chooseExistingPlayerButton;

    [SerializeField]
    GameObject carSelectGO;

    [SerializeField]
    GameObject selectPlayerPanel;

    [SerializeField]
    GameObject warningPanel;
    #endregion

    [SerializeField]
    int playerInitialMoney;
    void Start()
    {
        if(GameManager.gameState == GameState.unsigned)
        { 
            createPlayerMenu.SetActive(true);
        }       
        else if(GameManager.gameState == GameState.notSelected)
        {
            selectPlayerMenu.SetActive(true);
            if (GameManager.playerCollection.players.Count >= 5)
                createNewPlayerButton.SetActive(false); 
        }
    }

    public void OnNameFieldValueChange()
    {

        if (nameInputField.text.Length >= 3)
            if (ValidateName(nameInputField.text))
            createButton.SetActive(true);
        else
            createButton.SetActive(false);
    }

    private bool ValidateName(string text)
    {
        foreach(var player in GameManager.playerCollection.players)
        {
            if(text == player.playerName)
            {
                warningPanel.SetActive(true);
                return false;
            }
        }
        warningPanel.SetActive(false);
        return true;
    }

    public void OnCreateButtonClick()
    {
        GameManager.playerCollection.CreatePlayer(nameInputField.text,playerInitialMoney);
        CarSelectionController.SyncData();
        carSelectGO.SetActive(true);
        selectCarMenu.SetActive(true);
        selectPlayerPanel.SetActive(false);
    }

    public void CarSelectMenuOpen(int id)
    {
        GameManager.currentPlayer = GameManager.playerCollection.players[id];
        CarSelectionController.SyncData();
        carSelectGO.SetActive(true);
        selectCarMenu.SetActive(true);
        selectPlayerPanel.SetActive(false);
    }

    public void OpenCreatePlayerMenu() {
        createPlayerMenu.SetActive(true);
        selectPlayerMenu.SetActive(false);
    }

    #region Player Data Load on Buttons
    public void LoadPlayerData()
    {
        List<TextMeshProUGUI> playerButtons = new List<TextMeshProUGUI>();
        for(int i = 0; i < 5; i++)
        {
            if (i < GameManager.playerCollection.players.Count)
                playerButtons.Add(playerButtonsGO.transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>());
            else
                playerButtonsGO.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }
        ModifyButtonData(playerButtons);

        #region UIControls

        playerButtonsGO.SetActive(true);
        chooseExistingPlayerButton.interactable = false;
        #endregion
    }

    private void ModifyButtonData(List<TextMeshProUGUI> playerButtons)
    {
        List<Player> players = GameManager.playerCollection.players;
        for (int i = 0; i < players.Count;i++)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(players[i].playerName);
            sb.AppendLine(players[i].money.ToString());
            playerButtons[i].text = sb.ToString();
        }
    }
    #endregion 

}
