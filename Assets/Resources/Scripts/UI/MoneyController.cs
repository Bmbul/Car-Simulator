using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyController : MonoBehaviour
{
    [SerializeField]
    int minX;
    [SerializeField]
    int maxX;
    [SerializeField]
    int minZ;
    [SerializeField]
    int maxZ;
    [SerializeField]
    int earningMoney;

    [SerializeField]
    TextMeshProUGUI moneyText;


    private void Start()
    {
        moneyText.text = GameManager.currentPlayer.money.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            transform.position = new Vector3(Random.Range(minX, maxX), -0.97f, Random.Range(minZ, maxZ));
            GameManager.currentPlayer.money += earningMoney;
            moneyText.text = GameManager.currentPlayer.money.ToString();
        }

    }
}
