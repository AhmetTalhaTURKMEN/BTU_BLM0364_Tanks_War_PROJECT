using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wontext_sc : MonoBehaviour
{
    [SerializeField]
    private GameObject wonText;

    [SerializeField]
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        wonText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy==null){
            wonText.SetActive(true);
        }
    }
}
