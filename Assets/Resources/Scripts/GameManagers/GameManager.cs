using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum GameState { unsigned, notSelected, Selected};

public class GameManager : MonoBehaviour
{

    #region Simple Singleton
    private static GameManager _instance;

    public static GameState gameState = GameState.unsigned;
    public static Player currentPlayer;
    public static ProfileController playerCollection;

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if(_instance != null && _instance != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);

        #endregion

        //var playerStats = Resources.Load<TextAsset>(ProfileController.path);
        playerCollection = ProfileController.LoadData(XmlLoader.xmlPath);

        if (playerCollection.players.Count == 0)
            gameState = GameState.unsigned;
        else
            gameState = GameState.notSelected;
    }
}
