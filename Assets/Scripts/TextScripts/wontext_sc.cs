using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wontext_sc : MonoBehaviour
{
    [SerializeField]
    private GameObject wonText;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private bool isThatP1;
    // Start is called before the first frame update
    void Start()
    {
        wonText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isThatP1)
        {
            if(enemy.GetComponent<player2_sc>().lives<1){
               wonText.SetActive(true);     
            }
        }
        else
        {
            if(enemy.GetComponent<player1_sc>().lives<1){
               wonText.SetActive(true);     
            }
        }
    }
}
