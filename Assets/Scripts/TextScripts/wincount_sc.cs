using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class wincount_sc : MonoBehaviour
{
    [SerializeField]
    private bool isThatP1;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private TMP_Text changingText;

    string i;
    void Update()
    {
        if (isThatP1)
        {
            i = player.GetComponent<player2_sc>().enemyScore.ToString();
        }
        else
        {
            i = player.GetComponent<player1_sc>().enemyScore.ToString();
        }
        changingText.text = i;


    }
}
