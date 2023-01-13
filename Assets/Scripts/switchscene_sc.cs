using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class switchscene_sc : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public GameObject loadingScreen;
    public Slider loadingBar;

    public GameObject button;

    void Update()
    {
        bool p1alive = player1.GetComponent<player1_sc>().tankIsAlive;
        bool p2alive = player2.GetComponent<player2_sc>().tankIsAlive;
        if ((!p1alive || !p2alive) && button != null)
        {
            button.SetActive(true);
        }
    }
    public void GoNextLevel()
    {
        button.SetActive(false);
        Destroy(button);
        StartCoroutine(SahneyiGec());
    }
    IEnumerator SahneyiGec()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
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
