using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class p2lives_sc : MonoBehaviour
{

    public Text changingText;

    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private Image livesImg;

    public Sprite[] livesSprites;
    void Start()
    {

    }

    void Update()
    {
        TextChange();
    }
    public void TextChange()
    {
        string k = Player.GetComponent<player2_sc>().lives.ToString();
        if (k == "3")
        {
            changingText.text = "MAX";
        }
        else
        {
            changingText.text = "";
        }
        int i = ((int)Player.GetComponent<player2_sc>().lives);
        livesImg.sprite = livesSprites[i];
        livesImg.rectTransform.sizeDelta = new Vector2(livesSprites[i].bounds.size.x * 10, livesSprites[i].bounds.size.y * 10);
    }
}

