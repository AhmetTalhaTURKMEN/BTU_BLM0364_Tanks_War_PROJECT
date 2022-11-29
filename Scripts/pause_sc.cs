using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause_sc : MonoBehaviour
{

    [SerializeField]
    private GameObject pauseMenu;

    public bool gameIsPaused;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        escapeFunction();
        if (gameIsPaused)
        {
            pause();
        }
        else
        {
            resume();
        }
    }
    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }
    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
    public void escapeFunction()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Input.GetAxis("escape")==0
        {
            gameIsPaused = !gameIsPaused;
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void setGameIsPaused()
    {
        gameIsPaused = !gameIsPaused;
    }
}
