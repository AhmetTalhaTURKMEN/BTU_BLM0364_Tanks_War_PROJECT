using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu_sc : MonoBehaviour
{
    public bool startGame = false;

    private bool oneshot = true;

    public GameObject loadingScreen;
    public Slider loadingBar;
    void Update()
    {
        if (startGame && oneshot)
        {
            oneshot = !oneshot;
            StartCoroutine(SahneyiGec());
        }
    }
    public void setStartGame()
    {
        startGame = !startGame;
        PlayerPrefs.SetInt("savedScene", 0);
        PlayerPrefs.SetInt("p1score", 0);
        PlayerPrefs.SetInt("p2score", 0);
    }

    IEnumerator SahneyiGec()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameScene");
        while (!asyncLoad.isDone)
        {
            loadingBar.value = asyncLoad.progress;
            yield return null;
        }
    }

}
