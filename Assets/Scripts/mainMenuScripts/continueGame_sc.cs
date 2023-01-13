using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class continueGame_sc : MonoBehaviour
{
    public int savedScene;
    public GameObject continueButton;

    public GameObject loadingScreen;
    public Slider loadingBar;
    void Start()
    {
        continueButton.SetActive(false);
        savedScene = PlayerPrefs.GetInt("savedScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (savedScene != 0)
        {
            continueButton.SetActive(true);
        }
    }
    public void loadSceneFunc()
    {
        StartCoroutine(loadScene());
    }
    IEnumerator loadScene()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(savedScene);
        Debug.Log(asyncLoad);
        if (asyncLoad == null)
        {
            asyncLoad = SceneManager.LoadSceneAsync("GameScene");
        }
        while (!asyncLoad.isDone)
        {
            loadingBar.value = asyncLoad.progress;
            yield return null;
        }
    }
}
