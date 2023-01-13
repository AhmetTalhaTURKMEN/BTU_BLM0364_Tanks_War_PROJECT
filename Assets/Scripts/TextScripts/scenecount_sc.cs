using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class scenecount_sc : MonoBehaviour
{
    [SerializeField]
    private TMP_Text changingText;
    void Start()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        changingText.text = "Scene " + activeScene;
    }
}
