using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuMusic_sc : MonoBehaviour
{
    private static mainMenuMusic_sc Instance;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}