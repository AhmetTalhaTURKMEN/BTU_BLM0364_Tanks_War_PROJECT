using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class p1reloadtime_sc : MonoBehaviour
{
    public Text changingText;

    [SerializeField]
    private GameObject reloadObject;

    void Start()
    {

    }

    void Update()
    {
        TextChange();
    }
    public void TextChange()
    {

        float nextFire = reloadObject.GetComponent<p1bulletspawner_sc>().nextFire;
        nextFire = (nextFire - Time.time);
        if (nextFire < 0)
        {
            changingText.text = "Ready";
        }
        else
        {
            string remainTime = (nextFire).ToString("N2");
            changingText.text = remainTime;
        }

    }
}

