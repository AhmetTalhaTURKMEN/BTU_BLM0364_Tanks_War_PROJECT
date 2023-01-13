using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1lvesdisplayspawner_sc : MonoBehaviour
{
    [SerializeField]
    private GameObject Image;

    [SerializeField]
    private GameObject Player;
    void Start()
    {

    }

    void Update()
    {

    }
    void livesDisplaySpawner()
    {
        float a = Player.GetComponent<player1_sc>().lives;
    }
}
