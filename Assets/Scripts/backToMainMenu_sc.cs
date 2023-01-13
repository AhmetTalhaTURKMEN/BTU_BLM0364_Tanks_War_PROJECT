using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backToMainMenu_sc : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider loadingBar;

    [SerializeField]
    private GameObject pauseMenu;

    void Start()
    {

    }

    void Update()
    {

    }
    public void BackToMainMenuFunc()
    {
        int savedScene = PlayerPrefs.GetInt("savedScene");
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        if (savedScene < activeScene)
        {
            PlayerPrefs.SetInt("savedScene", activeScene);
        }
        pauseMenu.GetComponent<pause_sc>().gameIsPaused = false;
        StartCoroutine(BackToMainMenu());
    }

    IEnumerator BackToMainMenu()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");
        while (!asyncLoad.isDone)
        {
            loadingBar.value = asyncLoad.progress;
            yield return null;
        }
    }
}
