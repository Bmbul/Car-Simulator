using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    GameObject LoadingPanel;
    [SerializeField]
    Slider slider;
    [SerializeField]
    float loadingDelayer;

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadAsynch(sceneIndex));
    }

    IEnumerator LoadAsynch(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        LoadingPanel.SetActive(true);

        while (!operation.isDone)
        {
            float progress =operation.progress/ loadingDelayer;

            slider.value = progress;
            yield return null;
        }
    }
}
