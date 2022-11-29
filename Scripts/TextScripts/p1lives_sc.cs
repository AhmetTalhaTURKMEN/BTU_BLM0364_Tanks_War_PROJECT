using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class p1lives_sc : MonoBehaviour
{

    public Text changingText;

    [SerializeField]
    private GameObject Player;
    void Start()
    {

    }

    void Update()
    {
        TextChange();
    }
    public void TextChange()
    {
        string k = Player.GetComponent<player1_sc>().lives.ToString();
        changingText.text = k;
    }
}
