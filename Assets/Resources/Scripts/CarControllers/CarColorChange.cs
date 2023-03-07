using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColorChange : MonoBehaviour
{
    [SerializeField]
    GameObject colorPickPanel;
    public static Color newColor;
    public static GameObject acceptPanel;
    bool canEnter = true;


    private void Awake()
    {
        acceptPanel = colorPickPanel.transform.FindChildByRecursive("AcceptPanel").gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (canEnter)
        {
            if (other.gameObject.tag == "Car")
            {
                colorPickPanel.SetActive(true);
                Time.timeScale = 0;
                canEnter = false;
            }
        }
    }

    public void OnBackClick()
    {
        acceptPanel.SetActive(false);
    }


    public void OnAcceptClick()
    {
        acceptPanel.SetActive(false);
        colorPickPanel.SetActive(false);
        SceneData.WheelsController.GetComponent<MainTexture>().mainMeshRenderer.material.color = newColor;
        Time.timeScale = 1;
        StartCoroutine(changeEnterState());
    }

    public void OnCloseClick()
    {
        colorPickPanel.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(changeEnterState());

    }


    IEnumerator changeEnterState()
    {
        yield return new WaitForSeconds(5);
        canEnter = true;
    }
}
